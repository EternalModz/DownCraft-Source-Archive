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

namespace DownCraftUI.Tabs.Non_Host_Options
{
    public partial class Non_HostOptions : Form
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

        public Non_HostOptions()
        {
            InitializeComponent();
        }

        private void Non_HostOptions_Load(object sender, EventArgs e)
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

            if (Variables.SuperSpeed == true)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox1.Checked = true;
            }
            if (Variables.SuperSpeedV2 == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.SuperSpeedV3 == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.SuperSpeedV4 == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.SuperSpeedV5 == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.SuperSpeedV6 == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.SuperSpeedV7 == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.SuperSpeedLegit == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.MultiJump == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.JumpForBuild == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.JumpInSky == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.SuperJump == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.SuperJumpV2 == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.JumpForwardX2 == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.RemoveJump == true)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox15.Checked = true;
            }
            if (Variables.JumpSpeed == true)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox16.Checked = true;
            }
            if (Variables.AnimationSwimFly == true)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox17.Checked = true;
            }
            if (Variables.RemoveSwim == true)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox18.Checked = true;
            }
            if (Variables.DisableSwim == true)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox19.Checked = true;
            }
            if (Variables.ChangeMovementSwim == true)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox20.Checked = true;
            }
            if (Variables.SwimGlitch == true)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox21.Checked = true;
            }
            if (Variables.NoColission == true)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox22.Checked = true;
            }
            if (Variables.NonHostOptionsPage2 == true)
            {
                guna2Button1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                guna2Button1.Checked = true;
            }

            #endregion
        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox1.Checked)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_SPEED(true);
                Variables.SuperSpeed = true;
            }
            else
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_SPEED(false);
                Variables.SuperSpeed = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.NEW_SUPER_SPEED(true);
                Variables.SuperSpeedV2 = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NEW_SUPER_SPEED(false);
                Variables.SuperSpeedV2 = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_SPEED_V3(true);
                Variables.SuperSpeedV3 = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_SPEED_V3(false);
                Variables.SuperSpeedV3 = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_SPEED_V4(true);
                Variables.SuperSpeedV4 = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_SPEED_V4(false);
                Variables.SuperSpeedV4 = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_SPEED_V5(true);
                Variables.SuperSpeedV5 = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_SPEED_V5(false);
                Variables.SuperSpeedV5 = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_SPEED_V6(true);
                Variables.SuperSpeedV6 = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_SPEED_V6(false);
                Variables.SuperSpeedV6 = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_SPEED_V7(true);
                Variables.SuperSpeedV7 = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_SPEED_V7(false);
                Variables.SuperSpeedV7 = false;
            }
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_SPEED_LEGIT(true);
                Variables.SuperSpeedLegit = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_SPEED_LEGIT(false);
                Variables.SuperSpeedLegit = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.MULTI_JUMP(true);
                Variables.MultiJump = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.MULTI_JUMP(false);
                Variables.MultiJump = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.JUMP_FOR_BUILD(true);
                Variables.JumpForBuild = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.JUMP_FOR_BUILD(false);
                Variables.JumpForBuild = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.INSTANT_JUMP_IN_SKY(true);
                Variables.JumpInSky = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.INSTANT_JUMP_IN_SKY(false);
                Variables.JumpInSky = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_JUMP(true);
                Variables.SuperJump = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_JUMP(false);
                Variables.SuperJump = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUPER_JUMP_V2(true);
                Variables.SuperJumpV2 = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUPER_JUMP_V2(false);
                Variables.SuperJumpV2 = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.JUMP_FORWARD(true);
                Variables.JumpForwardX2 = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.JUMP_FORWARD(false);
                Variables.JumpForwardX2 = false;
            }
        }

        private void gunaCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox15.Checked)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_JUMP(true);
                Variables.RemoveJump = true;
            }
            else
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_JUMP(false);
                Variables.RemoveJump = false;
            }
        }

        private void gunaCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox16.Checked)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.JUMP_SPEED(true);
                Variables.JumpSpeed = true;
            }
            else
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.JUMP_SPEED(false);
                Variables.JumpSpeed = false;
            }
        }

        private void gunaCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox17.Checked)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ANIM_SWIM_FLY(true);
                Variables.AnimationSwimFly = true;
            }
            else
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ANIM_SWIM_FLY(false);
                Variables.AnimationSwimFly = false;
            }
        }

        private void gunaCheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox18.Checked)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_SWIM(true);
                Variables.RemoveSwim = true;
            }
            else
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_SWIM(false);
                Variables.RemoveSwim = false;
            }
        }

        private void gunaCheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox19.Checked)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DISABLE_SWIM(true);
                Variables.DisableSwim = true;
            }
            else
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DISABLE_SWIM(false);
                Variables.DisableSwim = false;
            }
        }

        private void gunaCheckBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox20.Checked)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CHANGE_MOVEMENT_SWIM(true);
                Variables.ChangeMovementSwim = true;
            }
            else
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CHANGE_MOVEMENT_SWIM(false);
                Variables.ChangeMovementSwim = false;
            }
        }

        private void gunaCheckBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox21.Checked)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SWIM_GLITCH(true);
                Variables.SwimGlitch = true;
            }
            else
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SWIM_GLITCH(false);
                Variables.SwimGlitch = false;
            }
        }

        private void gunaCheckBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox22.Checked)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.NO_COLISSION(true);
                Variables.NoColission = true;
            }
            else
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NO_COLISSION(false);
                Variables.NoColission = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!Variables.NonHostOptionsPage2)
            {
                guna2Button1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                Non_HostOptions1 frm = new Non_HostOptions1();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 219, Functions.y);
                Variables.NonHostOptionsPage2 = true;
            }
            else
            {
                guna2Button1.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["Non_HostOptions1"];
                frm.Close();
                Variables.NonHostOptionsPage2 = false;
            }
        }
    }
}
