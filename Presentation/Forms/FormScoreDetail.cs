using StudentManagement.DataAccess;
using StudentManagement.Models;

namespace StudentManagement.Presentation.Forms
{
    public partial class FormScoreDetail : Form
    {
        private Score? _score;
        private DataRepository _repository;
        private bool _isEditMode;

        public FormScoreDetail(Score? score)
        {
            InitializeComponent();
            _repository = DataRepository.Instance;
            _score = score;
            _isEditMode = score != null;

            if (_isEditMode)
            {
                this.Text = "Sửa điểm";
                LoadScoreData();
            }
            else
            {
                this.Text = "Thêm điểm mới";
            }

            LoadStudents();
            LoadSubjects();
        }

        private void LoadStudents()
        {
            comboBoxStudent.Items.Clear();
            foreach (var student in _repository.Students)
            {
                comboBoxStudent.Items.Add($"{student.StudentID} - {student.FullName}");
            }
        }

        private void LoadSubjects()
        {
            comboBoxSubject.Items.Clear();
            foreach (var subject in _repository.Subjects)
            {
                comboBoxSubject.Items.Add($"{subject.SubjectID} - {subject.SubjectName}");
            }
        }

        private void LoadScoreData()
        {
            if (_score == null) return;

            comboBoxStudent.Text = $"{_score.StudentID} - {_repository.Students.FirstOrDefault(s => s.StudentID == _score.StudentID)?.FullName ?? ""}";
            comboBoxStudent.Enabled = false;
            comboBoxSubject.Text = $"{_score.SubjectID} - {_repository.Subjects.FirstOrDefault(s => s.SubjectID == _score.SubjectID)?.SubjectName ?? ""}";
            comboBoxSubject.Enabled = false;
            numericUpDownProcessScore.Value = (decimal)_score.ProcessScore;
            numericUpDownFinalScore.Value = (decimal)_score.FinalScore;
            CalculateTotalScore();
        }

        private void numericUpDownProcessScore_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalScore();
        }

        private void numericUpDownFinalScore_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalScore();
        }

        private void CalculateTotalScore()
        {
            double processScore = (double)numericUpDownProcessScore.Value;
            double finalScore = (double)numericUpDownFinalScore.Value;
            double totalScore = Math.Round(processScore * 0.3 + finalScore * 0.7, 2);
            lblTotalScore.Text = $"Điểm tổng kết: {totalScore:F2}";
            
            if (totalScore >= 5.0)
            {
                lblTotalScore.ForeColor = Color.Green;
            }
            else
            {
                lblTotalScore.ForeColor = Color.Red;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                string studentId = comboBoxStudent.Text.Split('-')[0].Trim();
                string subjectId = comboBoxSubject.Text.Split('-')[0].Trim();
                double processScore = (double)numericUpDownProcessScore.Value;
                double finalScore = (double)numericUpDownFinalScore.Value;

                if (_isEditMode && _score != null)
                {
                    // Update existing score
                    string oldValue = $"TP: {_score.ProcessScore}, Thi: {_score.FinalScore}, TK: {_score.TotalScore}";
                    _score.ProcessScore = processScore;
                    _score.FinalScore = finalScore;
                    _score.CalculateTotalScore();
                    _score.ModifiedDate = DateTime.Now;
                    _score.ModifiedBy = Environment.UserName;
                    string newValue = $"TP: {_score.ProcessScore}, Thi: {_score.FinalScore}, TK: {_score.TotalScore}";

                    _repository.UpdateScore(_score);
                    _repository.AddAuditLog(new AuditLog("Update", "Score", $"{studentId}-{subjectId}", Environment.UserName, $"Cập nhật điểm: {oldValue} -> {newValue}"));
                }
                else
                {
                    // Create new score
                    if (_repository.Scores.Any(s => s.StudentID == studentId && s.SubjectID == subjectId))
                    {
                        MessageBox.Show("Điểm của sinh viên này cho môn học này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newScore = new Score(studentId, subjectId, processScore, finalScore);
                    newScore.ModifiedBy = Environment.UserName;
                    _repository.AddScore(newScore);
                    _repository.AddAuditLog(new AuditLog("Create", "Score", $"{studentId}-{subjectId}", Environment.UserName, $"Thêm điểm mới: TP: {processScore}, Thi: {finalScore}, TK: {newScore.TotalScore}"));
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
            if (comboBoxStudent.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxStudent.Focus();
                return false;
            }

            if (comboBoxSubject.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSubject.Focus();
                return false;
            }

            if (numericUpDownProcessScore.Value < 0 || numericUpDownProcessScore.Value > 10)
            {
                MessageBox.Show("Điểm thành phần phải từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownProcessScore.Focus();
                return false;
            }

            if (numericUpDownFinalScore.Value < 0 || numericUpDownFinalScore.Value > 10)
            {
                MessageBox.Show("Điểm thi phải từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownFinalScore.Focus();
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

