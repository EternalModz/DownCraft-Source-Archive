using DownCraftUI.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DownCraftUI.Tabs
{
    public partial class Main : Form
    {
        Offsets OFFSETS = new Offsets();
        Functions FUNCS = new Functions();
        bool HostOptions = false;

        int x;
        int y;

        string TabsError = "You need connect DownCraft to your console before open a options";

        public Main()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            const string message = "Press YES for (TMAPI), NO for (CCAPI), CANCEL for (HEN)";
            const string caption = "DownCraft Connect";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OFFSETS.API = "TMAPI";
            }
            else if (result == DialogResult.No)
            {
                OFFSETS.API = "CCAPI";
            }
            else if (result == DialogResult.Cancel)
            {
                OFFSETS.API = "HEN";
            }

            OFFSETS.ChangeAPI();
            OFFSETS.doConnect();

            if (Offsets.ConnectStatus == true)
            {
                guna2Button1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            if (Offsets.ConnectStatus == true)
            {
                if (!HostOptions)
                {
                    guna2Button2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE); ;
                    HostOptions frm = new HostOptions();
                    frm.Show();
                    frm.SetDesktopLocation(Functions.x, Functions.y);
                    HostOptions = true;
                }
                else
                {
                    guna2Button2.ForeColor = Color.FromArgb(169, 169, 171);
                    Form frm = Application.OpenForms["HostOptions"];
                    frm.Close();
                    HostOptions = false;
                }
            }
            else
            {
                MessageBox.Show(TabsError, "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            if (Offsets.ConnectStatus == true)
            {
                if (!Variables.RealTimeEditingPage1)
                {
                    guna2Button3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE); ;
                    Real_Time_Editing.RealTimeEditing frm = new Real_Time_Editing.RealTimeEditing();
                    frm.Show();
                    frm.SetDesktopLocation(Functions.x, Functions.y);
                    Variables.RealTimeEditingPage1 = true;
                }
                else
                {
                    guna2Button3.ForeColor = Color.FromArgb(169, 169, 171);
                    Form frm = Application.OpenForms["RealTimeEditing"];
                    frm.Close();
                    Variables.RealTimeEditingPage1 = false;
                }
            }
            else
            {
                MessageBox.Show(TabsError, "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            if (Offsets.ConnectStatus == true)
            {
                if (!Variables.NonHostOptionsPage1)
                {
                    guna2Button4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE); ;
                    Non_Host_Options.Non_HostOptions frm = new Non_Host_Options.Non_HostOptions();
                    frm.Show();
                    frm.SetDesktopLocation(Functions.x, Functions.y);
                    Variables.NonHostOptionsPage1 = true;
                }
                else
                {
                    guna2Button4.ForeColor = Color.FromArgb(169, 169, 171);
                    Form frm = Application.OpenForms["Non_HostOptions"];
                    frm.Close();
                    Variables.NonHostOptionsPage1 = false;
                }
            }
            else
            {
                MessageBox.Show(TabsError, "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            if (Offsets.ConnectStatus == true)
            {
                if (!Variables.VisionsOptionsPage1)
                {
                    guna2Button5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE); ;
                    Visions_Options.VisionsOptions frm = new Visions_Options.VisionsOptions();
                    frm.Show();
                    frm.SetDesktopLocation(Functions.x, Functions.y);
                    Variables.VisionsOptionsPage1 = true;
                }
                else
                {
                    guna2Button5.ForeColor = Color.FromArgb(169, 169, 171);
                    Form frm = Application.OpenForms["VisionsOptions"];
                    frm.Close();
                    Variables.VisionsOptionsPage1 = false;
                }
            }
            else
            {
                MessageBox.Show(TabsError, "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            if (Offsets.ConnectStatus == true)
            {
                if (!Variables.MiniGamesOptionsPage1)
                {
                    guna2Button6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                    Mini_Games_Options.Mini_GamesOptions frm = new Mini_Games_Options.Mini_GamesOptions();
                    frm.Show();
                    frm.SetDesktopLocation(Functions.x, Functions.y);
                    Variables.MiniGamesOptionsPage1 = true;
                }
                else
                {
                    guna2Button6.ForeColor = Color.FromArgb(169, 169, 171);
                    Form frm = Application.OpenForms["Mini_GamesOptions"];
                    frm.Close();
                    Variables.MiniGamesOptionsPage1 = false;
                }
            }
            else
            {
                MessageBox.Show(TabsError, "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            if (Offsets.ConnectStatus == true)
            {
                if (!Variables.NameChangerOptions1)
                {
                    guna2Button7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE); ;
                    Name_Changer.NameChanger frm = new Name_Changer.NameChanger();
                    frm.Show();
                    frm.SetDesktopLocation(Functions.x, Functions.y);
                    Variables.NameChangerOptions1 = true;
                }
                else
                {
                    guna2Button7.ForeColor = Color.FromArgb(169, 169, 171);
                    Form frm = Application.OpenForms["NameChanger"];
                    frm.Close();
                    Variables.NameChangerOptions1 = false;
                }
            }
            else
            {
                MessageBox.Show(TabsError, "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            FUNCS.ClickSound();
            if (Offsets.ConnectStatus == true)
            {
                if (!Variables.SPRXControlPage1)
                {
                    guna2Button8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE); ;
                    SPRX_Control.SPRXControl frm = new SPRX_Control.SPRXControl();
                    frm.Show();
                    frm.SetDesktopLocation(Functions.x, Functions.y);
                    Variables.SPRXControlPage1 = true;
                }
                else
                {
                    guna2Button8.ForeColor = Color.FromArgb(169, 169, 171);
                    Form frm = Application.OpenForms["SPRXControl"];
                    frm.Close();
                    Variables.SPRXControlPage1 = false;
                }
            }
            else
            {
                MessageBox.Show(TabsError, "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_Move(object sender, EventArgs e)
        {
            Functions.x = this.Location.X + this.Size.Width - 1;
            Functions.y = this.Location.Y;
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
