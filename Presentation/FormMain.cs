using FontAwesome.Sharp;
using StudentManagement.Presentation.UserControls;
using System.Windows.Forms;

namespace StudentManagement.Presentation
{
    public partial class FormMain : Form
    {
        private IconButton? currentBtn;
        private Panel leftBorderBtn;
        private UserControl? currentControl;
        private Form? activeForm;

        public FormMain()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard, Color.FromArgb(41, 128, 185));
            OpenChildForm(new UCDashboard());
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;

                // Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }

        private void OpenChildForm(UserControl childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = null;
            if (currentControl != null)
            {
                panelDesktop.Controls.Remove(currentControl);
            }
            currentControl = childForm;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(41, 128, 185));
            OpenChildForm(new UCDashboard());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(46, 213, 115));
            OpenChildForm(new UCStudentManagement());
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(255, 159, 67));
            OpenChildForm(new UCScoreManagement());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(108, 92, 231));
            MessageBox.Show("Tính năng đang phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}

