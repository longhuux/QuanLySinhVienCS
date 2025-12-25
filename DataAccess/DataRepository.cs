using StudentManagement.Models;
using System.Collections.Concurrent;

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

        private DataRepository()
        {
            InitializeSampleData();
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
            // Sample Classrooms
            Classrooms.Add(new Classroom("CNTT1", "Công nghệ thông tin 1", "Khoa CNTT"));
            Classrooms.Add(new Classroom("CNTT2", "Công nghệ thông tin 2", "Khoa CNTT"));
            Classrooms.Add(new Classroom("KT1", "Kế toán 1", "Khoa Kinh tế"));

            // Sample Subjects
            Subjects.Add(new Subject("CS101", "Lập trình C#", 3));
            Subjects.Add(new Subject("CS102", "Cơ sở dữ liệu", 3));
            Subjects.Add(new Subject("CS103", "Lập trình Web", 4));
            Subjects.Add(new Subject("MATH101", "Toán cao cấp", 3));

            // Sample Students
            Students.Add(new Student("SV001", "Nguyễn Văn An", new DateTime(2000, 5, 15), "Nam", "an.nguyen@email.com", "CNTT1"));
            Students.Add(new Student("SV002", "Trần Thị Bình", new DateTime(2001, 8, 20), "Nữ", "binh.tran@email.com", "CNTT1"));
            Students.Add(new Student("SV003", "Lê Văn Cường", new DateTime(2000, 3, 10), "Nam", "cuong.le@email.com", "CNTT2"));
        }

        public void AddAuditLog(AuditLog log)
        {
            AuditLogs.Add(log);
        }
    }
}

