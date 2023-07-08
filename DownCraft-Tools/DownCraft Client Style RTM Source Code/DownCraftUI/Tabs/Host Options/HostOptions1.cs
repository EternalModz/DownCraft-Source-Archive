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

namespace DownCraftUI.Tabs.Host_Options
{
    public partial class HostOptions1 : Form
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

        public HostOptions1()
        {
            InitializeComponent();
        }

        private void HostOptions1_Load(object sender, EventArgs e)
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

            if (Variables.MaxPickUpItems == true)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox1.Checked = true;
            }
            if (Variables.WolfRemoveWater == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.RemoveFallDamage == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.InfinitePlaceBlocks == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.NameInLogsOfWorlds == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.BurnInWater == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.RemoveFire == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.CreativeSlot == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.SurvivalSlot == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.AutoKillSpawnedEntity == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.StopBlocksFallGravity == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.NoDelayHitDamage == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.BypassMaxItems == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.InfiniteFood == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.MobsIgnoreMe == true)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox15.Checked = true;
            }
            if (Variables.LeadCantBeRemoved == true)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox16.Checked = true;
            }
            if (Variables.DisablePortals == true)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox17.Checked = true;
            }
            if (Variables.AutoKillPlayersOnRespawn == true)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox18.Checked = true;
            }
            if (Variables.FreezeAllEntity == true)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox19.Checked = true;
            }
            if (Variables.EntityAlreadyDamaged == true)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox20.Checked = true;
            }
            if (Variables.CantGrabItemsV1 == true)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox21.Checked = true;
            }
            if (Variables.CantGrabItemsV2 == true)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox22.Checked = true;
            }
            if (Variables.HostOptionsPage2)
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
                OFFSETS.MAX_PICKUP_ITEMS(true);
                Variables.MaxPickUpItems = true;
            }
            else
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.MAX_PICKUP_ITEMS(false);
                Variables.MaxPickUpItems = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.WOLF_REMOVE_WATER(true);
                Variables.WolfRemoveWater = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.WOLF_REMOVE_WATER(false);
                Variables.WolfRemoveWater = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_FALL_DAMAGE(true);
                Variables.RemoveFallDamage = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_FALL_DAMAGE(false);
                Variables.RemoveFallDamage = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.INFINITE_BLOCK(true);
                Variables.InfinitePlaceBlocks = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.INFINITE_BLOCK(false);
                Variables.InfinitePlaceBlocks = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(true);
                Variables.NameInLogsOfWorlds = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(false);
                Variables.NameInLogsOfWorlds = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BURN_IN_WATER(true);
                Variables.BurnInWater = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BURN_IN_WATER(false);
                Variables.BurnInWater = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.FIRE_INSTANT_REMOVED(true);
                Variables.RemoveFire = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FIRE_INSTANT_REMOVED(false);
                Variables.RemoveFire = false;
            }
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CREATIVE_SLOT(true);
                Variables.CreativeSlot = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CREATIVE_SLOT(false);
                Variables.CreativeSlot = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SURVIVAL_SLOT(true);
                Variables.SurvivalSlot = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SURVIVAL_SLOT(false);
                Variables.SurvivalSlot = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_KILL_MOBS_SPAWNED(true);
                Variables.AutoKillSpawnedEntity = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_KILL_MOBS_SPAWNED(false);
                Variables.AutoKillSpawnedEntity = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.STOP_FALL_GRAVITY(true);
                Variables.StopBlocksFallGravity = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.STOP_FALL_GRAVITY(false);
                Variables.StopBlocksFallGravity = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.NO_DELAY_HIT_DAMAGE(true);
                Variables.NoDelayHitDamage = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NO_DELAY_HIT_DAMAGE(false);
                Variables.NoDelayHitDamage = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BYPASS_MAX_ITEMS(true);
                Variables.BypassMaxItems = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BYPASS_MAX_ITEMS(false);
                Variables.BypassMaxItems = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.INFINITE_FOOD(true);
                Variables.InfiniteFood = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.INFINITE_FOOD(false);
                Variables.InfiniteFood = false;
            }
        }

        private void gunaCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox15.Checked)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.MOBS_IGNORE_ME(true);
                Variables.MobsIgnoreMe = true;
            }
            else
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.MOBS_IGNORE_ME(false);
                Variables.MobsIgnoreMe = false;
            }
        }

        private void gunaCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox16.Checked)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.LEAD_CANT_BE_REMOVED(true);
                Variables.LeadCantBeRemoved = true;
            }
            else
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.LEAD_CANT_BE_REMOVED(false);
                Variables.LeadCantBeRemoved = false;
            }
        }

        private void gunaCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox17.Checked)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DISABLE_PORTALS(true);
                Variables.DisablePortals = true;
            }
            else
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DISABLE_PORTALS(false);
                Variables.DisablePortals = false;
            }
        }

        private void gunaCheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox18.Checked)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_KILL_PLAYERS(true);
                Variables.AutoKillPlayersOnRespawn = true;
            }
            else
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_KILL_PLAYERS(false);
                Variables.AutoKillPlayersOnRespawn = false;
            }
        }

        private void gunaCheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox19.Checked)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.FREEZE_ALL_ENTITY(true);
                Variables.FreezeAllEntity = true;
            }
            else
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FREEZE_ALL_ENTITY(false);
                Variables.FreezeAllEntity = false;
            }
        }

        private void gunaCheckBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox20.Checked)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DETECT_IF_PLAYERS_HAS_BEEN_ALREADY_DAMAGED(true);
                Variables.EntityAlreadyDamaged = true;
            }
            else
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DETECT_IF_PLAYERS_HAS_BEEN_ALREADY_DAMAGED(false);
                Variables.EntityAlreadyDamaged = false;
            }
        }

        private void gunaCheckBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox21.Checked)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CANT_GRAB_ITEMS(true);
                Variables.CantGrabItemsV1 = true;
            }
            else
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CANT_GRAB_ITEMS(false);
                Variables.CantGrabItemsV1 = false;
            }
        }

        private void gunaCheckBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox22.Checked)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CANT_GRAB_ITEMS_V2(true);
                Variables.CantGrabItemsV2 = true;
            }
            else
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CANT_GRAB_ITEMS_V2(false);
                Variables.CantGrabItemsV2 = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!Variables.HostOptionsPage2)
            {
                guna2Button1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                Host_Options.HostOptions2 frm = new Host_Options.HostOptions2();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 419, Functions.y);
                Variables.HostOptionsPage2 = true;
            }
            else
            {
                guna2Button1.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["HostOptions2"];
                frm.Close();
                Variables.HostOptionsPage2 = false;
            }
        }
    }
}