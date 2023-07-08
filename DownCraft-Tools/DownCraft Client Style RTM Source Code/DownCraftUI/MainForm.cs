using DownCraftUI.Classes;
using System;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace DownCraftUI
{
    public partial class MainForm : Form
    {
        bool OpenedPanel;
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        Functions FUNCS = new Functions();
        Offsets OFFSETS = new Offsets();
        public static Thread Process = new Thread(new ThreadStart(Functions.CheckBadProcess));

        public MainForm()
        {
            InitializeComponent();
        }

        #region "System Move Title Panel"
        private void xMouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - base.Location.X;
            y = Control.MousePosition.Y - base.Location.Y;
        }
        private void xMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= x;
                newpoint.Y -= y;
                base.Location = newpoint;
            }
        }
        #endregion

        #region "Open Panels In Form"

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            guna2GradientPanel2.Controls.Add(childForm);
            guna2GradientPanel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            Process.Start();

            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2ImageButton1.MouseDown += this.xMouseDown;
            this.guna2ImageButton1.MouseMove += this.xMouseMove;
            this.guna2ImageButton1.MouseDown += this.xMouseDown;
            this.guna2ImageButton1.MouseMove += this.xMouseMove;
            this.guna2ImageButton2.MouseDown += this.xMouseDown;
            this.guna2ImageButton2.MouseMove += this.xMouseMove;
            this.guna2ImageButton2.MouseDown += this.xMouseDown;
            this.guna2ImageButton2.MouseMove += this.xMouseMove;
            this.guna2ImageButton3.MouseDown += this.xMouseDown;
            this.guna2ImageButton3.MouseMove += this.xMouseMove;
            this.guna2ImageButton3.MouseDown += this.xMouseDown;
            this.guna2ImageButton3.MouseMove += this.xMouseMove;

            openChildFormInPanel(new Tabs.Main());
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (!OpenedPanel)
            {
                openChildFormInPanel(new Tabs.Settings());
                OpenedPanel = true;
            }
            else
            {
                openChildFormInPanel(new Tabs.Main());
                OpenedPanel = false;
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            // Launches a link to the Discord server invite page.
            Process.Start("https://discord.gg/kxUQFEUMUa");
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Move(object sender, EventArgs e)
        {
            Functions.x = this.Location.X + this.Size.Width - 1;
            Functions.y = this.Location.Y;
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
