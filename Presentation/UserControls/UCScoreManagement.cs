using StudentManagement.BusinessLogic;
using StudentManagement.DataAccess;
using StudentManagement.Models;
using StudentManagement.Presentation.Forms;

namespace StudentManagement.Presentation.UserControls
{
    public partial class UCScoreManagement : UserControl
    {
        private DataRepository _repository;
        private StudentService _studentService;
        private List<Score> _allScores;
        private List<Score> _filteredScores;

        public UCScoreManagement()
        {
            InitializeComponent();
            _repository = DataRepository.Instance;
            _studentService = new StudentService();
            _allScores = new List<Score>();
            _filteredScores = new List<Score>();
        }

        private void UCScoreManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadStudents();
            LoadSubjects();
            LoadWarnings();
        }

        private void LoadData()
        {
            _allScores = _repository.Scores;
            _filteredScores = _allScores;
            RefreshDataGrid();
        }

        private void LoadStudents()
        {
            comboBoxStudent.Items.Clear();
            comboBoxStudent.Items.Add("Tất cả");
            foreach (var student in _repository.Students)
            {
                comboBoxStudent.Items.Add($"{student.StudentID} - {student.FullName}");
            }
            comboBoxStudent.SelectedIndex = 0;
        }

        private void LoadSubjects()
        {
            comboBoxSubject.Items.Clear();
            comboBoxSubject.Items.Add("Tất cả");
            foreach (var subject in _repository.Subjects)
            {
                comboBoxSubject.Items.Add($"{subject.SubjectID} - {subject.SubjectName}");
            }
            comboBoxSubject.SelectedIndex = 0;
        }

        private void RefreshDataGrid()
        {
            dataGridViewScores.DataSource = null;
            dataGridViewScores.DataSource = _filteredScores.Select(s => new
            {
                Mã_SV = s.StudentID,
                Họ_tên = _repository.Students.FirstOrDefault(st => st.StudentID == s.StudentID)?.FullName ?? "",
                Mã_Môn = s.SubjectID,
                Tên_Môn = _repository.Subjects.FirstOrDefault(sub => sub.SubjectID == s.SubjectID)?.SubjectName ?? "",
                Điểm_TP = s.ProcessScore,
                Điểm_Thi = s.FinalScore,
                Điểm_TK = s.TotalScore,
                Xếp_loại = s.GetGrade(),
                Đạt = s.IsPassed() ? "Có" : "Không"
            }).ToList();

            // Tô màu đỏ cho các điểm không đạt
            foreach (DataGridViewRow row in dataGridViewScores.Rows)
            {
                if (row.Cells["Đạt"].Value?.ToString() == "Không")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                }
            }

            dataGridViewScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewScores.RowHeadersVisible = false;
        }

        private void LoadWarnings()
        {
            var lowGPAStudents = _studentService.GetStudentsWithLowGPA(5.0);
            var lowAttendanceStudents = _studentService.GetStudentsWithLowAttendance(80);

            var warnings = lowGPAStudents.Select(s => new
            {
                Mã_SV = s.StudentID,
                Họ_tên = s.FullName,
                Lớp = s.ClassID,
                GPA = _studentService.CalculateGPA(s.StudentID),
                Loại_cảnh_báo = "GPA thấp"
            }).ToList();

            warnings.AddRange(lowAttendanceStudents.Select(s => new
            {
                Mã_SV = s.StudentID,
                Họ_tên = s.FullName,
                Lớp = s.ClassID,
                GPA = _studentService.CalculateGPA(s.StudentID),
                Loại_cảnh_báo = "Chuyên cần thấp"
            }));

            dataGridViewWarnings.DataSource = warnings;
            dataGridViewWarnings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewWarnings.RowHeadersVisible = false;

            // Tô màu đỏ cho cảnh báo
            foreach (DataGridViewRow row in dataGridViewWarnings.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormScoreDetail(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                LoadWarnings();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewScores.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewScores.SelectedRows[0];
                string studentId = selectedRow.Cells["Mã_SV"].Value?.ToString() ?? "";
                string subjectId = selectedRow.Cells["Mã_Môn"].Value?.ToString() ?? "";
                var score = _repository.Scores.FirstOrDefault(s => s.StudentID == studentId && s.SubjectID == subjectId);

                if (score != null)
                {
                    var form = new FormScoreDetail(score);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        LoadWarnings();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn điểm cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewScores.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var selectedRow = dataGridViewScores.SelectedRows[0];
                    string studentId = selectedRow.Cells["Mã_SV"].Value?.ToString() ?? "";
                    string subjectId = selectedRow.Cells["Mã_Môn"].Value?.ToString() ?? "";
                    var score = _repository.Scores.FirstOrDefault(s => s.StudentID == studentId && s.SubjectID == subjectId);

                    if (score != null)
                    {
                        _repository.Scores.Remove(score);
                        _repository.AddAuditLog(new AuditLog("Delete", "Score", $"{studentId}-{subjectId}", Environment.UserName, $"Xóa điểm {subjectId} của sinh viên {studentId}"));
                        LoadData();
                        LoadWarnings();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn điểm cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Files|*.xlsx";
                dialog.Title = "Lưu bảng điểm";
                dialog.FileName = $"Bang_diem_{DateTime.Now:yyyyMMdd}.xlsx";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var helper = new ExcelHelper(dialog.FileName);
                        helper.ExportScores(_filteredScores, _repository.Students, _repository.Subjects, dialog.FileName);
                        MessageBox.Show("Export thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi export: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            _filteredScores = _allScores;

            // Lọc theo sinh viên
            if (comboBoxStudent.SelectedIndex > 0)
            {
                string selectedStudent = comboBoxStudent.SelectedItem?.ToString() ?? "";
                string studentId = selectedStudent.Split('-')[0].Trim();
                _filteredScores = _filteredScores.Where(s => s.StudentID == studentId).ToList();
            }

            // Lọc theo môn học
            if (comboBoxSubject.SelectedIndex > 0)
            {
                string selectedSubject = comboBoxSubject.SelectedItem?.ToString() ?? "";
                string subjectId = selectedSubject.Split('-')[0].Trim();
                _filteredScores = _filteredScores.Where(s => s.SubjectID == subjectId).ToList();
            }

            // Lọc theo điểm
            if (!string.IsNullOrWhiteSpace(textBoxMinScore.Text) && double.TryParse(textBoxMinScore.Text, out double minScore))
            {
                _filteredScores = _filteredScores.Where(s => s.TotalScore >= minScore).ToList();
            }

            if (!string.IsNullOrWhiteSpace(textBoxMaxScore.Text) && double.TryParse(textBoxMaxScore.Text, out double maxScore))
            {
                _filteredScores = _filteredScores.Where(s => s.TotalScore <= maxScore).ToList();
            }

            // Chỉ hiển thị không đạt
            if (checkBoxFailedOnly.Checked)
            {
                _filteredScores = _filteredScores.Where(s => !s.IsPassed()).ToList();
            }

            RefreshDataGrid();
            lblFilterResult.Text = $"Kết quả: {_filteredScores.Count} bản ghi";
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            comboBoxStudent.SelectedIndex = 0;
            comboBoxSubject.SelectedIndex = 0;
            textBoxMinScore.Clear();
            textBoxMaxScore.Clear();
            checkBoxFailedOnly.Checked = false;
            _filteredScores = _allScores;
            RefreshDataGrid();
            lblFilterResult.Text = $"Tổng số: {_allScores.Count} bản ghi";
        }
    }
}

