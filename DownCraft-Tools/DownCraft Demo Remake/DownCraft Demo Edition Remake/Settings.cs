using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownCraft_Demo_Edition_Remake
{
    public partial class Settings : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;

        Main frm = (Main)Application.OpenForms["Main"];

        public Settings()
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

        private void Settings_Load(object sender, EventArgs e)
        {
            this.siticonePanel2.MouseDown += this.xMouseDown; //For Move Form
            this.siticonePanel2.MouseMove += this.xMouseMove; //For Move Form
            this.siticonePanel2.MouseDown += this.xMouseDown; //For Move Form
            this.siticonePanel2.MouseMove += this.xMouseMove; //For Move Form
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            frm.siticonePanel1.BackColor = Color.FromArgb(3, 90, 100);
            frm.siticoneTextBox1.BorderColor = Color.FromArgb(3, 90, 100);
            frm.siticoneButton1.FillColor = Color.FromArgb(3, 90, 100);

            siticoneButton1.FillColor = Color.FromArgb(3, 90, 100);
            siticoneButton2.FillColor = Color.FromArgb(3, 90, 100);

            frm.siticonePanel2.BackgroundImage = DownCraft_Demo_Edition_Remake.Properties.Resources.img2;

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            frm.siticonePanel1.BackColor = Color.FromArgb(0, 90, 161);
            frm.siticoneTextBox1.BorderColor = Color.FromArgb(0, 90, 161);
            frm.siticoneButton1.FillColor = Color.FromArgb(0, 90, 161);

            siticoneButton1.FillColor = Color.FromArgb(0, 90, 161);
            siticoneButton2.FillColor = Color.FromArgb(0, 90, 161);

            frm.siticonePanel2.BackgroundImage = DownCraft_Demo_Edition_Remake.Properties.Resources.img1;
        }
    }
}
