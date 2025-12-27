using StudentManagement.Models;
using System.Collections.Concurrent;
using System.IO;

namespace StudentManagement.DataAccess
{
    public class DataRepository
    {
        private static DataRepository? _instance;
        private static readonly object _lock = new object();

        public List<Student> Students { get; set; } = new List<Student>();
        public List<Classroom> Classrooms { get; set; } = new List<Classroom>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public List<Score> Scores { get; set; } = new List<Score>();
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        public List<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

        private ExcelHelper? _excelHelper;
        private string _excelFilePath;

        private DataRepository()
        {
            // Đường dẫn file Excel mặc định (trong thư mục ứng dụng)
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _excelFilePath = Path.Combine(appDirectory, "StudentManagementData.xlsx");
            
            InitializeSampleData();
            LoadDataFromExcel();
        }

        public void SetExcelFilePath(string filePath)
        {
            _excelFilePath = filePath;
            _excelHelper = new ExcelHelper(_excelFilePath);
        }

        public static DataRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DataRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        private void InitializeSampleData()
        {
            // Sample Classrooms (luôn khởi tạo, không load từ Excel)
            if (Classrooms.Count == 0)
            {
                Classrooms.Add(new Classroom("CNTT1", "Công nghệ thông tin 1", "Khoa CNTT"));
                Classrooms.Add(new Classroom("CNTT2", "Công nghệ thông tin 2", "Khoa CNTT"));
                Classrooms.Add(new Classroom("KT1", "Kế toán 1", "Khoa Kinh tế"));
            }

            // Sample Subjects (luôn khởi tạo, không load từ Excel)
            if (Subjects.Count == 0)
            {
                Subjects.Add(new Subject("CS101", "Lập trình C#", 3));
                Subjects.Add(new Subject("CS102", "Cơ sở dữ liệu", 3));
                Subjects.Add(new Subject("CS103", "Lập trình Web", 4));
                Subjects.Add(new Subject("MATH101", "Toán cao cấp", 3));
            }
        }

        private void LoadDataFromExcel()
        {
            try
            {
                _excelHelper = new ExcelHelper(_excelFilePath);
                
                // Load Students từ Excel
                var studentsFromExcel = _excelHelper.LoadStudents();
                if (studentsFromExcel.Count > 0)
                {
                    Students = studentsFromExcel;
                }
                else
                {
                    // Nếu file Excel chưa có dữ liệu, tạo dữ liệu mẫu
                    Students.Add(new Student("SV001", "Nguyễn Văn An", new DateTime(2000, 5, 15), "Nam", "an.nguyen@email.com", "CNTT1"));
                    Students.Add(new Student("SV002", "Trần Thị Bình", new DateTime(2001, 8, 20), "Nữ", "binh.tran@email.com", "CNTT1"));
                    Students.Add(new Student("SV003", "Lê Văn Cường", new DateTime(2000, 3, 10), "Nam", "cuong.le@email.com", "CNTT2"));
                    // Lưu dữ liệu mẫu vào Excel
                    SaveAllToExcel();
                }

                // Load Scores từ Excel
                var scoresFromExcel = _excelHelper.LoadScores(Students, Subjects);
                if (scoresFromExcel.Count > 0)
                {
                    Scores = scoresFromExcel;
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi đọc Excel, vẫn dùng dữ liệu mẫu
                System.Diagnostics.Debug.WriteLine($"Lỗi load dữ liệu từ Excel: {ex.Message}");
                if (Students.Count == 0)
                {
                    Students.Add(new Student("SV001", "Nguyễn Văn An", new DateTime(2000, 5, 15), "Nam", "an.nguyen@email.com", "CNTT1"));
                    Students.Add(new Student("SV002", "Trần Thị Bình", new DateTime(2001, 8, 20), "Nữ", "binh.tran@email.com", "CNTT1"));
                    Students.Add(new Student("SV003", "Lê Văn Cường", new DateTime(2000, 3, 10), "Nam", "cuong.le@email.com", "CNTT2"));
                }
            }
        }

        public void SaveAllToExcel()
        {
            try
            {
                if (_excelHelper == null)
                {
                    _excelHelper = new ExcelHelper(_excelFilePath);
                }
                _excelHelper.SaveAllToExcel(Students, Scores, Subjects);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi lưu dữ liệu vào Excel: {ex.Message}");
            }
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            try
            {
                if (_excelHelper == null)
                {
                    _excelHelper = new ExcelHelper(_excelFilePath);
                }
                _excelHelper.UpdateStudentInExcel(student, "Create");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi cập nhật Excel khi thêm sinh viên: {ex.Message}");
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                if (_excelHelper == null)
                {
                    _excelHelper = new ExcelHelper(_excelFilePath);
                }
                _excelHelper.UpdateStudentInExcel(student, "Update");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi cập nhật Excel khi sửa sinh viên: {ex.Message}");
            }
        }

        public void DeleteStudent(Student student)
        {
            Students.Remove(student);
            try
            {
                if (_excelHelper == null)
                {
                    _excelHelper = new ExcelHelper(_excelFilePath);
                }
                _excelHelper.UpdateStudentInExcel(student, "Delete");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi cập nhật Excel khi xóa sinh viên: {ex.Message}");
            }
        }

        public void AddScore(Score score)
        {
            Scores.Add(score);
            try
            {
                if (_excelHelper == null)
                {
                    _excelHelper = new ExcelHelper(_excelFilePath);
                }
                _excelHelper.UpdateScoreInExcel(score, Students, Subjects, "Create");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi cập nhật Excel khi thêm điểm: {ex.Message}");
            }
        }

        public void UpdateScore(Score score)
        {
            try
            {
                if (_excelHelper == null)
                {
                    _excelHelper = new ExcelHelper(_excelFilePath);
                }
                _excelHelper.UpdateScoreInExcel(score, Students, Subjects, "Update");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi cập nhật Excel khi sửa điểm: {ex.Message}");
            }
        }

        public void DeleteScore(Score score)
        {
            Scores.Remove(score);
            try
            {
                if (_excelHelper == null)
                {
                    _excelHelper = new ExcelHelper(_excelFilePath);
                }
                _excelHelper.UpdateScoreInExcel(score, Students, Subjects, "Delete");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi cập nhật Excel khi xóa điểm: {ex.Message}");
            }
        }

        public void AddAuditLog(AuditLog log)
        {
            AuditLogs.Add(log);
        }
    }
}

