namespace StudentManagement.Presentation.UserControls
{
    partial class UCDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelStats;
        private Label lblTotalStudentsLabel;
        private Label lblTotalStudents;
        private Label lblStudentsWithDebtLabel;
        private Label lblStudentsWithDebt;
        private Label lblAttendanceRateLabel;
        private Label lblAttendanceRate;
        private Label lblGenderRatioLabel;
        private Label lblGenderRatio;
        private DataGridView dataGridViewClassStats;
        private DataGridView dataGridViewWarnings;
        private Label lblClassStats;
        private Label lblWarnings;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelStats = new Panel();
            this.lblGenderRatio = new Label();
            this.lblGenderRatioLabel = new Label();
            this.lblAttendanceRate = new Label();
            this.lblAttendanceRateLabel = new Label();
            this.lblStudentsWithDebt = new Label();
            this.lblStudentsWithDebtLabel = new Label();
            this.lblTotalStudents = new Label();
            this.lblTotalStudentsLabel = new Label();
            this.dataGridViewClassStats = new DataGridView();
            this.dataGridViewWarnings = new DataGridView();
            this.lblClassStats = new Label();
            this.lblWarnings = new Label();
            this.panelStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarnings)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.lblGenderRatio);
            this.panelStats.Controls.Add(this.lblGenderRatioLabel);
            this.panelStats.Controls.Add(this.lblAttendanceRate);
            this.panelStats.Controls.Add(this.lblAttendanceRateLabel);
            this.panelStats.Controls.Add(this.lblStudentsWithDebt);
            this.panelStats.Controls.Add(this.lblStudentsWithDebtLabel);
            this.panelStats.Controls.Add(this.lblTotalStudents);
            this.panelStats.Controls.Add(this.lblTotalStudentsLabel);
            this.panelStats.Dock = DockStyle.Top;
            this.panelStats.Location = new Point(0, 0);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new Size(1180, 150);
            this.panelStats.TabIndex = 0;
            // 
            // lblTotalStudentsLabel
            // 
            this.lblTotalStudentsLabel.AutoSize = true;
            this.lblTotalStudentsLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblTotalStudentsLabel.Location = new Point(30, 20);
            this.lblTotalStudentsLabel.Name = "lblTotalStudentsLabel";
            this.lblTotalStudentsLabel.Size = new Size(130, 20);
            this.lblTotalStudentsLabel.TabIndex = 0;
            this.lblTotalStudentsLabel.Text = "Tổng số sinh viên:";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotalStudents.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTotalStudents.Location = new Point(30, 50);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new Size(45, 46);
            this.lblTotalStudents.TabIndex = 1;
            this.lblTotalStudents.Text = "0";
            // 
            // lblStudentsWithDebtLabel
            // 
            this.lblStudentsWithDebtLabel.AutoSize = true;
            this.lblStudentsWithDebtLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblStudentsWithDebtLabel.Location = new Point(250, 20);
            this.lblStudentsWithDebtLabel.Name = "lblStudentsWithDebtLabel";
            this.lblStudentsWithDebtLabel.Size = new Size(150, 20);
            this.lblStudentsWithDebtLabel.TabIndex = 2;
            this.lblStudentsWithDebtLabel.Text = "Sinh viên nợ môn:";
            // 
            // lblStudentsWithDebt
            // 
            this.lblStudentsWithDebt.AutoSize = true;
            this.lblStudentsWithDebt.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblStudentsWithDebt.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblStudentsWithDebt.Location = new Point(250, 50);
            this.lblStudentsWithDebt.Name = "lblStudentsWithDebt";
            this.lblStudentsWithDebt.Size = new Size(45, 46);
            this.lblStudentsWithDebt.TabIndex = 3;
            this.lblStudentsWithDebt.Text = "0";
            // 
            // lblAttendanceRateLabel
            // 
            this.lblAttendanceRateLabel.AutoSize = true;
            this.lblAttendanceRateLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblAttendanceRateLabel.Location = new Point(500, 20);
            this.lblAttendanceRateLabel.Name = "lblAttendanceRateLabel";
            this.lblAttendanceRateLabel.Size = new Size(120, 20);
            this.lblAttendanceRateLabel.TabIndex = 4;
            this.lblAttendanceRateLabel.Text = "Tỉ lệ chuyên cần:";
            // 
            // lblAttendanceRate
            // 
            this.lblAttendanceRate.AutoSize = true;
            this.lblAttendanceRate.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblAttendanceRate.ForeColor = Color.FromArgb(46, 213, 115);
            this.lblAttendanceRate.Location = new Point(500, 50);
            this.lblAttendanceRate.Name = "lblAttendanceRate";
            this.lblAttendanceRate.Size = new Size(80, 46);
            this.lblAttendanceRate.TabIndex = 5;
            this.lblAttendanceRate.Text = "0%";
            // 
            // lblGenderRatioLabel
            // 
            this.lblGenderRatioLabel.AutoSize = true;
            this.lblGenderRatioLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblGenderRatioLabel.Location = new Point(750, 20);
            this.lblGenderRatioLabel.Name = "lblGenderRatioLabel";
            this.lblGenderRatioLabel.Size = new Size(100, 20);
            this.lblGenderRatioLabel.TabIndex = 6;
            this.lblGenderRatioLabel.Text = "Tỉ lệ giới tính:";
            // 
            // lblGenderRatio
            // 
            this.lblGenderRatio.AutoSize = true;
            this.lblGenderRatio.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblGenderRatio.ForeColor = Color.FromArgb(155, 89, 182);
            this.lblGenderRatio.Location = new Point(750, 50);
            this.lblGenderRatio.Name = "lblGenderRatio";
            this.lblGenderRatio.Size = new Size(200, 25);
            this.lblGenderRatio.TabIndex = 7;
            this.lblGenderRatio.Text = "Nam: 0% | Nữ: 0%";
            // 
            // dataGridViewClassStats
            // 
            this.dataGridViewClassStats.AllowUserToAddRows = false;
            this.dataGridViewClassStats.AllowUserToDeleteRows = false;
            this.dataGridViewClassStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClassStats.BackgroundColor = Color.White;
            this.dataGridViewClassStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassStats.Location = new Point(30, 200);
            this.dataGridViewClassStats.Name = "dataGridViewClassStats";
            this.dataGridViewClassStats.ReadOnly = true;
            this.dataGridViewClassStats.RowHeadersWidth = 51;
            this.dataGridViewClassStats.Size = new Size(550, 300);
            this.dataGridViewClassStats.TabIndex = 1;
            // 
            // dataGridViewWarnings
            // 
            this.dataGridViewWarnings.AllowUserToAddRows = false;
            this.dataGridViewWarnings.AllowUserToDeleteRows = false;
            this.dataGridViewWarnings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWarnings.BackgroundColor = Color.White;
            this.dataGridViewWarnings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarnings.Location = new Point(600, 200);
            this.dataGridViewWarnings.Name = "dataGridViewWarnings";
            this.dataGridViewWarnings.ReadOnly = true;
            this.dataGridViewWarnings.RowHeadersWidth = 51;
            this.dataGridViewWarnings.Size = new Size(550, 300);
            this.dataGridViewWarnings.TabIndex = 2;
            // 
            // lblClassStats
            // 
            this.lblClassStats.AutoSize = true;
            this.lblClassStats.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblClassStats.Location = new Point(30, 170);
            this.lblClassStats.Name = "lblClassStats";
            this.lblClassStats.Size = new Size(180, 25);
            this.lblClassStats.TabIndex = 3;
            this.lblClassStats.Text = "Thống kê theo lớp:";
            // 
            // lblWarnings
            // 
            this.lblWarnings.AutoSize = true;
            this.lblWarnings.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblWarnings.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblWarnings.Location = new Point(600, 170);
            this.lblWarnings.Name = "lblWarnings";
            this.lblWarnings.Size = new Size(200, 25);
            this.lblWarnings.TabIndex = 4;
            this.lblWarnings.Text = "Cảnh báo học vụ:";
            // 
            // UCDashboard
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(237, 242, 244);
            this.Controls.Add(this.lblWarnings);
            this.Controls.Add(this.lblClassStats);
            this.Controls.Add(this.dataGridViewWarnings);
            this.Controls.Add(this.dataGridViewClassStats);
            this.Controls.Add(this.panelStats);
            this.Name = "UCDashboard";
            this.Size = new Size(1180, 720);
            this.Load += new EventHandler(this.UCDashboard_Load);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarnings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

