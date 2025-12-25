namespace StudentManagement.Presentation.Forms
{
    partial class FormStudentDetail
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblStudentID;
        private TextBox textBoxStudentID;
        private Label lblFullName;
        private TextBox textBoxFullName;
        private Label lblDOB;
        private DateTimePicker dateTimePickerDOB;
        private Label lblGender;
        private ComboBox comboBoxGender;
        private Label lblEmail;
        private TextBox textBoxEmail;
        private Label lblClass;
        private ComboBox comboBoxClass;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelMain;

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
            this.comboBoxClass = new ComboBox();
            this.lblClass = new Label();
            this.textBoxEmail = new TextBox();
            this.lblEmail = new Label();
            this.comboBoxGender = new ComboBox();
            this.lblGender = new Label();
            this.dateTimePickerDOB = new DateTimePicker();
            this.lblDOB = new Label();
            this.textBoxFullName = new TextBox();
            this.lblFullName = new Label();
            this.textBoxStudentID = new TextBox();
            this.lblStudentID = new Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.btnSave);
            this.panelMain.Controls.Add(this.comboBoxClass);
            this.panelMain.Controls.Add(this.lblClass);
            this.panelMain.Controls.Add(this.textBoxEmail);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.comboBoxGender);
            this.panelMain.Controls.Add(this.lblGender);
            this.panelMain.Controls.Add(this.dateTimePickerDOB);
            this.panelMain.Controls.Add(this.lblDOB);
            this.panelMain.Controls.Add(this.textBoxFullName);
            this.panelMain.Controls.Add(this.lblFullName);
            this.panelMain.Controls.Add(this.textBoxStudentID);
            this.panelMain.Controls.Add(this.lblStudentID);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(20);
            this.panelMain.Size = new Size(500, 400);
            this.panelMain.TabIndex = 0;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new Point(30, 30);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new Size(80, 20);
            this.lblStudentID.TabIndex = 0;
            this.lblStudentID.Text = "Mã SV:";
            // 
            // textBoxStudentID
            // 
            this.textBoxStudentID.Location = new Point(130, 27);
            this.textBoxStudentID.Name = "textBoxStudentID";
            this.textBoxStudentID.Size = new Size(320, 27);
            this.textBoxStudentID.TabIndex = 1;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new Point(30, 70);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new Size(70, 20);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ tên:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new Point(130, 67);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new Size(320, 27);
            this.textBoxFullName.TabIndex = 3;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new Point(30, 110);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new Size(80, 20);
            this.lblDOB.TabIndex = 4;
            this.lblDOB.Text = "Ngày sinh:";
            // 
            // dateTimePickerDOB
            // 
            this.dateTimePickerDOB.Location = new Point(130, 107);
            this.dateTimePickerDOB.Name = "dateTimePickerDOB";
            this.dateTimePickerDOB.Size = new Size(320, 27);
            this.dateTimePickerDOB.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new Point(30, 150);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new Size(70, 20);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Giới tính:";
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            this.comboBoxGender.Location = new Point(130, 147);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new Size(320, 28);
            this.comboBoxGender.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new Point(30, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(50, 20);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new Point(130, 187);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new Size(320, 27);
            this.textBoxEmail.TabIndex = 9;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new Point(30, 230);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new Size(40, 20);
            this.lblClass.TabIndex = 10;
            this.lblClass.Text = "Lớp:";
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new Point(130, 227);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new Size(320, 28);
            this.comboBoxClass.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = Color.FromArgb(46, 213, 115);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(250, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(100, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(360, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(100, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // FormStudentDetail
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 400);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStudentDetail";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Thông tin sinh viên";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}

