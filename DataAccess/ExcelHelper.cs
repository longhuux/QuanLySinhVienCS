using OfficeOpenXml;
using StudentManagement.Models;
using System.IO;

namespace StudentManagement.DataAccess
{
    public class ExcelHelper
    {
        private string _filePath;

        public ExcelHelper(string filePath)
        {
            _filePath = filePath;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public List<Student> LoadStudents()
        {
            var list = new List<Student>();
            FileInfo fileInfo = new FileInfo(_filePath);

            if (!fileInfo.Exists) return list;

            try
            {
                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    if (worksheet == null) return list;

                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    if (rowCount < 2) return list;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            var student = new Student
                            {
                                StudentID = worksheet.Cells[row, 1].Text.Trim(),
                                FullName = worksheet.Cells[row, 2].Text.Trim(),
                                DateOfBirth = DateTime.Parse(worksheet.Cells[row, 3].Text),
                                Gender = worksheet.Cells[row, 4].Text.Trim(),
                                Email = worksheet.Cells[row, 5].Text.Trim(),
                                ClassID = worksheet.Cells[row, 6].Text.Trim()
                            };

                            if (!string.IsNullOrEmpty(student.StudentID))
                            {
                                list.Add(student);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Bỏ qua dòng lỗi, tiếp tục đọc dòng tiếp theo
                            System.Diagnostics.Debug.WriteLine($"Lỗi đọc dòng {row}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đọc file Excel: {ex.Message}", ex);
            }

            return list;
        }

        public void ExportStudents(List<Student> students, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            
            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách sinh viên");

                // Header
                worksheet.Cells[1, 1].Value = "Mã SV";
                worksheet.Cells[1, 2].Value = "Họ tên";
                worksheet.Cells[1, 3].Value = "Ngày sinh";
                worksheet.Cells[1, 4].Value = "Giới tính";
                worksheet.Cells[1, 5].Value = "Email";
                worksheet.Cells[1, 6].Value = "Mã Lớp";

                // Style header
                using (var range = worksheet.Cells[1, 1, 1, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                }

                // Data
                for (int i = 0; i < students.Count; i++)
                {
                    var student = students[i];
                    int row = i + 2;
                    worksheet.Cells[row, 1].Value = student.StudentID;
                    worksheet.Cells[row, 2].Value = student.FullName;
                    worksheet.Cells[row, 3].Value = student.DateOfBirth.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 4].Value = student.Gender;
                    worksheet.Cells[row, 5].Value = student.Email;
                    worksheet.Cells[row, 6].Value = student.ClassID;
                }

                // Auto fit columns
                worksheet.Cells.AutoFitColumns();

                package.Save();
            }
        }

        public void ExportScores(List<Score> scores, List<Student> students, List<Subject> subjects, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets.Add("Bảng điểm");

                // Header
                worksheet.Cells[1, 1].Value = "Mã SV";
                worksheet.Cells[1, 2].Value = "Họ tên";
                worksheet.Cells[1, 3].Value = "Mã Môn";
                worksheet.Cells[1, 4].Value = "Tên Môn";
                worksheet.Cells[1, 5].Value = "Điểm TP";
                worksheet.Cells[1, 6].Value = "Điểm Thi";
                worksheet.Cells[1, 7].Value = "Điểm TK";
                worksheet.Cells[1, 8].Value = "Xếp loại";

                // Style header
                using (var range = worksheet.Cells[1, 1, 1, 8])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                }

                // Data
                for (int i = 0; i < scores.Count; i++)
                {
                    var score = scores[i];
                    var student = students.FirstOrDefault(s => s.StudentID == score.StudentID);
                    var subject = subjects.FirstOrDefault(s => s.SubjectID == score.SubjectID);
                    int row = i + 2;

                    worksheet.Cells[row, 1].Value = score.StudentID;
                    worksheet.Cells[row, 2].Value = student?.FullName ?? "";
                    worksheet.Cells[row, 3].Value = score.SubjectID;
                    worksheet.Cells[row, 4].Value = subject?.SubjectName ?? "";
                    worksheet.Cells[row, 5].Value = score.ProcessScore;
                    worksheet.Cells[row, 6].Value = score.FinalScore;
                    worksheet.Cells[row, 7].Value = score.TotalScore;
                    worksheet.Cells[row, 8].Value = score.GetGrade();
                }

                // Auto fit columns
                worksheet.Cells.AutoFitColumns();

                package.Save();
            }
        }
    }
}

