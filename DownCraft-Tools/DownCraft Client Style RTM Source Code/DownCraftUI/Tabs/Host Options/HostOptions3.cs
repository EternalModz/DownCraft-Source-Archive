using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownCraftUI.Classes;

namespace DownCraftUI.Tabs.Host_Options
{
    public partial class HostOptions3 : Form
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

        public HostOptions3()
        {
            InitializeComponent();
        }

        private void HostOptions3_Load(object sender, EventArgs e)
        {
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;

            #region "Variables ON / OFF"

            if (Variables.DisableRespawn == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.CreativeSlotV2 == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.Disable3rdPersonView == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.TotemGiveMoreHealth == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.TNTCantBrokenBlockV1 == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.TNTCantBrokenBlockV2 == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.TNTSmallParticlesExplode == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.TNTBigParticlesExplode == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.TNTFlyInAirWhenEnable == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.TNTGoInGroundWhenEnable == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.TNTExplodeSoundOff == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.TNTInstantExplodeWhenEnable == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.TNTExplodRadiusSmall == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.HostOptionsPage4)
            {
                guna2Button4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                guna2Button4.Checked = true;
            }

            #endregion
        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox1.Checked)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.GOD_MODE_FOR_MYSELF();
                gunaCheckBox1.Checked = false;
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DISABLE_RESPAWN(true);
                Variables.DisableRespawn = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DISABLE_RESPAWN(false);
                Variables.DisableRespawn = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CREATIVE_SLOT_V2(true);
                Variables.CreativeSlotV2 = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CREATIVE_SLOT_V2(false);
                Variables.CreativeSlotV2 = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DISABLE_3RD_PERSON_VIEW(true);
                Variables.Disable3rdPersonView = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DISABLE_3RD_PERSON_VIEW(false);
                Variables.Disable3rdPersonView = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TOTEM_FLOAT_HEALTH(true);
                Variables.TotemGiveMoreHealth = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TOTEM_FLOAT_HEALTH(false);
                Variables.TotemGiveMoreHealth = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_CANT_DESTROY_BLOCKS(true);
                Variables.TNTCantBrokenBlockV1 = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_CANT_DESTROY_BLOCKS(false);
                Variables.TNTCantBrokenBlockV1 = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_CANT_EXPLODE_BLOCKS(true);
                Variables.TNTCantBrokenBlockV2 = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_CANT_EXPLODE_BLOCKS(false);
                Variables.TNTCantBrokenBlockV2 = false;
            }
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_SMALL_PARTICLES(true);
                Variables.TNTSmallParticlesExplode = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_SMALL_PARTICLES(false);
                Variables.TNTSmallParticlesExplode = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_MAKE_MORE_PARTICLES(true);
                Variables.TNTBigParticlesExplode = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_MAKE_MORE_PARTICLES(false);
                Variables.TNTBigParticlesExplode = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_FLY_IN_AIR_WHEN_ENABLED(true);
                Variables.TNTFlyInAirWhenEnable = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_FLY_IN_AIR_WHEN_ENABLED(false);
                Variables.TNTFlyInAirWhenEnable = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_GO_DOWN(true);
                Variables.TNTGoInGroundWhenEnable = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_GO_DOWN(false);
                Variables.TNTGoInGroundWhenEnable = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_EXPLODE_SOUND_OFF(true);
                Variables.TNTExplodeSoundOff = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_EXPLODE_SOUND_OFF(false);
                Variables.TNTExplodeSoundOff = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_INSTANT_EXPLODE(true);
                Variables.TNTInstantExplodeWhenEnable = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_INSTANT_EXPLODE(false);
                Variables.TNTInstantExplodeWhenEnable = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TNT_EXPLODE_RADIUS_SMALL(true);
                Variables.TNTExplodRadiusSmall = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TNT_EXPLODE_RADIUS_SMALL(false);
                Variables.TNTExplodRadiusSmall = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OFFSETS.LAST_PLAYERS_JOINED_THE_WORLD();

            try
            {
                var request = WebRequest.Create(OFFSETS.LastPlayersAvatar);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error, we cannot get any infos.", "DownCraft", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            label4.Text = OFFSETS.LastPlayersJoinedPSN; //Get the PSN Name
            label5.Text = OFFSETS.LastPlayersRegion; //Get the region
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                pictureBox1.Image.Save(sfd.FileName);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!Variables.HostOptionsPage4)
            {
                guna2Button4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                Host_Options.HostOptions4 frm = new Host_Options.HostOptions4();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 819, Functions.y);
                Variables.HostOptionsPage4 = true;
            }
            else
            {
                guna2Button4.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["HostOptions4"];
                frm.Close();
                Variables.HostOptionsPage4 = false;
            }
        }
    }
}
