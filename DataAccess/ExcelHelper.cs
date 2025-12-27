using OfficeOpenXml;
using StudentManagement.Models;
using System.IO;

namespace StudentManagement.DataAccess
{
    public class ExcelHelper
    {
        private string _filePath;
        private const string STUDENTS_SHEET = "Danh sách sinh viên";
        private const string SCORES_SHEET = "Bảng điểm";

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
                    var worksheet = package.Workbook.Worksheets[STUDENTS_SHEET];
                    if (worksheet == null) return list;

                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    if (rowCount < 2) return list;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            var studentId = worksheet.Cells[row, 1].Text.Trim();
                            if (string.IsNullOrEmpty(studentId)) continue;

                            var student = new Student
                            {
                                StudentID = studentId,
                                FullName = worksheet.Cells[row, 2].Text.Trim(),
                                DateOfBirth = DateTime.Parse(worksheet.Cells[row, 3].Text),
                                Gender = worksheet.Cells[row, 4].Text.Trim(),
                                Email = worksheet.Cells[row, 5].Text.Trim(),
                                ClassID = worksheet.Cells[row, 6].Text.Trim()
                            };

                            list.Add(student);
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

        public List<Score> LoadScores(List<Student> students, List<Subject> subjects)
        {
            var list = new List<Score>();
            FileInfo fileInfo = new FileInfo(_filePath);

            if (!fileInfo.Exists) return list;

            try
            {
                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[SCORES_SHEET];
                    if (worksheet == null) return list;

                    int rowCount = worksheet.Dimension?.Rows ?? 0;
                    if (rowCount < 2) return list;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {
                            var studentId = worksheet.Cells[row, 1].Text.Trim();
                            var subjectId = worksheet.Cells[row, 3].Text.Trim();
                            
                            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(subjectId)) continue;

                            var score = new Score
                            {
                                StudentID = studentId,
                                SubjectID = subjectId,
                                ProcessScore = Convert.ToDouble(worksheet.Cells[row, 5].Value ?? 0),
                                FinalScore = Convert.ToDouble(worksheet.Cells[row, 6].Value ?? 0)
                            };
                            score.CalculateTotalScore();

                            // Parse dates if available
                            if (worksheet.Cells[row, 9].Value != null)
                                score.CreatedDate = DateTime.Parse(worksheet.Cells[row, 9].Text);
                            if (worksheet.Cells[row, 10].Value != null)
                                score.ModifiedDate = DateTime.Parse(worksheet.Cells[row, 10].Text);
                            if (worksheet.Cells[row, 11].Value != null)
                                score.ModifiedBy = worksheet.Cells[row, 11].Text.Trim();

                            list.Add(score);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Lỗi đọc dòng điểm {row}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đọc bảng điểm từ Excel: {ex.Message}", ex);
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

        public void SaveAllToExcel(List<Student> students, List<Score> scores, List<Subject> subjects)
        {
            FileInfo fileInfo = new FileInfo(_filePath);
            
            using (var package = new ExcelPackage(fileInfo))
            {
                // Xóa các sheet cũ nếu có
                package.Workbook.Worksheets.Delete(STUDENTS_SHEET);
                package.Workbook.Worksheets.Delete(SCORES_SHEET);

                // Lưu danh sách sinh viên
                SaveStudentsToSheet(package, students);
                
                // Lưu bảng điểm
                SaveScoresToSheet(package, scores, students, subjects);

                package.Save();
            }
        }

        private void SaveStudentsToSheet(ExcelPackage package, List<Student> students)
        {
            var worksheet = package.Workbook.Worksheets.Add(STUDENTS_SHEET);

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

            worksheet.Cells.AutoFitColumns();
        }

        private void SaveScoresToSheet(ExcelPackage package, List<Score> scores, List<Student> students, List<Subject> subjects)
        {
            var worksheet = package.Workbook.Worksheets.Add(SCORES_SHEET);

            // Header
            worksheet.Cells[1, 1].Value = "Mã SV";
            worksheet.Cells[1, 2].Value = "Họ tên";
            worksheet.Cells[1, 3].Value = "Mã Môn";
            worksheet.Cells[1, 4].Value = "Tên Môn";
            worksheet.Cells[1, 5].Value = "Điểm TP";
            worksheet.Cells[1, 6].Value = "Điểm Thi";
            worksheet.Cells[1, 7].Value = "Điểm TK";
            worksheet.Cells[1, 8].Value = "Xếp loại";
            worksheet.Cells[1, 9].Value = "Ngày tạo";
            worksheet.Cells[1, 10].Value = "Ngày sửa";
            worksheet.Cells[1, 11].Value = "Người sửa";

            // Style header
            using (var range = worksheet.Cells[1, 1, 1, 11])
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
                worksheet.Cells[row, 9].Value = score.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss");
                worksheet.Cells[row, 10].Value = score.ModifiedDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                worksheet.Cells[row, 11].Value = score.ModifiedBy ?? "";
            }

            worksheet.Cells.AutoFitColumns();
        }

        public void UpdateStudentInExcel(Student student, string action)
        {
            FileInfo fileInfo = new FileInfo(_filePath);
            
            // Tạo file mới nếu chưa có
            if (!fileInfo.Exists)
            {
                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets.Add(STUDENTS_SHEET);
                    // Header
                    worksheet.Cells[1, 1].Value = "Mã SV";
                    worksheet.Cells[1, 2].Value = "Họ tên";
                    worksheet.Cells[1, 3].Value = "Ngày sinh";
                    worksheet.Cells[1, 4].Value = "Giới tính";
                    worksheet.Cells[1, 5].Value = "Email";
                    worksheet.Cells[1, 6].Value = "Mã Lớp";
                    
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                    }
                    package.Save();
                }
            }

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[STUDENTS_SHEET];
                if (worksheet == null)
                {
                    worksheet = package.Workbook.Worksheets.Add(STUDENTS_SHEET);
                    // Header
                    worksheet.Cells[1, 1].Value = "Mã SV";
                    worksheet.Cells[1, 2].Value = "Họ tên";
                    worksheet.Cells[1, 3].Value = "Ngày sinh";
                    worksheet.Cells[1, 4].Value = "Giới tính";
                    worksheet.Cells[1, 5].Value = "Email";
                    worksheet.Cells[1, 6].Value = "Mã Lớp";
                }

