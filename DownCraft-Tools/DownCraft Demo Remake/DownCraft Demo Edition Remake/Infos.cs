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

    public partial class Infos : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;

        public Infos()
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

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Infos_Load(object sender, EventArgs e)
        {
            this.siticonePanel2.MouseDown += this.xMouseDown; //For Move Form
            this.siticonePanel2.MouseMove += this.xMouseMove; //For Move Form
            this.siticonePanel2.MouseDown += this.xMouseDown; //For Move Form
            this.siticonePanel2.MouseMove += this.xMouseMove; //For Move Form

            this.pictureBox1.MouseDown += this.xMouseDown; //For Move Form
            this.pictureBox1.MouseMove += this.xMouseMove; //For Move Form
            this.pictureBox1.MouseDown += this.xMouseDown; //For Move Form
            this.pictureBox1.MouseMove += this.xMouseMove; //For Move Form
        }
    }
}
