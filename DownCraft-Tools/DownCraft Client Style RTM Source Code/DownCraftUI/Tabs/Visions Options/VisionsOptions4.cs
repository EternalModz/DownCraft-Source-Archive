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
    public partial class VisionsOptions4 : Form
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

        public VisionsOptions4()
        {
            InitializeComponent();
        }

        private void VisionsOptions4_Load(object sender, EventArgs e)
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

            if (Variables.NetherVisions == true)
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox1.Checked = true;
            }
            if (Variables.ParticlesHitSpam == true)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox2.Checked = true;
            }
            if (Variables.PlayersRobloxAnimation == true)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox3.Checked = true;
            }
            if (Variables.RemoveNotifsLogs == true)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox4.Checked = true;
            }
            if (Variables.GenerateBubbleInWater == true)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox5.Checked = true;
            }
            if (Variables.ElytraOnAllPlayers == true)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox6.Checked = true;
            }
            if (Variables.MoveHeadButNotTheBody == true)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox7.Checked = true;
            }
            if (Variables.StopAnimation == true)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox8.Checked = true;
            }
            if (Variables.GiantGameplay == true)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox9.Checked = true;
            }
            if (Variables.RemoveInventoryHUD == true)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox10.Checked = true;
            }
            if (Variables.RemovePointerAim == true)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox11.Checked = true;
            }
            if (Variables.WorldLightWhite == true)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox12.Checked = true;
            }
            if (Variables.WorldRainbowLight == true)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox13.Checked = true;
            }
            if (Variables.DoubleNameOverHead == true)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox14.Checked = true;
            }
            if (Variables.HideHUDEverything == true)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox15.Checked = true;
            }
            if (Variables.GameplayNoItems == true)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox16.Checked = true;
            }
            if (Variables.OptimizeChunks == true)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox17.Checked = true;
            }
            if (Variables.StopChunksLoad == true)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox18.Checked = true;
            }
            if (Variables.RealJumpAnimation == true)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                gunaCheckBox19.Checked = true;
            }

            if (Variables.MoonAndSunValue == 0)
            {
                guna2ComboBox1.SelectedIndex = 0;
            }
            else if (Variables.MoonAndSunValue == 1)
            {
                guna2ComboBox1.SelectedIndex = 1;
            }
            else if (Variables.MoonAndSunValue == 2)
            {
                guna2ComboBox1.SelectedIndex = 2;
            }
            else if (Variables.MoonAndSunValue == 3)
            {
                guna2ComboBox1.SelectedIndex = 3;
            }
            else if (Variables.MoonAndSunValue == 4)
            {
                guna2ComboBox1.SelectedIndex = 4;
            }
            else if (Variables.MoonAndSunValue == 5)
            {
                guna2ComboBox1.SelectedIndex = 5;
            }
            else if (Variables.MoonAndSunValue == 6)
            {
                guna2ComboBox1.SelectedIndex = 6;
            }
            else if (Variables.MoonAndSunValue == 7)
            {
                guna2ComboBox1.SelectedIndex = 7;
            }
            else if (Variables.MoonAndSunValue == 8)
            {
                guna2ComboBox1.SelectedIndex = 8;
            }

            if (Variables.LineSelectBlockValue == 0)
            {
                guna2ComboBox2.SelectedIndex = 0;
            }
            else if (Variables.LineSelectBlockValue == 1)
            {
                guna2ComboBox2.SelectedIndex = 1;
            }
            else if (Variables.LineSelectBlockValue == 2)
            {
                guna2ComboBox2.SelectedIndex = 2;
            }
            else if (Variables.LineSelectBlockValue == 3)
            {
                guna2ComboBox2.SelectedIndex = 3;
            }
            else if (Variables.LineSelectBlockValue == 4)
            {
                guna2ComboBox2.SelectedIndex = 4;
            }
            else if (Variables.LineSelectBlockValue == 5)
            {
                guna2ComboBox2.SelectedIndex = 5;
            }
            else if (Variables.LineSelectBlockValue == 6)
            {
                guna2ComboBox2.SelectedIndex = 6;
            }
            else if (Variables.LineSelectBlockValue == 7)
            {
                guna2ComboBox2.SelectedIndex = 7;
            }
            else if (Variables.LineSelectBlockValue == 8)
            {
                guna2ComboBox2.SelectedIndex = 8;
            }
            else if (Variables.LineSelectBlockValue == 9)
            {
                guna2ComboBox2.SelectedIndex = 9;
            }
            else if (Variables.LineSelectBlockValue == 10)
            {
                guna2ComboBox2.SelectedIndex = 10;
            }
            else if (Variables.LineSelectBlockValue == 11)
            {
                guna2ComboBox2.SelectedIndex = 11;
            }
            if (Variables.VisionsOptionsPage6 == true)
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
                OFFSETS.NETHER_VISION(true);
                Variables.NetherVisions = true;
            }
            else
            {
                gunaCheckBox1.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NETHER_VISION(false);
                Variables.NetherVisions = false;
            }
        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox2.Checked)
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.PARTICLES_DAMAGE_NO_STOP(true);
                Variables.ParticlesHitSpam = true;
            }
            else
            {
                gunaCheckBox2.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.PARTICLES_DAMAGE_NO_STOP(false);
                Variables.ParticlesHitSpam = false;
            }
        }

        private void gunaCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox3.Checked)
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ROBLOX_ANIMATION(true);
                Variables.PlayersRobloxAnimation = true;
            }
            else
            {
                gunaCheckBox3.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ROBLOX_ANIMATION(false);
                Variables.PlayersRobloxAnimation = false;
            }
        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox4.Checked)
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(true);
                Variables.RemoveNotifsLogs = true;
            }
            else
            {
                gunaCheckBox4.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(false);
                Variables.RemoveNotifsLogs = false;
            }
        }

        private void gunaCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox5.Checked)
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.GENEREATE_BUBBLE_IN_WATER(true);
                Variables.GenerateBubbleInWater = true;
            }
            else
            {
                gunaCheckBox5.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.GENEREATE_BUBBLE_IN_WATER(false);
                Variables.GenerateBubbleInWater = false;
            }
        }

        private void gunaCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox6.Checked)
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ELYTRA_ON_ALL_ENTITY(true);
                Variables.ElytraOnAllPlayers = true;
            }
            else
            {
                gunaCheckBox6.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ELYTRA_ON_ALL_ENTITY(false);
                Variables.ElytraOnAllPlayers = false;
            }
        }

        private void gunaCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox7.Checked)
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.MOVE_HEAD_BUT_NOT_BODY(true);
                Variables.MoveHeadButNotTheBody = true;
            }
            else
            {
                gunaCheckBox7.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.MOVE_HEAD_BUT_NOT_BODY(false);
                Variables.MoveHeadButNotTheBody = false;
            }
        }

        private void gunaCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox8.Checked)
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.STOP_ANIMATIONS(true);
                Variables.StopAnimation = true;
            }
            else
            {
                gunaCheckBox8.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.STOP_ANIMATIONS(false);
                Variables.StopAnimation = false;
            }
        }

        private void gunaCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox9.Checked)
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.BIG_GAMEPLAY(true);
                Variables.GiantGameplay = true;
            }
            else
            {
                gunaCheckBox9.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.BIG_GAMEPLAY(false);
                Variables.GiantGameplay = false;
            }
        }

        private void gunaCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox10.Checked)
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_INVENTORY_HUD(true);
                Variables.RemoveInventoryHUD = true;
            }
            else
            {
                gunaCheckBox10.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_INVENTORY_HUD(false);
                Variables.RemoveInventoryHUD = false;
            }
        }

        private void gunaCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox11.Checked)
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REMOVE_POINTER_AIM(true);
                Variables.RemovePointerAim = true;
            }
            else
            {
                gunaCheckBox11.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REMOVE_POINTER_AIM(false);
                Variables.RemovePointerAim = false;
            }
        }

        private void gunaCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox12.Checked)
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.ALL_WORLD_LIGHT_WHITE(true);
                Variables.WorldLightWhite = true;
            }
            else
            {
                gunaCheckBox12.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.ALL_WORLD_LIGHT_WHITE(false);
                Variables.WorldLightWhite = false;
            }
        }

        private void gunaCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox13.Checked)
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.RAINBOW_LIGHT(true);
                Variables.WorldRainbowLight = true;
            }
            else
            {
                gunaCheckBox13.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.RAINBOW_LIGHT(false);
                Variables.WorldRainbowLight = false;
            }
        }

        private void gunaCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox14.Checked)
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.NAME_OVER_HEAD_DOUBLE(true);
                Variables.DoubleNameOverHead = true;
            }
            else
            {
                gunaCheckBox14.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.NAME_OVER_HEAD_DOUBLE(false);
                Variables.DoubleNameOverHead = false;
            }
        }

        private void gunaCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox15.Checked)
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.HUD_HIDE_EVERYTHING(true);
                Variables.HideHUDEverything = true;
            }
            else
            {
                gunaCheckBox15.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.HUD_HIDE_EVERYTHING(false);
                Variables.HideHUDEverything = false;
            }
        }

        private void gunaCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox16.Checked)
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.GAME_NO_ITEMS(true);
                Variables.GameplayNoItems = true;
            }
            else
            {
                gunaCheckBox16.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.GAME_NO_ITEMS(false);
                Variables.GameplayNoItems = false;
            }
        }

        private void gunaCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox17.Checked)
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.OPTIMIZE_CHUNKS_LOAD(true);
                Variables.OptimizeChunks = true;
            }
            else
            {
                gunaCheckBox17.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.OPTIMIZE_CHUNKS_LOAD(false);
                Variables.OptimizeChunks = false;
            }
        }

        private void gunaCheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox18.Checked)
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.STOP_CHUNKS_LOAD(true);
                Variables.StopChunksLoad = true;
            }
            else
            {
                gunaCheckBox18.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.STOP_CHUNKS_LOAD(false);
                Variables.StopChunksLoad = false;
            }
        }

        private void gunaCheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaCheckBox19.Checked)
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                OFFSETS.REAL_JUMP_ANIMATION(true);
                Variables.RealJumpAnimation = true;
            }
            else
            {
                gunaCheckBox19.ForeColor = Color.FromArgb(169, 169, 171);
                OFFSETS.REAL_JUMP_ANIMATION(false);
                Variables.RealJumpAnimation = false;
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                OFFSETS.SUN_MOON_SIZE("0");
                Variables.MoonAndSunValue = 0;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                OFFSETS.SUN_MOON_SIZE("1");
                Variables.MoonAndSunValue = 1;
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                OFFSETS.SUN_MOON_SIZE("2");
                Variables.MoonAndSunValue = 2;
            }
            else if (guna2ComboBox1.SelectedIndex == 3)
            {
                OFFSETS.SUN_MOON_SIZE("3");
                Variables.MoonAndSunValue = 3;
            }
            else if (guna2ComboBox1.SelectedIndex == 4)
            {
                OFFSETS.SUN_MOON_SIZE("4");
                Variables.MoonAndSunValue = 4;
            }
            else if (guna2ComboBox1.SelectedIndex == 5)
            {
                OFFSETS.SUN_MOON_SIZE("5");
                Variables.MoonAndSunValue = 5;
            }
            else if (guna2ComboBox1.SelectedIndex == 6)
            {
                OFFSETS.SUN_MOON_SIZE("6");
                Variables.MoonAndSunValue = 6;
            }
            else if (guna2ComboBox1.SelectedIndex == 7)
            {
                OFFSETS.SUN_MOON_SIZE("7");
                Variables.MoonAndSunValue = 7;
            }
            else if (guna2ComboBox1.SelectedIndex == 8)
            {
                OFFSETS.SUN_MOON_SIZE("8");
                Variables.MoonAndSunValue = 8;
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == 0)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("0");
                Variables.LineSelectBlockValue = 0;
            }
            else if (guna2ComboBox2.SelectedIndex == 1)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("1");
                Variables.LineSelectBlockValue = 1;
            }
            else if (guna2ComboBox2.SelectedIndex == 2)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("2");
                Variables.LineSelectBlockValue = 2;
            }
            else if (guna2ComboBox2.SelectedIndex == 3)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("3");
                Variables.LineSelectBlockValue = 3;
            }
            else if (guna2ComboBox2.SelectedIndex == 4)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("4");
                Variables.LineSelectBlockValue = 4;
            }
            else if (guna2ComboBox2.SelectedIndex == 5)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("5");
                Variables.LineSelectBlockValue = 5;
            }
            else if (guna2ComboBox2.SelectedIndex == 6)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("6");
                Variables.LineSelectBlockValue = 6;
            }
            else if (guna2ComboBox2.SelectedIndex == 7)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("7");
                Variables.LineSelectBlockValue = 7;
            }
            else if (guna2ComboBox2.SelectedIndex == 8)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("8");
                Variables.LineSelectBlockValue = 8;
            }
            else if (guna2ComboBox2.SelectedIndex == 9)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("9");
                Variables.LineSelectBlockValue = 9;
            }
            else if (guna2ComboBox2.SelectedIndex == 10)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("10");
                Variables.LineSelectBlockValue = 10;
            }
            else if (guna2ComboBox2.SelectedIndex == 11)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("11");
                Variables.LineSelectBlockValue = 11;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!Variables.VisionsOptionsPage6)
            {
                guna2Button3.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                VisionsOptions5 frm = new VisionsOptions5();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 1019, Functions.y);
                Variables.VisionsOptionsPage6 = true;
            }
            else
            {
                guna2Button3.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["VisionsOptions5"];
                frm.Close();
                Variables.VisionsOptionsPage6 = false;
            }
        }
    }
}
