using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mc.Tabs
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DownCraft RTM\n\nDownCraft RTM is a real time modding (tool) for Minecraft PS3 Editon update 1.84.\n\nWith this tool you can mods your game for ex: give you speed, infinite jump, fly.\n\nIt's working on online or offline, in your world or in the world of your friends.\n\nThis tool has been created by Misakiii", "About Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
