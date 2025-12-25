namespace StudentManagement.Presentation.UserControls
{
    partial class UCScoreManagement
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelToolbar;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnExport;
        private Panel panelFilter;
        private Label lblStudent;
        private ComboBox comboBoxStudent;
        private Label lblSubject;
        private ComboBox comboBoxSubject;
        private Label lblMinScore;
        private TextBox textBoxMinScore;
        private Label lblMaxScore;
        private TextBox textBoxMaxScore;
        private CheckBox checkBoxFailedOnly;
        private Button btnFilter;
        private Button btnClearFilter;
        private Label lblFilterResult;
        private DataGridView dataGridViewScores;
        private Panel panelWarnings;
        private Label lblWarnings;
        private DataGridView dataGridViewWarnings;

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
            this.btnDelete = new Button();
            this.btnEdit = new Button();
            this.btnAdd = new Button();
            this.panelFilter = new Panel();
            this.lblFilterResult = new Label();
            this.btnClearFilter = new Button();
            this.btnFilter = new Button();
            this.checkBoxFailedOnly = new CheckBox();
            this.textBoxMaxScore = new TextBox();
            this.lblMaxScore = new Label();
            this.textBoxMinScore = new TextBox();
            this.lblMinScore = new Label();
            this.comboBoxSubject = new ComboBox();
            this.lblSubject = new Label();
            this.comboBoxStudent = new ComboBox();
            this.lblStudent = new Label();
            this.dataGridViewScores = new DataGridView();
            this.panelWarnings = new Panel();
            this.dataGridViewWarnings = new DataGridView();
            this.lblWarnings = new Label();
            this.panelToolbar.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).BeginInit();
            this.panelWarnings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarnings)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.btnExport);
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
            this.btnAdd.Text = "Thêm điểm";
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
            // btnExport
            // 
            this.btnExport.BackColor = Color.FromArgb(241, 196, 15);
            this.btnExport.FlatStyle = FlatStyle.Flat;
            this.btnExport.ForeColor = Color.White;
            this.btnExport.Location = new Point(350, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(100, 35);
            this.btnExport.TabIndex = 3;
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
            this.panelFilter.Controls.Add(this.checkBoxFailedOnly);
            this.panelFilter.Controls.Add(this.textBoxMaxScore);
            this.panelFilter.Controls.Add(this.lblMaxScore);
            this.panelFilter.Controls.Add(this.textBoxMinScore);
            this.panelFilter.Controls.Add(this.lblMinScore);
            this.panelFilter.Controls.Add(this.comboBoxSubject);
            this.panelFilter.Controls.Add(this.lblSubject);
            this.panelFilter.Controls.Add(this.comboBoxStudent);
            this.panelFilter.Controls.Add(this.lblStudent);
            this.panelFilter.Dock = DockStyle.Top;
            this.panelFilter.Location = new Point(0, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new Size(1180, 100);
            this.panelFilter.TabIndex = 1;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new Point(20, 15);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new Size(80, 20);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Sinh viên:";
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new Point(110, 12);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new Size(250, 28);
            this.comboBoxStudent.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new Point(380, 15);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new Size(70, 20);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Môn học:";
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new Point(460, 12);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new Size(250, 28);
            this.comboBoxSubject.TabIndex = 3;
            // 
            // lblMinScore
            // 
            this.lblMinScore.AutoSize = true;
            this.lblMinScore.Location = new Point(20, 55);
            this.lblMinScore.Name = "lblMinScore";
            this.lblMinScore.Size = new Size(80, 20);
            this.lblMinScore.TabIndex = 4;
            this.lblMinScore.Text = "Điểm từ:";
            // 
            // textBoxMinScore
            // 
            this.textBoxMinScore.Location = new Point(110, 52);
            this.textBoxMinScore.Name = "textBoxMinScore";
            this.textBoxMinScore.Size = new Size(100, 27);
            this.textBoxMinScore.TabIndex = 5;
            // 
            // lblMaxScore
            // 
            this.lblMaxScore.AutoSize = true;
            this.lblMaxScore.Location = new Point(230, 55);
            this.lblMaxScore.Name = "lblMaxScore";
            this.lblMaxScore.Size = new Size(70, 20);
            this.lblMaxScore.TabIndex = 6;
            this.lblMaxScore.Text = "Điểm đến:";
            // 
            // textBoxMaxScore
            // 
            this.textBoxMaxScore.Location = new Point(310, 52);
            this.textBoxMaxScore.Name = "textBoxMaxScore";
            this.textBoxMaxScore.Size = new Size(100, 27);
            this.textBoxMaxScore.TabIndex = 7;
            // 
            // checkBoxFailedOnly
            // 
            this.checkBoxFailedOnly.AutoSize = true;
            this.checkBoxFailedOnly.Location = new Point(430, 55);
            this.checkBoxFailedOnly.Name = "checkBoxFailedOnly";
            this.checkBoxFailedOnly.Size = new Size(150, 24);
            this.checkBoxFailedOnly.TabIndex = 8;
            this.checkBoxFailedOnly.Text = "Chỉ hiển thị không đạt";
            this.checkBoxFailedOnly.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = Color.FromArgb(52, 152, 219);
            this.btnFilter.FlatStyle = FlatStyle.Flat;
            this.btnFilter.ForeColor = Color.White;
            this.btnFilter.Location = new Point(600, 50);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new Size(100, 30);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new EventHandler(this.btnFilter_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = Color.FromArgb(149, 165, 166);
            this.btnClearFilter.FlatStyle = FlatStyle.Flat;
            this.btnClearFilter.ForeColor = Color.White;
            this.btnClearFilter.Location = new Point(710, 50);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new Size(100, 30);
            this.btnClearFilter.TabIndex = 10;
            this.btnClearFilter.Text = "Xóa lọc";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new EventHandler(this.btnClearFilter_Click);
            // 
            // lblFilterResult
            // 
            this.lblFilterResult.AutoSize = true;
            this.lblFilterResult.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblFilterResult.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblFilterResult.Location = new Point(830, 55);
            this.lblFilterResult.Name = "lblFilterResult";
            this.lblFilterResult.Size = new Size(100, 20);
            this.lblFilterResult.TabIndex = 11;
            this.lblFilterResult.Text = "Tổng số: 0";
            // 
            // dataGridViewScores
            // 
            this.dataGridViewScores.AllowUserToAddRows = false;
            this.dataGridViewScores.AllowUserToDeleteRows = false;
            this.dataGridViewScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewScores.BackgroundColor = Color.White;
            this.dataGridViewScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScores.Dock = DockStyle.Fill;
            this.dataGridViewScores.Location = new Point(0, 160);
            this.dataGridViewScores.Name = "dataGridViewScores";
            this.dataGridViewScores.ReadOnly = true;
            this.dataGridViewScores.RowHeadersWidth = 51;
            this.dataGridViewScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewScores.Size = new Size(1180, 280);
            this.dataGridViewScores.TabIndex = 2;
            // 
            // panelWarnings
            // 
            this.panelWarnings.Controls.Add(this.dataGridViewWarnings);
            this.panelWarnings.Controls.Add(this.lblWarnings);
            this.panelWarnings.Dock = DockStyle.Bottom;
            this.panelWarnings.Location = new Point(0, 440);
            this.panelWarnings.Name = "panelWarnings";
            this.panelWarnings.Size = new Size(1180, 280);
            this.panelWarnings.TabIndex = 3;
            // 
            // lblWarnings
            // 
            this.lblWarnings.AutoSize = true;
            this.lblWarnings.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblWarnings.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblWarnings.Location = new Point(20, 10);
            this.lblWarnings.Name = "lblWarnings";
            this.lblWarnings.Size = new Size(200, 25);
            this.lblWarnings.TabIndex = 0;
            this.lblWarnings.Text = "Cảnh báo học vụ:";
            // 
            // dataGridViewWarnings
            // 
            this.dataGridViewWarnings.AllowUserToAddRows = false;
            this.dataGridViewWarnings.AllowUserToDeleteRows = false;
            this.dataGridViewWarnings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWarnings.BackgroundColor = Color.White;
            this.dataGridViewWarnings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarnings.Location = new Point(20, 40);
            this.dataGridViewWarnings.Name = "dataGridViewWarnings";
            this.dataGridViewWarnings.ReadOnly = true;
            this.dataGridViewWarnings.RowHeadersWidth = 51;
            this.dataGridViewWarnings.Size = new Size(1140, 230);
            this.dataGridViewWarnings.TabIndex = 1;
            // 
            // UCScoreManagement
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(237, 242, 244);
            this.Controls.Add(this.dataGridViewScores);
            this.Controls.Add(this.panelWarnings);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelToolbar);
            this.Name = "UCScoreManagement";
            this.Size = new Size(1180, 720);
            this.Load += new EventHandler(this.UCScoreManagement_Load);
            this.panelToolbar.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScores)).EndInit();
            this.panelWarnings.ResumeLayout(false);
            this.panelWarnings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarnings)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

