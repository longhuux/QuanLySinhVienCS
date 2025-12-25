using StudentManagement.DataAccess;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Forms
{
    public partial class FormStudentDetail : Form
    {
        private Student? _student;
        private DataRepository _repository;
        private bool _isEditMode;

        public FormStudentDetail(Student? student)
        {
            InitializeComponent();
            _repository = DataRepository.Instance;
            _student = student;
            _isEditMode = student != null;

            if (_isEditMode)
            {
                this.Text = "Sửa thông tin sinh viên";
                LoadStudentData();
            }
            else
            {
                this.Text = "Thêm sinh viên mới";
            }

            LoadClassrooms();
        }

        private void LoadClassrooms()
        {
            comboBoxClass.Items.Clear();
            foreach (var classroom in _repository.Classrooms)
            {
                comboBoxClass.Items.Add($"{classroom.ClassID} - {classroom.ClassName}");
            }
        }

        private void LoadStudentData()
        {
            if (_student == null) return;

            textBoxStudentID.Text = _student.StudentID;
            textBoxStudentID.ReadOnly = true;
            textBoxFullName.Text = _student.FullName;
            dateTimePickerDOB.Value = _student.DateOfBirth;
            comboBoxGender.Text = _student.Gender;
            textBoxEmail.Text = _student.Email;
            comboBoxClass.Text = $"{_student.ClassID} - {_repository.Classrooms.FirstOrDefault(c => c.ClassID == _student.ClassID)?.ClassName ?? ""}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                string classId = comboBoxClass.Text.Split('-')[0].Trim();

                if (_isEditMode && _student != null)
                {
                    // Update existing student
                    _student.FullName = textBoxFullName.Text.Trim();
                    _student.DateOfBirth = dateTimePickerDOB.Value;
                    _student.Gender = comboBoxGender.Text;
                    _student.Email = textBoxEmail.Text.Trim();
                    _student.ClassID = classId;

                    _repository.AddAuditLog(new AuditLog("Update", "Student", _student.StudentID, Environment.UserName, $"Cập nhật thông tin sinh viên {_student.FullName}"));
                }
                else
                {
                    // Create new student
                    string studentId = textBoxStudentID.Text.Trim();
                    
                    if (_repository.Students.Any(s => s.StudentID == studentId))
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newStudent = new Student(
                        studentId,
                        textBoxFullName.Text.Trim(),
                        dateTimePickerDOB.Value,
                        comboBoxGender.Text,
                        textBoxEmail.Text.Trim(),
                        classId
                    );

                    _repository.Students.Add(newStudent);
                    _repository.AddAuditLog(new AuditLog("Create", "Student", studentId, Environment.UserName, $"Thêm mới sinh viên {newStudent.FullName}"));
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (!_isEditMode && string.IsNullOrWhiteSpace(textBoxStudentID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxStudentID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFullName.Focus();
                return false;
            }

            if (comboBoxGender.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxGender.Focus();
                return false;
            }

            if (comboBoxClass.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxClass.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text) && !textBoxEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

