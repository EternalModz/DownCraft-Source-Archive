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
    public partial class HostOptions2 : Form
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

        public HostOptions2()
        {
            InitializeComponent();
        }

        private void HostOptions2_Load(object sender, EventArgs e)
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
            if (Variables.NetherPortalWithStone == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.StopEndermanTeleport == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.IgnoringPressurePlate == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.DeadPlayersRemainStanding == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.DisableDieOutOfTheWorld == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.KillDontDisappearEntity == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.GetAllEnchant == 0)
            {
                guna2ComboBox1.SelectedIndex = 0;
            }
            else if (Variables.GetAllEnchant == 1)
            {
                guna2ComboBox1.SelectedIndex = 1;
            }
            else if (Variables.GetAllEnchant == 2)
            {
                guna2ComboBox1.SelectedIndex = 2;
            }
            else if (Variables.GetAllEnchant == 3)
            {
                guna2ComboBox1.SelectedIndex = 3;
            }
            else if (Variables.GetAllEnchant == 4)
            {
                guna2ComboBox1.SelectedIndex = 4;
            }
            else if (Variables.GetAllEnchant == 5)
            {
                guna2ComboBox1.SelectedIndex = 5;
            }
            else if (Variables.GetAllEnchant == 6)
            {
                guna2ComboBox1.SelectedIndex = 6;
            }
            else if (Variables.GetAllEnchant == 7)
            {
                guna2ComboBox1.SelectedIndex = 7;
            }
            else if (Variables.GetAllEnchant == 8)
            {
                guna2ComboBox1.SelectedIndex = 8;
            }
            else if (Variables.GetAllEnchant == 9)
            {
                guna2ComboBox1.SelectedIndex = 9;
            }
            else if (Variables.GetAllEnchant == 10)
            {
                guna2ComboBox1.SelectedIndex = 10;
            }
            if (Variables.EnableAllEnchantement == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.AllowAllItemsAndBlockOnHead == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.BoatStopWorking == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.CanMineInAdventure == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.NoWebHax == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.EntityOnGodMode == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.SpectralArrowsWithBow == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.InfiniteOxygenInWater == true)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox15.Checked = true;
            }
            if (Variables.GetSpectatorGamemode == true)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox16.Checked = true;
            }
            if (Variables.AutoRegenHealth == true)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox17.Checked = true;
            }
            if (Variables.LockChangingGamemode == true)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox18.Checked = true;
            }
            if (Variables.LockChangingWeather == true)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox19.Checked = true;
            }
            if (Variables.FastBow == true)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox20.Checked = true;
            }
            if (Variables.StopBow == true)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox21.Checked = true;
            }
            if (Variables.ChangeDirectionArrows == true)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox22.Checked = true;
            }
            if (Variables.HostOptionsPage3 == true)
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
                OFFSETS.FISHING_ROD_CANT_BE_REMOVED(true);
                Variables.FishingRoadCantBeRemoved = true;
            }
            else
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FISHING_ROD_CANT_BE_REMOVED(false);
                Variables.FishingRoadCantBeRemoved = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.NETHER_PORTAL_WITH_STONE(true);
                Variables.NetherPortalWithStone = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NETHER_PORTAL_WITH_STONE(false);
                Variables.NetherPortalWithStone = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ENDERMAN_AND_CHORUS_FRUIT_CANT_BE_TELEPORTED(true);
                Variables.StopEndermanTeleport = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ENDERMAN_AND_CHORUS_FRUIT_CANT_BE_TELEPORTED(false);
                Variables.StopEndermanTeleport = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.IGNIORING_PRESSURE_PLATE(true);
                Variables.IgnoringPressurePlate = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.IGNIORING_PRESSURE_PLATE(false);
                Variables.IgnoringPressurePlate = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DEAD_PLAYERS_REMAINS_STANDING(true);
                Variables.DeadPlayersRemainStanding = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DEAD_PLAYERS_REMAINS_STANDING(false);
                Variables.DeadPlayersRemainStanding = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DISABLE_KILLED_OUT_OF_WORLD(true);
                Variables.DisableDieOutOfTheWorld = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DISABLE_KILLED_OUT_OF_WORLD(false);
                Variables.DisableDieOutOfTheWorld = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.KILL_DONT_DISAPPEAR_ENTITY(true);
                Variables.KillDontDisappearEntity = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.KILL_DONT_DISAPPEAR_ENTITY(false);
                Variables.KillDontDisappearEntity = false;
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.guna2ComboBox1.SelectedIndex == 0)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("0");
                Variables.GetAllEnchant = 0;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("1");
                Variables.GetAllEnchant = 1;
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("2");
                Variables.GetAllEnchant = 2;
            }
            else if (guna2ComboBox1.SelectedIndex == 3)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("3");
                Variables.GetAllEnchant = 3;
            }
            else if (guna2ComboBox1.SelectedIndex == 4)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("4");
                Variables.GetAllEnchant = 4;
            }
            else if (guna2ComboBox1.SelectedIndex == 5)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("5");
                Variables.GetAllEnchant = 5;
            }
            else if (guna2ComboBox1.SelectedIndex == 6)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("6");
                Variables.GetAllEnchant = 6;
            }
            else if (guna2ComboBox1.SelectedIndex == 7)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("7");
                Variables.GetAllEnchant = 7;
            }
            else if (guna2ComboBox1.SelectedIndex == 8)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("8");
                Variables.GetAllEnchant = 8;
            }
            else if (guna2ComboBox1.SelectedIndex == 9)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("9");
                Variables.GetAllEnchant = 9;
            }
            else if (guna2ComboBox1.SelectedIndex == 10)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("10");
                Variables.GetAllEnchant = 10;
            };
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ENABLE_ALL_ENCHANTEMENT(true);
                Variables.EnableAllEnchantement = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ENABLE_ALL_ENCHANTEMENT(false);
                Variables.EnableAllEnchantement = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ALLOW_ALL_ITEMS_ON_HEAD(true);
                Variables.AllowAllItemsAndBlockOnHead = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ALLOW_ALL_ITEMS_ON_HEAD(false);
                Variables.AllowAllItemsAndBlockOnHead = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BOAT_STOP_WORKING(true);
                Variables.BoatStopWorking = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BOAT_STOP_WORKING(false);
                Variables.BoatStopWorking = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.MINE_IN_ADVENTURE(true);
                Variables.CanMineInAdventure = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.MINE_IN_ADVENTURE(false);
                Variables.CanMineInAdventure = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.NO_WEB_HAX(true);
                Variables.NoWebHax = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NO_WEB_HAX(false);
                Variables.NoWebHax = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ENTITY_GOD_MODE(true);
                Variables.EntityOnGodMode = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ENTITY_GOD_MODE(false);
                Variables.EntityOnGodMode = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.SPECTRAL_ARROWS_WITH_BOW(true);
                Variables.SpectralArrowsWithBow = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.SPECTRAL_ARROWS_WITH_BOW(false);
                Variables.SpectralArrowsWithBow = false;
            }
        }

        private void gunaCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox15.Checked)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.INFINITE_OXYGEN_IN_WATER(true);
                Variables.InfiniteOxygenInWater = true;
            }
            else
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.INFINITE_OXYGEN_IN_WATER(false);
                Variables.InfiniteOxygenInWater = false;
            }
        }

        private void gunaCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox16.Checked)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.GET_SPECTATOR_GAMEMODE(true);
                Variables.GetSpectatorGamemode = true;
            }
            else
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.GET_SPECTATOR_GAMEMODE(false);
                Variables.GetSpectatorGamemode = false;
            }
        }

        private void gunaCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox17.Checked)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.AUTO_REGENERATE_HEALTH(true);
                Variables.AutoRegenHealth = true;
            }
            else
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.AUTO_REGENERATE_HEALTH(false);
                Variables.AutoRegenHealth = false;
            }
        }

        private void gunaCheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox18.Checked)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.GAME_GAMEMODE_LOCKED(true);
                Variables.LockChangingGamemode = true;
            }
            else
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.GAME_GAMEMODE_LOCKED(false);
                Variables.LockChangingGamemode = false;
            }
        }

        private void gunaCheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox19.Checked)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.DISABLE_CHANGING_WEATHER(true);
                Variables.LockChangingWeather = true;
            }
            else
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.DISABLE_CHANGING_WEATHER(false);
                Variables.LockChangingWeather = false;
            }
        }

        private void gunaCheckBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox20.Checked)
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.FAST_BOW(true);
                Variables.FastBow = true;
            }
            else
            {
                gunaCheckBox20.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.FAST_BOW(false);
                Variables.FastBow = false;
            }
        }

        private void gunaCheckBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox21.Checked)
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.STOP_BOW(true);
                Variables.StopBow = true;
            }
            else
            {
                gunaCheckBox21.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.STOP_BOW(false);
                Variables.StopBow = false;
            }
        }

        private void gunaCheckBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox22.Checked)
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ARROWS_CHANGE_DIRECTIONS(true);
                Variables.ChangeDirectionArrows = true;
            }
            else
            {
                gunaCheckBox22.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ARROWS_CHANGE_DIRECTIONS(false);
                Variables.ChangeDirectionArrows = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!Variables.HostOptionsPage3)
            {
                guna2Button1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                Host_Options.HostOptions3 frm = new Host_Options.HostOptions3();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 619, Functions.y);
                Variables.HostOptionsPage3 = true;
            }
            else
            {
                guna2Button1.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["HostOptions3"];
                frm.Close();
                Variables.HostOptionsPage3 = false;
            }
        }
    }
}
