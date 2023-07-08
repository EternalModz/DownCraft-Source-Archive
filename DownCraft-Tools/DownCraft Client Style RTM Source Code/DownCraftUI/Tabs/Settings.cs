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

namespace DownCraftUI.Tabs
{
    public partial class Settings : Form
    {
        Functions FUNCS = new Functions();
        Offsets OFFSETS = new Offsets();

        public Settings()
        {
            InitializeComponent();
        }

        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
            Application.Exit();
        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            if (!Variables.ThemeColorsPage)
            {
                guna2TileButton2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE); ;
                new Tabs.ThemeColors().Show();
                Variables.ThemeColorsPage = true;
            }
            else
            {
                guna2TileButton2.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["ThemeColors"];
                frm.Close();
                Variables.ThemeColorsPage = false;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (Variables.ThemeColorsPage == true)
            {
                guna2TileButton2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                guna2TileButton2.Checked = true;
            }

            if (Offsets.ConnectStatus == true)
            {
                label1.Text = "Connected";
                label3.Text = Offsets.PSN;
                label7.Text = Offsets.CPU;
                label8.Text = Offsets.RSX;
                label9.Text = Offsets.FIRMWARE;
                label12.Text = Offsets.ps3IP;
            }

            if (Offsets.StatusSPRX == true)
            {
                label11.Text = "Enabled";
            }
            else
            {
                label11.Text = "Disabled";
            }
        }
    }
}
