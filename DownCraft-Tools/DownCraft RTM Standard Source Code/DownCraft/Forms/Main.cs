
#region "Library"

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
using System.Media;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MetroFramework.Controls;
using Microsoft.Win32;

#endregion

namespace DownCraft
{
    public partial class Form1 : Form
    {

        #region "Variables"

        Offsets OFFSETS = new Offsets();
        Functions FUNCTIONS = new Functions();
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        PS3API PS3 = new PS3API();

        string DefaultName;

        string xRegistry = Path.GetTempPath() + "xRegistry.sys";
        public static string PathLocation1 = "/dev_flash2/etc/xRegistry.sys";

        string ps3IP;
        string PSID;
        string IDPS;
        string CPU;
        string RSX;
        string FIRMWARE;
        string TYPE_CONSOLE;

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

        public Form1()
        {
            InitializeComponent();
        }

        #region "Form Load"

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GunaPanelTop.MouseDown += this.xMouseDown; //For Move Form
            this.GunaPanelTop.MouseMove += this.xMouseMove; //For Move Form
            this.GunaPanelTop.MouseDown += this.xMouseDown; //For Move Form
            this.GunaPanelTop.MouseMove += this.xMouseMove; //For Move Form
        }

        #endregion

        #region "Connect + change API Code"

        void ChangeAPI()
        {
            if (gunaRadioButton1.Checked)
            {
                Offsets.curAPI = "tm";
                Offsets.labelTxtCT = "Select a Target Number(Default = 1)";
                Offsets.listCT.Clear();
                for (int i = 1; i < 10; i++)
                    Offsets.listCT.Add("Target " + i.ToString());
            }
            else if (gunaRadioButton2.Checked || gunaRadioButton3.Checked)
            {
                Offsets.curAPI = "cc";
                Offsets.labelTxtCT = "Select an IP";
                Offsets.listCT.Clear();
                if (Offsets.cList.Count != 0)
                {
                    foreach (CCAPI.ConsoleInfo item in Offsets.cList)
                        Offsets.listCT.Add(item.Name + " : " + item.Ip);
                }
                else
                {
                    Offsets.textBoxCT = "192.168.1.1";
                    Offsets.labelTxtCT = "No IPs Found - Enter IP Manually";
                }
            }
            gunaRadioButton1.Enabled = false;
            gunaRadioButton2.Enabled = false;
            gunaRadioButton3.Enabled = false;
            Offsets.apiForm_.ShowDialog();
            gunaRadioButton1.Enabled = true;
            gunaRadioButton2.Enabled = true;
            gunaRadioButton3.Enabled = true;


            if (gunaRadioButton1.Checked)
                Offsets.targetStatus = "Target Number: " + Offsets.targetIndex;
            else if (gunaRadioButton2.Checked)
                Offsets.ccapiipStatus = "PS3 IP: " + Offsets.ps3IP;

            label3.Text = Offsets.targetStatus + " " + Offsets.ccapiipStatus;
        }

        private void doConnect()
        {
            string[] AVATAR = { "https://pbs.twimg.com/media/Cw6mWuqWIAAQx_5.jpg", "https://imgcloud.pw/images/2019/06/19/yvumaobmgfeb376003c61ff3ba9d.jpg", "https://i.imgur.com/7PdJUhd.jpg", "https://i.imgur.com/kRzV4hu.png" };
            string[] Emojis = { "🍁", "🌲", "☄️", "⚡️", "❄️", "🔥", "🌪", "🌸", "🌹", "🍣", "🧃", "🌌", "💊", "💉", "🩸", "🔪", "🧸", "🎀", "❤️", "🔰", "🩹" };
            string RandomAvatar = AVATAR[new Random().Next(0, AVATAR.Length)];
            string RandomEmojis = Emojis[new Random().Next(0, Emojis.Length)];

            bool canConnect = false;

            bool canTry2Connect = false;
            if (gunaRadioButton1.Checked)
            {
                TYPE_CONSOLE = "CFW";
                if (Offsets.targetIndex != -1)
                    canTry2Connect = true;
            }
            else if (gunaRadioButton2.Checked)
            {
                TYPE_CONSOLE = "CFW";
                if (Offsets.ps3IP != "-1")
                    canTry2Connect = true;
            }
            else if (gunaRadioButton3.Checked)
            {
                TYPE_CONSOLE = "HEN";
                if (Offsets.ps3IP != "-1")
                    canTry2Connect = true;
            }
            if (canTry2Connect)
            {
                try
                {
                    if (gunaRadioButton1.Checked) { PS3.ChangeAPI(SelectAPI.TargetManager); canConnect = PS3.ConnectTarget(Offsets.targetIndex - 1); }
                    else if (gunaRadioButton2.Checked) { PS3.ChangeAPI(SelectAPI.ControlConsole); canConnect = PS3.ConnectTarget(Offsets.ps3IP); }
                    else if (gunaRadioButton3.Checked) { PS3.ChangeAPI(SelectAPI.PS3Manager); canConnect = PS3.ConnectTarget(Offsets.ps3IP, true); }

                    if (canConnect == true)
                    {
                        label3.Text = "True";
                        try
                        {
                            if (PS3.AttachProcess())
                            {
                                label3.Location = new Point(258, 9);
                                label3.Text = "Connected!";
                                DefaultName = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT

                                if (DefaultName == "")
                                {
                                    DefaultName = PS3.Extension.ReadString(0x3000ABA4); //name of profils player
                                }

                                PS3.CCAPI.Notify(CCAPI.NotifyIcon.INFO, "Welcome to DownCraft RTM");

                                label5.Text = DefaultName;
                                label14.Text = PS3.CCAPI.GetTemperatureRSX();
                                label17.Text = PS3.CCAPI.GetTemperatureCELL();
                                label19.Text = PS3.CCAPI.GetFirmwareType();

                                RSX = PS3.CCAPI.GetTemperatureRSX();
                                CPU = PS3.CCAPI.GetTemperatureCELL();
                                FIRMWARE = PS3.CCAPI.GetFirmwareType();

                                Offsets.Connected = true;
                            }
                            else
                            {
                                label3.Text = "Cannot connect";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            label3.Text = "Impossible";
                        }
                    }
                    else
                    {
                        label3.Text = "Cannot connect";
                    }
                }
                catch
                {
                    label3.Text = "Impossible";
                }
            }
            else
            {
                if (gunaRadioButton1.Checked)
                    MessageBox.Show("Please click the 'Change' button and select a target number to connect with.\n\nNOTE: Target 1 is default.", "Change Target Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (gunaRadioButton2.Checked || gunaRadioButton3.Checked)
                    MessageBox.Show("Please click the 'Change' button and select an IP to connect with.", "Change IP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) //Button Connect
        {
            SoundPlayer audio = new SoundPlayer(DownCraft.Properties.Resources.click);
            audio.Play();
            ChangeAPI();
            doConnect();

            try
            {
                label5.Text = FUNCTIONS.DefaultName.ToString(); //Get the PSN Name
            }
            catch (Exception ex)
            {

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(DownCraft.Properties.Resources.click);
            audio.Play();
        }

        #endregion

        #region "Options + Mods"

        private void guna2Button27_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Images File (*.png)|*.png";
            openFileDialog1.FileName = "Background Title DownCraft";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            GunaPanelTop.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, can't found or add background images !");
                }
            }
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                GunaPanelTop.BackColor = colorDlg.Color;
                guna2GroupBox19.CustomBorderColor = colorDlg.Color;
                guna2Button1.FillColor = colorDlg.Color;
                guna2Button2.FillColor = colorDlg.Color;
                guna2Button26.FillColor = colorDlg.Color;
                guna2GroupBox38.CustomBorderColor = colorDlg.Color;
                guna2GroupBox1.CustomBorderColor = colorDlg.Color;
                guna2GroupBox2.CustomBorderColor = colorDlg.Color;
                guna2GroupBox3.CustomBorderColor = colorDlg.Color;
                guna2GroupBox8.CustomBorderColor = colorDlg.Color;
                guna2GroupBox9.CustomBorderColor = colorDlg.Color;
                guna2GroupBox31.CustomBorderColor = colorDlg.Color;
                guna2GroupBox7.CustomBorderColor = colorDlg.Color;
                guna2GroupBox4.CustomBorderColor = colorDlg.Color;
                guna2GroupBox20.CustomBorderColor = colorDlg.Color;
                guna2GroupBox5.CustomBorderColor = colorDlg.Color;
                guna2GroupBox28.CustomBorderColor = colorDlg.Color;
                guna2GroupBox35.CustomBorderColor = colorDlg.Color;
                guna2GroupBox37.CustomBorderColor = colorDlg.Color;
                guna2GroupBox36.CustomBorderColor = colorDlg.Color;
                guna2GroupBox10.CustomBorderColor = colorDlg.Color;
                guna2GroupBox11.CustomBorderColor = colorDlg.Color;
                guna2GroupBox12.CustomBorderColor = colorDlg.Color;
                guna2GroupBox13.CustomBorderColor = colorDlg.Color;
                guna2GroupBox14.CustomBorderColor = colorDlg.Color;
                guna2GroupBox15.CustomBorderColor = colorDlg.Color;
                guna2GroupBox16.CustomBorderColor = colorDlg.Color;
                guna2GroupBox17.CustomBorderColor = colorDlg.Color;
                guna2GroupBox21.CustomBorderColor = colorDlg.Color;
                guna2GroupBox22.CustomBorderColor = colorDlg.Color;
                guna2GroupBox23.CustomBorderColor = colorDlg.Color;
                guna2GroupBox24.CustomBorderColor = colorDlg.Color;
                guna2GroupBox30.CustomBorderColor = colorDlg.Color;
                guna2GroupBox33.CustomBorderColor = colorDlg.Color;
                guna2GroupBox34.CustomBorderColor = colorDlg.Color;
                guna2GroupBox25.CustomBorderColor = colorDlg.Color;
                guna2GroupBox26.CustomBorderColor = colorDlg.Color;
                guna2GroupBox27.CustomBorderColor = colorDlg.Color;
                guna2GroupBox29.CustomBorderColor = colorDlg.Color;
                guna2GroupBox32.CustomBorderColor = colorDlg.Color;
            }
        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DownCraft RTM Premium\nUpdate V5\n\nWhat is DownCraft?\nDownCraft is a RTM (Real-Time Modding) for Minecraft PS3, it works on the last version, 1.84. DownCraft was created in 2018 on the TU1.71 update for Minecraft PS3.\n\nAll credits go to NELUxP, MayhemModding, DublinModz, EternalModz, KKC Kobra, LordVirus, OhItsDiiTz, Eddit Mac, Misakiii, He6po, and Magethsi.\n\nJoin our Discord servers to stay updated on what's new!\n\nA big thanks to you for still using DownCraft after about 3 - 4 years now <3\n\n-  ̷M̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷i̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷s̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷a̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷k̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷i̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷   EternalModz", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                OFFSETS.GOD_MODE(true);
            }
            else
            {
                OFFSETS.GOD_MODE(false);
            }
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox2.Checked)
            {
                OFFSETS.DEMI_GOD(true);
            }
            else
            {
                OFFSETS.DEMI_GOD(false);
            }
        }

