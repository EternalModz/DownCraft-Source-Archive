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
    public partial class Non_HostOptions4 : Form
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

        public Non_HostOptions4()
        {
            InitializeComponent();
        }

        private void Non_HostOptions4_Load(object sender, EventArgs e)
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

            if (Variables.AutoLadder == true)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox1.Checked = true;
            }
            if (Variables.AirToWater == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.MultiJumpV2 == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.SuicideMode == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.CanFly == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.GameSpeedStatic == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.AutoJump == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.AutoChangeView == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.AutoCrouch == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.AutoMine == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.AutoHit == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.AutoTossItems == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.AutoBuildSurvival == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.Get64ItemsAndBlocks == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.BatEggsGetOfflineTheWorld == true)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox15.Checked = true;
            }
            if (Variables.BatEggsFreezeTheWorld == true)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox16.Checked = true;
            }
            if (Variables.GetSpecialBlocksInInventory == true)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox17.Checked = true;
            }

            if (Variables.EggModifierValues == 0)
            {
                guna2ComboBox1.SelectedIndex = 0;
            }
            else if (Variables.EggModifierValues == 1)
            {
                guna2ComboBox1.SelectedIndex = 1;
            }
            else if (Variables.EggModifierValues == 2)
            {
                guna2ComboBox1.SelectedIndex = 2;
            }
            else if (Variables.EggModifierValues == 3)
            {
                guna2ComboBox1.SelectedIndex = 3;
            }
            else if (Variables.EggModifierValues == 4)
            {
                guna2ComboBox1.SelectedIndex = 4;
            }
            else if (Variables.EggModifierValues == 5)
            {
                guna2ComboBox1.SelectedIndex = 5;
            }
            else if (Variables.EggModifierValues == 6)
            {
                guna2ComboBox1.SelectedIndex = 6;
            }
            if (Variables.NonHostOptionsPage6 == true)
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
                OFFSETS.AUTO_LADDER(true);
                Variables.AutoLadder = true;
            }
            else
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_LADDER(false);
                Variables.AutoLadder = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CHANGE_AIR_TO_WATER(true);
                Variables.AirToWater = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CHANGE_AIR_TO_WATER(false);
                Variables.AirToWater = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.MULTI_JUMP_V2(true);
                Variables.MultiJumpV2 = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.MULTI_JUMP_V2(false);
                Variables.MultiJumpV2 = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SUICIDE(true);
                Variables.SuicideMode = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SUICIDE(false);
                Variables.SuicideMode = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.CAN_FLY(true);
                Variables.CanFly = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.CAN_FLY(false);
                Variables.CanFly = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.GAME_SPEED_STATIC(true);
                Variables.GameSpeedStatic = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.GAME_SPEED_STATIC(false);
                Variables.GameSpeedStatic = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_JUMP(true);
                Variables.AutoJump = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_JUMP(false);
                Variables.AutoJump = false;
            }
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_CHANGE_VIEW(true);
                Variables.AutoChangeView = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_CHANGE_VIEW(false);
                Variables.AutoChangeView = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_CROUCH(true);
                Variables.AutoCrouch = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_CROUCH(false);
                Variables.AutoCrouch = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_MINE(true);
                Variables.AutoMine = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_MINE(false);
                Variables.AutoMine = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_HIT(true);
                Variables.AutoHit = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_HIT(false);
                Variables.AutoHit = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_TOSS_ITEMS(true);
                Variables.AutoTossItems = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_TOSS_ITEMS(false);
                Variables.AutoTossItems = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_BUILD_IN_SURVIVAL(true);
                Variables.AutoBuildSurvival = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_BUILD_IN_SURVIVAL(false);
                Variables.AutoBuildSurvival = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.GET_64_ITEMS_BLOCKS(true);
                Variables.Get64ItemsAndBlocks = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.GET_64_ITEMS_BLOCKS(false);
                Variables.Get64ItemsAndBlocks = false;
            }
        }

        private void gunaCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox15.Checked)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SWITCH_GAME_TO_OFFLINE(true);
                Variables.BatEggsGetOfflineTheWorld = true;
            }
            else
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SWITCH_GAME_TO_OFFLINE(false);
                Variables.BatEggsGetOfflineTheWorld = false;
            }
        }

        private void gunaCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox16.Checked)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.FREEZE_THE_WORLD_WITH_EGG(true);
                Variables.BatEggsFreezeTheWorld = true;
            }
            else
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FREEZE_THE_WORLD_WITH_EGG(false);
                Variables.BatEggsFreezeTheWorld = false;
            }
        }

        private void gunaCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox17.Checked)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.INVENTORY_SPECIAL_BLOCKS(true);
                Variables.GetSpecialBlocksInInventory = true;
            }
            else
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.INVENTORY_SPECIAL_BLOCKS(false);
                Variables.GetSpecialBlocksInInventory = false;
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                OFFSETS.SPAWN_DRAGON_EGGS(false);
                OFFSETS.SPAWN_GIANT_EGGS(false);
                OFFSETS.SPAWN_IRON_GOLEM_EGGS(false);
                OFFSETS.SPAWN_SNOWBALL_EGGS(false);
                OFFSETS.SPAWN_WHITER_EGGS(false);
                OFFSETS.SPAWN_ARMOR_STAND_EGGS(false);
                Variables.EggModifierValues = 0;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                OFFSETS.SPAWN_DRAGON_EGGS(true);
                Variables.EggModifierValues = 1;
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                OFFSETS.SPAWN_GIANT_EGGS(true);
                Variables.EggModifierValues = 2;
            }
            else if (guna2ComboBox1.SelectedIndex == 3)
            {
                OFFSETS.SPAWN_IRON_GOLEM_EGGS(true);
                Variables.EggModifierValues = 3;
            }
            else if (guna2ComboBox1.SelectedIndex == 4)
            {
                OFFSETS.SPAWN_SNOWBALL_EGGS(true);
                Variables.EggModifierValues = 4;
            }
            else if (guna2ComboBox1.SelectedIndex == 5)
            {
                OFFSETS.SPAWN_WHITER_EGGS(true);
                Variables.EggModifierValues = 5;
            }
            else if (guna2ComboBox1.SelectedIndex == 6)
            {
                OFFSETS.SPAWN_ARMOR_STAND_EGGS(true);
                Variables.EggModifierValues = 6;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!Variables.NonHostOptionsPage6)
            {
                guna2Button3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                Non_HostOptions5 frm = new Non_HostOptions5();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 1019, Functions.y);
                Variables.NonHostOptionsPage6 = true;
            }
            else
            {
                guna2Button3.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["Non_HostOptions5"];
                frm.Close();
                Variables.NonHostOptionsPage6 = false;
            }
        }

        private void gunaCheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            OFFSETS.setRegen(true);
            Task.Delay(1000).Wait();
            OFFSETS.takeDamage();
            Task.Delay(1000).Wait();
            OFFSETS.setRegen(false);
        }
    }
}