                int rowCount = worksheet.Dimension?.Rows ?? 1;
                
                if (action == "Create")
                {
                    // Thêm mới ở cuối
                    int newRow = rowCount + 1;
                    worksheet.Cells[newRow, 1].Value = student.StudentID;
                    worksheet.Cells[newRow, 2].Value = student.FullName;
                    worksheet.Cells[newRow, 3].Value = student.DateOfBirth.ToString("dd/MM/yyyy");
                    worksheet.Cells[newRow, 4].Value = student.Gender;
                    worksheet.Cells[newRow, 5].Value = student.Email;
                    worksheet.Cells[newRow, 6].Value = student.ClassID;
                }
                else if (action == "Update")
                {
                    // Tìm dòng chứa studentId
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (worksheet.Cells[row, 1].Text.Trim() == student.StudentID)
                        {
                            worksheet.Cells[row, 2].Value = student.FullName;
                            worksheet.Cells[row, 3].Value = student.DateOfBirth.ToString("dd/MM/yyyy");
                            worksheet.Cells[row, 4].Value = student.Gender;
                            worksheet.Cells[row, 5].Value = student.Email;
                            worksheet.Cells[row, 6].Value = student.ClassID;
                            break;
                        }
                    }
                }
                else if (action == "Delete")
                {
                    // Tìm và xóa dòng
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (worksheet.Cells[row, 1].Text.Trim() == student.StudentID)
                        {
                            worksheet.DeleteRow(row);
                            break;
                        }
                    }
                }

                package.Save();
            }
        }

        public void UpdateScoreInExcel(Score score, List<Student> students, List<Subject> subjects, string action)
        {
            FileInfo fileInfo = new FileInfo(_filePath);
            
            // Tạo file mới nếu chưa có
            if (!fileInfo.Exists)
            {
                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets.Add(SCORES_SHEET);
                    // Header
                    worksheet.Cells[1, 1].Value = "Mã SV";
                    worksheet.Cells[1, 2].Value = "Họ tên";
                    worksheet.Cells[1, 3].Value = "Mã Môn";
                    worksheet.Cells[1, 4].Value = "Tên Môn";
                    worksheet.Cells[1, 5].Value = "Điểm TP";
                    worksheet.Cells[1, 6].Value = "Điểm Thi";
                    worksheet.Cells[1, 7].Value = "Điểm TK";
                    worksheet.Cells[1, 8].Value = "Xếp loại";
                    worksheet.Cells[1, 9].Value = "Ngày tạo";
                    worksheet.Cells[1, 10].Value = "Ngày sửa";
                    worksheet.Cells[1, 11].Value = "Người sửa";
                    package.Save();
                }
            }

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[SCORES_SHEET];
                if (worksheet == null)
                {
                    worksheet = package.Workbook.Worksheets.Add(SCORES_SHEET);
                    // Header
                    worksheet.Cells[1, 1].Value = "Mã SV";
                    worksheet.Cells[1, 2].Value = "Họ tên";
                    worksheet.Cells[1, 3].Value = "Mã Môn";
                    worksheet.Cells[1, 4].Value = "Tên Môn";
                    worksheet.Cells[1, 5].Value = "Điểm TP";
                    worksheet.Cells[1, 6].Value = "Điểm Thi";
                    worksheet.Cells[1, 7].Value = "Điểm TK";
                    worksheet.Cells[1, 8].Value = "Xếp loại";
                    worksheet.Cells[1, 9].Value = "Ngày tạo";
                    worksheet.Cells[1, 10].Value = "Ngày sửa";
                    worksheet.Cells[1, 11].Value = "Người sửa";
                }

                int rowCount = worksheet.Dimension?.Rows ?? 1;
                var student = students.FirstOrDefault(s => s.StudentID == score.StudentID);
                var subject = subjects.FirstOrDefault(s => s.SubjectID == score.SubjectID);
                
                if (action == "Create")
                {
                    // Thêm mới ở cuối
                    int newRow = rowCount + 1;
                    worksheet.Cells[newRow, 1].Value = score.StudentID;
                    worksheet.Cells[newRow, 2].Value = student?.FullName ?? "";
                    worksheet.Cells[newRow, 3].Value = score.SubjectID;
                    worksheet.Cells[newRow, 4].Value = subject?.SubjectName ?? "";
                    worksheet.Cells[newRow, 5].Value = score.ProcessScore;
                    worksheet.Cells[newRow, 6].Value = score.FinalScore;
                    worksheet.Cells[newRow, 7].Value = score.TotalScore;
                    worksheet.Cells[newRow, 8].Value = score.GetGrade();
                    worksheet.Cells[newRow, 9].Value = score.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss");
                    worksheet.Cells[newRow, 10].Value = score.ModifiedDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                    worksheet.Cells[newRow, 11].Value = score.ModifiedBy ?? "";
                }
                else if (action == "Update")
                {
                    // Tìm dòng chứa cặp (StudentID, SubjectID)
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (worksheet.Cells[row, 1].Text.Trim() == score.StudentID &&
                            worksheet.Cells[row, 3].Text.Trim() == score.SubjectID)
                        {
                            worksheet.Cells[row, 5].Value = score.ProcessScore;
                            worksheet.Cells[row, 6].Value = score.FinalScore;
                            worksheet.Cells[row, 7].Value = score.TotalScore;
                            worksheet.Cells[row, 8].Value = score.GetGrade();
                            worksheet.Cells[row, 10].Value = score.ModifiedDate?.ToString("dd/MM/yyyy HH:mm:ss") ?? "";
                            worksheet.Cells[row, 11].Value = score.ModifiedBy ?? "";
                            break;
                        }
                    }
                }
                else if (action == "Delete")
                {
                    // Tìm và xóa dòng
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (worksheet.Cells[row, 1].Text.Trim() == score.StudentID &&
                            worksheet.Cells[row, 3].Text.Trim() == score.SubjectID)
                        {
                            worksheet.DeleteRow(row);
                            break;
                        }
                    }
                }

                package.Save();
            }
        }

        // Giữ lại method ExportStudents và ExportScores để tương thích ngược (nếu có code cũ đang dùng)
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

