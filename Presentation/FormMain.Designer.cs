using FontAwesome.Sharp;

namespace StudentManagement.Presentation
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelMenu;
        private Panel panelLogo;
        private Panel panelDesktop;
        private Panel panelTitleBar;
        private IconButton btnDashboard;
        private IconButton btnStudents;
        private IconButton btnScores;
        private IconButton btnSettings;
        private IconButton btnClose;
        private IconButton btnMaximize;
        private IconButton btnMinimize;
        private Label lblTitle;

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
            this.panelMenu = new Panel();
            this.btnSettings = new IconButton();
            this.btnScores = new IconButton();
            this.btnStudents = new IconButton();
            this.btnDashboard = new IconButton();
            this.panelLogo = new Panel();
            this.panelDesktop = new Panel();
            this.panelTitleBar = new Panel();
            this.btnClose = new IconButton();
            this.btnMaximize = new IconButton();
            this.btnMinimize = new IconButton();
            this.lblTitle = new Label();
            this.panelMenu.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = Color.FromArgb(31, 30, 68);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.btnScores);
            this.panelMenu.Controls.Add(this.btnStudents);
            this.panelMenu.Controls.Add(this.btnDashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = DockStyle.Left;
            this.panelMenu.Location = new Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new Size(220, 800);
            this.panelMenu.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Dock = DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = FlatStyle.Flat;
            this.btnSettings.ForeColor = Color.Gainsboro;
            this.btnSettings.IconChar = IconChar.Cog;
            this.btnSettings.IconColor = Color.Gainsboro;
            this.btnSettings.IconFont = IconFont.Auto;
            this.btnSettings.IconSize = 32;
            this.btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new Point(0, 240);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new Padding(10, 0, 20, 0);
            this.btnSettings.Size = new Size(220, 60);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Cài đặt";
            this.btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);
            // 
            // btnScores
            // 
            this.btnScores.Dock = DockStyle.Top;
            this.btnScores.FlatAppearance.BorderSize = 0;
            this.btnScores.FlatStyle = FlatStyle.Flat;
            this.btnScores.ForeColor = Color.Gainsboro;
            this.btnScores.IconChar = IconChar.ChartLine;
            this.btnScores.IconColor = Color.Gainsboro;
            this.btnScores.IconFont = IconFont.Auto;
            this.btnScores.IconSize = 32;
            this.btnScores.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnScores.Location = new Point(0, 180);
            this.btnScores.Name = "btnScores";
            this.btnScores.Padding = new Padding(10, 0, 20, 0);
            this.btnScores.Size = new Size(220, 60);
            this.btnScores.TabIndex = 2;
            this.btnScores.Text = "Quản lý Điểm";
            this.btnScores.TextAlign = ContentAlignment.MiddleLeft;
            this.btnScores.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnScores.UseVisualStyleBackColor = true;
            this.btnScores.Click += new EventHandler(this.btnScores_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.Dock = DockStyle.Top;
            this.btnStudents.FlatAppearance.BorderSize = 0;
            this.btnStudents.FlatStyle = FlatStyle.Flat;
            this.btnStudents.ForeColor = Color.Gainsboro;
            this.btnStudents.IconChar = IconChar.UserGraduate;
            this.btnStudents.IconColor = Color.Gainsboro;
            this.btnStudents.IconFont = IconFont.Auto;
            this.btnStudents.IconSize = 32;
            this.btnStudents.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnStudents.Location = new Point(0, 120);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Padding = new Padding(10, 0, 20, 0);
            this.btnStudents.Size = new Size(220, 60);
            this.btnStudents.TabIndex = 1;
            this.btnStudents.Text = "Quản lý Sinh viên";
            this.btnStudents.TextAlign = ContentAlignment.MiddleLeft;
            this.btnStudents.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnStudents.UseVisualStyleBackColor = true;
            this.btnStudents.Click += new EventHandler(this.btnStudents_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Dock = DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = FlatStyle.Flat;
            this.btnDashboard.ForeColor = Color.Gainsboro;
            this.btnDashboard.IconChar = IconChar.Home;
            this.btnDashboard.IconColor = Color.Gainsboro;
            this.btnDashboard.IconFont = IconFont.Auto;
            this.btnDashboard.IconSize = 32;
            this.btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new Point(0, 60);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new Padding(10, 0, 20, 0);
            this.btnDashboard.Size = new Size(220, 60);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Trang chủ";
            this.btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new EventHandler(this.btnDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            this.panelLogo.Dock = DockStyle.Top;
            this.panelLogo.Location = new Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new Size(220, 60);
            this.panelLogo.TabIndex = 0;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = Color.FromArgb(237, 242, 244);
            this.panelDesktop.Dock = DockStyle.Fill;
            this.panelDesktop.Location = new Point(220, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new Size(1180, 720);
            this.panelDesktop.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = Color.FromArgb(26, 25, 62);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = DockStyle.Top;
            this.panelTitleBar.Location = new Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new Size(1180, 80);
            this.panelTitleBar.TabIndex = 2;
            this.panelTitleBar.MouseDown += new MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.IconChar = IconChar.Times;
            this.btnClose.IconColor = Color.White;
            this.btnClose.IconFont = IconFont.Auto;
            this.btnClose.IconSize = 25;
            this.btnClose.Location = new Point(1130, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(50, 80);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = FlatStyle.Flat;
            this.btnMaximize.IconChar = IconChar.WindowMaximize;
            this.btnMaximize.IconColor = Color.White;
            this.btnMaximize.IconFont = IconFont.Auto;
            this.btnMaximize.IconSize = 25;
            this.btnMaximize.Location = new Point(1080, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new Size(50, 80);
            this.btnMaximize.TabIndex = 2;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = FlatStyle.Flat;
            this.btnMinimize.IconChar = IconChar.WindowMinimize;
            this.btnMinimize.IconColor = Color.White;
            this.btnMinimize.IconFont = IconFont.Auto;
            this.btnMinimize.IconSize = 25;
            this.btnMinimize.Location = new Point(1030, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new Size(50, 80);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new EventHandler(this.btnMinimize_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(350, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hệ thống Quản lý Sinh viên";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1400, 800);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Sinh viên";
            this.Load += new EventHandler(this.FormMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Allow dragging the form
                const int WM_NCLBUTTONDOWN = 0xA1;
                const int HT_CAPTION = 0x2;
                var msg = Message.Create(this.Handle, WM_NCLBUTTONDOWN, new IntPtr(HT_CAPTION), IntPtr.Zero);
                this.WndProc(ref msg);
            }
        }
    }
}

