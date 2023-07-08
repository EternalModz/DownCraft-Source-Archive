using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownCraftUI.Classes;

namespace DownCraftUI.Tabs.Name_Changer
{
    public partial class NameChanger : Form
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

        public NameChanger()
        {
            InitializeComponent();
        }

        private void NameChanger_Load(object sender, EventArgs e)
        {
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            OFFSETS.NAME_CHANGER(guna2TextBox1.Text);
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to use it? \n\nYou can add 18 characters for the name works and add (space) as if I want to add Misaki Dev I will put: \n\n (Misaki Dev          ) make space to the maximum you can when it blocked, you can set your name\n\nIf you don't understand, contact me on discord", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            OFFSETS.NAME_CHANGER_GLITCHED(guna2TextBox2.Text);
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("List colors for Name Changer\n\nHere you can change your name with a colors !!\n\nColors:\n0 = Black,  2 = Dark Green, 4 = Dark Red, 6 = Gold, 8 = Dark Gray, a = Green, c = Red, e = Yellow, 1 = Dark Blue, 3 = Dark Aqua, 5 = Dark Purple, 7 = Gray, 9 = Blue, b = Aqua, d = Light Purple, f = White, g = Random Letter\n\nFor use name colors put in text ex: 1Misaki Dev and press (Set Name) your name is now Blue", "List colors Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            OFFSETS.NAME_CHANGER_COLORED(guna2TextBox3.Text);
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            OFFSETS.NAME_CHANGER_LINE(richTextBox1.Text);
        }
    }
}
