using StudentManagement.BusinessLogic;
using StudentManagement.DataAccess;
using System.Windows.Forms;

namespace StudentManagement.Presentation.UserControls
{
    public partial class UCDashboard : UserControl
    {
        private StudentService _studentService;
        private DataRepository _repository;

        public UCDashboard()
        {
            InitializeComponent();
            _studentService = new StudentService();
            _repository = DataRepository.Instance;
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            // Tổng số sinh viên
            int totalStudents = _studentService.GetTotalStudents();
            lblTotalStudents.Text = totalStudents.ToString();

            // Số sinh viên nợ môn
            int studentsWithDebt = _studentService.GetStudentsWithLowGPA(5.0).Count;
            lblStudentsWithDebt.Text = studentsWithDebt.ToString();

            // Tỉ lệ chuyên cần
            double attendanceRate = _studentService.GetAverageAttendanceRate();
            lblAttendanceRate.Text = $"{attendanceRate}%";

            // Thống kê giới tính
            var genderStats = _studentService.GetGenderStatistics();
            int maleCount = genderStats.ContainsKey("Nam") ? genderStats["Nam"] : 0;
            int femaleCount = genderStats.ContainsKey("Nữ") ? genderStats["Nữ"] : 0;
            int total = maleCount + femaleCount;
            
            if (total > 0)
            {
                double malePercent = Math.Round((double)maleCount / total * 100, 1);
                double femalePercent = Math.Round((double)femaleCount / total * 100, 1);
                lblGenderRatio.Text = $"Nam: {malePercent}% | Nữ: {femalePercent}%";
            }
            else
            {
                lblGenderRatio.Text = "Chưa có dữ liệu";
            }

            // Thống kê theo lớp
            var classStats = _studentService.GetClassStatistics();
            dataGridViewClassStats.DataSource = classStats.Select(kvp => new
            {
                Lớp = kvp.Key,
                Số_sinh_viên = kvp.Value
            }).ToList();

            // Danh sách sinh viên cần cảnh báo
            var warningStudents = _studentService.GetStudentsWithLowGPA(5.0)
                .Take(10)
                .Select(s => new
                {
                    Mã_SV = s.StudentID,
                    Họ_tên = s.FullName,
                    Lớp = s.ClassID,
                    GPA = _studentService.CalculateGPA(s.StudentID)
                }).ToList();

            dataGridViewWarnings.DataSource = warningStudents;
        }
    }
}