        private void guna2CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox3.Checked)
            {
                OFFSETS.GOD_MODE_V3(true);
            }
            else
            {
                OFFSETS.GOD_MODE_V3(false);
            }
        }

        private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox4.Checked)
            {
                OFFSETS.INSTANT_DAMAGE(true);
            }
            else
            {
                OFFSETS.INSTANT_DAMAGE(false);
            }
        }

        private void guna2CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox5.Checked)
            {
                OFFSETS.INSTANT_KILL(true);
            }
            else
            {
                OFFSETS.INSTANT_KILL(false);
            }
        }

        private void guna2CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox6.Checked)
            {
                OFFSETS.INSTANT_KILL_ALL(true);
            }
            else
            {
                OFFSETS.INSTANT_KILL_ALL(false);
            }
        }

        private void guna2CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox7.Checked)
            {
                OFFSETS.BYPASS_KILL_ALL(true);
            }
            else
            {
                OFFSETS.BYPASS_KILL_ALL(false);
            }
        }

        private void guna2CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox8.Checked)
            {
                OFFSETS.INSTANT_KILL_IN_FIRE(true);
            }
            else
            {
                OFFSETS.INSTANT_KILL_IN_FIRE(false);
            }
        }

        private void guna2CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox9.Checked)
            {
                OFFSETS.NO_DAMAGE_HIT(true);
            }
            else
            {
                OFFSETS.NO_DAMAGE_HIT(false);
            }
        }

        private void guna2CheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox10.Checked)
            {
                OFFSETS.KNOCKBACK(true);
            }
            else
            {
                OFFSETS.KNOCKBACK(false);
            }
        }

        private void guna2CheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox11.Checked)
            {
                OFFSETS.ANTI_KNOCKBACK(true);
            }
            else
            {
                OFFSETS.ANTI_KNOCKBACK(false);
            }
        }

        private void guna2CheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox12.Checked)
            {
                OFFSETS.REVERSE_KNOCKBACK(true);
            }
            else
            {
                OFFSETS.REVERSE_KNOCKBACK(false);
            }
        }

        private void guna2CheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox13.Checked)
            {
                OFFSETS.AUTO_SAVE(true);
            }
            else
            {
                OFFSETS.AUTO_SAVE(false);
            }
        }

        private void guna2CheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox14.Checked)
            {
                OFFSETS.GUN_ITEMS(true);
            }
            else
            {
                OFFSETS.GUN_ITEMS(false);
            }
        }

        private void guna2CheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox15.Checked)
            {
                OFFSETS.MAX_XP_LEVEL(true);
            }
            else
            {
                OFFSETS.MAX_XP_LEVEL(false);
            }
        }

        private void guna2CheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox16.Checked)
            {
                OFFSETS.REMOVE_LEVEL_XP(true);
            }
            else
            {
                OFFSETS.REMOVE_LEVEL_XP(false);
            }
        }

        private void guna2CheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox17.Checked)
            {
                OFFSETS.WATER_JUMP(true);
            }
            else
            {
                OFFSETS.WATER_JUMP(false);
            }
        }

        private void guna2CheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox18.Checked)
            {
                OFFSETS.DRIFT_BOAT(true);
            }
            else
            {
                OFFSETS.DRIFT_BOAT(false);
            }
        }

        private void guna2CheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox19.Checked)
            {
                OFFSETS.ARROWS_BLOCKS_ITEMS(true);
            }
            else
            {
                OFFSETS.ARROWS_BLOCKS_ITEMS(false);
            }
        }

        private void guna2CheckBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox20.Checked)
            {
                OFFSETS.ARROWS_REMOVE(true);
            }
            else
            {
                OFFSETS.ARROWS_REMOVE(false);
            }
        }

        private void guna2CheckBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox21.Checked)
            {
                OFFSETS.POTIONS_GRAVITY_FLY(true);
            }
            else
            {
                OFFSETS.POTIONS_GRAVITY_FLY(false);
            }
        }

        private void guna2CheckBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox22.Checked)
            {
                OFFSETS.POTIONS_NO_GRAVITY(true);
            }
            else
            {
                OFFSETS.POTIONS_NO_GRAVITY(false);
            }
        }

        private void guna2CheckBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox23.Checked)
            {
                OFFSETS.INFINITE_PICK_UP(true);
            }
            else
            {
                OFFSETS.INFINITE_PICK_UP(false);
            }
        }

        private void guna2CheckBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox24.Checked)
            {
                OFFSETS.MAX_PICKUP_ITEMS(true);
            }
            else
            {
                OFFSETS.MAX_PICKUP_ITEMS(false);
            }
        }

        private void guna2CheckBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox25.Checked)
            {
                OFFSETS.GLITCHED_DEAD_MOBS(true);
            }
            else
            {
                OFFSETS.GLITCHED_DEAD_MOBS(false);
            }
        }

        private void guna2CheckBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox26.Checked)
            {
                OFFSETS.DISABLE_MOBS(true);
            }
            else
            {
                OFFSETS.DISABLE_MOBS(false);
            }
        }

        private void guna2CheckBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox27.Checked)
            {
                OFFSETS.WOLF_TURN_HEAD(true);
            }
            else
            {
                OFFSETS.WOLF_TURN_HEAD(false);
            }
        }

        private void guna2CheckBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox28.Checked)
            {
                OFFSETS.WOLF_REMOVE_WATER(true);
            }
            else
            {
                OFFSETS.WOLF_REMOVE_WATER(false);
            }
        }

        private void guna2CheckBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox29.Checked)
            {
                OFFSETS.REMOVE_FALL_DAMAGE(true);
            }
            else
            {
                OFFSETS.REMOVE_FALL_DAMAGE(false);
            }
        }

        private void guna2CheckBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox30.Checked)
            {
                OFFSETS.INFINITE_BLOCK(true);
            }
            else
            {
                OFFSETS.INFINITE_BLOCK(false);
            }
        }

        private void guna2CheckBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox31.Checked)
            {
                OFFSETS.LOBBY_MESSAGES(true);
            }
            else
            {
                OFFSETS.LOBBY_MESSAGES(false);
            }
        }

        private void guna2CheckBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox32.Checked)
            {
                OFFSETS.BURN_IN_WATER(true);
            }
            else
            {
                OFFSETS.BURN_IN_WATER(false);
            }
        }

        private void guna2CheckBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox33.Checked)
            {
                OFFSETS.FIRE_INSTANT_REMOVED(true);
            }
            else
            {
                OFFSETS.FIRE_INSTANT_REMOVED(false);
            }
        }

        private void guna2CheckBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox34.Checked)
            {
                OFFSETS.CREATIVE_SLOT(true);
            }
            else
            {
                OFFSETS.CREATIVE_SLOT(false);
            }
        }

        private void guna2CheckBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox35.Checked)
            {
                OFFSETS.SURVIVAL_SLOT(true);
            }
            else
            {
                OFFSETS.SURVIVAL_SLOT(false);
            }
        }

        private void guna2CheckBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox36.Checked)
            {
                OFFSETS.AUTO_KILL_MOBS_SPAWNED(true);
            }
            else
            {
                OFFSETS.AUTO_KILL_MOBS_SPAWNED(false);
            }
        }

        private void guna2CheckBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox37.Checked)
            {
                OFFSETS.STOP_FALL_GRAVITY(true);
            }
            else
            {
                OFFSETS.STOP_FALL_GRAVITY(false);
            }
        }

        private void guna2CheckBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox38.Checked)
            {
                OFFSETS.NO_DELAY_HIT_DAMAGE(true);
            }
            else
            {
                OFFSETS.NO_DELAY_HIT_DAMAGE(false);
            }
        }

        private void guna2CheckBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox39.Checked)
            {
                OFFSETS.BYPASS_MAX_ITEMS(true);
            }
            else
            {
                OFFSETS.BYPASS_MAX_ITEMS(false);
            }
        }

        private void guna2CheckBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox40.Checked)
            {
                OFFSETS.INFINITE_FOOD(true);
            }
            else
            {
                OFFSETS.INFINITE_FOOD(false);
            }
        }

        private void guna2CheckBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox41.Checked)
            {
                OFFSETS.MOBS_IGNORE_ME(true);
            }
            else
            {
                OFFSETS.MOBS_IGNORE_ME(false);
            }
        }

        private void guna2CheckBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox42.Checked)
            {
                OFFSETS.LEAD_CANT_BE_REMOVED(true);
            }
            else
            {
                OFFSETS.LEAD_CANT_BE_REMOVED(false);
            }
        }

        private void guna2CheckBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox43.Checked)
            {
                OFFSETS.DISABLE_PORTALS(true);
            }
            else
            {
                OFFSETS.DISABLE_PORTALS(false);
            }
        }

        private void guna2CheckBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox44.Checked)
            {
                OFFSETS.AUTO_KILL_PLAYERS(true);
            }
            else
            {
                OFFSETS.AUTO_KILL_PLAYERS(false);
            }
        }

        private void guna2CheckBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox45.Checked)
            {
                OFFSETS.FREEZE_ALL_ENTITY(true);
            }
            else
            {
                OFFSETS.FREEZE_ALL_ENTITY(false);
            }
        }

        private void guna2CheckBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox46.Checked)
            {
                OFFSETS.DETECT_IF_PLAYERS_HAS_BEEN_ALREADY_DAMAGED(true);
            }
            else
            {
                OFFSETS.DETECT_IF_PLAYERS_HAS_BEEN_ALREADY_DAMAGED(false);
            }
        }

        private void guna2CheckBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox47.Checked)
            {
                OFFSETS.CANT_GRAB_ITEMS(true);
            }
            else
            {
                OFFSETS.CANT_GRAB_ITEMS(false);
            }
        }

        private void guna2CheckBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox48.Checked)
            {
                OFFSETS.CANT_GRAB_ITEMS_V2(true);
            }
            else
            {
                OFFSETS.CANT_GRAB_ITEMS_V2(false);
            }
        }

        private void guna2CheckBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox49.Checked)
            {
                OFFSETS.FISHING_ROD_CANT_BE_REMOVED(true);
            }
            else
            {
                OFFSETS.FISHING_ROD_CANT_BE_REMOVED(false);
            }
        }

        private void guna2CheckBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox50.Checked)
            {
                OFFSETS.NETHER_PORTAL_WITH_STONE(true);
            }
            else
            {
                OFFSETS.NETHER_PORTAL_WITH_STONE(false);
            }
        }

        private void guna2CheckBox51_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox51.Checked)
            {
                OFFSETS.ENDERMAN_AND_CHORUS_FRUIT_CANT_BE_TELEPORTED(true);
            }
            else
            {
                OFFSETS.ENDERMAN_AND_CHORUS_FRUIT_CANT_BE_TELEPORTED(false);
            }
        }

        private void guna2CheckBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox52.Checked)
            {
                OFFSETS.TOTEM_FLOAT_HEALTH(true);
            }
            else
            {
                OFFSETS.TOTEM_FLOAT_HEALTH(false);
            }
        }

        private void guna2CheckBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox53.Checked)
            {
                OFFSETS.FISHING_ROD_NO_GRAVITY(true);
            }
            else
            {
                OFFSETS.FISHING_ROD_NO_GRAVITY(false);
            }
        }

        private void guna2CheckBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox54.Checked)
            {
                OFFSETS.DISABLE_TOTEM_OF_UNDYING(true);
            }
            else
            {
                OFFSETS.DISABLE_TOTEM_OF_UNDYING(false);
            }
        }

        private void guna2CheckBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox55.Checked)
            {
                OFFSETS.IGNIORING_PRESSURE_PLATE(true);
            }
            else
            {
                OFFSETS.IGNIORING_PRESSURE_PLATE(false);
            }
        }

        private void guna2CheckBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox56.Checked)
            {
                OFFSETS.DEAD_PLAYERS_REMAINS_STANDING(true);
            }
            else
            {
                OFFSETS.DEAD_PLAYERS_REMAINS_STANDING(false);
            }
        }

        private void guna2CheckBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox57.Checked)
            {
                OFFSETS.DISABLE_KILLED_OUT_OF_WORLD(true);
            }
            else
            {
                OFFSETS.DISABLE_KILLED_OUT_OF_WORLD(false);
            }
        }

        private void guna2CheckBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox58.Checked)
            {
                OFFSETS.KILL_DONT_DISAPPEAR_ENTITY(true);
            }
            else
            {
                OFFSETS.KILL_DONT_DISAPPEAR_ENTITY(false);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.guna2ComboBox1.SelectedIndex == 0)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("0");
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("1");
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("2");
            }
            else if (guna2ComboBox1.SelectedIndex == 3)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("3");
            }
            else if (guna2ComboBox1.SelectedIndex == 4)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("4");
            }
            else if (guna2ComboBox1.SelectedIndex == 5)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("5");
            }
            else if (guna2ComboBox1.SelectedIndex == 6)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("6");
            }
            else if (guna2ComboBox1.SelectedIndex == 7)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("7");
            }
            else if (guna2ComboBox1.SelectedIndex == 8)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("8");
            }
            else if (guna2ComboBox1.SelectedIndex == 9)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("9");
            }
            else if (guna2ComboBox1.SelectedIndex == 10)
            {
                OFFSETS.ENCHANTEMENT_LEVEL("10");
            }
        }

        private void guna2CheckBox60_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox60.Checked)
            {
                OFFSETS.ALLOW_ALL_ITEMS_ON_HEAD(true);
            }
            else
            {
                OFFSETS.ALLOW_ALL_ITEMS_ON_HEAD(false);
            }
        }

        private void guna2CheckBox61_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox61.Checked)
            {
                OFFSETS.BOAT_STOP_WORKING(true);
            }
            else
            {
                OFFSETS.BOAT_STOP_WORKING(false);
            }
        }

        private void guna2CheckBox62_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox62.Checked)
            {
                OFFSETS.MINE_IN_ADVENTURE(true);
            }
            else
            {
                OFFSETS.MINE_IN_ADVENTURE(false);
            }
        }

        private void guna2CheckBox63_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox63.Checked)
            {
                OFFSETS.NO_WEB_HAX(true);
            }
            else
            {
                OFFSETS.NO_WEB_HAX(false);
            }
        }

        private void guna2CheckBox64_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox64.Checked)
            {
                OFFSETS.ENTITY_GOD_MODE(true);
            }
            else
            {
                OFFSETS.ENTITY_GOD_MODE(false);
            }
        }

        private void guna2CheckBox65_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox65.Checked)
            {
                OFFSETS.SPECTRAL_ARROWS_WITH_BOW(true);
            }
            else
            {
                OFFSETS.SPECTRAL_ARROWS_WITH_BOW(false);
            }
        }

        private void guna2CheckBox66_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox66.Checked)
            {
                OFFSETS.INFINITE_OXYGEN_IN_WATER(true);
            }
            else
            {
                OFFSETS.INFINITE_OXYGEN_IN_WATER(false);
            }
        }

        private void guna2CheckBox67_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox67.Checked)
            {
                OFFSETS.GET_SPECTATOR_GAMEMODE(true);
            }
            else
            {
                OFFSETS.GET_SPECTATOR_GAMEMODE(false);
            }
        }

        private void guna2CheckBox68_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox68.Checked)
            {
                OFFSETS.AUTO_REGENERATE_HEALTH(true);
            }
            else
            {
                OFFSETS.AUTO_REGENERATE_HEALTH(false);
            }
        }

        private void guna2CheckBox69_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox69.Checked)
            {
                OFFSETS.GAME_GAMEMODE_LOCKED(true);
            }
            else
            {
                OFFSETS.GAME_GAMEMODE_LOCKED(false);
            }
        }

        private void guna2CheckBox70_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox70.Checked)
            {
                OFFSETS.DISABLE_CHANGING_WEATHER(true);
            }
            else
            {
                OFFSETS.DISABLE_CHANGING_WEATHER(false);
            }
        }

        private void guna2CheckBox71_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox71.Checked)
            {
                OFFSETS.FAST_BOW(true);
            }
            else
            {
                OFFSETS.FAST_BOW(false);
            }
        }

        private void guna2CheckBox72_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox72.Checked)
            {
                OFFSETS.STOP_BOW(true);
            }
            else
            {
                OFFSETS.STOP_BOW(false);
            }
        }

        private void guna2CheckBox73_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox73.Checked)
            {
                OFFSETS.ARROWS_CHANGE_DIRECTIONS(true);
            }
            else
            {
                OFFSETS.ARROWS_CHANGE_DIRECTIONS(false);
            }
        }

        private void guna2CheckBox74_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox74.Checked)
            {
                OFFSETS.GOD_MODE_FOR_MYSELF();
            }
            else
            {

            }
        }

        private void guna2CheckBox75_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox75.Checked)
            {
                OFFSETS.DISABLE_RESPAWN(true);
            }
            else
            {
                OFFSETS.DISABLE_RESPAWN(false);
            }
        }

        private void guna2CheckBox76_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox76.Checked)
            {
                OFFSETS.CREATIVE_SLOT_V2(true);
            }
            else
            {
                OFFSETS.CREATIVE_SLOT_V2(false);
            }
        }

        private void guna2CheckBox77_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox77.Checked)
            {
                OFFSETS.DISABLE_3RD_PERSON_VIEW(true);
            }
            else
            {
                OFFSETS.DISABLE_3RD_PERSON_VIEW(false);
            }
        }


        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.guna2ComboBox2.SelectedIndex == 0)
            {
                OFFSETS.DRAW_MODE("0");
            }
            else if (guna2ComboBox2.SelectedIndex == 1)
            {
                OFFSETS.DRAW_MODE("1");
            }
        }

        private void guna2CheckBox78_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox78.Checked)
            {
                OFFSETS.TNT_CANT_DESTROY_BLOCKS(true);
            }
            else
            {
                OFFSETS.TNT_CANT_DESTROY_BLOCKS(false);
            }
        }

        private void guna2CheckBox79_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox79.Checked)
            {
                OFFSETS.TNT_CANT_EXPLODE_BLOCKS(true);
            }
            else
            {
                OFFSETS.TNT_CANT_EXPLODE_BLOCKS(false);
            }
        }

        private void guna2CheckBox80_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox80.Checked)
            {
                OFFSETS.TNT_SMALL_PARTICLES(true);
            }
            else
            {
                OFFSETS.TNT_SMALL_PARTICLES(false);
            }
        }

        private void guna2CheckBox81_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox81.Checked)
            {
                OFFSETS.TNT_MAKE_MORE_PARTICLES(true);
            }
            else
            {
                OFFSETS.TNT_MAKE_MORE_PARTICLES(false);
            }
        }

        private void guna2CheckBox82_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox82.Checked)
            {
                OFFSETS.TNT_FLY_IN_AIR_WHEN_ENABLED(true);
            }
            else
            {
                OFFSETS.TNT_FLY_IN_AIR_WHEN_ENABLED(false);
            }
        }

        private void guna2CheckBox83_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox83.Checked)
            {
                OFFSETS.TNT_GO_DOWN(true);
            }
            else
            {
                OFFSETS.TNT_GO_DOWN(false);
            }
        }

        private void guna2CheckBox84_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox84.Checked)
            {
                OFFSETS.TNT_EXPLODE_SOUND_OFF(true);
            }
            else
            {
                OFFSETS.TNT_EXPLODE_SOUND_OFF(false);
            }
        }

        private void guna2CheckBox85_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox85.Checked)
            {
                OFFSETS.TNT_INSTANT_EXPLODE(true);
            }
            else
            {
                OFFSETS.TNT_INSTANT_EXPLODE(false);
            }
        }

        private void guna2CheckBox86_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox86.Checked)
            {
                OFFSETS.TNT_EXPLODE_RADIUS_SMALL(true);
            }
            else
            {
                OFFSETS.TNT_EXPLODE_RADIUS_SMALL(false);
            }
        }

        private void guna2CheckBox87_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox87.Checked)
            {
                OFFSETS.MAKE_CREEPER_BIG(true);
            }
            else
            {
                OFFSETS.MAKE_CREEPER_BIG(false);
            }
        }

        private void guna2CheckBox88_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox88.Checked)
            {
                OFFSETS.CREEPER_SMALL_EXPLOSION(true);
            }
            else
            {
                OFFSETS.CREEPER_SMALL_EXPLOSION(false);
            }
        }

        private void guna2CheckBox89_CheckedChanged(object sender, EventArgs e)
        {

            if (guna2CheckBox89.Checked)
            {
                OFFSETS.CREEPER_EXPLODE_MEDIUM(true);
            }
            else
            {
                OFFSETS.CREEPER_EXPLODE_MEDIUM(false);
            }
        }

        private void guna2CheckBox90_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox90.Checked)
            {
                OFFSETS.CREEPER_MEDIUM_EXPLOSION(true);
            }
            else
            {
                OFFSETS.CREEPER_MEDIUM_EXPLOSION(false);
            }
        }

        private void guna2CheckBox91_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox91.Checked)
            {
                OFFSETS.CREEPER_EXTREM_EXPLOSION(true);
            }
            else
            {
                OFFSETS.CREEPER_EXTREM_EXPLOSION(false);
            }
        }

        private void guna2CheckBox92_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox92.Checked)
            {
                OFFSETS.CREEPER_INSTANT_EXPLODE(true);
            }
            else
            {
                OFFSETS.CREEPER_INSTANT_EXPLODE(false);
            }
        }

        private void guna2CheckBox93_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox93.Checked)
            {
                OFFSETS.FIRE_CREEPER_EXPLODE(true);
            }
            else
            {
                OFFSETS.FIRE_CREEPER_EXPLODE(false);
            }
        }

        private void guna2CheckBox94_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox94.Checked)
            {
                OFFSETS.CREEPER_CANT_DESTROY_BLOCKS(true);
            }
            else
            {
                OFFSETS.CREEPER_CANT_DESTROY_BLOCKS(false);
            }
        }

        private void guna2CheckBox95_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox95.Checked)
            {
                OFFSETS.CREEPER_CHARGED_DISABLED(true);
            }
            else
            {
                OFFSETS.CREEPER_CHARGED_DISABLED(false);
            }
        }

        private void guna2CheckBox96_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox96.Checked)
            {
                OFFSETS.DARK_STORM(true);
            }
            else
            {
                OFFSETS.DARK_STORM(false);
            }
        }

        private void guna2CheckBox97_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox97.Checked)
            {
                OFFSETS.RAINBOW_STORM(true);
            }
            else
            {
                OFFSETS.RAINBOW_STORM(false);
            }
        }

        private void guna2CheckBox98_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox98.Checked)
            {
                OFFSETS.RAIN_TO_SNOW(true);
            }
            else
            {
                OFFSETS.RAIN_TO_SNOW(false);
            }
        }

        private void guna2CheckBox99_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox99.Checked)
            {
                OFFSETS.SKY_TO_RAINBOW_WITH_SNOW(true);
            }
            else
            {
                OFFSETS.SKY_TO_RAINBOW_WITH_SNOW(false);
            }
        }

        private void guna2CheckBox100_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox100.Checked)
            {
                OFFSETS.SMALL_RAIN(true);
            }
            else
            {
                OFFSETS.SMALL_RAIN(false);
            }
        }

        private void guna2CheckBox101_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox101.Checked)
            {
                OFFSETS.FLASH_SKY_WITH_PARTICLES(true);
            }
            else
            {
                OFFSETS.FLASH_SKY_WITH_PARTICLES(false);
            }
        }

        private void guna2CheckBox102_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox102.Checked)
            {
                OFFSETS.LIGHTING_BOLT(true);
            }
            else
            {
                OFFSETS.LIGHTING_BOLT(false);
            }
        }

        private void guna2CheckBox103_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox103.Checked)
            {
                OFFSETS.LIGHTNING_BOLT_V2(true);
            }
            else
            {
                OFFSETS.LIGHTNING_BOLT_V2(false);
            }
        }

        private void guna2CheckBox104_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox104.Checked)
            {
                OFFSETS.BLINK_SKY(true);
            }
            else
            {
                OFFSETS.BLINK_SKY(false);
            }
        }

        private void guna2CheckBox105_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox105.Checked)
            {
                OFFSETS.WEATHER_RAIN(true);
            }
            else
            {
                OFFSETS.WEATHER_RAIN(false);
            }
        }

        private void guna2CheckBox106_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox106.Checked)
            {
                OFFSETS.ALL_PLAYERS_FAST_MINE(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_FAST_MINE(false);
            }
        }

        private void guna2CheckBox107_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox107.Checked)
            {
                OFFSETS.ALL_PLAYERS_FAST_MINE_V2(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_FAST_MINE_V2(false);
            }
        }

        private void guna2CheckBox108_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox108.Checked)
            {
                OFFSETS.ALL_PLAYERS_FAST_SPEED(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_FAST_SPEED(false);
            }
        }

        private void guna2CheckBox109_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox109.Checked)
            {
                OFFSETS.ALL_PLAYERS_FAST_SPEED_V2(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_FAST_SPEED_V2(false);
            }
        }

        private void guna2CheckBox110_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox110.Checked)
            {
                OFFSETS.ALL_PLAYERS_CANT_RUN(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_CANT_RUN(false);
            }
        }

        private void guna2CheckBox111_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox111.Checked)
            {
                OFFSETS.ALL_PLAYERS_SPAM_ZOOM(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_SPAM_ZOOM(false);
            }
        }

        private void guna2CheckBox112_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox112.Checked)
            {
                OFFSETS.CORRUPT_WORLD(true);
            }
            else
            {
                OFFSETS.CORRUPT_WORLD(false);
            }
        }

        private void guna2CheckBox113_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox113.Checked)
            {
                OFFSETS.ALL_PLAYERS_TAKE_DAMAGE(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_TAKE_DAMAGE(false);
            }
        }

        private void guna2CheckBox114_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox114.Checked)
            {
                OFFSETS.ALL_PLAYERS_LEFT_HAND(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_LEFT_HAND(false);
            }
        }

        private void guna2CheckBox115_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox115.Checked)
            {
                OFFSETS.ALL_PLAYERS_SUFFOCATE(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_SUFFOCATE(false);
            }
        }

        private void guna2CheckBox116_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox116.Checked)
            {
                OFFSETS.ALL_PLAYERS_SET_IN_FIRE(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_SET_IN_FIRE(false);
            }
        }

        private void guna2CheckBox117_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox117.Checked)
            {
                OFFSETS.ALL_PLAYERS_FREEZE_PS3(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_FREEZE_PS3(false);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //Get Infos Last Players Joined on the world
            OFFSETS.LAST_PLAYERS_JOINED_THE_WORLD();


            try
            {
                var request = WebRequest.Create(OFFSETS.LastPlayersAvatar);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    guna2PictureBox3.Image = Bitmap.FromStream(stream);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error, can't get the last players !", "DownCraft RTM", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            label7.Text = OFFSETS.LastPlayersJoinedPSN; //Get the PSN Name
            label9.Text = OFFSETS.LastPlayersRegion; //Get the region
        }

        private void guna2CheckBox118_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox118.Checked)
            {
                OFFSETS.SUPER_SPEED(true);
            }
            else
            {
                OFFSETS.SUPER_SPEED(false);
            }
        }

        private void guna2CheckBox119_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox119.Checked)
            {
                OFFSETS.NEW_SUPER_SPEED(true);
            }
            else
            {
                OFFSETS.NEW_SUPER_SPEED(false);
            }
        }

        private void guna2CheckBox120_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox120.Checked)
            {
                OFFSETS.SUPER_SPEED_V3(true);
            }
            else
            {
                OFFSETS.SUPER_SPEED_V3(false);
            }
        }

        private void guna2CheckBox121_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox121.Checked)
            {
                OFFSETS.SUPER_SPEED_V4(true);
            }
            else
            {
                OFFSETS.SUPER_SPEED_V4(false);
            }
        }

        private void guna2CheckBox122_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox122.Checked)
            {
                OFFSETS.SUPER_SPEED_V5(true);
            }
            else
            {
                OFFSETS.SUPER_SPEED_V4(false);
            }
        }

        private void guna2CheckBox123_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox123.Checked)
            {
                OFFSETS.SUPER_SPEED_V6(true);
            }
            else
            {
                OFFSETS.SUPER_SPEED_V6(false);
            }
        }

        private void guna2CheckBox124_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox124.Checked)
            {
                OFFSETS.SUPER_SPEED_V7(true);
            }
            else
            {
                OFFSETS.SUPER_SPEED_V7(false);
            }
        }

        private void guna2CheckBox125_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox125.Checked)
            {
                OFFSETS.SUPER_SPEED_LEGIT(true);
            }
            else
            {
                OFFSETS.SUPER_SPEED_LEGIT(false);
            }
        }

        private void guna2CheckBox126_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox126.Checked)
            {
                OFFSETS.MULTI_JUMP(true);
            }
            else
            {
                OFFSETS.MULTI_JUMP(false);
            }
        }

        private void guna2CheckBox127_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox127.Checked)
            {
                OFFSETS.JUMP_FOR_BUILD(true);
            }
            else
            {
                OFFSETS.JUMP_FOR_BUILD(false);
            }
        }

        private void guna2CheckBox128_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox128.Checked)
            {
                OFFSETS.INSTANT_JUMP_IN_SKY(true);
            }
            else
            {
                OFFSETS.INSTANT_JUMP_IN_SKY(false);
            }
        }

        private void guna2CheckBox129_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox129.Checked)
            {
                OFFSETS.SUPER_JUMP(true);
            }
            else
            {
                OFFSETS.SUPER_JUMP(false);
            }
        }

        private void guna2CheckBox130_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox130.Checked)
            {
                OFFSETS.SUPER_JUMP_V2(true);
            }
            else
            {
                OFFSETS.SUPER_JUMP_V2(false);
            }
        }

        private void guna2CheckBox131_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox131.Checked)
            {
                OFFSETS.JUMP_FORWARD(true);
            }
            else
            {
                OFFSETS.JUMP_FORWARD(false);
            }
        }

        private void guna2CheckBox132_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox132.Checked)
            {
                OFFSETS.REMOVE_JUMP(true);
            }
            else
            {
                OFFSETS.REMOVE_JUMP(false);
            }
        }

        private void guna2CheckBox133_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox133.Checked)
            {
                OFFSETS.JUMP_SPEED(true);
            }
            else
            {
                OFFSETS.JUMP_SPEED(false);
            }
        }

        private void guna2CheckBox134_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox134.Checked)
            {
                OFFSETS.ANIM_SWIM_FLY(true);
            }
            else
            {
                OFFSETS.ANIM_SWIM_FLY(false);
            }
        }

        private void guna2CheckBox135_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox135.Checked)
            {
                OFFSETS.REMOVE_SWIM(true);
            }
            else
            {
                OFFSETS.REMOVE_SWIM(false);
            }
        }

        private void guna2CheckBox136_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox136.Checked)
            {
                OFFSETS.DISABLE_SWIM(true);
            }
            else
            {
                OFFSETS.DISABLE_SWIM(false);
            }
        }

        private void guna2CheckBox137_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox137.Checked)
            {
                OFFSETS.CHANGE_MOVEMENT_SWIM(true);
            }
            else
            {
                OFFSETS.CHANGE_MOVEMENT_SWIM(false);
            }
        }

        private void guna2CheckBox138_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox138.Checked)
            {
                OFFSETS.SWIM_GLITCH(true);
            }
            else
            {
                OFFSETS.SWIM_GLITCH(false);
            }
        }

        private void guna2CheckBox139_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox139.Checked)
            {
                OFFSETS.NO_COLISSION(true);
            }
            else
            {
                OFFSETS.NO_COLISSION(false);
            }
        }

        private void guna2CheckBox140_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox140.Checked)
            {
                OFFSETS.NO_COLISSION_BYPASS(true);
            }
            else
            {
                OFFSETS.NO_COLISSION_BYPASS(false);
            }
        }

        private void guna2CheckBox141_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox141.Checked)
            {
                OFFSETS.FLY_MODE_X(true);
            }
            else
            {
                OFFSETS.FLY_MODE_X(false);
            }
        }

        private void guna2CheckBox142_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox142.Checked)
            {
                OFFSETS.SUICIDE(true);
            }
            else
            {
                OFFSETS.SUICIDE(false);
            }
        }

        private void guna2CheckBox143_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox143.Checked)
            {
                OFFSETS.CAN_FLY(true);
            }
            else
            {
                OFFSETS.CAN_FLY(false);
            }
        }

        private void guna2CheckBox144_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox144.Checked)
            {
                OFFSETS.GAME_SPEED_STATIC(true);
            }
            else
            {
                OFFSETS.GAME_SPEED_STATIC(false);
            }
        }

        private void guna2CheckBox145_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox145.Checked)
            {
                OFFSETS.IDS_ITEMS(true);
            }
            else
            {
                OFFSETS.IDS_ITEMS(false);
            }
        }

        private void guna2CheckBox146_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox146.Checked)
            {
                OFFSETS.ANTI_KICK_PREMIUM(true);
            }
            else
            {
                OFFSETS.ANTI_KICK_PREMIUM(false);
            }
        }

        private void guna2CheckBox147_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox147.Checked)
            {
                OFFSETS.DISABLE_FLY_CREATIVE(true);
            }
            else
            {
                OFFSETS.DISABLE_FLY_CREATIVE(false);
            }
        }

        private void guna2CheckBox148_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox148.Checked)
            {
                OFFSETS.INSTANT_PLACE_SURVIVAL(true);
            }
            else
            {
                OFFSETS.INSTANT_PLACE_SURVIVAL(false);
            }
        }

        private void guna2CheckBox149_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox149.Checked)
            {
                OFFSETS.STUCK_IN_BLOCKS(true);
            }
            else
            {
                OFFSETS.STUCK_IN_BLOCKS(false);
            }
        }

        private void guna2CheckBox150_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox150.Checked)
            {
                OFFSETS.CHANGE_POSITION_VIEW(true);
            }
            else
            {
                OFFSETS.CHANGE_POSITION_VIEW(false);
            }
        }

        private void guna2CheckBox151_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox151.Checked)
            {
                OFFSETS.FUNNY_SOUND(true);
            }
            else
            {
                OFFSETS.FUNNY_SOUND(false);
            }
        }

        private void guna2CheckBox152_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox152.Checked)
            {
                OFFSETS.FLOAT_UP(true);
            }
            else
            {
                OFFSETS.FLOAT_UP(false);
            }
        }

        private void guna2CheckBox153_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox153.Checked)
            {
                OFFSETS.ESP_CHESTS_V1(true);
            }
            else
            {
                OFFSETS.ESP_CHESTS_V1(false);
            }
        }

        private void guna2CheckBox154_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox154.Checked)
            {
                OFFSETS.ESP_CHESTS_V2(true);
            }
            else
            {
                OFFSETS.ESP_CHESTS_V2(false);
            }
        }

        private void guna2CheckBox155_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox155.Checked)
            {
                OFFSETS.SCREEN_DEAD(true);
            }
            else
            {
                OFFSETS.SCREEN_DEAD(false);
            }
        }

        private void guna2CheckBox156_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox156.Checked)
            {
                OFFSETS.FAST_BROKEN_BLOCKS_IN_CREATIVE(true);
            }
            else
            {
                OFFSETS.FAST_BROKEN_BLOCKS_IN_CREATIVE(false);
            }
        }

        private void guna2CheckBox157_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox157.Checked)
            {
                OFFSETS.REMOVE_SOME_FPS(true);
            }
            else
            {
                OFFSETS.REMOVE_SOME_FPS(false);
            }
        }

        private void guna2CheckBox158_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox158.Checked)
            {
                OFFSETS.CAM_DOWN_R3(true);
            }
            else
            {
                OFFSETS.CAM_DOWN_R3(false);
            }
        }

        private void guna2CheckBox159_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox159.Checked)
            {
                OFFSETS.INSTANT_MINE(true);
            }
            else
            {
                OFFSETS.INSTANT_MINE(false);
            }
        }

        private void guna2CheckBox160_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox160.Checked)
            {
                OFFSETS.INFINITE_CRAFT(true);
            }
            else
            {
                OFFSETS.INFINITE_CRAFT(false);
            }
        }

        private void guna2CheckBox161_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox161.Checked)
            {
                OFFSETS.HUD_MINI_GAME(true);
            }
            else
            {
                OFFSETS.HUD_MINI_GAME(false);
            }
        }

        private void guna2CheckBox162_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox162.Checked)
            {
                OFFSETS.ANTI_TELEPORT_BY_HOST(true);
            }
            else
            {
                OFFSETS.ANTI_TELEPORT_BY_HOST(false);
            }
        }

        private void guna2CheckBox163_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox163.Checked)
            {
                OFFSETS.UFO_MODE(true);
            }
            else
            {
                OFFSETS.UFO_MODE(false);
            }
        }

        private void guna2CheckBox164_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox164.Checked)
            {
                OFFSETS.ANTI_AFK(true);
            }
            else
            {
                OFFSETS.ANTI_AFK(false);
            }
        }

        private void guna2CheckBox165_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox165.Checked)
            {
                OFFSETS.ANTI_AFK_V2(true);
            }
            else
            {
                OFFSETS.ANTI_AFK_V2(false);
            }
        }

        private void guna2CheckBox166_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox166.Checked)
            {
                OFFSETS.ANTI_AFK_V3(true);
            }
            else
            {
                OFFSETS.ANTI_AFK_V3(false);
            }
        }

        private void guna2CheckBox167_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox167.Checked)
            {
                OFFSETS.SENSIBILITY_FAST(true);
            }
            else
            {
                OFFSETS.SENSIBILITY_FAST(false);
            }
        }

        private void guna2CheckBox168_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox168.Checked)
            {
                OFFSETS.SENSIBILITY_MAX(true);
            }
            else
            {
                OFFSETS.SENSIBILITY_MAX(false);
            }
        }

        private void guna2CheckBox169_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox169.Checked)
            {
                OFFSETS.MOVE_WITH_INVENTORY_OPENED(true);
            }
            else
            {
                OFFSETS.MOVE_WITH_INVENTORY_OPENED(false);
            }
        }

        private void guna2CheckBox170_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox170.Checked)
            {
                OFFSETS.DISABLE_RUN(true);
            }
            else
            {
                OFFSETS.DISABLE_RUN(false);
            }
        }

        private void guna2CheckBox171_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox171.Checked)
            {
                OFFSETS.ENTITY_INVISIBLE(true);
            }
            else
            {
                OFFSETS.ENTITY_INVISIBLE(false);
            }
        }

        private void guna2CheckBox172_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox172.Checked)
            {
                OFFSETS.WALK_ALONE(true);
            }
            else
            {
                OFFSETS.WALK_ALONE(false);
            }
        }

        private void guna2CheckBox173_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox173.Checked)
            {
                OFFSETS.NAME_OVER_HEAD(true);
            }
            else
            {
                OFFSETS.NAME_OVER_HEAD(false);
            }
        }

        private void guna2CheckBox174_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox174.Checked)
            {
                OFFSETS.KNOCKBACK_V1(true);
            }
            else
            {
                OFFSETS.KNOCKBACK_V1(false);
            }
        }

        private void guna2CheckBox175_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox175.Checked)
            {
                OFFSETS.NAME_OVER_HEAD_GO_UP_DOWN(true);
            }
            else
            {
                OFFSETS.NAME_OVER_HEAD_GO_UP_DOWN(false);
            }
        }

        private void guna2CheckBox176_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox176.Checked)
            {
                OFFSETS.STATIC_MOVEMENT(true);
            }
            else
            {
                OFFSETS.STATIC_MOVEMENT(false);
            }
        }

        private void guna2CheckBox177_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox177.Checked)
            {
                OFFSETS.WALK_IN_SKY(true);
            }
            else
            {
                OFFSETS.WALK_IN_SKY(false);
            }
        }

        private void guna2CheckBox178_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox178.Checked)
            {
                OFFSETS.GRAVITY_MOON(true);
            }
            else
            {
                OFFSETS.GRAVITY_MOON(false);
            }
        }

        private void guna2CheckBox179_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox179.Checked)
            {
                OFFSETS.LOOK_FORBACK(true);
            }
            else
            {
                OFFSETS.LOOK_FORBACK(false);
            }
        }

        private void guna2CheckBox180_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox180.Checked)
            {
                OFFSETS.CAM_DOWN(true);
            }
            else
            {
                OFFSETS.CAM_DOWN(false);
            }
        }

        private void guna2CheckBox181_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox181.Checked)
            {
                OFFSETS.BETTER_TIME(true);
            }
            else
            {
                OFFSETS.BETTER_TIME(false);
            }
        }

        private void guna2CheckBox182_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox182.Checked)
            {
                OFFSETS.SEE_OUTSIDE_MAP(true);
            }
            else
            {
                OFFSETS.SEE_OUTSIDE_MAP(false);
            }
        }

        private void guna2CheckBox183_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox183.Checked)
            {
                OFFSETS.REMOVE_ALL_TEXT(true);
            }
            else
            {
                OFFSETS.REMOVE_ALL_TEXT(false);
            }
        }

        private void guna2CheckBox184_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox184.Checked)
            {
                OFFSETS.XRAY(true);
            }
            else
            {
                OFFSETS.XRAY(false);
            }
        }

        private void guna2CheckBox185_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox185.Checked)
            {
                OFFSETS.SCAFFOLD_BETA(true);
            }
            else
            {
                OFFSETS.SCAFFOLD_BETA(false);
            }
        }

        private void guna2CheckBox186_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox186.Checked)
            {
                OFFSETS.DAYS_NIGHT(true);
            }
            else
            {
                OFFSETS.DAYS_NIGHT(false);
            }
        }

        private void guna2CheckBox187_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox187.Checked)
            {
                OFFSETS.NIGHT_VISION(true);
            }
            else
            {
                OFFSETS.NIGHT_VISION(false);
            }
        }

        private void guna2CheckBox188_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox188.Checked)
            {
                OFFSETS.WEATHER_SNOW(true);
            }
            else
            {
                OFFSETS.WEATHER_SNOW(false);
            }
        }

        private void guna2CheckBox189_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox189.Checked)
            {
                OFFSETS.WEATHER_RAIN(true);
            }
            else
            {
                OFFSETS.WEATHER_RAIN(false);
            }
        }

        private void guna2CheckBox190_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox190.Checked)
            {
                OFFSETS.LABYMOD_SETTINGS(true);
            }
            else
            {
                OFFSETS.LABYMOD_SETTINGS(false);
            }
        }

        private void guna2CheckBox191_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox191.Checked)
            {
                OFFSETS.ESP_PLAYERS(true);
            }
            else
            {
                OFFSETS.ESP_PLAYERS(false);
            }
        }

        private void guna2CheckBox192_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox192.Checked)
            {
                OFFSETS.OLD_FLY_OPTIONS(true);
            }
            else
            {
                OFFSETS.OLD_FLY_OPTIONS(false);
            }
        }

        private void guna2CheckBox193_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox193.Checked)
            {
                OFFSETS.TRIDENT_RIPTIDE_TO_MAX(true);
            }
            else
            {
                OFFSETS.TRIDENT_RIPTIDE_TO_MAX(false);
            }
        }

        private void guna2CheckBox194_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox194.Checked)
            {
                OFFSETS.NO_COLISSION_ENTITY(true);
            }
            else
            {
                OFFSETS.NO_COLISSION_ENTITY(false);
            }
        }

        private void guna2CheckBox195_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox195.Checked)
            {
                OFFSETS.FLY_OR_RUN_ON_CROUCH(true);
            }
            else
            {
                OFFSETS.FLY_OR_RUN_ON_CROUCH(false);
            }
        }

        private void guna2CheckBox196_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox196.Checked)
            {
                OFFSETS.AUTO_LADDER(true);
            }
            else
            {
                OFFSETS.AUTO_LADDER(false);
            }
        }

        private void guna2CheckBox197_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox197.Checked)
            {
                OFFSETS.CHANGE_AIR_TO_WATER(true);
            }
            else
            {
                OFFSETS.CHANGE_AIR_TO_WATER(false);
            }
        }

        private void guna2CheckBox198_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox198.Checked)
            {
                OFFSETS.MULTI_JUMP_V2(true);
            }
            else
            {
                OFFSETS.MULTI_JUMP_V2(false);
            }
        }

        private void guna2CheckBox199_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox199.Checked)
            {
                OFFSETS.GET_IDS_PLAYERS_ON_HEAD(true);
            }
            else
            {
                OFFSETS.GET_IDS_PLAYERS_ON_HEAD(false);
            }
        }

        private void guna2CheckBox200_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox200.Checked)
            {

            }
            else
            {

            }
        }

        private void guna2CheckBox201_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox201.Checked)
            {
                OFFSETS.ELYTRA_ON_ALL_ENTITY(true);
            }
            else
            {
                OFFSETS.ELYTRA_ON_ALL_ENTITY(false);
            }
        }

        private void guna2CheckBox202_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox202.Checked)
            {
                OFFSETS.WATER_SLOW_DOWN(true);
            }
            else
            {
                OFFSETS.WATER_SLOW_DOWN(false);
            }
        }

        private void guna2CheckBox203_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox203.Checked)
            {
                OFFSETS.JUMP_IN_LAVA(true);
            }
            else
            {
                OFFSETS.JUMP_IN_LAVA(false);
            }
        }

        private void guna2CheckBox204_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox204.Checked)
            {
                OFFSETS.AUTO_CROUCH_ON_MOVEMENT(true);
            }
            else
            {
                OFFSETS.AUTO_CROUCH_ON_MOVEMENT(false);
            }
        }

        private void guna2CheckBox205_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox205.Checked)
            {
                OFFSETS.FAKE_LAGS(true);
            }
            else
            {
                OFFSETS.FAKE_LAGS(false);
            }
        }

        private void guna2CheckBox206_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox206.Checked)
            {
                OFFSETS.CHANGE_POSITIONS_PLACE(true);
            }
            else
            {
                OFFSETS.CHANGE_POSITIONS_PLACE(false);
            }
        }

        private void guna2CheckBox207_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox207.Checked)
            {
                OFFSETS.DESTROY_GAME(true);
            }
            else
            {
                OFFSETS.DESTROY_GAME(false);
            }
        }

        private void guna2CheckBox208_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox208.Checked)
            {
                OFFSETS.LEVITATION(true);
            }
            else
            {
                OFFSETS.LEVITATION(false);
            }
        }

        private void guna2CheckBox209_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox209.Checked)
            {
                OFFSETS.RETURN_TO_XMB(true);
            }
            else
            {
                OFFSETS.RETURN_TO_XMB(false);
            }
        }

        private void guna2CheckBox210_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox210.Checked)
            {
                OFFSETS.KICK_TO_XMB_HUD(true);
            }
            else
            {
                OFFSETS.KICK_TO_XMB_HUD(false);
            }
        }

        private void guna2CheckBox211_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox211.Checked)
            {
                OFFSETS.ADD_FAKE_CLONE_CONTROLLER(true);
            }
            else
            {
                OFFSETS.ADD_FAKE_CLONE_CONTROLLER(false);
            }
        }

        private void guna2CheckBox212_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox212.Checked)
            {
                OFFSETS.REACH_ATTACK(true);
            }
            else
            {
                OFFSETS.REACH_ATTACK(false);
            }
        }

        private void guna2CheckBox213_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox213.Checked)
            {
                OFFSETS.TOGGLE_SPRINT(true);
            }
            else
            {
                OFFSETS.TOGGLE_SPRINT(false);
            }
        }

        private void guna2CheckBox214_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox214.Checked)
            {
                OFFSETS.TOGGLE_SPRINT_V2(true);
            }
            else
            {
                OFFSETS.TOGGLE_SPRINT_V2(false);
            }
        }

        private void guna2CheckBox215_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox215.Checked)
            {
                OFFSETS.INSTANT_HIT(true);
            }
            else
            {
                OFFSETS.INSTANT_HIT(false);
            }
        }

        private void guna2CheckBox216_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox216.Checked)
            {
                OFFSETS.KILL_AURA(true);
            }
            else
            {
                OFFSETS.KILL_AURA(false);
            }
        }

        private void guna2CheckBox217_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox217.Checked)
            {
                OFFSETS.FAST_BUILD(true);
            }
            else
            {
                OFFSETS.FAST_BUILD(false);
            }
        }

        private void guna2CheckBox218_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox218.Checked)
            {
                OFFSETS.CRITICAL_HIT_V1(true);
            }
            else
            {
                OFFSETS.CRITICAL_HIT_V1(false);
            }
        }

        private void guna2CheckBox219_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox219.Checked)
            {
                OFFSETS.CRITICAL_HIT_V2(true);
            }
            else
            {
                OFFSETS.CRITICAL_HIT_V2(false);
            }
        }

        private void guna2CheckBox220_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox220.Checked)
            {
                OFFSETS.NO_SLOW_DOWN(true);
            }
            else
            {
                OFFSETS.NO_SLOW_DOWN(false);
            }
        }

        private void guna2CheckBox221_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox221.Checked)
            {
                OFFSETS.REMOVE_HURT_CAM(true);
            }
            else
            {
                OFFSETS.REMOVE_HURT_CAM(false);
            }
        }

        private void guna2CheckBox222_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox222.Checked)
            {
                OFFSETS.PRESS_X_FOR_HIT(true);
            }
            else
            {
                OFFSETS.PRESS_X_FOR_HIT(false);
            }
        }

        private void guna2CheckBox223_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox223.Checked)
            {
                OFFSETS.SHOW_ARMOR(true);
            }
            else
            {
                OFFSETS.SHOW_ARMOR(false);
            }
        }

        private void guna2CheckBox224_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox224.Checked)
            {
                OFFSETS.UNFAIR_ATTACK(true);
            }
            else
            {
                OFFSETS.UNFAIR_ATTACK(false);
            }
        }

        private void guna2CheckBox225_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox225.Checked)
            {
                OFFSETS.HITBOX_BETA(true);
            }
            else
            {
                OFFSETS.HITBOX_BETA(false);
            }
        }

        private void guna2CheckBox226_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox226.Checked)
            {
                OFFSETS.BLOCKS_STATIC_CRACK(true);
            }
            else
            {
                OFFSETS.BLOCKS_STATIC_CRACK(false);
            }
        }

        private void guna2CheckBox227_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox227.Checked)
            {
                OFFSETS.VELOCITY_SMALL(true);
            }
            else
            {
                OFFSETS.VELOCITY_SMALL(false);
            }
        }

        private void guna2CheckBox228_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox228.Checked)
            {
                OFFSETS.VELOCITY_BIG(true);
            }
            else
            {
                OFFSETS.VELOCITY_BIG(false);
            }
        }

        private void guna2CheckBox229_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox229.Checked)
            {
                OFFSETS.AUTO_JUMP(true);
            }
            else
            {
                OFFSETS.AUTO_JUMP(false);
            }
        }

        private void guna2CheckBox230_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox230.Checked)
            {
                OFFSETS.AUTO_CHANGE_VIEW(true);
            }
            else
            {
                OFFSETS.AUTO_CHANGE_VIEW(false);
            }
        }

        private void guna2CheckBox231_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox231.Checked)
            {
                OFFSETS.AUTO_CROUCH(true);
            }
            else
            {
                OFFSETS.AUTO_CROUCH(false);
            }
        }

        private void guna2CheckBox232_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox232.Checked)
            {
                OFFSETS.AUTO_MINE(true);
            }
            else
            {
                OFFSETS.AUTO_MINE(false);
            }
        }

        private void guna2CheckBox233_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox233.Checked)
            {
                OFFSETS.AUTO_HIT(true);
            }
            else
            {
                OFFSETS.AUTO_HIT(false);
            }
        }

        private void guna2CheckBox234_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox234.Checked)
            {
                OFFSETS.AUTO_TOSS_ITEMS(true);
            }
            else
            {
                OFFSETS.AUTO_TOSS_ITEMS(false);
            }
        }

        private void guna2CheckBox235_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox235.Checked)
            {
                OFFSETS.AUTO_BUILD_IN_SURVIVAL(true);
            }
            else
            {
                OFFSETS.AUTO_BUILD_IN_SURVIVAL(false);
            }
        }

        private void guna2CheckBox236_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox236.Checked)
            {
                OFFSETS.GET_64_ITEMS_BLOCKS(true);
            }
            else
            {
                OFFSETS.GET_64_ITEMS_BLOCKS(false);
            }
        }

        private void guna2CheckBox237_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox237.Checked)
            {
                OFFSETS.SWITCH_GAME_TO_OFFLINE(true);
            }
            else
            {
                OFFSETS.SWITCH_GAME_TO_OFFLINE(false);
            }
        }

        private void guna2CheckBox238_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox238.Checked)
            {
                OFFSETS.FREEZE_THE_WORLD_WITH_EGG(true);
            }
            else
            {
                OFFSETS.FREEZE_THE_WORLD_WITH_EGG(false);
            }
        }

        private void guna2CheckBox239_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox239.Checked)
            {
                OFFSETS.INVENTORY_SPECIAL_BLOCKS(true);
            }
            else
            {
                OFFSETS.INVENTORY_SPECIAL_BLOCKS(false);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string[] split = Regex.Split(guna2TextBox1.Text, ",");
            OFFSETS.setLocation(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]));
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string get = OFFSETS.getLocation();
            guna2TextBox1.Text = get.Remove(get.Length - 1, 1);
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.SelectedIndex == 0)
            {
                OFFSETS.ITEMS_2TH_HAND("0");
            }
            else if (guna2ComboBox4.SelectedIndex == 1)
            {
                OFFSETS.ITEMS_2TH_HAND("1");
            }
            else if (guna2ComboBox4.SelectedIndex == 2)
            {
                OFFSETS.ITEMS_2TH_HAND("2");
            }
            else if (guna2ComboBox4.SelectedIndex == 3)
            {
                OFFSETS.ITEMS_2TH_HAND("3");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                guna2PictureBox3.Image.Save(sfd.FileName);
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox3.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_SOURCE_KILL("0");
            }
            else if (guna2ComboBox3.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_SOURCE_KILL("1");
            }
            else if (guna2ComboBox3.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_SOURCE_KILL("2");
            }
            else if (guna2ComboBox3.SelectedIndex == 3)
            {
                OFFSETS.CHANGE_SOURCE_KILL("3");
            }
        }

        private void guna2ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox9.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("0");
            }
            else if (guna2ComboBox9.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("1");
            }
            else if (guna2ComboBox9.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("2");
            }
            else if (guna2ComboBox9.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("3");
            }
            else if (guna2ComboBox9.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("4");
            }
            else if (guna2ComboBox9.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("5");
            }
            else if (guna2ComboBox9.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("6");
            }
            else if (guna2ComboBox9.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("7");
            }
            else if (guna2ComboBox9.SelectedIndex == 8)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("8");
            }
            else if (guna2ComboBox9.SelectedIndex == 9)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("9");
            }
            else if (guna2ComboBox9.SelectedIndex == 10)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("10");
            }
            else if (guna2ComboBox9.SelectedIndex == 11)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("11");
            }
            else if (guna2ComboBox9.SelectedIndex == 12)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("12");
            }
            else if (guna2ComboBox9.SelectedIndex == 13)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("13");
            }
            else if (guna2ComboBox9.SelectedIndex == 14)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("14");
            }
            else if (guna2ComboBox9.SelectedIndex == 15)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("15");
            }
            else if (guna2ComboBox9.SelectedIndex == 16)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("16");
            }
            else if (guna2ComboBox9.SelectedIndex == 17)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("17");
            }
            else if (guna2ComboBox9.SelectedIndex == 18)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("18");
            }
            else if (guna2ComboBox9.SelectedIndex == 19)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("19");
            }
            else if (guna2ComboBox9.SelectedIndex == 20)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("20");
            }
            else if (guna2ComboBox9.SelectedIndex == 21)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("22");
            }
            else if (guna2ComboBox9.SelectedIndex == 23)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("23");
            }
            else if (guna2ComboBox9.SelectedIndex == 24)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("24");
            }
            else if (guna2ComboBox9.SelectedIndex == 25)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("25");
            }
            else if (guna2ComboBox9.SelectedIndex == 26)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("26");
            }
            else if (guna2ComboBox9.SelectedIndex == 27)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("27");
            }
            else if (guna2ComboBox9.SelectedIndex == 28)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("28");
            }
            else if (guna2ComboBox9.SelectedIndex == 29)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("29");
            }
        }

        private void guna2ComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox12.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("0");
            }
            else if (guna2ComboBox12.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("1");
            }
            else if (guna2ComboBox12.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("2");
            }
            else if (guna2ComboBox12.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("3");
            }
            else if (guna2ComboBox12.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("4");
            }
            else if (guna2ComboBox12.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("5");
            }
            else if (guna2ComboBox12.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("6");
            }
            else if (guna2ComboBox12.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("7");
            }
            else if (guna2ComboBox12.SelectedIndex == 8)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("8");
            }
        }

        private void guna2CheckBox240_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox240.Checked)
            {
                OFFSETS.APOCALIPSE(true);
            }
            else
            {
                OFFSETS.APOCALIPSE(false);
            }
        }

        private void guna2CheckBox241_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox241.Checked)
            {
                OFFSETS.FUNNY_SCREEN(true);
            }
            else
            {
                OFFSETS.FUNNY_SCREEN(false);
            }
        }

        private void guna2CheckBox242_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox242.Checked)
            {
                OFFSETS.CHANGE_PLAYERS_POSITION(true);
            }
            else
            {
                OFFSETS.CHANGE_PLAYERS_POSITION(false);
            }
        }

        private void guna2CheckBox243_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox243.Checked)
            {
                OFFSETS.HORROR_VIEW(true);
            }
            else
            {
                OFFSETS.HORROR_VIEW(false);
            }
        }

        private void guna2CheckBox244_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox244.Checked)
            {
                OFFSETS.ANIMATION_RUNNING(true);
            }
            else
            {
                OFFSETS.ANIMATION_RUNNING(false);
            }
        }

        private void guna2CheckBox245_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox245.Checked)
            {
                OFFSETS.RAINBOW_SKY(true);
            }
            else
            {
                OFFSETS.RAINBOW_SKY(false);
            }
        }

        private void guna2CheckBox246_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox246.Checked)
            {
                OFFSETS.LSD_VIEW(true);
            }
            else
            {
                OFFSETS.LSD_VIEW(false);
            }
        }

        private void guna2CheckBox247_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox247.Checked)
            {
                OFFSETS.SPLIT_SCREEN(true);
            }
            else
            {
                OFFSETS.SPLIT_SCREEN(false);
            }
        }

        private void guna2CheckBox248_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox248.Checked)
            {
                OFFSETS.SIZE_HUD(true);
            }
            else
            {
                OFFSETS.SIZE_HUD(false);
            }
        }

        private void guna2CheckBox249_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox249.Checked)
            {
                OFFSETS.TEXT_TO_ALIEN(true);
            }
            else
            {
                OFFSETS.TEXT_TO_ALIEN(false);
            }
        }

        private void guna2CheckBox250_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox250.Checked)
            {
                OFFSETS.BROKEN_TEXTURES(true);
            }
            else
            {
                OFFSETS.BROKEN_TEXTURES(false);
            }
        }

        private void guna2CheckBox251_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox251.Checked)
            {
                OFFSETS.SHOCKWAVE_EFFECT(true);
            }
            else
            {
                OFFSETS.SHOCKWAVE_EFFECT(false);
            }
        }

        private void guna2CheckBox252_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox252.Checked)
            {
                OFFSETS.WALL_HACK_V1(true);
            }
            else
            {
                OFFSETS.WALL_HACK_V1(false);
            }
        }

        private void guna2CheckBox253_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox253.Checked)
            {
                OFFSETS.WALL_HACK_V2(true);
            }
            else
            {
                OFFSETS.WALL_HACK_V2(false);
            }
        }

        private void guna2CheckBox254_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox254.Checked)
            {
                OFFSETS.WALL_HACK_V3(true);
            }
            else
            {
                OFFSETS.WALL_HACK_V3(false);
            }
        }

        private void guna2CheckBox255_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox255.Checked)
            {
                OFFSETS.TEXTURE_PLASTIC(true);
            }
            else
            {
                OFFSETS.TEXTURE_PLASTIC(false);
            }
        }

        private void guna2CheckBox256_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox256.Checked)
            {
                OFFSETS.GHOST_PLAYERS(true);
            }
            else
            {
                OFFSETS.GHOST_PLAYERS(false);
            }
        }

        private void guna2CheckBox257_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox257.Checked)
            {
                OFFSETS.FOG_BLUE(true);
            }
            else
            {
                OFFSETS.FOG_BLUE(false);
            }
        }

        private void guna2CheckBox258_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox258.Checked)
            {
                OFFSETS.BEST_SKY(true);
            }
            else
            {
                OFFSETS.BEST_SKY(false);
            }
        }

        private void guna2CheckBox259_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox259.Checked)
            {
                OFFSETS.SHAKE_CAMERA(true);
            }
            else
            {
                OFFSETS.SHAKE_CAMERA(false);
            }
        }

        private void guna2CheckBox260_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox260.Checked)
            {
                OFFSETS.LIGHT_MAKE_MORE_POWER(true);
            }
            else
            {
                OFFSETS.LIGHT_MAKE_MORE_POWER(false);
            }
        }

        private void guna2CheckBox261_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox261.Checked)
            {
                OFFSETS.FLAT_BLOCKS(true);
            }
            else
            {
                OFFSETS.FLAT_BLOCKS(false);
            }
        }

        private void guna2CheckBox262_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox262.Checked)
            {
                OFFSETS.BLOCKS_HAND_UP(true);
            }
            else
            {
                OFFSETS.BLOCKS_HAND_UP(false);
            }
        }

        private void guna2CheckBox263_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox263.Checked)
            {
                OFFSETS.VIBRATE_WALK(true);
            }
            else
            {
                OFFSETS.VIBRATE_WALK(false);
            }
        }

        private void guna2CheckBox264_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox264.Checked)
            {
                OFFSETS.BIG_GAMEPLAY(true);
            }
            else
            {
                OFFSETS.BIG_GAMEPLAY(false);
            }
        }

        private void guna2CheckBox265_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox265.Checked)
            {
                OFFSETS.REMOVE_INVENTORY_HUD(true);
            }
            else
            {
                OFFSETS.REMOVE_INVENTORY_HUD(false);
            }
        }

        private void guna2CheckBox266_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox266.Checked)
            {
                OFFSETS.REMOVE_POINTER_AIM(true);
            }
            else
            {
                OFFSETS.REMOVE_POINTER_AIM(false);
            }
        }

        private void guna2CheckBox267_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox267.Checked)
            {
                OFFSETS.HUD_SHOW_PLAYERS_AROUND_YOU(true);
            }
            else
            {
                OFFSETS.HUD_SHOW_PLAYERS_AROUND_YOU(false);
            }
        }

        private void guna2CheckBox268_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox268.Checked)
            {
                OFFSETS.HUD_INVENTORY_DOWN_ON_SCREEN(true);
            }
            else
            {
                OFFSETS.HUD_INVENTORY_DOWN_ON_SCREEN(false);
            }
        }

        private void guna2CheckBox269_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox269.Checked)
            {
                OFFSETS.PLAYERS_SKATE_MODE(true);
            }
            else
            {
                OFFSETS.PLAYERS_SKATE_MODE(false);
            }
        }

        private void guna2CheckBox270_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox270.Checked)
            {
                OFFSETS.ARMS_AND_LEGS_WEIRD(true);
            }
            else
            {
                OFFSETS.ARMS_AND_LEGS_WEIRD(false);
            }
        }

        private void guna2CheckBox271_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox271.Checked)
            {
                OFFSETS.RAYMAN_MODE(true);
            }
            else
            {
                OFFSETS.RAYMAN_MODE(false);
            }
        }

        private void guna2CheckBox272_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox272.Checked)
            {
                OFFSETS.ARMS_HIT_SPEED(true);
            }
            else
            {
                OFFSETS.ARMS_HIT_SPEED(false);
            }
        }

        private void guna2CheckBox273_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox273.Checked)
            {
                OFFSETS.REMOVE_ANIMATION_RUN(true);
            }
            else
            {
                OFFSETS.REMOVE_ANIMATION_RUN(false);
            }
        }

        private void guna2CheckBox274_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox274.Checked)
            {
                OFFSETS.SMALL_GRAPHIC(true);
            }
            else
            {
                OFFSETS.SMALL_GRAPHIC(false);
            }
        }

        private void guna2CheckBox275_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox275.Checked)
            {
                OFFSETS.PLAYERS_SLIDE(true);
            }
            else
            {
                OFFSETS.PLAYERS_SLIDE(false);
            }
        }

        private void guna2CheckBox276_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox276.Checked)
            {
                OFFSETS.FREEZE_PARTICLES(true);
            }
            else
            {
                OFFSETS.FREEZE_PARTICLES(false);
            }
        }

        private void guna2CheckBox277_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox277.Checked)
            {
                OFFSETS.SEMI_BLACKSCREEN(true);
            }
            else
            {
                OFFSETS.SEMI_BLACKSCREEN(false);
            }
        }

        private void guna2CheckBox278_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox278.Checked)
            {
                OFFSETS.BREAK_PARTICLES_FLY(true);
            }
            else
            {
                OFFSETS.BREAK_PARTICLES_FLY(false);
            }
        }

        private void guna2CheckBox279_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox279.Checked)
            {
                OFFSETS.PLAYERS_PAPER_MODELS(true);
            }
            else
            {
                OFFSETS.PLAYERS_PAPER_MODELS(false);
            }
        }

        private void guna2CheckBox280_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox280.Checked)
            {
                OFFSETS.PLAYERS_BIG_MODELS(true);
            }
            else
            {
                OFFSETS.PLAYERS_BIG_MODELS(false);
            }
        }

        private void guna2CheckBox281_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox281.Checked)
            {
                OFFSETS.CAMERA_LEFT_POSITION(true);
            }
            else
            {
                OFFSETS.CAMERA_LEFT_POSITION(false);
            }
        }

        private void guna2CheckBox282_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox282.Checked)
            {
                OFFSETS.CAMERA_RIGHT_POSITION(true);
            }
            else
            {
                OFFSETS.CAMERA_RIGHT_POSITION(false);
            }
        }

        private void guna2CheckBox283_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox283.Checked)
            {
                OFFSETS.REMOVE_PARTICLES(true);
            }
            else
            {
                OFFSETS.REMOVE_PARTICLES(false);
            }
        }

        private void guna2CheckBox284_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox284.Checked)
            {
                OFFSETS.BIG_PARTICLES(true);
            }
            else
            {
                OFFSETS.BIG_PARTICLES(false);
            }
        }

        private void guna2CheckBox285_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox285.Checked)
            {
                OFFSETS.HUD_LOADING(true);
            }
            else
            {
                OFFSETS.HUD_LOADING(false);
            }
        }

        private void guna2CheckBox286_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox286.Checked)
            {
                OFFSETS.FLASH_STARS_IN_SKY(true);
            }
            else
            {
                OFFSETS.FLASH_STARS_IN_SKY(false);
            }
        }

        private void guna2CheckBox287_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox287.Checked)
            {
                OFFSETS.REMOVE_STARS_IN_SKY(true);
            }
            else
            {
                OFFSETS.REMOVE_STARS_IN_SKY(false);
            }
        }

        private void guna2CheckBox288_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox288.Checked)
            {
                OFFSETS.FOOT_STEP_FAST(true);
            }
            else
            {
                OFFSETS.FOOT_STEP_FAST(false);
            }
        }

        private void guna2CheckBox289_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox289.Checked)
            {
                OFFSETS.FOOT_STEP_SLOW(true);
            }
            else
            {
                OFFSETS.FOOT_STEP_SLOW(false);
            }
        }

        private void guna2CheckBox290_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox290.Checked)
            {
                OFFSETS.DEBUG_SKINS_TEXTURE(true);
            }
            else
            {
                OFFSETS.DEBUG_SKINS_TEXTURE(false);
            }
        }

        private void guna2CheckBox291_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox291.Checked)
            {
                OFFSETS.ALL_WORLD_LIGHT_WHITE(true);
            }
            else
            {
                OFFSETS.ALL_WORLD_LIGHT_WHITE(false);
            }
        }

        private void guna2CheckBox292_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox292.Checked)
            {
                OFFSETS.RAINBOW_LIGHT(true);
            }
            else
            {
                OFFSETS.RAINBOW_LIGHT(false);
            }
        }

        private void guna2CheckBox293_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox293.Checked)
            {
                OFFSETS.SHADOW_SKINS_PLAYERS(true);
            }
            else
            {
                OFFSETS.SHADOW_SKINS_PLAYERS(false);
            }
        }

        private void guna2CheckBox294_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox294.Checked)
            {
                OFFSETS.SHADOW_SKINS_V2(true);
            }
            else
            {
                OFFSETS.SHADOW_SKINS_V2(false);
            }
        }

        private void guna2CheckBox295_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox295.Checked)
            {
                OFFSETS.ENTITY_SKINS_RED(true);
            }
            else
            {
                OFFSETS.ENTITY_SKINS_RED(false);
            }
        }

        private void guna2CheckBox296_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox296.Checked)
            {
                OFFSETS.PARTICLES_FLY_V2(true);
            }
            else
            {
                OFFSETS.PARTICLES_FLY_V2(false);
            }
        }

        private void guna2CheckBox297_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox297.Checked)
            {
                OFFSETS.LINES_BLOCKS_MOVE(true);
            }
            else
            {
                OFFSETS.LINES_BLOCKS_MOVE(false);
            }
        }

        private void guna2CheckBox298_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox298.Checked)
            {
                OFFSETS.DISABLE_PLAYERS(true);
            }
            else
            {
                OFFSETS.DISABLE_PLAYERS(false);
            }
        }

        private void guna2CheckBox299_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox299.Checked)
            {
                OFFSETS.PLAYERS_LISTS(true);
            }
            else
            {
                OFFSETS.PLAYERS_LISTS(false);
            }
        }

        private void guna2CheckBox300_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox300.Checked)
            {
                OFFSETS.SMALL_TEXT(true);
            }
            else
            {
                OFFSETS.SMALL_TEXT(false);
            }
        }

        private void guna2CheckBox301_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox301.Checked)
            {
                OFFSETS.POSITIONS_HUD(true);
            }
            else
            {
                OFFSETS.POSITIONS_HUD(false);
            }
        }

        private void guna2CheckBox302_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox302.Checked)
            {
                OFFSETS.ARMS_BROKEN_V2(true);
            }
            else
            {
                OFFSETS.ARMS_BROKEN_V2(false);
            }
        }

        private void guna2CheckBox303_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox303.Checked)
            {
                OFFSETS.FOG_BLACK(true);
            }
            else
            {
                OFFSETS.FOG_BLACK(false);
            }
        }

        private void guna2CheckBox304_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox304.Checked)
            {
                OFFSETS.SKY_TO_NETHER(true);
            }
            else
            {
                OFFSETS.SKY_TO_NETHER(false);
            }
        }

        private void guna2CheckBox305_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox305.Checked)
            {
                OFFSETS.SMOKE_LOBBY(true);
            }
            else
            {
                OFFSETS.SMOKE_LOBBY(false);
            }
        }

        private void guna2CheckBox306_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox306.Checked)
            {
                OFFSETS.CAN_SEE_UNDER_WORLD(true);
            }
            else
            {
                OFFSETS.CAN_SEE_UNDER_WORLD(false);
            }
        }

        private void guna2CheckBox307_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox307.Checked)
            {
                OFFSETS.FREE_CAM(true);
            }
            else
            {
                OFFSETS.FREE_CAM(false);
            }
        }

        private void guna2CheckBox308_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox308.Checked)
            {
                OFFSETS.LIGHT_EYES_ENDERMAN(true);
            }
            else
            {
                OFFSETS.LIGHT_EYES_ENDERMAN(false);
            }
        }

        private void guna2CheckBox309_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox309.Checked)
            {
                OFFSETS.REMOVE_HANDS(true);
            }
            else
            {
                OFFSETS.REMOVE_HANDS(false);
            }
        }

        private void guna2CheckBox310_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox310.Checked)
            {
                OFFSETS.PARTICLES_TORNADO(true);
            }
            else
            {
                OFFSETS.PARTICLES_TORNADO(false);
            }
        }

        private void guna2CheckBox311_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox311.Checked)
            {
                OFFSETS.DAMAGE_HIT_RED_BLUE(true);
            }
            else
            {
                OFFSETS.DAMAGE_HIT_RED_BLUE(false);
            }
        }

        private void guna2CheckBox312_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox312.Checked)
            {
                OFFSETS.DISABLE_FOG(true);
            }
            else
            {
                OFFSETS.DISABLE_FOG(false);
            }
        }

        private void guna2CheckBox313_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox313.Checked)
            {
                OFFSETS.FOV_WITHOUT_HAND(true);
            }
            else
            {
                OFFSETS.FOV_WITHOUT_HAND(false);
            }
        }

        private void guna2CheckBox314_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox314.Checked)
            {
                OFFSETS.ZOOM_WITHOUT_HAND(true);
            }
            else
            {
                OFFSETS.ZOOM_WITHOUT_HAND(false);
            }
        }

        private void guna2CheckBox315_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox315.Checked)
            {
                OFFSETS.ESP_ENTITY_RED(true);
            }
            else
            {
                OFFSETS.ESP_ENTITY_RED(false);
            }
        }

        private void guna2CheckBox316_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox316.Checked)
            {
                OFFSETS.ESP_ENTITY_BLUE(true);
            }
            else
            {
                OFFSETS.ESP_ENTITY_BLUE(false);
            }
        }

        private void guna2CheckBox317_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox317.Checked)
            {
                OFFSETS.DISALBE_HUD_TEXT(true);
            }
            else
            {
                OFFSETS.DISALBE_HUD_TEXT(false);
            }
        }

        private void guna2CheckBox318_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox318.Checked)
            {
                OFFSETS.NAME_OVER_HEAD_DOUBLE(true);
            }
            else
            {
                OFFSETS.NAME_OVER_HEAD_DOUBLE(false);
            }
        }

        private void guna2CheckBox319_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox319.Checked)
            {
                OFFSETS.HUD_HIDE_EVERYTHING(true);
            }
            else
            {
                OFFSETS.HUD_HIDE_EVERYTHING(false);
            }
        }

        private void guna2CheckBox320_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox320.Checked)
            {
                OFFSETS.GAME_NO_ITEMS(true);
            }
            else
            {
                OFFSETS.GAME_NO_ITEMS(false);
            }
        }

        private void guna2CheckBox321_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox321.Checked)
            {
                OFFSETS.IRON_HELMET_EVERYONE(true);
            }
            else
            {
                OFFSETS.IRON_HELMET_EVERYONE(false);
            }
        }

        private void guna2CheckBox322_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox322.Checked)
            {
                OFFSETS.ENTITY_TO_BABY(true);
            }
            else
            {
                OFFSETS.ENTITY_TO_BABY(false);
            }
        }

        private void guna2CheckBox323_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox323.Checked)
            {
                OFFSETS.REMOVE_ANIMATION_DETAILED_SKINS(true);
            }
            else
            {
                OFFSETS.REMOVE_ANIMATION_DETAILED_SKINS(false);
            }
        }

        private void guna2CheckBox324_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox324.Checked)
            {
                OFFSETS.ENABLE_AIM_ON_3TH_PRESON(true);
            }
            else
            {
                OFFSETS.ENABLE_AIM_ON_3TH_PRESON(false);
            }
        }

        private void guna2CheckBox325_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox325.Checked)
            {
                OFFSETS.ENTITY_RENDER(true);
            }
            else
            {
                OFFSETS.ENTITY_RENDER(false);
            }
        }

        private void guna2CheckBox326_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox326.Checked)
            {
                OFFSETS.ROTATION_HEAD_360_DEGRES(true);
            }
            else
            {
                OFFSETS.ROTATION_HEAD_360_DEGRES(false);
            }
        }

        private void guna2CheckBox327_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox327.Checked)
            {
                OFFSETS.TEXTURE_BLACK(true);
            }
            else
            {
                OFFSETS.TEXTURE_BLACK(false);
            }
        }

        private void guna2CheckBox328_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox328.Checked)
            {
                OFFSETS.GAMMA_TO_MAX(true);
            }
            else
            {
                OFFSETS.GAMMA_TO_MAX(false);
            }
        }

        private void guna2CheckBox329_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox329.Checked)
            {
                OFFSETS.NAME_AND_SHADOW_BLACK(true);
            }
            else
            {
                OFFSETS.NAME_AND_SHADOW_BLACK(false);
            }
        }

        private void guna2CheckBox330_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox330.Checked)
            {
                OFFSETS.ANIMATION_CHARACTER(true);
            }
            else
            {
                OFFSETS.ANIMATION_CHARACTER(false);
            }
        }

        private void guna2CheckBox331_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox331.Checked)
            {
                OFFSETS.BIG_ANIMATION_CHARACTER(true);
            }
            else
            {
                OFFSETS.BIG_ANIMATION_CHARACTER(false);
            }
        }

        private void guna2CheckBox332_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox332.Checked)
            {
                OFFSETS.FUNNY_ARMS_LEGS(true);
            }
            else
            {
                OFFSETS.FUNNY_ARMS_LEGS(false);
            }
        }

        private void guna2CheckBox333_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox333.Checked)
            {
                OFFSETS.REAL_JUMP_ANIMATION(true);
            }
            else
            {
                OFFSETS.REAL_JUMP_ANIMATION(false);
            }
        }

        private void guna2CheckBox334_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox334.Checked)
            {
                OFFSETS.ROTATION_BODY(true);
            }
            else
            {
                OFFSETS.ROTATION_BODY(false);
            }
        }

        private void guna2CheckBox335_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox335.Checked)
            {
                OFFSETS.PLAYERS_BODY_LIGHT(true);
            }
            else
            {
                OFFSETS.PLAYERS_BODY_LIGHT(false);
            }
        }

        private void guna2CheckBox336_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox336.Checked)
            {
                OFFSETS.FAST_MOVE_LEGS_ARMS(true);
            }
            else
            {
                OFFSETS.FAST_MOVE_LEGS_ARMS(false);
            }
        }

        private void guna2CheckBox337_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox337.Checked)
            {
                OFFSETS.LEGS_IN_AIR(true);
            }
            else
            {
                OFFSETS.LEGS_IN_AIR(false);
            }
        }

        private void guna2CheckBox338_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox338.Checked)
            {
                OFFSETS.NETHER_VISION(true);
            }
            else
            {
                OFFSETS.NETHER_VISION(false);
            }
        }

        private void guna2CheckBox339_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox339.Checked)
            {
                OFFSETS.PARTICLES_DAMAGE_NO_STOP(true);
            }
            else
            {
                OFFSETS.PARTICLES_DAMAGE_NO_STOP(false);
            }
        }

        private void guna2CheckBox340_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox340.Checked)
            {
                OFFSETS.ROBLOX_ANIMATION(true);
            }
            else
            {
                OFFSETS.ROBLOX_ANIMATION(false);
            }
        }

        private void guna2CheckBox341_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox341.Checked)
            {
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(true);
            }
            else
            {
                OFFSETS.STOP_SHOW_LOGS_NOTIFS(false);
            }
        }

        private void guna2CheckBox342_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox342.Checked)
            {
                OFFSETS.GENEREATE_BUBBLE_IN_WATER(true);
            }
            else
            {
                OFFSETS.GENEREATE_BUBBLE_IN_WATER(false);
            }
        }

        private void guna2CheckBox343_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox343.Checked)
            {
                OFFSETS.ELYTRA_ON_ALL_ENTITY(true);
            }
            else
            {
                OFFSETS.ELYTRA_ON_ALL_ENTITY(false);
            }
        }

        private void guna2CheckBox344_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox344.Checked)
            {
                OFFSETS.MOVE_HEAD_BUT_NOT_BODY(true);
            }
            else
            {
                OFFSETS.MOVE_HEAD_BUT_NOT_BODY(false);
            }
        }

        private void guna2CheckBox345_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox345.Checked)
            {
                OFFSETS.STOP_ANIMATIONS(true);
            }
            else
            {
                OFFSETS.STOP_ANIMATIONS(false);
            }
        }

        private void guna2CheckBox346_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox346.Checked)
            {
                OFFSETS.OPTIMIZE_CHUNKS_LOAD(true);
            }
            else
            {
                OFFSETS.OPTIMIZE_CHUNKS_LOAD(false);
            }
        }

        private void guna2CheckBox347_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox347.Checked)
            {
                OFFSETS.STOP_CHUNKS_LOAD(true);
            }
            else
            {
                OFFSETS.STOP_CHUNKS_LOAD(false);
            }
        }

        private void guna2CheckBox348_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox348.Checked)
            {
                OFFSETS.CREATIVE_INVENTORY_IN_LOBBY(true);
            }
            else
            {
                OFFSETS.CREATIVE_INVENTORY_IN_LOBBY(false);
            }
        }

        private void guna2CheckBox349_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox349.Checked)
            {
                OFFSETS.PERMISSIONS_DESTROY_BLOCKS(true);
            }
            else
            {
                OFFSETS.PERMISSIONS_DESTROY_BLOCKS(false);
            }
        }

        private void guna2CheckBox350_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox350.Checked)
            {
                OFFSETS.SURVIVAL_IN_LOBBY(true);
            }
            else
            {
                OFFSETS.SURVIVAL_IN_LOBBY(false);
            }
        }

        private void guna2CheckBox351_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox351.Checked)
            {
                OFFSETS.GET_CRAFTING_IN_BATTLE_WORLD(true);
            }
            else
            {
                OFFSETS.GET_CRAFTING_IN_BATTLE_WORLD(false);
            }
        }

        private void guna2CheckBox352_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox352.Checked)
            {
                OFFSETS.PLACE_BLOCKS_IN_BATTLE_WORLDS(true);
            }
            else
            {
                OFFSETS.PLACE_BLOCKS_IN_BATTLE_WORLDS(false);
            }
        }

        private void guna2CheckBox353_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox353.Checked)
            {
                OFFSETS.ENABLE_TAKE_EVERYTHING_IN_CHESTS(true);
            }
            else
            {
                OFFSETS.ENABLE_TAKE_EVERYTHING_IN_CHESTS(false);
            }
        }

        private void guna2CheckBox354_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox354.Checked)
            {
                OFFSETS.CAN_SEE_REAL_SKINS_IN_SPECTATOR(true);
            }
            else
            {
                OFFSETS.CAN_SEE_REAL_SKINS_IN_SPECTATOR(false);
            }
        }

        private void guna2CheckBox355_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox355.Checked)
            {
                OFFSETS.STARVED_ALL_PLAYERS_IN_BATTLE_WORLD(true);
            }
            else
            {
                OFFSETS.STARVED_ALL_PLAYERS_IN_BATTLE_WORLD(false);
            }
        }

        private void guna2CheckBox356_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox356.Checked)
            {
                OFFSETS.ALLOW_PORTAL_IN_MINI_GAMES(true);
            }
            else
            {
                OFFSETS.ALLOW_PORTAL_IN_MINI_GAMES(false);
            }
        }

        private void guna2CheckBox357_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox357.Checked)
            {
                OFFSETS.TNT_CAN_DESTROY_BLOCKS_IN_MINI_GAMES(true);
            }
            else
            {
                OFFSETS.TNT_CAN_DESTROY_BLOCKS_IN_MINI_GAMES(false);
            }
        }

        private void guna2CheckBox358_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox358.Checked)
            {
                OFFSETS.BYPASS_CREATIVE_IN_TRUMBLE(true);
            }
            else
            {
                OFFSETS.BYPASS_CREATIVE_IN_TRUMBLE(false);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYING_ALONE(guna2TextBox3.Text);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYING_MULTI(guna2TextBox5.Text);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYER_JOIN(guna2TextBox6.Text);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYER_LEAVE(guna2TextBox7.Text);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            OFFSETS.NAME_CHANGER(guna2TextBox2.Text);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            OFFSETS.NAME_CHANGER_GLITCHED(guna2TextBox4.Text);
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to use it? \n\nYou can add 18 characters for the name works and add (space) as if I want to add Misaki Dev I will put: \n\n (Misaki Dev          ) make space to the maximum you can when it blocked, you can set your name\n\nIf you don't understand, contact me on discord", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("List colors for Name Changer\n\nHere you can change your name with a colors !!\n\nColors:\n0 = Black,  2 = Dark Green, 4 = Dark Red, 6 = Gold, 8 = Dark Gray, a = Green, c = Red, e = Yellow, 1 = Dark Blue, 3 = Dark Aqua, 5 = Dark Purple, 7 = Gray, 9 = Blue, b = Aqua, d = Light Purple, f = White, g = Random Letter\n\nFor use name colors put in text ex: 1Misaki Dev and press (Set Name) your name is now Blue", "List colors Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            OFFSETS.NAME_CHANGER_COLORED(guna2TextBox8.Text);
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            OFFSETS.NAME_CHANGER_LINE(richTextBox1.Text);
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            OFFSETS.BATTLE_WORLD_TELEPORT_TO_LOBBY();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            OFFSETS.BATTLE_WORLDS_TELEPORT_TO_CAVERN();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            OFFSETS.BATTLE_WORLDS_TELEPORT_TO_COVE();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            OFFSETS.BATTLE_WORLD_TELEPORT_TO_CRUCIBLE();
        }

        private void guna2ComboBox32_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox32.SelectedIndex == 0)
            {
                OFFSETS.INDICATOR_DAMAGE_COLORS("0");
            }
            else if (guna2ComboBox32.SelectedIndex == 1)
            {
                OFFSETS.INDICATOR_DAMAGE_COLORS("1");
            }
            else if (guna2ComboBox32.SelectedIndex == 2)
            {
                OFFSETS.INDICATOR_DAMAGE_COLORS("2");
            }
        }

        private void guna2ComboBox34_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox34.SelectedIndex == 0)
            {
                OFFSETS.ENTITY_FUNNY_VISION("0");
            }
            else if (guna2ComboBox34.SelectedIndex == 1)
            {
                OFFSETS.ENTITY_FUNNY_VISION("1");
            }
            else if (guna2ComboBox34.SelectedIndex == 2)
            {
                OFFSETS.ENTITY_FUNNY_VISION("2");
            }
            else if (guna2ComboBox34.SelectedIndex == 3)
            {
                OFFSETS.ENTITY_FUNNY_VISION("3");
            }
            else if (guna2ComboBox34.SelectedIndex == 4)
            {
                OFFSETS.ENTITY_FUNNY_VISION("4");
            }
            else if (guna2ComboBox34.SelectedIndex == 5)
            {
                OFFSETS.ENTITY_FUNNY_VISION("5");
            }
            else if (guna2ComboBox34.SelectedIndex == 6)
            {
                OFFSETS.ENTITY_FUNNY_VISION("6");
            }
            else if (guna2ComboBox34.SelectedIndex == 7)
            {
                OFFSETS.ENTITY_FUNNY_VISION("7");
            }
        }

        private void guna2ComboBox35_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox35.SelectedIndex == 0)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("0");
            }
            else if (guna2ComboBox35.SelectedIndex == 1)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("1");
            }
            else if (guna2ComboBox35.SelectedIndex == 2)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("2");
            }
            else if (guna2ComboBox35.SelectedIndex == 3)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("3");
            }
            else if (guna2ComboBox35.SelectedIndex == 4)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("4");
            }
            else if (guna2ComboBox35.SelectedIndex == 5)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("5");
            }
            else if (guna2ComboBox35.SelectedIndex == 6)
            {
                OFFSETS.ENTITY_FUNNY_VISUAL("6");
            }
        }

        private void guna2ComboBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox36.SelectedIndex == 0)
            {
                OFFSETS.FPS_VALUES("0");
            }
            else if (guna2ComboBox36.SelectedIndex == 1)
            {
                OFFSETS.FPS_VALUES("1");
            }
            else if (guna2ComboBox36.SelectedIndex == 2)
            {
                OFFSETS.FPS_VALUES("2");
            }
            else if (guna2ComboBox36.SelectedIndex == 3)
            {
                OFFSETS.FPS_VALUES("3");
            }
            else if (guna2ComboBox36.SelectedIndex == 4)
            {
                OFFSETS.FPS_VALUES("4");
            }
            else if (guna2ComboBox36.SelectedIndex == 5)
            {
                OFFSETS.FPS_VALUES("5");
            }
            else if (guna2ComboBox36.SelectedIndex == 6)
            {
                OFFSETS.FPS_VALUES("6");
            }
            else if (guna2ComboBox36.SelectedIndex == 7)
            {
                OFFSETS.FPS_VALUES("7");
            }
            else if (guna2ComboBox36.SelectedIndex == 8)
            {
                OFFSETS.FPS_VALUES("8");
            }
            else if (guna2ComboBox36.SelectedIndex == 9)
            {
                OFFSETS.FPS_VALUES("9");
            }
            else if (guna2ComboBox36.SelectedIndex == 10)
            {
                OFFSETS.FPS_VALUES("10");
            }
            else if (guna2ComboBox36.SelectedIndex == 11)
            {
                OFFSETS.FPS_VALUES("11");
            }
            else if (guna2ComboBox36.SelectedIndex == 12)
            {
                OFFSETS.FPS_VALUES("12");
            }
            else if (guna2ComboBox36.SelectedIndex == 13)
            {
                OFFSETS.FPS_VALUES("13");
            }
            else if (guna2ComboBox36.SelectedIndex == 14)
            {
                OFFSETS.FPS_VALUES("14");
            }
            else if (guna2ComboBox36.SelectedIndex == 15)
            {
                OFFSETS.FPS_VALUES("15");
            }
        }

        private void guna2ComboBox37_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox37.SelectedIndex == 0)
            {
                OFFSETS.CLOUD_COLORS("0");
            }
            else if (guna2ComboBox37.SelectedIndex == 1)
            {
                OFFSETS.CLOUD_COLORS("1");
            }
            else if (guna2ComboBox37.SelectedIndex == 2)
            {
                OFFSETS.CLOUD_COLORS("2");
            }
            else if (guna2ComboBox37.SelectedIndex == 3)
            {
                OFFSETS.CLOUD_COLORS("3");
            }
            else if (guna2ComboBox37.SelectedIndex == 4)
            {
                OFFSETS.CLOUD_COLORS("4");
            }
            else if (guna2ComboBox37.SelectedIndex == 5)
            {
                OFFSETS.CLOUD_COLORS("5");
            }
            else if (guna2ComboBox37.SelectedIndex == 6)
            {
                OFFSETS.CLOUD_COLORS("6");
            }
            else if (guna2ComboBox37.SelectedIndex == 7)
            {
                OFFSETS.CLOUD_COLORS("7");
            }
            else if (guna2ComboBox37.SelectedIndex == 8)
            {
                OFFSETS.CLOUD_COLORS("8");
            }
        }

        private void guna2ComboBox38_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox38.SelectedIndex == 0)
            {
                OFFSETS.TIME_SPEED("0");
            }
            else if (guna2ComboBox38.SelectedIndex == 1)
            {
                OFFSETS.TIME_SPEED("1");
            }
            else if (guna2ComboBox38.SelectedIndex == 2)
            {
                OFFSETS.TIME_SPEED("2");
            }
            else if (guna2ComboBox38.SelectedIndex == 3)
            {
                OFFSETS.TIME_SPEED("3");
            }
            else if (guna2ComboBox38.SelectedIndex == 4)
            {
                OFFSETS.TIME_SPEED("4");
            }
            else if (guna2ComboBox38.SelectedIndex == 5)
            {
                OFFSETS.TIME_SPEED("5");
            }
            else if (guna2ComboBox38.SelectedIndex == 6)
            {
                OFFSETS.TIME_SPEED("6");
            }
            else if (guna2ComboBox38.SelectedIndex == 7)
            {
                OFFSETS.TIME_SPEED("7");
            }
            else if (guna2ComboBox38.SelectedIndex == 8)
            {
                OFFSETS.TIME_SPEED("8");
            }
            else if (guna2ComboBox38.SelectedIndex == 9)
            {
                OFFSETS.TIME_SPEED("9");
            }
            else if (guna2ComboBox38.SelectedIndex == 10)
            {
                OFFSETS.TIME_SPEED("10");
            }
        }

        private void guna2ComboBox39_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox39.SelectedIndex == 0)
            {
                OFFSETS.SUN_MOON_SIZE("0");
            }
            else if (guna2ComboBox39.SelectedIndex == 1)
            {
                OFFSETS.SUN_MOON_SIZE("1");
            }
            else if (guna2ComboBox39.SelectedIndex == 2)
            {
                OFFSETS.SUN_MOON_SIZE("2");
            }
            else if (guna2ComboBox39.SelectedIndex == 3)
            {
                OFFSETS.SUN_MOON_SIZE("3");
            }
            else if (guna2ComboBox39.SelectedIndex == 4)
            {
                OFFSETS.SUN_MOON_SIZE("4");
            }
            else if (guna2ComboBox39.SelectedIndex == 5)
            {
                OFFSETS.SUN_MOON_SIZE("5");
            }
            else if (guna2ComboBox39.SelectedIndex == 6)
            {
                OFFSETS.SUN_MOON_SIZE("6");
            }
            else if (guna2ComboBox39.SelectedIndex == 7)
            {
                OFFSETS.SUN_MOON_SIZE("7");
            }
            else if (guna2ComboBox39.SelectedIndex == 8)
            {
                OFFSETS.SUN_MOON_SIZE("8");
            }
        }

        private void guna2ComboBox40_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox40.SelectedIndex == 0)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("0");
            }
            else if (guna2ComboBox40.SelectedIndex == 1)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("1");
            }
            else if (guna2ComboBox40.SelectedIndex == 2)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("2");
            }
            else if (guna2ComboBox40.SelectedIndex == 3)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("3");
            }
            else if (guna2ComboBox40.SelectedIndex == 4)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("4");
            }
            else if (guna2ComboBox40.SelectedIndex == 5)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("5");
            }
            else if (guna2ComboBox40.SelectedIndex == 6)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("6");
            }
            else if (guna2ComboBox40.SelectedIndex == 7)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("7");
            }
            else if (guna2ComboBox40.SelectedIndex == 8)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("8");
            }
            else if (guna2ComboBox40.SelectedIndex == 9)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("9");
            }
            else if (guna2ComboBox40.SelectedIndex == 10)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("10");
            }
            else if (guna2ComboBox40.SelectedIndex == 11)
            {
                OFFSETS.LINES_SELECTED_BLOCKS("11");
            }
        }

        private void guna2ComboBox41_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox41.SelectedIndex == 0)
            {
                OFFSETS.SKY_COLORS("0");
            }
            else if (guna2ComboBox41.SelectedIndex == 1)
            {
                OFFSETS.SKY_COLORS("1");
            }
            else if (guna2ComboBox41.SelectedIndex == 2)
            {
                OFFSETS.SKY_COLORS("2");
            }
            else if (guna2ComboBox41.SelectedIndex == 3)
            {
                OFFSETS.SKY_COLORS("3");
            }
            else if (guna2ComboBox41.SelectedIndex == 4)
            {
                OFFSETS.SKY_COLORS("4");
            }
            else if (guna2ComboBox41.SelectedIndex == 5)
            {
                OFFSETS.SKY_COLORS("5");
            }
            else if (guna2ComboBox41.SelectedIndex == 6)
            {
                OFFSETS.SKY_COLORS("6");
            }
            else if (guna2ComboBox41.SelectedIndex == 7)
            {
                OFFSETS.SKY_COLORS("7");
            }
        }

        private void guna2ComboBox42_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox42.SelectedIndex == 0)
            {
                OFFSETS.TIMECYCLE_V2("0");
            }
            else if (guna2ComboBox42.SelectedIndex == 1)
            {
                OFFSETS.TIMECYCLE_V2("1");
            }
            else if (guna2ComboBox42.SelectedIndex == 2)
            {
                OFFSETS.TIMECYCLE_V2("2");
            }
            else if (guna2ComboBox42.SelectedIndex == 3)
            {
                OFFSETS.TIMECYCLE_V2("3");
            }
            else if (guna2ComboBox42.SelectedIndex == 4)
            {
                OFFSETS.TIMECYCLE_V2("4");
            }
            else if (guna2ComboBox42.SelectedIndex == 5)
            {
                OFFSETS.TIMECYCLE_V2("5");
            }
            else if (guna2ComboBox42.SelectedIndex == 6)
            {
                OFFSETS.TIMECYCLE_V2("6");
            }
            else if (guna2ComboBox42.SelectedIndex == 7)
            {
                OFFSETS.TIMECYCLE_V2("7");
            }
            else if (guna2ComboBox42.SelectedIndex == 8)
            {
                OFFSETS.TIMECYCLE_V2("8");
            }
            else if (guna2ComboBox42.SelectedIndex == 9)
            {
                OFFSETS.TIMECYCLE_V2("9");
            }
            else if (guna2ComboBox42.SelectedIndex == 10)
            {
                OFFSETS.TIMECYCLE_V2("10");
            }
        }

        private void guna2ComboBox43_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox43.SelectedIndex == 0)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("0");
            }
            else if (guna2ComboBox43.SelectedIndex == 1)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("1");
            }
            else if (guna2ComboBox43.SelectedIndex == 2)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("2");
            }
            else if (guna2ComboBox43.SelectedIndex == 3)
            {
                OFFSETS.REMOVE_SHADOW_ENTITY("3");
            }
        }

        private void guna2ComboBox44_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox44.SelectedIndex == 0)
            {
                OFFSETS.GAMEPLAY_COLORS("0");
            }
            else if (guna2ComboBox44.SelectedIndex == 1)
            {
                OFFSETS.GAMEPLAY_COLORS("1");
            }
            else if (guna2ComboBox44.SelectedIndex == 2)
            {
                OFFSETS.GAMEPLAY_COLORS("2");
            }
            else if (guna2ComboBox44.SelectedIndex == 3)
            {
                OFFSETS.GAMEPLAY_COLORS("3");
            }
            else if (guna2ComboBox44.SelectedIndex == 4)
            {
                OFFSETS.GAMEPLAY_COLORS("4");
            }
            else if (guna2ComboBox44.SelectedIndex == 5)
            {
                OFFSETS.GAMEPLAY_COLORS("5");
            }
            else if (guna2ComboBox44.SelectedIndex == 6)
            {
                OFFSETS.GAMEPLAY_COLORS("6");
            }
            else if (guna2ComboBox44.SelectedIndex == 7)
            {
                OFFSETS.GAMEPLAY_COLORS("7");
            }
            else if (guna2ComboBox44.SelectedIndex == 8)
            {
                OFFSETS.GAMEPLAY_COLORS("8");
            }
            else if (guna2ComboBox44.SelectedIndex == 9)
            {
                OFFSETS.GAMEPLAY_COLORS("9");
            }
            else if (guna2ComboBox44.SelectedIndex == 10)
            {
                OFFSETS.GAMEPLAY_COLORS("10");
            }
            else if (guna2ComboBox44.SelectedIndex == 11)
            {
                OFFSETS.GAMEPLAY_COLORS("11");
            }
            else if (guna2ComboBox44.SelectedIndex == 12)
            {
                OFFSETS.GAMEPLAY_COLORS("12");
            }
        }

        private void guna2ComboBox45_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox45.SelectedIndex == 0)
            {
                OFFSETS.ITEMS_SIZE("0");
            }
            else if (guna2ComboBox45.SelectedIndex == 1)
            {
                OFFSETS.ITEMS_SIZE("1");
            }
            else if (guna2ComboBox45.SelectedIndex == 2)
            {
                OFFSETS.ITEMS_SIZE("2");
            }
            else if (guna2ComboBox45.SelectedIndex == 3)
            {
                OFFSETS.ITEMS_SIZE("3");
            }
            else if (guna2ComboBox45.SelectedIndex == 4)
            {
                OFFSETS.ITEMS_SIZE("4");
            }
            else if (guna2ComboBox45.SelectedIndex == 5)
            {
                OFFSETS.ITEMS_SIZE("5");
            }
            else if (guna2ComboBox45.SelectedIndex == 6)
            {
                OFFSETS.ITEMS_SIZE("6");
            }
            else if (guna2ComboBox45.SelectedIndex == 7)
            {
                OFFSETS.ITEMS_SIZE("7");
            }
        }

        private void guna2ComboBox46_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox46.SelectedIndex == 0)
            {
                OFFSETS.WEATHER_STATE("0");
            }
            else if (guna2ComboBox46.SelectedIndex == 1)
            {
                OFFSETS.WEATHER_STATE("1");
            }
            else if (guna2ComboBox46.SelectedIndex == 2)
            {
                OFFSETS.WEATHER_STATE("2");
            }
            else if (guna2ComboBox46.SelectedIndex == 3)
            {
                OFFSETS.WEATHER_STATE("3");
            }
            else if (guna2ComboBox46.SelectedIndex == 4)
            {
                OFFSETS.WEATHER_STATE("4");
            }
            else if (guna2ComboBox46.SelectedIndex == 5)
            {
                OFFSETS.WEATHER_STATE("5");
            }
            else if (guna2ComboBox46.SelectedIndex == 6)
            {
                OFFSETS.WEATHER_STATE("6");
            }
            else if (guna2ComboBox46.SelectedIndex == 7)
            {
                OFFSETS.WEATHER_STATE("7");
            }
            else if (guna2ComboBox46.SelectedIndex == 8)
            {
                OFFSETS.WEATHER_STATE("8");
            }
            else if (guna2ComboBox46.SelectedIndex == 9)
            {
                OFFSETS.WEATHER_STATE("9");
            }
        }

        private void guna2ComboBox47_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox47.SelectedIndex == 0)
            {
                OFFSETS.HUD_COLORS("0");
            }
            else if (guna2ComboBox47.SelectedIndex == 1)
            {
                OFFSETS.HUD_COLORS("1");
            }
            else if (guna2ComboBox47.SelectedIndex == 2)
            {
                OFFSETS.HUD_COLORS("2");
            }
            else if (guna2ComboBox47.SelectedIndex == 3)
            {
                OFFSETS.HUD_COLORS("3");
            }
            else if (guna2ComboBox47.SelectedIndex == 4)
            {
                OFFSETS.HUD_COLORS("4");
            }
            else if (guna2ComboBox47.SelectedIndex == 5)
            {
                OFFSETS.HUD_COLORS("5");
            }
            else if (guna2ComboBox47.SelectedIndex == 6)
            {
                OFFSETS.HUD_COLORS("6");
            }
        }

        private void guna2ComboBox48_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox48.SelectedIndex == 0)
            {
                OFFSETS.HAND_POSITION("0");
            }
            else if (guna2ComboBox48.SelectedIndex == 1)
            {
                OFFSETS.HAND_POSITION("1");
            }
            else if (guna2ComboBox48.SelectedIndex == 2)
            {
                OFFSETS.HAND_POSITION("2");
            }
            else if (guna2ComboBox48.SelectedIndex == 3)
            {
                OFFSETS.HAND_POSITION("3");
            }
            else if (guna2ComboBox48.SelectedIndex == 4)
            {
                OFFSETS.HAND_POSITION("4");
            }
            else if (guna2ComboBox48.SelectedIndex == 5)
            {
                OFFSETS.HAND_POSITION("5");
            }
            else if (guna2ComboBox48.SelectedIndex == 6)
            {
                OFFSETS.HAND_POSITION("6");
            }
        }

        private void guna2ComboBox49_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox49.SelectedIndex == 0)
            {
                OFFSETS.FOV_VALUE("0");
            }
            else if (guna2ComboBox49.SelectedIndex == 1)
            {
                OFFSETS.FOV_VALUE("1");
            }
            else if (guna2ComboBox49.SelectedIndex == 2)
            {
                OFFSETS.FOV_VALUE("2");
            }
            else if (guna2ComboBox49.SelectedIndex == 3)
            {
                OFFSETS.FOV_VALUE("3");
            }
            else if (guna2ComboBox49.SelectedIndex == 4)
            {
                OFFSETS.FOV_VALUE("4");
            }
            else if (guna2ComboBox49.SelectedIndex == 5)
            {
                OFFSETS.FOV_VALUE("5");
            }
            else if (guna2ComboBox49.SelectedIndex == 6)
            {
                OFFSETS.FOV_VALUE("6");
            }
            else if (guna2ComboBox49.SelectedIndex == 7)
            {
                OFFSETS.FOV_VALUE("7");
            }
            else if (guna2ComboBox49.SelectedIndex == 8)
            {
                OFFSETS.FOV_VALUE("8");
            }
            else if (guna2ComboBox49.SelectedIndex == 9)
            {
                OFFSETS.FOV_VALUE("9");
            }
            else if (guna2ComboBox49.SelectedIndex == 10)
            {
                OFFSETS.FOV_VALUE("10");
            }
            else if (guna2ComboBox49.SelectedIndex == 11)
            {
                OFFSETS.FOV_VALUE("11");
            }
        }

        private void guna2ComboBox50_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox50.SelectedIndex == 0)
            {
                OFFSETS.HUD_NEW_COLORS("0");
            }
            else if (guna2ComboBox50.SelectedIndex == 1)
            {
                OFFSETS.HUD_NEW_COLORS("1");
            }
            else if (guna2ComboBox50.SelectedIndex == 2)
            {
                OFFSETS.HUD_NEW_COLORS("2");
            }
            else if (guna2ComboBox50.SelectedIndex == 3)
            {
                OFFSETS.HUD_NEW_COLORS("3");
            }
            else if (guna2ComboBox50.SelectedIndex == 4)
            {
                OFFSETS.HUD_NEW_COLORS("4");
            }
            else if (guna2ComboBox50.SelectedIndex == 5)
            {
                OFFSETS.HUD_NEW_COLORS("5");
            }
            else if (guna2ComboBox50.SelectedIndex == 6)
            {
                OFFSETS.HUD_NEW_COLORS("6");
            }
            else if (guna2ComboBox50.SelectedIndex == 7)
            {
                OFFSETS.HUD_NEW_COLORS("7");
            }
            else if (guna2ComboBox50.SelectedIndex == 8)
            {
                OFFSETS.HUD_NEW_COLORS("8");
            }
            else if (guna2ComboBox50.SelectedIndex == 9)
            {
                OFFSETS.HUD_NEW_COLORS("9");
            }
        }

        private void GunaControlClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://discord.gg/XqjKXrbxak");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://downcraft.xyz");
        }

        private void guna2CheckBox359_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox359.Checked)
            {
                OFFSETS.MAX_PLAYERS_FOR_SMALL_MAPS(true);
            }
            else
            {
                OFFSETS.MAX_PLAYERS_FOR_SMALL_MAPS(false);
            }
        }

        private void guna2ComboBox51_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox51.SelectedIndex == 0)
            {
                OFFSETS.SPAWN_DRAGON_EGGS(false);
                OFFSETS.SPAWN_GIANT_EGGS(false);
                OFFSETS.SPAWN_IRON_GOLEM_EGGS(false);
                OFFSETS.SPAWN_SNOWBALL_EGGS(false);
                OFFSETS.SPAWN_WHITER_EGGS(false);
                OFFSETS.SPAWN_ARMOR_STAND_EGGS(false);
            }
            else if (guna2ComboBox51.SelectedIndex == 1)
            {
                OFFSETS.SPAWN_DRAGON_EGGS(true);
            }
            else if (guna2ComboBox51.SelectedIndex == 2)
            {
                OFFSETS.SPAWN_GIANT_EGGS(true);
            }
            else if (guna2ComboBox51.SelectedIndex == 3)
            {
                OFFSETS.SPAWN_IRON_GOLEM_EGGS(true);
            }
            else if (guna2ComboBox51.SelectedIndex == 4)
            {
                OFFSETS.SPAWN_SNOWBALL_EGGS(true);
            }
            else if (guna2ComboBox51.SelectedIndex == 5)
            {
                OFFSETS.SPAWN_WHITER_EGGS(true);
            }
            else if (guna2ComboBox51.SelectedIndex == 6)
            {
                OFFSETS.SPAWN_ARMOR_STAND_EGGS(true);
            }
        }

        private void guna2ComboBox52_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox52.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("0");
                OFFSETS.CHANGE_NETHER_DIMENSION("0");
                OFFSETS.CHANGE_THE_END_DIMENSION("0");
            }
            else if (guna2ComboBox52.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("1");
            }
            else if (guna2ComboBox52.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("2");
            }
        }

        private void guna2ComboBox53_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox53.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("0");
                OFFSETS.CHANGE_NETHER_DIMENSION("0");
                OFFSETS.CHANGE_THE_END_DIMENSION("0");
            }
            else if (guna2ComboBox53.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_NETHER_DIMENSION("1");
            }
            else if (guna2ComboBox53.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_NETHER_DIMENSION("2");
            }
        }

        private void guna2ComboBox54_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox54.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("0");
                OFFSETS.CHANGE_NETHER_DIMENSION("0");
                OFFSETS.CHANGE_THE_END_DIMENSION("0");
            }
            else if (guna2ComboBox54.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_THE_END_DIMENSION("1");
            }
            else if (guna2ComboBox54.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_THE_END_DIMENSION("2");
            }
        }

        private void guna2ComboBox55_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SELECT OFFSET FOR SWAPPE THE ITEMS
            if (guna2ComboBox55.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("0");
            }
            else if (guna2ComboBox55.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("1");
            }
            else if (guna2ComboBox55.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("2");
            }
            else if (guna2ComboBox55.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("3");
            }
            else if (guna2ComboBox55.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("4");
            }
            else if (guna2ComboBox55.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("5");
            }
            else if (guna2ComboBox55.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("6");
            }
            else if (guna2ComboBox55.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("7");
            }
        }

        private void guna2ComboBox57_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SELECT THE VALUES FOR SWAPPE THE ITEMS
            if (guna2ComboBox57.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("0");
            }
            else if (guna2ComboBox57.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("1");
            }
            else if (guna2ComboBox57.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("2");
            }
            else if (guna2ComboBox57.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("3");
            }
            else if (guna2ComboBox57.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("4");
            }
            else if (guna2ComboBox57.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("5");
            }
            else if (guna2ComboBox57.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("6");
            }
            else if (guna2ComboBox57.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("7");
            }
            else if (guna2ComboBox57.SelectedIndex == 8)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("8");
            }
            else if (guna2ComboBox57.SelectedIndex == 9)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("9");
            }
            else if (guna2ComboBox57.SelectedIndex == 10)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("10");
            }
            else if (guna2ComboBox57.SelectedIndex == 11)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("11");
            }
            else if (guna2ComboBox57.SelectedIndex == 11)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("12");
            }
            else if (guna2ComboBox57.SelectedIndex == 13)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("13");
            }
            else if (guna2ComboBox57.SelectedIndex == 14)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("14");
            }
            else if (guna2ComboBox57.SelectedIndex == 15)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("15");
            }
            else if (guna2ComboBox57.SelectedIndex == 16)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("16");
            }
            else if (guna2ComboBox57.SelectedIndex == 17)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("17");
            }
            else if (guna2ComboBox57.SelectedIndex == 18)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("18");
            }
            else if (guna2ComboBox57.SelectedIndex == 19)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("19");
            }
            else if (guna2ComboBox57.SelectedIndex == 20)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("20");
            }
            else if (guna2ComboBox57.SelectedIndex == 21)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("21");
            }
            else if (guna2ComboBox57.SelectedIndex == 22)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("22");
            }
            else if (guna2ComboBox57.SelectedIndex == 23)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("23");
            }
            else if (guna2ComboBox57.SelectedIndex == 24)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("24");
            }
            else if (guna2ComboBox57.SelectedIndex == 25)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("25");
            }
            else if (guna2ComboBox57.SelectedIndex == 26)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("26");
            }
            else if (guna2ComboBox57.SelectedIndex == 27)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("27");
            }
            else if (guna2ComboBox57.SelectedIndex == 28)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("28");
            }
            else if (guna2ComboBox57.SelectedIndex == 29)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("29");
            }
            else if (guna2ComboBox57.SelectedIndex == 30)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("30");
            }
            else if (guna2ComboBox57.SelectedIndex == 31)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("31");
            }
            else if (guna2ComboBox57.SelectedIndex == 32)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("32");
            }
            else if (guna2ComboBox57.SelectedIndex == 33)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("33");
            }
            else if (guna2ComboBox57.SelectedIndex == 34)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("34");
            }
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            //Swap the items
            PS3.SetMemory(OFFSETS.Offset_Default_Items, OFFSETS.Items_Default_Items);
        }

        private void guna2ComboBox56_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SELECT OFFSET FOR SWAPPE THE ITEMS
            if (guna2ComboBox55.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("0");
            }
            else if (guna2ComboBox55.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("1");
            }
            else if (guna2ComboBox55.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("2");
            }
            else if (guna2ComboBox55.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("3");
            }
            else if (guna2ComboBox55.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("4");
            }
            else if (guna2ComboBox55.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("5");
            }
            else if (guna2ComboBox55.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("6");
            }
            else if (guna2ComboBox55.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("7");
            }
        }

        private void guna2ComboBox59_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SELECT THE VALUES FOR SWAPPE THE ITEMS
            if (guna2ComboBox59.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_VALUES("0");
            }
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            //Swap the block
            PS3.SetMemory(OFFSETS.Offset_Default_Blocks, OFFSETS.Blocks_Default_Blocks);
        }

        private void guna2CheckBox360_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox360.Checked)
            {
                OFFSETS.REMOVE_EFFECT_OPTION(true);
            }
            else
            {
                OFFSETS.REMOVE_EFFECT_OPTION(false);
            }
        }

        #endregion

        #region "SPRX Premium Function"

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            //Start SPRX
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            //Stop SPRX
        }

        #endregion

        #region "Some stuff"

        private void guna2Button24_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Remember to have a image resize to 1291x632 for a better result.");

            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Backgrounds");
            openFileDialog1.Filter = "Images File (*.png)|*.png";
            openFileDialog1.FileName = "Background DownCraft";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Host_Tab.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                            RTE_Tab.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                            NonHost_Tab.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                            Visuals_Tab.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                            MiniGame_Tab.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                            Name_Tab.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

                            guna2GroupBox38.FillColor = Color.Transparent;

                            guna2GroupBox1.FillColor = Color.Transparent;
                            guna2GroupBox2.FillColor = Color.Transparent;
                            guna2GroupBox3.FillColor = Color.Transparent;
                            guna2GroupBox4.FillColor = Color.Transparent;
                            guna2GroupBox7.FillColor = Color.Transparent;
                            guna2GroupBox8.FillColor = Color.Transparent;
                            guna2GroupBox9.FillColor = Color.Transparent;
                            guna2GroupBox31.FillColor = Color.Transparent;
                            guna2GroupBox41.FillColor = Color.Transparent;
                            guna2GroupBox28.FillColor = Color.Transparent;
                            guna2GroupBox37.FillColor = Color.Transparent;
                            guna2GroupBox36.FillColor = Color.Transparent;
                            guna2GroupBox35.FillColor = Color.Transparent;
                            guna2GroupBox5.FillColor = Color.Transparent;
                            guna2GroupBox18.FillColor = Color.Transparent;
                            guna2GroupBox20.FillColor = Color.Transparent;
                            guna2GroupBox6.FillColor = Color.Transparent;
                            guna2GroupBox10.FillColor = Color.Transparent;
                            guna2GroupBox11.FillColor = Color.Transparent;
                            guna2GroupBox12.FillColor = Color.Transparent;
                            guna2GroupBox13.FillColor = Color.Transparent;
                            guna2GroupBox15.FillColor = Color.Transparent;
                            guna2GroupBox14.FillColor = Color.Transparent;
                            guna2GroupBox16.FillColor = Color.Transparent;
                            guna2GroupBox32.FillColor = Color.Transparent;
                            guna2GroupBox17.FillColor = Color.Transparent;
                            guna2GroupBox21.FillColor = Color.Transparent;
                            guna2GroupBox22.FillColor = Color.Transparent;
                            guna2GroupBox23.FillColor = Color.Transparent;
                            guna2GroupBox24.FillColor = Color.Transparent;
                            guna2GroupBox33.FillColor = Color.Transparent;
                            guna2GroupBox30.FillColor = Color.Transparent;
                            guna2GroupBox34.FillColor = Color.Transparent;
                            guna2GroupBox26.FillColor = Color.Transparent;
                            guna2GroupBox25.FillColor = Color.Transparent;
                            guna2GroupBox27.FillColor = Color.Transparent;
                            guna2GroupBox29.FillColor = Color.Transparent;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, can't found or add background images !");
                }
            }
        }

        private void guna2Button23_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button23_Click_2(object sender, EventArgs e)
        {

        }

        private void metroTabPage16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
            if (Offsets.Connected == true)
            {
                FUNCTIONS.DefaultName = PS3.Extension.ReadString(0x3000AD34);

                if (FUNCTIONS.DefaultName == "")
                {
                    FUNCTIONS.DefaultName = PS3.Extension.ReadString(0x3000ABA4);
                }

                if (PS3.Extension.ReadString(0x3100AD34) == "DownCraft SPRX V4") //check if the ID is DownCraft SPRX
                {
                    PS3.SetMemory(0x3200AD34, new byte[] { 0xFF, 0xFF, 0xFF, 0x3F });
                    PS3.SetMemory(0x32F0AD34, new byte[] { 0x02, 0x02, 0x02, 0x02 });
                    PS3.SetMemory(0x32C6AD34, new byte[] { 0x20, 0x20, 0x80, 0x3F });
                    PS3.SetMemory(0x12C6AD34, new byte[] { 0x40, 0x75, 0x20, 0x35 });

                    string[] AVATAR = { "https://pbs.twimg.com/media/Cw6mWuqWIAAQx_5.jpg", "https://imgcloud.pw/images/2019/06/19/yvumaobmgfeb376003c61ff3ba9d.jpg", "https://i.imgur.com/7PdJUhd.jpg", "https://i.imgur.com/kRzV4hu.png" };
                    string[] Emojis = { "🍁", "🌲", "☄️", "⚡️", "❄️", "🔥", "🌪", "🌸", "🌹", "🍣", "🧃", "🌌", "💊", "💉", "🩸", "🔪", "🧸", "🎀", "❤️", "🔰", "🩹" };
                    string RandomAvatar = AVATAR[new Random().Next(0, AVATAR.Length)];
                    string RandomEmojis = Emojis[new Random().Next(0, Emojis.Length)];
                }
                else
                {
                    MessageBox.Show("Sorry, the SPRX is not installed on your Minecraft", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sorry, you need connect the RTM to your PS3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GroupBox31_Click(object sender, EventArgs e)
        {

        }

        private void GunaPanelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            Process.Start("");
        }

        #endregion
    }
}
