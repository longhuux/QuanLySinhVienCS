namespace StudentManagement.Presentation.UserControls
{
    partial class UCStudentManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelToolbar;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnImport;
        private Button btnExport;
        private Panel panelFilter;
        private Label lblNameFilter;
        private TextBox textBoxNameFilter;
        private Label lblClassFilter;
        private ComboBox comboBoxClassFilter;
        private Label lblGenderFilter;
        private ComboBox comboBoxGenderFilter;
        private Label lblGPAFilter;
        private TextBox textBoxGPAFilter;
        private Button btnFilter;
        private Button btnClearFilter;
        private Label lblFilterResult;
        private DataGridView dataGridViewStudents;

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
            this.panelToolbar = new Panel();
            this.btnExport = new Button();
            this.btnImport = new Button();
            this.btnDelete = new Button();
            this.btnEdit = new Button();
            this.btnAdd = new Button();
            this.panelFilter = new Panel();
            this.lblFilterResult = new Label();
            this.btnClearFilter = new Button();
            this.btnFilter = new Button();
            this.textBoxGPAFilter = new TextBox();
            this.lblGPAFilter = new Label();
            this.comboBoxGenderFilter = new ComboBox();
            this.lblGenderFilter = new Label();
            this.comboBoxClassFilter = new ComboBox();
            this.lblClassFilter = new Label();
            this.textBoxNameFilter = new TextBox();
            this.lblNameFilter = new Label();
            this.dataGridViewStudents = new DataGridView();
            this.panelToolbar.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.btnExport);
            this.panelToolbar.Controls.Add(this.btnImport);
            this.panelToolbar.Controls.Add(this.btnDelete);
            this.panelToolbar.Controls.Add(this.btnEdit);
            this.panelToolbar.Controls.Add(this.btnAdd);
            this.panelToolbar.Dock = DockStyle.Top;
            this.panelToolbar.Location = new Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new Size(1180, 60);
            this.panelToolbar.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = Color.FromArgb(46, 213, 115);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Location = new Point(20, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(100, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new Point(130, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new Size(100, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(240, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(100, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = Color.FromArgb(155, 89, 182);
            this.btnImport.FlatStyle = FlatStyle.Flat;
            this.btnImport.ForeColor = Color.White;
            this.btnImport.Location = new Point(350, 15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new Size(100, 35);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import Excel";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = Color.FromArgb(241, 196, 15);
            this.btnExport.FlatStyle = FlatStyle.Flat;
            this.btnExport.ForeColor = Color.White;
            this.btnExport.Location = new Point(460, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(100, 35);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = Color.White;
            this.panelFilter.Controls.Add(this.lblFilterResult);
            this.panelFilter.Controls.Add(this.btnClearFilter);
            this.panelFilter.Controls.Add(this.btnFilter);
            this.panelFilter.Controls.Add(this.textBoxGPAFilter);
            this.panelFilter.Controls.Add(this.lblGPAFilter);
            this.panelFilter.Controls.Add(this.comboBoxGenderFilter);
            this.panelFilter.Controls.Add(this.lblGenderFilter);
            this.panelFilter.Controls.Add(this.comboBoxClassFilter);
            this.panelFilter.Controls.Add(this.lblClassFilter);
            this.panelFilter.Controls.Add(this.textBoxNameFilter);
            this.panelFilter.Controls.Add(this.lblNameFilter);
            this.panelFilter.Dock = DockStyle.Top;
            this.panelFilter.Location = new Point(0, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new Size(1180, 100);
            this.panelFilter.TabIndex = 1;
            // 
            // lblNameFilter
            // 
            this.lblNameFilter.AutoSize = true;
            this.lblNameFilter.Location = new Point(20, 15);
            this.lblNameFilter.Name = "lblNameFilter";
            this.lblNameFilter.Size = new Size(60, 20);
            this.lblNameFilter.TabIndex = 0;
            this.lblNameFilter.Text = "Tên SV:";
            // 
            // textBoxNameFilter
            // 
            this.textBoxNameFilter.Location = new Point(90, 12);
            this.textBoxNameFilter.Name = "textBoxNameFilter";
            this.textBoxNameFilter.Size = new Size(200, 27);
            this.textBoxNameFilter.TabIndex = 1;
            // 
            // lblClassFilter
            // 
            this.lblClassFilter.AutoSize = true;
            this.lblClassFilter.Location = new Point(310, 15);
            this.lblClassFilter.Name = "lblClassFilter";
            this.lblClassFilter.Size = new Size(40, 20);
            this.lblClassFilter.TabIndex = 2;
            this.lblClassFilter.Text = "Lớp:";
            // 
            // comboBoxClassFilter
            // 
            this.comboBoxClassFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxClassFilter.FormattingEnabled = true;
            this.comboBoxClassFilter.Location = new Point(360, 12);
            this.comboBoxClassFilter.Name = "comboBoxClassFilter";
            this.comboBoxClassFilter.Size = new Size(150, 28);
            this.comboBoxClassFilter.TabIndex = 3;
            // 
            // lblGenderFilter
            // 
            this.lblGenderFilter.AutoSize = true;
            this.lblGenderFilter.Location = new Point(530, 15);
            this.lblGenderFilter.Name = "lblGenderFilter";
            this.lblGenderFilter.Size = new Size(70, 20);
            this.lblGenderFilter.TabIndex = 4;
            this.lblGenderFilter.Text = "Giới tính:";
            // 
            // comboBoxGenderFilter
            // 
            this.comboBoxGenderFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxGenderFilter.FormattingEnabled = true;
            this.comboBoxGenderFilter.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ" });
            this.comboBoxGenderFilter.Location = new Point(610, 12);
            this.comboBoxGenderFilter.Name = "comboBoxGenderFilter";
            this.comboBoxGenderFilter.Size = new Size(100, 28);
            this.comboBoxGenderFilter.TabIndex = 5;
            this.comboBoxGenderFilter.SelectedIndex = 0;
            // 
            // lblGPAFilter
            // 
            this.lblGPAFilter.AutoSize = true;
            this.lblGPAFilter.Location = new Point(20, 55);
            this.lblGPAFilter.Name = "lblGPAFilter";
            this.lblGPAFilter.Size = new Size(100, 20);
            this.lblGPAFilter.TabIndex = 6;
            this.lblGPAFilter.Text = "GPA < (điểm):";
            // 
            // textBoxGPAFilter
            // 
            this.textBoxGPAFilter.Location = new Point(130, 52);
            this.textBoxGPAFilter.Name = "textBoxGPAFilter";
            this.textBoxGPAFilter.Size = new Size(100, 27);
            this.textBoxGPAFilter.TabIndex = 7;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = Color.FromArgb(52, 152, 219);
            this.btnFilter.FlatStyle = FlatStyle.Flat;
            this.btnFilter.ForeColor = Color.White;
            this.btnFilter.Location = new Point(250, 50);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new Size(100, 30);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new EventHandler(this.btnFilter_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClearFilter.FlatStyle = FlatStyle.Flat;
            this.btnClearFilter.ForeColor = Color.White;
            this.btnClearFilter.Location = new Point(360, 50);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new Size(100, 30);
            this.btnClearFilter.TabIndex = 9;
            this.btnClearFilter.Text = "Xóa lọc";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new EventHandler(this.btnClearFilter_Click);
            // 
            // lblFilterResult
            // 
            this.lblFilterResult.AutoSize = true;
            this.lblFilterResult.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblFilterResult.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblFilterResult.Location = new Point(500, 55);
            this.lblFilterResult.Name = "lblFilterResult";
            this.lblFilterResult.Size = new Size(100, 20);
            this.lblFilterResult.TabIndex = 10;
            this.lblFilterResult.Text = "Tổng số: 0";
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.AllowUserToAddRows = false;
            this.dataGridViewStudents.AllowUserToDeleteRows = false;
            this.dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudents.BackgroundColor = Color.White;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Dock = DockStyle.Fill;
            this.dataGridViewStudents.Location = new Point(0, 160);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.ReadOnly = true;
            this.dataGridViewStudents.RowHeadersWidth = 51;
            this.dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.Size = new Size(1180, 560);
            this.dataGridViewStudents.TabIndex = 2;
            // 
            // UCStudentManagement
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(237, 242, 244);
            this.Controls.Add(this.dataGridViewStudents);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelToolbar);
            this.Name = "UCStudentManagement";
            this.Size = new Size(1180, 720);
            this.Load += new EventHandler(this.UCStudentManagement_Load);
            this.panelToolbar.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

