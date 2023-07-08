#region "Library"
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace mc
{
    public partial class MainForm : Form
    {
        #region "Vars"

        public static Point newpoint = new Point();
        public static int x;
        public static int y;

        #endregion
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
        #region "Panel Form"
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel1.MouseDown += this.xMouseDown; //For Move Form
            this.panel1.MouseMove += this.xMouseMove; //For Move Form
            this.panel1.MouseDown += this.xMouseDown; //For Move Form
            this.panel1.MouseMove += this.xMouseMove; //For Move Form
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Tabs.Connection());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Tabs.HostOptions());
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Tabs.Settings());
        }
    }
}
