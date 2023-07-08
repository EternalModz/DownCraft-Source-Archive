using Guna.UI.WinForms;
using Guna.UI2.WinForms;
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
    public partial class HostOptions : Form
    {
        public Guna2ToggleSwitch checkbox = new Guna2ToggleSwitch();
        public GunaLabel label = new GunaLabel();

        int x = 10;
        int y = 12;
        int space = 10;

        string[] subTxt = { "God Mode", "Demi God Mode", "Totem God Mode", "Instant Damage", "Instant Kill", "Instant Kill All", "Instant Kill All In Fire", "No Damage Hit",
                "Big Knockback", "No Knockback", "Reverse Knockback", "Auto Save World", "Drop So Far Items", "Max XP Level" };

        Offsets OFFSETS = new Offsets();
        public HostOptions()
        {
            InitializeComponent();
        }
        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked)
            {
                OFFSETS.GOD_MODE(true);
            }
            else
            {
                OFFSETS.GOD_MODE(false);
            }
        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch2.Checked)
            {
                OFFSETS.DEMI_GOD(true);
            }
            else
            {
                OFFSETS.DEMI_GOD(false);
            }
        }

        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch3.Checked)
            {
                OFFSETS.TOTEM_GOD_MODE(true);
            }
            else
            {
                OFFSETS.TOTEM_GOD_MODE(false);
            }
        }

        private void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch4.Checked)
            {
                OFFSETS.INSTANT_DAMAGE(true);
            }
            else
            {
                OFFSETS.INSTANT_DAMAGE(false);
            }
        }

        private void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch5.Checked)
            {
                OFFSETS.INSTANT_KILL(true);
            }
            else
            {
                OFFSETS.INSTANT_KILL(false);
            }
        }

        private void guna2ToggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch6.Checked)
            {
                OFFSETS.INSTANT_KILL_ALL(true);
            }
            else
            {
                OFFSETS.INSTANT_KILL_ALL(false);
            }
        }

        private void guna2ToggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch7.Checked)
            {
                OFFSETS.INSTANT_KILL_IN_FIRE(true);
            }
            else
            {
                OFFSETS.INSTANT_KILL_IN_FIRE(false);
            }
        }

        private void guna2ToggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch8.Checked)
            {
                OFFSETS.NO_DAMAGE_HIT(true);
            }
            else
            {
                OFFSETS.NO_DAMAGE_HIT(false);
            }
        }

        private void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch9.Checked)
            {
                OFFSETS.KNOCKBACK(true);
            }
            else
            {
                OFFSETS.KNOCKBACK(false);
            }
        }

        private void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch10.Checked)
            {
                OFFSETS.NO_KNOCKBACK(true);
            }
            else
            {
                OFFSETS.NO_KNOCKBACK(false);
            }
        }

        private void guna2ToggleSwitch11_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch11.Checked)
            {
                OFFSETS.REVERSE_KNOCKBACK(true);
            }
            else
            {
                OFFSETS.REVERSE_KNOCKBACK(false);
            }
        }

        private void guna2ToggleSwitch12_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch12.Checked)
            {
                OFFSETS.AUTO_SAVE(true);
            }
            else
            {
                OFFSETS.AUTO_SAVE(false);
            }
        }

        private void guna2ToggleSwitch13_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch13.Checked)
            {
                OFFSETS.GUN_ITEMS(true);
            }
            else
            {
                OFFSETS.GUN_ITEMS(false);
            }
        }

        private void guna2ToggleSwitch14_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch14.Checked)
            {
                OFFSETS.MAX_XP_LEVEL(true);
            }
            else
            {
                OFFSETS.MAX_XP_LEVEL(false);
            }
        }

        private void guna2ToggleSwitch15_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch15.Checked)
            {
                OFFSETS.REMOVE_LEVEL_XP(true);
            }
            else
            {
                OFFSETS.REMOVE_LEVEL_XP(false);
            }
        }

        private void guna2ToggleSwitch16_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch16.Checked)
            {
                OFFSETS.WATER_JUMP(true);
            }
            else
            {
                OFFSETS.WATER_JUMP(false);
            }
        }

        private void guna2ToggleSwitch17_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch17.Checked)
            {
                OFFSETS.DRIFT_BOAT(true);
            }
            else
            {
                OFFSETS.DRIFT_BOAT(false);
            }
        }

        private void guna2ToggleSwitch18_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch18.Checked)
            {
                OFFSETS.ARROWS_BLOCKS_ITEMS(true);
            }
            else
            {
                OFFSETS.ARROWS_BLOCKS_ITEMS(false);
            }
        }

        private void guna2ToggleSwitch19_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch19.Checked)
            {
                OFFSETS.ARROWS_REMOVE(true);
            }
            else
            {
                OFFSETS.ARROWS_REMOVE(false);
            }
        }

        private void guna2ToggleSwitch20_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch20.Checked)
            {
                OFFSETS.POTIONS_GRAVITY_FLY(true);
            }
            else
            {
                OFFSETS.POTIONS_GRAVITY_FLY(false);
            }
        }

        private void guna2ToggleSwitch21_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch21.Checked)
            {
                OFFSETS.POTIONS_NO_GRAVITY(true);
            }
            else
            {
                OFFSETS.POTIONS_NO_GRAVITY(false);
            }
        }

        private void guna2ToggleSwitch22_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch22.Checked)
            {
                OFFSETS.INFINITE_PICK_UP(true);
            }
            else
            {
                OFFSETS.INFINITE_PICK_UP(false);
            }
        }

        private void guna2ToggleSwitch23_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch23.Checked)
            {
                OFFSETS.MAX_PICKUP_ITEMS(true);
            }
            else
            {
                OFFSETS.MAX_PICKUP_ITEMS(false);
            }
        }

        private void guna2ToggleSwitch24_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch24.Checked)
            {
                OFFSETS.WOLF_REMOVE_WATER(true);
            }
            else
            {
                OFFSETS.WOLF_REMOVE_WATER(false);
            }
        }

        private void guna2ToggleSwitch25_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch25.Checked)
            {
                OFFSETS.REMOVE_FALL_DAMAGE(true);
            }
            else
            {
                OFFSETS.REMOVE_FALL_DAMAGE(false);
            }
        }

        private void guna2ToggleSwitch26_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch26.Checked)
            {
                OFFSETS.INFINITE_BLOCK(true);
            }
            else
            {
                OFFSETS.INFINITE_BLOCK(false);
            }
        }

        private void guna2ToggleSwitch27_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch27.Checked)
            {
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(true);
            }
            else
            {
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(false);
            }
        }

        private void guna2ToggleSwitch28_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch28.Checked)
            {
                OFFSETS.BURN_IN_WATER(true);
            }
            else
            {
                OFFSETS.BURN_IN_WATER(false);
            }
        }

        private void guna2ToggleSwitch29_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch29.Checked)
            {
                OFFSETS.FIRE_INSTANT_REMOVED(true);
            }
            else
            {
                OFFSETS.FIRE_INSTANT_REMOVED(false);
            }
        }

        private void guna2ToggleSwitch30_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch30.Checked)
            {
                OFFSETS.CREATIVE_SLOT(true);
            }
            else
            {
                OFFSETS.CREATIVE_SLOT(false);
            }
        }

        private void guna2ToggleSwitch31_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch31.Checked)
            {
                OFFSETS.SURVIVAL_SLOT(true);
            }
            else
            {
                OFFSETS.SURVIVAL_SLOT(false);
            }
        }

        private void guna2ToggleSwitch32_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch32.Checked)
            {
                OFFSETS.AUTO_KILL_MOBS_SPAWNED(true);
            }
            else
            {
                OFFSETS.AUTO_KILL_MOBS_SPAWNED(false);
            }
        }

        private void guna2ToggleSwitch33_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch33.Checked)
            {
                OFFSETS.STOP_FALL_GRAVITY(true);
            }
            else
            {
                OFFSETS.STOP_FALL_GRAVITY(false);
            }
        }

        private void guna2ToggleSwitch34_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch34.Checked)
            {
                OFFSETS.NO_DELAY_HIT_DAMAGE(true);
            }
            else
            {
                OFFSETS.NO_DELAY_HIT_DAMAGE(false);
            }
        }

        private void guna2ToggleSwitch35_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch35.Checked)
            {
                OFFSETS.BYPASS_MAX_ITEMS(true);
            }
            else
            {
                OFFSETS.BYPASS_MAX_ITEMS(false);
            }
        }

        private void guna2ToggleSwitch36_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch36.Checked)
            {
                OFFSETS.INFINITE_FOOD(true);
            }
            else
            {
                OFFSETS.INFINITE_FOOD(false);
            }
        }

        private void guna2ToggleSwitch37_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch37.Checked)
            {
                OFFSETS.MOBS_IGNORE_ME(true);
            }
            else
            {
                OFFSETS.MOBS_IGNORE_ME(false);
            }
        }

        private void guna2ToggleSwitch38_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch38.Checked)
            {
                OFFSETS.LEAD_CANT_BE_REMOVED(true);
            }
            else
            {
                OFFSETS.LEAD_CANT_BE_REMOVED(false);
            }
        }

        private void guna2ToggleSwitch39_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch39.Checked)
            {
                OFFSETS.DISABLE_PORTALS(true);
            }
            else
            {
                OFFSETS.DISABLE_PORTALS(false);
            }
        }

        private void guna2ToggleSwitch40_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch40.Checked)
            {
                OFFSETS.AUTO_KILL_PLAYERS(true);
            }
            else
            {
                OFFSETS.AUTO_KILL_PLAYERS(false);
            }
        }

        private void guna2ToggleSwitch41_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch41.Checked)
            {
                OFFSETS.FREEZE_ALL_ENTITY(true);
            }
            else
            {
                OFFSETS.FREEZE_ALL_ENTITY(false);
            }
        }

        private void guna2ToggleSwitch42_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch42.Checked)
            {
                OFFSETS.DETECT_IF_PLAYERS_HAS_BEEN_ALREADY_DAMAGED(true);
            }
            else
            {
                OFFSETS.DETECT_IF_PLAYERS_HAS_BEEN_ALREADY_DAMAGED(false);
            }
        }

        private void guna2ToggleSwitch43_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch43.Checked)
            {
                OFFSETS.CANT_GRAB_ITEMS(true);
            }
            else
            {
                OFFSETS.CANT_GRAB_ITEMS(false);
            }
        }

        private void guna2ToggleSwitch44_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch44.Checked)
            {
                OFFSETS.CANT_GRAB_ITEMS_V2(true);
            }
            else
            {
                OFFSETS.CANT_GRAB_ITEMS_V2(false);
            }
        }

        private void HostOptions_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 14; i++)
            {
                checkbox.Left = y;
                checkbox.Top = x;

                label.Left = y + 40;
                label.Top = x + 3;

                label.ForeColor = Color.White;

                label.Text = subTxt[i];

                panel2.Controls.Add(checkbox);
                panel2.Controls.Add(label);

                x += checkbox.Height + space;
            }
        }
    }
}
