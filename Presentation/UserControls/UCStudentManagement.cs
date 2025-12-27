using StudentManagement.BusinessLogic;
using StudentManagement.DataAccess;
using StudentManagement.Models;
using StudentManagement.Presentation.Forms;

namespace StudentManagement.Presentation.UserControls
{
    public partial class UCStudentManagement : UserControl
    {
        private DataRepository _repository;
        private StudentService _studentService;
        private List<Student> _allStudents;
        private List<Student> _filteredStudents;

        public UCStudentManagement()
        {
            InitializeComponent();
            _repository = DataRepository.Instance;
            _studentService = new StudentService();
            _allStudents = new List<Student>();
            _filteredStudents = new List<Student>();
        }

        private void UCStudentManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadClassrooms();
        }

        private void LoadData()
        {
            _allStudents = _repository.Students;
            _filteredStudents = _allStudents;
            RefreshDataGrid();
        }

        private void LoadClassrooms()
        {
            comboBoxClassFilter.Items.Clear();
            comboBoxClassFilter.Items.Add("Tất cả");
            foreach (var classroom in _repository.Classrooms)
            {
                comboBoxClassFilter.Items.Add(classroom.ClassID);
            }
            comboBoxClassFilter.SelectedIndex = 0;
        }

        private void RefreshDataGrid()
        {
            dataGridViewStudents.DataSource = null;
            dataGridViewStudents.DataSource = _filteredStudents.Select(s => new
            {
                Mã_SV = s.StudentID,
                Họ_tên = s.FullName,
                Ngày_sinh = s.DateOfBirth.ToString("dd/MM/yyyy"),
                Giới_tính = s.Gender,
                Email = s.Email,
                Lớp = s.ClassID,
                Tuổi = s.Age
            }).ToList();

            // Tùy chỉnh DataGridView
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.RowHeadersVisible = false;
            dataGridViewStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormStudentDetail(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewStudents.SelectedRows[0];
                string studentId = selectedRow.Cells["Mã_SV"].Value.ToString() ?? "";
                var student = _repository.Students.FirstOrDefault(s => s.StudentID == studentId);
                
                if (student != null)
                {
                    var form = new FormStudentDetail(student);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var selectedRow = dataGridViewStudents.SelectedRows[0];
                    string studentId = selectedRow.Cells["Mã_SV"].Value.ToString() ?? "";
                    var student = _repository.Students.FirstOrDefault(s => s.StudentID == studentId);
                    
                    if (student != null)
                    {
                        _repository.DeleteStudent(student);
                        _repository.AddAuditLog(new AuditLog("Delete", "Student", studentId, Environment.UserName, $"Xóa sinh viên {student.FullName}"));
                        LoadData();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Excel Files|*.xlsx;*.xls";
                dialog.Title = "Chọn file Excel để import";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var helper = new ExcelHelper(dialog.FileName);
                        var importedStudents = helper.LoadStudents();
                        
                        int addedCount = 0;
                        foreach (var student in importedStudents)
                        {
                            if (!_repository.Students.Any(s => s.StudentID == student.StudentID))
                            {
                                _repository.AddStudent(student);
                                _repository.AddAuditLog(new AuditLog("Create", "Student", student.StudentID, Environment.UserName, $"Import sinh viên {student.FullName}"));
                                addedCount++;
                            }
                        }

                        LoadData();
                        MessageBox.Show($"Import thành công {addedCount} sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi import: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Excel Files|*.xlsx";
                dialog.Title = "Lưu file Excel";
                dialog.FileName = $"Danh_sach_sinh_vien_{DateTime.Now:yyyyMMdd}.xlsx";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var helper = new ExcelHelper(dialog.FileName);
                        helper.ExportStudents(_filteredStudents, dialog.FileName);
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
            _filteredStudents = _allStudents.ToList();

            // Lọc theo tên
            if (!string.IsNullOrWhiteSpace(textBoxNameFilter.Text))
            {
                _filteredStudents = _filteredStudents.Where(s => s.FullName.Contains(textBoxNameFilter.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Lọc theo lớp
            if (comboBoxClassFilter.SelectedIndex > 0)
            {
                string selectedClass = comboBoxClassFilter.SelectedItem?.ToString() ?? "";
                _filteredStudents = _filteredStudents.Where(s => s.ClassID == selectedClass).ToList();
            }

            // Lọc theo giới tính
            if (comboBoxGenderFilter.SelectedIndex > 0)
            {
                string selectedGender = comboBoxGenderFilter.SelectedItem?.ToString() ?? "";
                _filteredStudents = _filteredStudents.Where(s => s.Gender == selectedGender).ToList();
            }

            // Lọc theo GPA (nếu có)
            if (!string.IsNullOrWhiteSpace(textBoxGPAFilter.Text) && double.TryParse(textBoxGPAFilter.Text, out double gpaThreshold))
            {
                _filteredStudents = _filteredStudents.Where(s => _studentService.CalculateGPA(s.StudentID) < gpaThreshold).ToList();
            }

            RefreshDataGrid();
            lblFilterResult.Text = $"Kết quả: {_filteredStudents.Count} sinh viên";
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            textBoxNameFilter.Clear();
            comboBoxClassFilter.SelectedIndex = 0;
            comboBoxGenderFilter.SelectedIndex = 0;
            textBoxGPAFilter.Clear();
            _filteredStudents = _allStudents;
            RefreshDataGrid();
            lblFilterResult.Text = $"Tổng số: {_allStudents.Count} sinh viên";
        }
    }
}

