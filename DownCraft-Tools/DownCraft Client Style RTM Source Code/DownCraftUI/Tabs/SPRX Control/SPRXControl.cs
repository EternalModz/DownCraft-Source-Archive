using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownCraftUI.Classes;

namespace DownCraftUI.Tabs.SPRX_Control
{
    public partial class SPRXControl : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        Offsets OFFSETS = new Offsets();
        Functions FUNCS = new Functions();

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

        public SPRXControl()
        {
            InitializeComponent();
        }

        private void SPRXControl_Load(object sender, EventArgs e)
        {
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;

            if (Offsets.StatusSPRX == true)
            {
                label18.ForeColor = Color.Green;
                label18.Text = "Connected !";
                guna2Button1.Enabled = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Before using SPRX V4, install the EBOOT + MC.sprx into your console and load Minecraft. \n\nDon't forget to change your PS3 language to: English United State. \n\nYou need use Minecraft BLES01976 Press the button 'Enable SPRX V4' until you are in a world with the SPRX installed, when you start Minecraft it's should give you awelcome message if you got this notif, all is good and you can press the button.", "How To Use SPRX ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/Installation SPRX");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OFFSETS.ENABLE_SPRX();
            if (Offsets.StatusSPRX == true)
            {
                label18.ForeColor = Color.Green;
                label18.Text = "Connected !";
                guna2Button1.Enabled = false;
            }
        }
    }
}
