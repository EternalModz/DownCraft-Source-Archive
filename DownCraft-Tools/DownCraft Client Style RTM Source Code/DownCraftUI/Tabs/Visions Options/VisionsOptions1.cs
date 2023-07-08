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

namespace DownCraftUI.Tabs.Visions_Options
{
    public partial class VisionsOptions1 : Form
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

        public VisionsOptions1()
        {
            InitializeComponent();
        }

        private void VisionsOptions1_Load(object sender, EventArgs e)
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

            if (Variables.BlockHandsUp == true)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox1.Checked = true;
            }
            if (Variables.VibrateWalk == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.ShowPlayersAroundYou == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.HUDInventoryDown == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.AnimationSkate == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.WeirdArmsLeft == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.RaymanMode == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.SpeedHandHit == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.RemoveAnimationRun == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.SmallGraphic == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.PlayersSlide == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.FreezeParticles == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.SemiBlackscreen == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.BreakingParticlesFly == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.PlayersPaperMode == true)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox15.Checked = true;
            }
            if (Variables.BigModels == true)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox16.Checked = true;
            }
            if (Variables.CameraLeft == true)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox17.Checked = true;
            }
            if (Variables.CameraRight == true)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox18.Checked = true;
            }
            if (Variables.RemoveParticles == true)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox19.Checked = true;
            }
            if (Variables.BigParticles == true)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox20.Checked = true;
            }
            if (Variables.HUDloading == true)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox21.Checked = true;
            }
            if (Variables.StarsInSky == true)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox22.Checked = true;
            }
            if (Variables.VisionsOptionsPage3 == true)
            {
                guna2Button3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                guna2Button3.Checked = true;
            }

            #endregion
        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox1.Checked)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BLOCKS_HAND_UP(true);
                Variables.BlockHandsUp = true;
            }
            else
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BLOCKS_HAND_UP(false);
                Variables.BlockHandsUp = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.VIBRATE_WALK(true);
                Variables.VibrateWalk = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.VIBRATE_WALK(false);
                Variables.VibrateWalk = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.HUD_SHOW_PLAYERS_AROUND_YOU(true);
                Variables.ShowPlayersAroundYou = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.HUD_SHOW_PLAYERS_AROUND_YOU(false);
                Variables.ShowPlayersAroundYou = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.HUD_INVENTORY_DOWN_ON_SCREEN(true);
                Variables.HUDInventoryDown = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.HUD_INVENTORY_DOWN_ON_SCREEN(false);
                Variables.HUDInventoryDown = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.PLAYERS_SKATE_MODE(true);
                Variables.AnimationSkate = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.PLAYERS_SKATE_MODE(false);
                Variables.AnimationSkate = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ARMS_AND_LEGS_WEIRD(true);
                Variables.WeirdArmsLeft = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ARMS_AND_LEGS_WEIRD(false);
                Variables.WeirdArmsLeft = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.RAYMAN_MODE(true);
                Variables.RaymanMode = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.RAYMAN_MODE(false);
                Variables.RaymanMode = false;
            }
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ARMS_HIT_SPEED(true);
                Variables.SpeedHandHit = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ARMS_HIT_SPEED(false);
                Variables.SpeedHandHit = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_ANIMATION_RUN(true);
                Variables.RemoveAnimationRun = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_ANIMATION_RUN(false);
                Variables.RemoveAnimationRun = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SMALL_GRAPHIC(true);
                Variables.SmallGraphic = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SMALL_GRAPHIC(false);
                Variables.SmallGraphic = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.PLAYERS_SLIDE(true);
                Variables.PlayersSlide = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.PLAYERS_SLIDE(false);
                Variables.PlayersSlide = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.FREEZE_PARTICLES(true);
                Variables.FreezeParticles = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FREEZE_PARTICLES(false);
                Variables.FreezeParticles = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SEMI_BLACKSCREEN(true);
                Variables.SemiBlackscreen = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SEMI_BLACKSCREEN(false);
                Variables.SemiBlackscreen = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BREAK_PARTICLES_FLY(true);
                Variables.BreakingParticlesFly = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BREAK_PARTICLES_FLY(false);
                Variables.BreakingParticlesFly = false;
            }
        }

        private void gunaCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox15.Checked)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.PLAYERS_PAPER_MODELS(true);
                Variables.PlayersPaperMode = true;
            }
            else
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.PLAYERS_PAPER_MODELS(false);
                Variables.PlayersPaperMode = false;
            }
        }

        private void gunaCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox16.Checked)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.PLAYERS_BIG_MODELS(true);
                Variables.BigModels = true;
            }
            else
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.PLAYERS_BIG_MODELS(false);
                Variables.BigModels = false;
            }
        }

        private void gunaCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox17.Checked)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CAMERA_LEFT_POSITION(true);
                Variables.CameraLeft = true;
            }
            else
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CAMERA_LEFT_POSITION(false);
                Variables.CameraLeft = false;
            }
        }

        private void gunaCheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox18.Checked)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CAMERA_RIGHT_POSITION(true);
                Variables.CameraRight = true;
            }
            else
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CAMERA_RIGHT_POSITION(false);
                Variables.CameraRight = false;
            }
        }

        private void gunaCheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox19.Checked)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_PARTICLES(true);
                Variables.RemoveParticles = true;
            }
            else
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_PARTICLES(false);
                Variables.RemoveParticles = false;
            }
        }

        private void gunaCheckBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox20.Checked)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BIG_PARTICLES(true);
                Variables.BigParticles = true;
            }
            else
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BIG_PARTICLES(false);
                Variables.BigParticles = false;
            }
        }

        private void gunaCheckBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox21.Checked)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.HUD_LOADING(true);
                Variables.HUDloading = true;
            }
            else
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.HUD_LOADING(false);
                Variables.HUDloading = false;
            }
        }

        private void gunaCheckBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox22.Checked)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.FLASH_STARS_IN_SKY(true);
                Variables.StarsInSky = true;
            }
            else
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FLASH_STARS_IN_SKY(false);
                Variables.StarsInSky = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!Variables.VisionsOptionsPage3)
            {
                guna2Button3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                VisionsOptions2 frm = new VisionsOptions2();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 419, Functions.y);
                Variables.VisionsOptionsPage3 = true;
            }
            else
            {
                guna2Button3.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["VisionsOptions2"];
                frm.Close();
                Variables.VisionsOptionsPage3 = false;
            }
        }
    }
}
