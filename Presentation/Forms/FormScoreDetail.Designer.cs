namespace StudentManagement.Presentation.Forms
{
    partial class FormScoreDetail
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMain;
        private Label lblStudent;
        private ComboBox comboBoxStudent;
        private Label lblSubject;
        private ComboBox comboBoxSubject;
        private Label lblProcessScore;
        private NumericUpDown numericUpDownProcessScore;
        private Label lblFinalScore;
        private NumericUpDown numericUpDownFinalScore;
        private Label lblTotalScore;
        private Button btnSave;
        private Button btnCancel;

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
            this.panelMain = new Panel();
            this.btnCancel = new Button();
            this.btnSave = new Button();
            this.lblTotalScore = new Label();
            this.numericUpDownFinalScore = new NumericUpDown();
            this.lblFinalScore = new Label();
            this.numericUpDownProcessScore = new NumericUpDown();
            this.lblProcessScore = new Label();
            this.comboBoxSubject = new ComboBox();
            this.lblSubject = new Label();
            this.comboBoxStudent = new ComboBox();
            this.lblStudent = new Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFinalScore)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.lblTotalScore);
            this.panelMain.Controls.Add(this.numericUpDownFinalScore);
            this.panelMain.Controls.Add(this.lblFinalScore);
            this.panelMain.Controls.Add(this.numericUpDownProcessScore);
            this.panelMain.Controls.Add(this.lblProcessScore);
            this.panelMain.Controls.Add(this.comboBoxSubject);
            this.panelMain.Controls.Add(this.lblSubject);
            this.panelMain.Controls.Add(this.comboBoxStudent);
            this.panelMain.Controls.Add(this.lblStudent);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(500, 350);
            this.panelMain.TabIndex = 0;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new Point(30, 30);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new Size(80, 20);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Sinh viên:";
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new Point(130, 27);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new Size(320, 28);
            this.comboBoxStudent.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new Point(30, 70);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new Size(70, 20);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Môn học:";
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new Point(130, 67);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new Size(320, 28);
            this.comboBoxSubject.TabIndex = 3;
            // 
            // lblProcessScore
            // 
            this.lblProcessScore.AutoSize = true;
            this.lblProcessScore.Location = new Point(30, 110);
            this.lblProcessScore.Name = "lblProcessScore";
            this.lblProcessScore.Size = new Size(100, 20);
            this.lblProcessScore.TabIndex = 4;
            this.lblProcessScore.Text = "Điểm thành phần:";
            // 
            // numericUpDownProcessScore
            // 
            this.numericUpDownProcessScore.DecimalPlaces = 2;
            this.numericUpDownProcessScore.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numericUpDownProcessScore.Location = new Point(130, 107);
            this.numericUpDownProcessScore.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericUpDownProcessScore.Name = "numericUpDownProcessScore";
            this.numericUpDownProcessScore.Size = new Size(320, 27);
            this.numericUpDownProcessScore.TabIndex = 5;
            this.numericUpDownProcessScore.ValueChanged += new EventHandler(this.numericUpDownProcessScore_ValueChanged);
            // 
            // lblFinalScore
            // 
            this.lblFinalScore.AutoSize = true;
            this.lblFinalScore.Location = new Point(30, 150);
            this.lblFinalScore.Name = "lblFinalScore";
            this.lblFinalScore.Size = new Size(60, 20);
            this.lblFinalScore.TabIndex = 6;
            this.lblFinalScore.Text = "Điểm thi:";
            // 
            // numericUpDownFinalScore
            // 
            this.numericUpDownFinalScore.DecimalPlaces = 2;
            this.numericUpDownFinalScore.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numericUpDownFinalScore.Location = new Point(130, 147);
            this.numericUpDownFinalScore.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericUpDownFinalScore.Name = "numericUpDownFinalScore";
            this.numericUpDownFinalScore.Size = new Size(320, 27);
            this.numericUpDownFinalScore.TabIndex = 7;
            this.numericUpDownFinalScore.ValueChanged += new EventHandler(this.numericUpDownFinalScore_ValueChanged);
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.AutoSize = true;
            this.lblTotalScore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTotalScore.Location = new Point(30, 190);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new Size(200, 25);
            this.lblTotalScore.TabIndex = 8;
            this.lblTotalScore.Text = "Điểm tổng kết: 0.00";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = Color.FromArgb(46, 213, 115);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(250, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(100, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(360, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(100, 40);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // FormScoreDetail
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 350);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormScoreDetail";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Thông tin điểm";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProcessScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFinalScore)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

