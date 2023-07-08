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
    public partial class Non_HostOptions5 : Form
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

        public Non_HostOptions5()
        {
            InitializeComponent();
        }

        private void Non_HostOptions5_Load(object sender, EventArgs e)
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

            if (Variables.ReachAttack == true)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox1.Checked = true;
            }
            if (Variables.AutoSprint == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.AutoSprintV2 == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.InstantHit == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.KillAura == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.FastBuild == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.CriticalMode == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.CriticalModeV1 == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.NoSlowDown == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.RemoveHurtCam == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.PressXForHit == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.ShowArmor == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.UnfairAttack == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.HitboxBETA == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.BlockStaticCrack == true)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox15.Checked = true;
            }
            if (Variables.NoKnockbackAndVelocity == true)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox16.Checked = true;
            }
            if (Variables.BigKnockbackAndVelocity == true)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox17.Checked = true;
            }

            #endregion
        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox1.Checked)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REACH_ATTACK(true);
                Variables.ReachAttack = true;
            }
            else
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REACH_ATTACK(false);
                Variables.ReachAttack = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TOGGLE_SPRINT(true);
                Variables.AutoSprint = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TOGGLE_SPRINT(false);
                Variables.AutoSprint = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.TOGGLE_SPRINT_V2(true);
                Variables.AutoSprintV2 = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.TOGGLE_SPRINT_V2(false);
                Variables.AutoSprintV2 = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.INSTANT_HIT(true);
                Variables.InstantHit = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.INSTANT_HIT(false);
                Variables.InstantHit = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.KILL_AURA(true);
                Variables.KillAura = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.KILL_AURA(false);
                Variables.KillAura = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.FAST_BUILD(true);
                Variables.FastBuild = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FAST_BUILD(false);
                Variables.FastBuild = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CRITICAL_HIT_V1(true);
                Variables.CriticalMode = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CRITICAL_HIT_V1(false);
                Variables.CriticalMode = false;
            }
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CRITICAL_HIT_V2(true);
                Variables.CriticalModeV1 = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CRITICAL_HIT_V2(false);
                Variables.CriticalModeV1 = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.NO_SLOW_DOWN(true);
                Variables.NoSlowDown = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NO_SLOW_DOWN(false);
                Variables.NoSlowDown = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_HURT_CAM(true);
                Variables.RemoveHurtCam = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_HURT_CAM(false);
                Variables.RemoveHurtCam = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.PRESS_X_FOR_HIT(true);
                Variables.PressXForHit = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.PRESS_X_FOR_HIT(false);
                Variables.PressXForHit = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SHOW_ARMOR(true);
                Variables.ShowArmor = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SHOW_ARMOR(false);
                Variables.ShowArmor = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.UNFAIR_ATTACK(true);
                Variables.UnfairAttack = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.UNFAIR_ATTACK(false);
                Variables.UnfairAttack = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.HITBOX_BETA(true);
                Variables.HitboxBETA = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.HITBOX_BETA(false);
                Variables.HitboxBETA = false;
            }
        }

        private void gunaCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox15.Checked)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BLOCKS_STATIC_CRACK(true);
                Variables.BlockStaticCrack = true;
            }
            else
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BLOCKS_STATIC_CRACK(false);
                Variables.BlockStaticCrack = false;
            }
        }

        private void gunaCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox16.Checked)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.VELOCITY_SMALL(true);
                Variables.NoKnockbackAndVelocity = true;
            }
            else
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.VELOCITY_SMALL(false);
                Variables.NoKnockbackAndVelocity = false;
            }
        }

        private void gunaCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox17.Checked)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.VELOCITY_BIG(true);
                Variables.BigKnockbackAndVelocity = true;
            }
            else
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.VELOCITY_BIG(false);
                Variables.BigKnockbackAndVelocity = false;
            }
        }
    }
}
