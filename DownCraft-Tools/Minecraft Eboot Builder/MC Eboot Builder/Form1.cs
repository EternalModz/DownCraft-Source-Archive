using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Input;
using System.Diagnostics;
using System.Net;
using DiscordRpcDemo;

namespace MC_Eboot_Builder
{
    public partial class Form1 : Form
    {
        static string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Config\FILE.txt");
        string content = File.ReadAllText(path, Encoding.UTF8);

        string TMP = Path.GetTempPath() + "MINECRAFT";
        const string MAKE = "make.exe";
        string BATFILE = "HFW.bat";
        public static string MINECRAFT = "BLES_EBOOT.ELF";

        BinaryWriter bn;
        SaveFileDialog sv;

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        public static Point newpoint = new Point();
        public static int x;
        public static int y;

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

        struct Offset
        {
            public static uint GOD_MODE = 0x4A2021;
            public static uint INSTANT_DAMAGE = 0x393FF0;
            public static uint KNOCKBACK = 0x394018;
            public static uint ANTI_KNOCKBACK = 0x394018;
            public static uint INSTANT_KILL = 0x19C411;
            public static uint WATER_JUMP = 0x39BD68;
            public static uint INFINITE_PICK_UP = 0x214B13;
            public static uint FAST_BOW = 0xEB4C5;
            public static uint ALL_PLAYERS_FAST_MINE = 0xFE0C4;
            public static uint ALL_PLAYERS_FAST_SPEED = 0x4568B6;
            public static uint SUPER_SPEED = 0x39BD49;
            public static uint DISABLE_MOBS = 0x4519E4;
            public static uint FIRE_CREEPER_EXPLODE = 0x1BC894;
            public static uint JUMP_SPEED = 0x39A999;
            public static uint MULTI_JUMP = 0x21790B;
            public static uint SUPER_JUMP = 0x39A77C;
            public static uint AUTO_JUMP = 0xAF1BAC;
            public static uint REACH_ENTITY_SURVIVAL = 0xA85FC1;
            public static uint REACH_ENTITY_CREATIVE = 0xA85FB9;
            public static uint REACH_BLOCK_SURVIVAL = 0xB251DC;
            public static uint REACH_BLOCK_CREATIVE = 0xB251D8;
            public static uint INSTANT_MINE = 0xADB090;
            public static uint INFINITE_CRAFT = 0x97871F;
            public static uint JUMP_FORWARD = 0x39A999;
            public static uint CAM_DOWN_R3 = 0x4A1D60;
            public static uint TOGGLE_SPRINT = 0xAF1DEC;
            public static uint NAME_OVER_HEAD = 0xAC8158;
            public static uint XRAY = 0xA89154;
            public static uint SHOW_ARMOR = 0x8FB5F0;
            public static uint FROST_WALKER = 0x208A4F;
            public static uint INSTANT_HIT = 0xADBED4;
            public static uint NO_COLISSION = 0x1230;
            public static uint FOV = 0x14B670C;
            public static uint SKY_COLORS1 = 0x400734;
            public static uint SKY_COLORS2 = 0x400738;
            public static uint HUD_COLORS = 0x30DAAD64;
            public static uint MAX_PICK_UP_ITEMS = 0x300AD4;
            public static uint NIGHT_VISION = 0xA8A6C8;
            public static uint KILL_AURA = 0x223290;
            public static uint GUN_ITEMS = 0x14B6880;
            public static uint CAN_FLY = 0xAF2378;
            public static uint ITEMS_ID1 = 0x2F97C8;
            public static uint ITEMS_ID2 = 0x2F97B8;
            public static uint FREEZE_PARTICLES = 0xADE7E8;
            public static uint ESP_ENTITY = 0xAC5A5C;
            public static uint INFINITE_BLOCK = 0xF673F;
            public static uint BEST_SKY1 = 0x400738;
            public static uint BEST_SKY2 = 0x37C658;
            public static uint DRIFT_BOAT = 0x2178E4;
            public static uint NO_SLOW_DOWN = 0x39FB60;
            public static uint BETTER_TIME = 0xA8A6DC;
            public static uint NO_COLISSION_BYPASS = 0x2171B0;
            public static uint FAST_SENSIBILITY = 0xAAA948;
            public static uint WALL_HACK = 0xA88F50;
            public static uint FLAT_BLOCK = 0x824FF;
            public static uint BLOCK_HAND_UP = 0x82507;
            public static uint SMOKE_LOBBY = 0xB14177;
            public static uint UNFAIR_ATTACK = 0xADBED4;
            public static uint ALLOW_ITEMS_ON_HEAD = 0x418704;
            public static uint AIR_TO_WATER = 0x1C7FCC;
            public static uint MULTI_JUMP_V2 = 0x3A000A;
            public static uint ALL_PLAYERS_LEFT_HAND = 0x150F2F0;
            public static uint ENTITY_TO_BABY = 0x38F52F;
            public static uint ALL_PLAYERS_SUFFOCATE = 0x21FDC8;
            public static uint ROTATION_360_HEAD1 = 0x214FD4;
            public static uint ROTATION_360_HEAD2 = 0x214FD8;
            public static uint VELOCITY_X = 0x2235C8;
            public static uint VELOCITY_Y = 0x2235CC;
            public static uint VELOCITY_Z = 0x2235D0;
            public static uint TNT_EXPLODE_RADIUS = 0x50E0D0;
            public static uint REAL_JUMP_ANIMATION = 0x14B6728;
            public static uint FLYING_POTIONS_GRAVITY = 0x64FB60;
            public static uint STOP_BLOCK_GRAVITY = 0x236A2C;
            public static uint NO_WEB_HAX = 0x224F9F;
            public static uint FLY_OR_RUN_ON_SNEAK = 0xAF142B;
            public static uint AUTO_LADDER = 0x3974F3;
            public static uint ENTITY_GOD_MODE = 0x393F6C;
            public static uint ROBLOX_ANIMATION = 0x2241D0;
            public static uint WATER_NO_SLOW_DOWN = 0x39A964;
            public static uint JUMP_IN_LAVA = 0x39A940;
            public static uint FREEZE_ALL_ENTITY = 0x399FE8;
            public static uint AUTO_KILL_PLAYERS = 0x398678;
            public static uint DISABLE_PORTALS = 0x2279E4;
        }

        void ExecCmd(string file, string arg)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = file;
            pro.StartInfo.WorkingDirectory = TMP;
            pro.StartInfo.Arguments = arg;
            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pro.StartInfo.CreateNoWindow = true;
            pro.StartInfo.UseShellExecute = false;
            pro.Start();
            pro.WaitForExit();
        }
        void PatchOffset(uint Offset, byte[] value)
        {
            bn.Seek((int)Offset, SeekOrigin.Begin);
            bn.Write(value);
            bn.Flush();
            Application.DoEvents();
        }
        void PatchOffset(uint Offset, byte value)
        {
            bn.Seek((int)Offset, SeekOrigin.Begin);
            bn.Write(value);
            bn.Flush();
            Application.DoEvents();
        }
        void LoadFiles(string path, byte[] fileBytes)
        {
            File.WriteAllBytes(path, fileBytes);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (content == "0")
            {
                MINECRAFT = "NPEB_EBOOT.ELF";
                label4.Text = "NPEB";
            }
            if (content == "1")
            {
                MINECRAFT = "BLES_EBOOT.ELF";
                label4.Text = "BLES";
            }
            if (content == "2")
            {
                MINECRAFT = "NPUB_EBOOT.ELF";
                label4.Text = "NPUB";
            }
            if (content == "3")
            {
                MINECRAFT = "BLUS_EBOOT.ELF";
                label4.Text = "BLUS";
            }

            this.panel1.MouseDown += this.xMouseDown; //For Move Form
            this.panel1.MouseMove += this.xMouseMove; //For Move Form
            this.panel1.MouseDown += this.xMouseDown; //For Move Form
            this.panel1.MouseMove += this.xMouseMove; //For Move Form

            if (!Directory.Exists(TMP))
            {
                Directory.CreateDirectory(TMP);
            }

            TMP += "\\";

            if (!File.Exists(TMP + MAKE))
            {
                LoadFiles(TMP + MAKE, Properties.Resources.make);
            }
            if (!File.Exists(TMP + MINECRAFT))
            {
                LoadFiles(TMP + MINECRAFT, Properties.Resources.EBOOT);
            }
            if (!File.Exists(TMP + BATFILE))
            {
                using (var tw = new StreamWriter(TMP + BATFILE, true))
                {
                    String UserName = Environment.UserName;
                    string desktop = @"C:\Users\" + UserName + @"\Desktop\EBOOT.BIN";

                    tw.WriteLine(@"cd C:\Users\" + UserName + @"\ps3tools\ps3tools\tools\");
                    tw.WriteLine("PKG_ContentID.exe --resign " + '"' + desktop + '"');
                }
            }

            try
            {
                WebClient webClientUpdate = new WebClient();

                if (!webClientUpdate.DownloadString("https://pastebin.com/raw/sgemtAh4").Contains("3.0"))
                {
                    if (MessageBox.Show("New update ? maybe ?", "DownCraft EBOOT Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("API is offline, wait 30 min - 1 hours.", "SERVER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("870258146923401236", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("870258146923401236", ref this.handlers, true, null);
            this.presence.details = "Waiting for build a EBOOT...";

            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

            presence.startTimestamp = cur_time;
            this.presence.state = "DownCraft EBOOT Build for Minecraft";
            this.presence.largeImageKey = "me";
            this.presence.largeImageText = "Made by Misaki (Miisaakii)\nhttps://github.com/Miisaakii/";

            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(TMP, true);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            try
            {
                bn = new BinaryWriter(File.Open(TMP + MINECRAFT, FileMode.Open, FileAccess.Write));

                if (siticoneCheckBox1.Checked)
                {
                    PatchOffset(Offset.GOD_MODE, new byte[] { 0x80 });
                }
                if (siticoneCheckBox2.Checked)
                {
                    PatchOffset(Offset.INSTANT_DAMAGE, new byte[] { 0x40, 0x80 });
                }
                if (siticoneCheckBox3.Checked)
                {
                    PatchOffset(Offset.KNOCKBACK, new byte[] { 0x40, 0x80 });
                }
                if (siticoneCheckBox4.Checked)
                {
                    PatchOffset(Offset.ANTI_KNOCKBACK, new byte[] { 0x00, 0x00 });
                }
                if (siticoneCheckBox5.Checked)
                {
                    PatchOffset(Offset.INSTANT_KILL, new byte[] { 0xE0, 0x28, 0x90 });
                }
                if (siticoneCheckBox6.Checked)
                {
                    PatchOffset(Offset.WATER_JUMP, new byte[] { 0x3F, 0xF9, 0x99, 0x99 });
                }
                if (siticoneCheckBox7.Checked)
                {
                    PatchOffset(Offset.INFINITE_PICK_UP, new byte[] { 0x00 });
                }
                if (siticoneCheckBox8.Checked)
                {
                    PatchOffset(Offset.FAST_BOW, new byte[] { 0xE0, 0x18, 0x18 });
                }
                if (siticoneCheckBox9.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_FAST_MINE, new byte[] { 0xFF, 0xE0, 0x28, 0x90 });
                }
                if (siticoneCheckBox10.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_FAST_SPEED, new byte[] { 0x58 });
                }
                if (siticoneCheckBox11.Checked)
                {
                    PatchOffset(Offset.SUPER_SPEED, new byte[] { 0xFF, 0xFF, 0xFF });
                }
                if (siticoneCheckBox12.Checked)
                {
                    PatchOffset(Offset.DISABLE_MOBS, new byte[] { 0x40 });
                }
                if (siticoneCheckBox13.Checked)
                {
                    PatchOffset(Offset.FIRE_CREEPER_EXPLODE, new byte[] { 0x39, 0x40, 0x00, 0x10 });
                }
                if (siticoneCheckBox14.Checked)
                {
                    PatchOffset(Offset.JUMP_SPEED, new byte[] { 0xA0 });
                }
                if (siticoneCheckBox15.Checked)
                {
                    PatchOffset(Offset.MULTI_JUMP, new byte[] { 0x14 });
                }
                if (siticoneCheckBox16.Checked)
                {
                    PatchOffset(Offset.SUPER_JUMP, new byte[] { 0x3F, 0x47, 0x7F, 0x42 });
                }
                if (siticoneCheckBox17.Checked)
                {
                    PatchOffset(Offset.AUTO_JUMP, new byte[] { 0x41 });
                }
                if (siticoneCheckBox18.Checked)
                {
                    PatchOffset(Offset.REACH_ENTITY_CREATIVE, new byte[] { 0x80 });
                    PatchOffset(Offset.REACH_ENTITY_SURVIVAL, new byte[] { 0x80 });
                    PatchOffset(Offset.REACH_BLOCK_CREATIVE, new byte[] { 0x43, 0xA0, 0x00, 0x00 });
                    PatchOffset(Offset.REACH_BLOCK_SURVIVAL, new byte[] { 0x43, 0xA0, 0x00, 0x00 });
                }
                if (siticoneCheckBox19.Checked)
                {
                    PatchOffset(Offset.INSTANT_MINE, new byte[] { 0xBF });
                }
                if (siticoneCheckBox20.Checked)
                {
                    PatchOffset(Offset.INFINITE_CRAFT, new byte[] { 0x01 });
                }
                if (siticoneCheckBox21.Checked)
                {
                    PatchOffset(Offset.JUMP_FORWARD, new byte[] { 0x80 });
                }
                if (siticoneCheckBox21.Checked)
                {
                    PatchOffset(Offset.CAM_DOWN_R3, new byte[] { 0xFC, 0x00, 0xF8, 0x90 });
                }
                if (siticoneCheckBox23.Checked)
                {
                    PatchOffset(Offset.TOGGLE_SPRINT, new byte[] { 0x40, 0x82 });
                }
                if (siticoneCheckBox24.Checked)
                {
                    PatchOffset(Offset.NAME_OVER_HEAD, new byte[] { 0x4C });
                }
                if (siticoneCheckBox25.Checked)
                {
                    PatchOffset(Offset.XRAY, new byte[] { 0xFC, 0x80, 0x30, 0x90 });
                }
                if (siticoneCheckBox26.Checked)
                {
                    PatchOffset(Offset.SHOW_ARMOR, new byte[] { 0x38, 0x80, 0x00, 0x01 });
                }
                if (siticoneCheckBox27.Checked)
                {
                    PatchOffset(Offset.FROST_WALKER, new byte[] { 0x10 });
                }
                if (siticoneCheckBox28.Checked)
                {
                    PatchOffset(Offset.INSTANT_HIT, new byte[] { 0xFF });
                }
                if (siticoneCheckBox29.Checked)
                {
                    PatchOffset(Offset.NO_COLISSION, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
                }
                if (guna2ComboBox47.SelectedIndex == 0)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x80 });
                }
                if (guna2ComboBox47.SelectedIndex == 1)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x70 });
                }
                if (guna2ComboBox47.SelectedIndex == 2)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x60 });
                }
                if (guna2ComboBox47.SelectedIndex == 3)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x50 });
                }
                if (guna2ComboBox47.SelectedIndex == 4)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x40 });
                }
                if (guna2ComboBox47.SelectedIndex == 5)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x30 });
                }
                if (guna2ComboBox47.SelectedIndex == 6)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x25 });
                }
                if (guna2ComboBox47.SelectedIndex == 7)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x20 });
                }
                if (guna2ComboBox47.SelectedIndex == 8)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x15 });
                }
                if (guna2ComboBox47.SelectedIndex == 9)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x10 });
                }
                if (guna2ComboBox47.SelectedIndex == 10)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x1F, 0x80 });
                }
                if (guna2ComboBox47.SelectedIndex == 11)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0xFF });
                }
                if (guna2ComboBox1.SelectedIndex == 0)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x40, 0xC0 });
                    PatchOffset(Offset.SKY_COLORS2, new byte[] { 0x3F, 0x80 });
                }
                if (guna2ComboBox1.SelectedIndex == 1)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x40, 0x50 });
                }
                if (guna2ComboBox1.SelectedIndex == 2)
                {
                    PatchOffset(Offset.SKY_COLORS2, new byte[] { 0xBF, 0x80 });
                }
                if (guna2ComboBox1.SelectedIndex == 3)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x49, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 4)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x42, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 5)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x43, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 6)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0xF0, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 7)
                {
                    PatchOffset(Offset.SKY_COLORS2, new byte[] { 0x3F, 0xF0 });
                }
                if (guna2ComboBox2.SelectedIndex == 0)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 1)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 2)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 3)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0xFF, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 4)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x5F, 0x80, 0x00, 0x00, 0x5F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 5)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x8F, 0x80, 0x00, 0x00, 0x8F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (siticoneCheckBox29.Checked)
                {
                    PatchOffset(Offset.NIGHT_VISION, new byte[] { 0x7F });
                }
                if (siticoneCheckBox30.Checked)
                {
                    PatchOffset(Offset.MAX_PICK_UP_ITEMS, new byte[] { 0x41 });
                }
                if (siticoneCheckBox31.Checked)
                {
                    PatchOffset(Offset.KILL_AURA, new byte[] { 0xFF });
                }
                if (siticoneCheckBox32.Checked)
                {
                    PatchOffset(Offset.GUN_ITEMS, new byte[] { 0x3F, 0xFF });
                }
                if (siticoneCheckBox33.Checked)
                {
                    PatchOffset(Offset.CAN_FLY, new byte[] { 0x40 });
                }
                if (siticoneCheckBox34.Checked)
                {
                    PatchOffset(Offset.ITEMS_ID1, new byte[] { 0x40 });
                    PatchOffset(Offset.ITEMS_ID2, new byte[] { 0x40 });
                }
                if (siticoneCheckBox35.Checked)
                {
                    PatchOffset(Offset.FREEZE_PARTICLES, new byte[] { 0x40 });
                }
                if (siticoneCheckBox36.Checked)
                {
                    PatchOffset(Offset.ESP_ENTITY, new byte[] { 0x6F, 0xFF });
                }
                if (siticoneCheckBox37.Checked)
                {
                    PatchOffset(Offset.INFINITE_BLOCK, new byte[] { 0x00 });
                }
                if (siticoneCheckBox38.Checked)
                {
                    PatchOffset(Offset.BEST_SKY1, new byte[] { 0x3F, 0x10 });
                    PatchOffset(Offset.BEST_SKY2, new byte[] { 0x7F });
                }
                if (siticoneCheckBox39.Checked)
                {
                    PatchOffset(Offset.DRIFT_BOAT, new byte[] { 0x41 });
                }
                if (siticoneCheckBox40.Checked)
                {
                    PatchOffset(Offset.NO_SLOW_DOWN, new byte[] { 0x4F });
                }
                if (siticoneCheckBox41.Checked)
                {
                    PatchOffset(Offset.BETTER_TIME, new byte[] { 0x0F });
                }
                if (siticoneCheckBox42.Checked)
                {
                    PatchOffset(Offset.NO_COLISSION_BYPASS, new byte[] { 0x40 });
                }
                if (siticoneCheckBox43.Checked)
                {
                    PatchOffset(Offset.FAST_SENSIBILITY, new byte[] { 0x42, 0xFF });
                }
                if (siticoneCheckBox44.Checked)
                {
                    PatchOffset(Offset.WALL_HACK, new byte[] { 0x40 });
                }
                if (siticoneCheckBox45.Checked)
                {
                    PatchOffset(Offset.FLAT_BLOCK, new byte[] { 0x01 });
                }
                if (siticoneCheckBox46.Checked)
                {
                    PatchOffset(Offset.BLOCK_HAND_UP, new byte[] { 0x01 });
                }
                if (siticoneCheckBox47.Checked)
                {
                    PatchOffset(Offset.SMOKE_LOBBY, new byte[] { 0x01 });
                }
                if (siticoneCheckBox48.Checked)
                {
                    PatchOffset(Offset.UNFAIR_ATTACK, new byte[] { 0xBE });
                }
                if (siticoneCheckBox49.Checked)
                {
                    PatchOffset(Offset.ALLOW_ITEMS_ON_HEAD, new byte[] { 0x40 });
                }
                if (siticoneCheckBox50.Checked)
                {
                    PatchOffset(Offset.AIR_TO_WATER, new byte[] { 0x40 });
                }
                if (siticoneCheckBox51.Checked)
                {
                    PatchOffset(Offset.MULTI_JUMP_V2, new byte[] { 0x02 });
                }
                if (siticoneCheckBox52.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_LEFT_HAND, new byte[] { 0x30, 0x01, 0x87, 0xF0 });
                }
                if (siticoneCheckBox53.Checked)
                {
                    PatchOffset(Offset.ENTITY_TO_BABY, new byte[] { 0x01 });
                }
                if (siticoneCheckBox54.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_SUFFOCATE, new byte[] { 0x4E, 0x80, 0x00, 0x20 });
                }
                if (siticoneCheckBox55.Checked)
                {
                    PatchOffset(Offset.ROTATION_360_HEAD1, new byte[] { 0xC3 });
                    PatchOffset(Offset.ROTATION_360_HEAD2, new byte[] { 0x43 });
                }
                if (siticoneCheckBox56.Checked)
                {
                    PatchOffset(Offset.VELOCITY_X, new byte[] { 0xD3, 0x23, 0x01, 0x30 });
                    PatchOffset(Offset.VELOCITY_Y, new byte[] { 0xD8, 0x43, 0x01, 0x38 });
                    PatchOffset(Offset.VELOCITY_Z, new byte[] { 0xD3, 0x63, 0x01, 0x40 });
                }
                if (siticoneCheckBox57.Checked)
                {
                    PatchOffset(Offset.VELOCITY_X, new byte[] { 0xD9, 0x23, 0x01, 0x30 });
                    PatchOffset(Offset.VELOCITY_Y, new byte[] { 0xD8, 0x43, 0x01, 0x38 });
                    PatchOffset(Offset.VELOCITY_Z, new byte[] { 0xD9, 0x63, 0x01, 0x40 });
                }
                if (siticoneCheckBox58.Checked)
                {
                    PatchOffset(Offset.TNT_EXPLODE_RADIUS, new byte[] { 0x42, 0x80, 0x00, 0x00 });
                }
                if (siticoneCheckBox59.Checked)
                {
                    PatchOffset(Offset.REAL_JUMP_ANIMATION, new byte[] { 0xBF });
                }
                if (siticoneCheckBox60.Checked)
                {
                    PatchOffset(Offset.FLYING_POTIONS_GRAVITY, new byte[] { 0x2D });
                }
                if (siticoneCheckBox61.Checked)
                {
                    PatchOffset(Offset.STOP_BLOCK_GRAVITY, new byte[] { 0xFF });
                }
                if (siticoneCheckBox62.Checked)
                {
                    PatchOffset(Offset.NO_WEB_HAX, new byte[] { 0x00 });
                }
                if (siticoneCheckBox63.Checked)
                {
                    PatchOffset(Offset.FLY_OR_RUN_ON_SNEAK, new byte[] { 0x01 });
                }
                if (siticoneCheckBox64.Checked)
                {
                    PatchOffset(Offset.AUTO_LADDER, new byte[] { 0x01 });
                }
                if (siticoneCheckBox65.Checked)
                {
                    PatchOffset(Offset.ENTITY_GOD_MODE, new byte[] { 0x40 });
                }
                if (siticoneCheckBox66.Checked)
                {
                    PatchOffset(Offset.ROBLOX_ANIMATION, new byte[] { 0xC3 });
                }
                if (siticoneCheckBox67.Checked)
                {
                    PatchOffset(Offset.WATER_NO_SLOW_DOWN, new byte[] { 0x3F, 0x7C, 0xCC, 0xCD });
                }
                if (siticoneCheckBox68.Checked)
                {
                    PatchOffset(Offset.JUMP_IN_LAVA, new byte[] { 0x3F, 0xF4, 0x7A, 0xE1 });
                }
                if (siticoneCheckBox69.Checked)
                {
                    PatchOffset(Offset.FREEZE_ALL_ENTITY, new byte[] { 0x4E, 0x80, 0x00, 0x20 });
                }
                if (siticoneCheckBox70.Checked)
                {
                    PatchOffset(Offset.DISABLE_PORTALS, new byte[] { 0x38, 0x60, 0x00, 0x00 });
                }

                bn.Close();

                String UserName = Environment.UserName;
                sv = new SaveFileDialog();
                sv.InitialDirectory = @"C:\Users\" + UserName + @"\Desktop";
                sv.FileName = "EBOOT";
                sv.Filter = "EBOOT.BIN|*.BIN";

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    ExecCmd(TMP + MAKE, TMP + MINECRAFT + " " + sv.FileName);
                }

                MessageBox.Show(String.Format("The eboot has been created\nFile Size {0}\nFile Location {1}\nFile Extension {2}", FormatBytes(File.ReadAllBytes(sv.FileName).Length, 1, true), sv.FileName, Path.GetExtension(sv.FileName)));

                File.Delete(TMP + MINECRAFT);
                LoadFiles(TMP + MINECRAFT, Properties.Resources.EBOOT);
            }
            catch(Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = " B";

            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                newBytes /= 1048576;
                byteType = " MB";
            }
            else
            {
                newBytes /= 1073741824;
                byteType = " GB";
            }
            if (decimalPlaces > 0)
                formatString += ":0.";
            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";
            formatString += "}";
            if (showByteType)
                formatString += byteType;

            return string.Format(formatString, newBytes);
        }

        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDlg.Color;
                siticoneGroupBox1.CustomBorderColor = colorDlg.Color;
                siticoneGroupBox2.CustomBorderColor = colorDlg.Color;
                siticoneGroupBox3.CustomBorderColor = colorDlg.Color;
                siticoneGroupBox4.CustomBorderColor = colorDlg.Color;
                siticoneGroupBox5.CustomBorderColor = colorDlg.Color;
                siticoneButton1.FillColor = colorDlg.Color;
                siticoneButton2.FillColor = colorDlg.Color;
                siticoneButton3.FillColor = colorDlg.Color;
                siticoneButton4.FillColor = colorDlg.Color;
                siticoneButton5.FillColor = colorDlg.Color;
                siticoneButton6.FillColor = colorDlg.Color;
                siticoneButton7.FillColor = colorDlg.Color;
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DownCraft EBOOT Builder Made By Misaki\n\nI made it bc i was lazy, you can make your own custom / modded EBOOT with this little tool, if the EBOOT return your a error while you start the game, try to convert it bc it's auto convet it like a debug eboot for CFW console.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Config\FILE.txt"));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fi.Open(FileMode.Truncate)))
            {
                file.Write("0");
            }

            MessageBox.Show("You have select to build a NPEB EBOOT, the program will closed for apply the change, restart it and then build your EBOOT.", "EBOOT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Config\FILE.txt"));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fi.Open(FileMode.Truncate)))
            {
                file.Write("1");
            }

            MessageBox.Show("You have select to build a BLES EBOOT, the program will closed for apply the change, restart it and then build your EBOOT.", "EBOOT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Config\FILE.txt"));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fi.Open(FileMode.Truncate)))
            {
                file.Write("2");
            }

            MessageBox.Show("You have select to build a NPUB EBOOT, the program will closed for apply the change, restart it and then build your EBOOT.", "EBOOT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Config\FILE.txt"));
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fi.Open(FileMode.Truncate)))
            {
                file.Write("3");
            }

            MessageBox.Show("You have select to build a BLUS EBOOT, the program will closed for apply the change, restart it and then build your EBOOT.", "EBOOT SELECTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\ps3tools";

                if (!Directory.Exists(path))
                {
                    MessageBox.Show("Sorry, but you need to have Adols Tools installed on your PC for continue to build your EBOOT FOR HFW.\nPlease install it and try again.", "EBOOT BUILDER HEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                bn = new BinaryWriter(File.Open(TMP + MINECRAFT, FileMode.Open, FileAccess.Write));

                if (siticoneCheckBox1.Checked)
                {
                    PatchOffset(Offset.GOD_MODE, new byte[] { 0x80 });
                }
                if (siticoneCheckBox2.Checked)
                {
                    PatchOffset(Offset.INSTANT_DAMAGE, new byte[] { 0x40, 0x80 });
                }
                if (siticoneCheckBox3.Checked)
                {
                    PatchOffset(Offset.KNOCKBACK, new byte[] { 0x40, 0x80 });
                }
                if (siticoneCheckBox4.Checked)
                {
                    PatchOffset(Offset.ANTI_KNOCKBACK, new byte[] { 0x00, 0x00 });
                }
                if (siticoneCheckBox5.Checked)
                {
                    PatchOffset(Offset.INSTANT_KILL, new byte[] { 0xE0, 0x28, 0x90 });
                }
                if (siticoneCheckBox6.Checked)
                {
                    PatchOffset(Offset.WATER_JUMP, new byte[] { 0x3F, 0xF9, 0x99, 0x99 });
                }
                if (siticoneCheckBox7.Checked)
                {
                    PatchOffset(Offset.INFINITE_PICK_UP, new byte[] { 0x00 });
                }
                if (siticoneCheckBox8.Checked)
                {
                    PatchOffset(Offset.FAST_BOW, new byte[] { 0xE0, 0x18, 0x18 });
                }
                if (siticoneCheckBox9.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_FAST_MINE, new byte[] { 0xFF, 0xE0, 0x28, 0x90 });
                }
                if (siticoneCheckBox10.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_FAST_SPEED, new byte[] { 0x58 });
                }
                if (siticoneCheckBox11.Checked)
                {
                    PatchOffset(Offset.SUPER_SPEED, new byte[] { 0xFF, 0xFF, 0xFF });
                }
                if (siticoneCheckBox12.Checked)
                {
                    PatchOffset(Offset.DISABLE_MOBS, new byte[] { 0x40 });
                }
                if (siticoneCheckBox13.Checked)
                {
                    PatchOffset(Offset.FIRE_CREEPER_EXPLODE, new byte[] { 0x39, 0x40, 0x00, 0x10 });
                }
                if (siticoneCheckBox14.Checked)
                {
                    PatchOffset(Offset.JUMP_SPEED, new byte[] { 0xA0 });
                }
                if (siticoneCheckBox15.Checked)
                {
                    PatchOffset(Offset.MULTI_JUMP, new byte[] { 0x14 });
                }
                if (siticoneCheckBox16.Checked)
                {
                    PatchOffset(Offset.SUPER_JUMP, new byte[] { 0x3F, 0x47, 0x7F, 0x42 });
                }
                if (siticoneCheckBox17.Checked)
                {
                    PatchOffset(Offset.AUTO_JUMP, new byte[] { 0x41 });
                }
                if (siticoneCheckBox18.Checked)
                {
                    PatchOffset(Offset.REACH_ENTITY_CREATIVE, new byte[] { 0x80 });
                    PatchOffset(Offset.REACH_ENTITY_SURVIVAL, new byte[] { 0x80 });
                    PatchOffset(Offset.REACH_BLOCK_CREATIVE, new byte[] { 0x43, 0xA0, 0x00, 0x00 });
                    PatchOffset(Offset.REACH_BLOCK_SURVIVAL, new byte[] { 0x43, 0xA0, 0x00, 0x00 });
                }
                if (siticoneCheckBox19.Checked)
                {
                    PatchOffset(Offset.INSTANT_MINE, new byte[] { 0xBF });
                }
                if (siticoneCheckBox20.Checked)
                {
                    PatchOffset(Offset.INFINITE_CRAFT, new byte[] { 0x01 });
                }
                if (siticoneCheckBox21.Checked)
                {
                    PatchOffset(Offset.JUMP_FORWARD, new byte[] { 0x80 });
                }
                if (siticoneCheckBox21.Checked)
                {
                    PatchOffset(Offset.CAM_DOWN_R3, new byte[] { 0xFC, 0x00, 0xF8, 0x90 });
                }
                if (siticoneCheckBox23.Checked)
                {
                    PatchOffset(Offset.TOGGLE_SPRINT, new byte[] { 0x40, 0x82 });
                }
                if (siticoneCheckBox24.Checked)
                {
                    PatchOffset(Offset.NAME_OVER_HEAD, new byte[] { 0x4C });
                }
                if (siticoneCheckBox25.Checked)
                {
                    PatchOffset(Offset.XRAY, new byte[] { 0xFC, 0x80, 0x30, 0x90 });
                }
                if (siticoneCheckBox26.Checked)
                {
                    PatchOffset(Offset.SHOW_ARMOR, new byte[] { 0x38, 0x80, 0x00, 0x01 });
                }
                if (siticoneCheckBox27.Checked)
                {
                    PatchOffset(Offset.FROST_WALKER, new byte[] { 0x10 });
                }
                if (siticoneCheckBox28.Checked)
                {
                    PatchOffset(Offset.INSTANT_HIT, new byte[] { 0xFF });
                }
                if (siticoneCheckBox29.Checked)
                {
                    PatchOffset(Offset.NO_COLISSION, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
                }
                if (guna2ComboBox47.SelectedIndex == 0)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x80 });
                }
                if (guna2ComboBox47.SelectedIndex == 1)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x70 });
                }
                if (guna2ComboBox47.SelectedIndex == 2)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x60 });
                }
                if (guna2ComboBox47.SelectedIndex == 3)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x50 });
                }
                if (guna2ComboBox47.SelectedIndex == 4)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x40 });
                }
                if (guna2ComboBox47.SelectedIndex == 5)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x30 });
                }
                if (guna2ComboBox47.SelectedIndex == 6)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x25 });
                }
                if (guna2ComboBox47.SelectedIndex == 7)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x20 });
                }
                if (guna2ComboBox47.SelectedIndex == 8)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x15 });
                }
                if (guna2ComboBox47.SelectedIndex == 9)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0x10 });
                }
                if (guna2ComboBox47.SelectedIndex == 10)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x1F, 0x80 });
                }
                if (guna2ComboBox47.SelectedIndex == 11)
                {
                    PatchOffset(Offset.FOV, new byte[] { 0x3F, 0xFF });
                }
                if (guna2ComboBox1.SelectedIndex == 0)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x40, 0xC0 });
                    PatchOffset(Offset.SKY_COLORS2, new byte[] { 0x3F, 0x80 });
                }
                if (guna2ComboBox1.SelectedIndex == 1)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x40, 0x50 });
                }
                if (guna2ComboBox1.SelectedIndex == 2)
                {
                    PatchOffset(Offset.SKY_COLORS2, new byte[] { 0xBF, 0x80 });
                }
                if (guna2ComboBox1.SelectedIndex == 3)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x49, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 4)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x42, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 5)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0x43, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 6)
                {
                    PatchOffset(Offset.SKY_COLORS1, new byte[] { 0xF0, 0xC0 });
                }
                if (guna2ComboBox1.SelectedIndex == 7)
                {
                    PatchOffset(Offset.SKY_COLORS2, new byte[] { 0x3F, 0xF0 });
                }
                if (guna2ComboBox2.SelectedIndex == 0)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 1)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 2)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 3)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x3F, 0xFF, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 4)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x5F, 0x80, 0x00, 0x00, 0x5F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (guna2ComboBox2.SelectedIndex == 5)
                {
                    PatchOffset(Offset.HUD_COLORS, new byte[] { 0x8F, 0x80, 0x00, 0x00, 0x8F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 });
                }
                if (siticoneCheckBox29.Checked)
                {
                    PatchOffset(Offset.NIGHT_VISION, new byte[] { 0x7F });
                }
                if (siticoneCheckBox30.Checked)
                {
                    PatchOffset(Offset.MAX_PICK_UP_ITEMS, new byte[] { 0x41 });
                }
                if (siticoneCheckBox31.Checked)
                {
                    PatchOffset(Offset.KILL_AURA, new byte[] { 0xFF });
                }
                if (siticoneCheckBox32.Checked)
                {
                    PatchOffset(Offset.GUN_ITEMS, new byte[] { 0x3F, 0xFF });
                }
                if (siticoneCheckBox33.Checked)
                {
                    PatchOffset(Offset.CAN_FLY, new byte[] { 0x40 });
                }
                if (siticoneCheckBox34.Checked)
                {
                    PatchOffset(Offset.ITEMS_ID1, new byte[] { 0x40 });
                    PatchOffset(Offset.ITEMS_ID2, new byte[] { 0x40 });
                }
                if (siticoneCheckBox35.Checked)
                {
                    PatchOffset(Offset.FREEZE_PARTICLES, new byte[] { 0x40 });
                }
                if (siticoneCheckBox36.Checked)
                {
                    PatchOffset(Offset.ESP_ENTITY, new byte[] { 0x6F, 0xFF });
                }
                if (siticoneCheckBox37.Checked)
                {
                    PatchOffset(Offset.INFINITE_BLOCK, new byte[] { 0x00 });
                }
                if (siticoneCheckBox38.Checked)
                {
                    PatchOffset(Offset.BEST_SKY1, new byte[] { 0x3F, 0x10 });
                    PatchOffset(Offset.BEST_SKY2, new byte[] { 0x7F });
                }
                if (siticoneCheckBox39.Checked)
                {
                    PatchOffset(Offset.DRIFT_BOAT, new byte[] { 0x41 });
                }
                if (siticoneCheckBox40.Checked)
                {
                    PatchOffset(Offset.NO_SLOW_DOWN, new byte[] { 0x4F });
                }
                if (siticoneCheckBox41.Checked)
                {
                    PatchOffset(Offset.BETTER_TIME, new byte[] { 0x0F });
                }
                if (siticoneCheckBox42.Checked)
                {
                    PatchOffset(Offset.NO_COLISSION_BYPASS, new byte[] { 0x40 });
                }
                if (siticoneCheckBox43.Checked)
                {
                    PatchOffset(Offset.FAST_SENSIBILITY, new byte[] { 0x42, 0xFF });
                }
                if (siticoneCheckBox44.Checked)
                {
                    PatchOffset(Offset.WALL_HACK, new byte[] { 0x40 });
                }
                if (siticoneCheckBox45.Checked)
                {
                    PatchOffset(Offset.FLAT_BLOCK, new byte[] { 0x01 });
                }
                if (siticoneCheckBox46.Checked)
                {
                    PatchOffset(Offset.BLOCK_HAND_UP, new byte[] { 0x01 });
                }
                if (siticoneCheckBox47.Checked)
                {
                    PatchOffset(Offset.SMOKE_LOBBY, new byte[] { 0x01 });
                }
                if (siticoneCheckBox48.Checked)
                {
                    PatchOffset(Offset.UNFAIR_ATTACK, new byte[] { 0xBE });
                }
                if (siticoneCheckBox49.Checked)
                {
                    PatchOffset(Offset.ALLOW_ITEMS_ON_HEAD, new byte[] { 0x40 });
                }
                if (siticoneCheckBox50.Checked)
                {
                    PatchOffset(Offset.AIR_TO_WATER, new byte[] { 0x40 });
                }
                if (siticoneCheckBox51.Checked)
                {
                    PatchOffset(Offset.MULTI_JUMP_V2, new byte[] { 0x02 });
                }
                if (siticoneCheckBox52.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_LEFT_HAND, new byte[] { 0x30, 0x01, 0x87, 0xF0 });
                }
                if (siticoneCheckBox53.Checked)
                {
                    PatchOffset(Offset.ENTITY_TO_BABY, new byte[] { 0x01 });
                }
                if (siticoneCheckBox54.Checked)
                {
                    PatchOffset(Offset.ALL_PLAYERS_SUFFOCATE, new byte[] { 0x4E, 0x80, 0x00, 0x20 });
                }
                if (siticoneCheckBox55.Checked)
                {
                    PatchOffset(Offset.ROTATION_360_HEAD1, new byte[] { 0xC3 });
                    PatchOffset(Offset.ROTATION_360_HEAD2, new byte[] { 0x43 });
                }
                if (siticoneCheckBox56.Checked)
                {
                    PatchOffset(Offset.VELOCITY_X, new byte[] { 0xD3, 0x23, 0x01, 0x30 });
                    PatchOffset(Offset.VELOCITY_Y, new byte[] { 0xD8, 0x43, 0x01, 0x38 });
                    PatchOffset(Offset.VELOCITY_Z, new byte[] { 0xD3, 0x63, 0x01, 0x40 });
                }
                if (siticoneCheckBox57.Checked)
                {
                    PatchOffset(Offset.VELOCITY_X, new byte[] { 0xD9, 0x23, 0x01, 0x30 });
                    PatchOffset(Offset.VELOCITY_Y, new byte[] { 0xD8, 0x43, 0x01, 0x38 });
                    PatchOffset(Offset.VELOCITY_Z, new byte[] { 0xD9, 0x63, 0x01, 0x40 });
                }
                if (siticoneCheckBox58.Checked)
                {
                    PatchOffset(Offset.TNT_EXPLODE_RADIUS, new byte[] { 0x42, 0x80, 0x00, 0x00 });
                }
                if (siticoneCheckBox59.Checked)
                {
                    PatchOffset(Offset.REAL_JUMP_ANIMATION, new byte[] { 0xBF });
                }
                if (siticoneCheckBox60.Checked)
                {
                    PatchOffset(Offset.FLYING_POTIONS_GRAVITY, new byte[] { 0x2D });
                }
                if (siticoneCheckBox61.Checked)
                {
                    PatchOffset(Offset.STOP_BLOCK_GRAVITY, new byte[] { 0xFF });
                }
                if (siticoneCheckBox62.Checked)
                {
                    PatchOffset(Offset.NO_WEB_HAX, new byte[] { 0x00 });
                }
                if (siticoneCheckBox63.Checked)
                {
                    PatchOffset(Offset.FLY_OR_RUN_ON_SNEAK, new byte[] { 0x01 });
                }
                if (siticoneCheckBox64.Checked)
                {
                    PatchOffset(Offset.AUTO_LADDER, new byte[] { 0x01 });
                }
                if (siticoneCheckBox65.Checked)
                {
                    PatchOffset(Offset.ENTITY_GOD_MODE, new byte[] { 0x40 });
                }
                if (siticoneCheckBox66.Checked)
                {
                    PatchOffset(Offset.ROBLOX_ANIMATION, new byte[] { 0xC3 });
                }
                if (siticoneCheckBox67.Checked)
                {
                    PatchOffset(Offset.WATER_NO_SLOW_DOWN, new byte[] { 0x3F, 0x7C, 0xCC, 0xCD });
                }
                if (siticoneCheckBox68.Checked)
                {
                    PatchOffset(Offset.JUMP_IN_LAVA, new byte[] { 0x3F, 0xF4, 0x7A, 0xE1 });
                }
                if (siticoneCheckBox69.Checked)
                {
                    PatchOffset(Offset.FREEZE_ALL_ENTITY, new byte[] { 0x4E, 0x80, 0x00, 0x20 });
                }
                if (siticoneCheckBox70.Checked)
                {
                    PatchOffset(Offset.DISABLE_PORTALS, new byte[] { 0x38, 0x60, 0x00, 0x00 });
                }

                bn.Close();

                String UserName = Environment.UserName;
                sv = new SaveFileDialog();
                sv.InitialDirectory = @"C:\Users\" + UserName + @"\Desktop";
                sv.FileName = "EBOOT";
                sv.Filter = "EBOOT.BIN|*.BIN";

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    ExecCmd(TMP + MAKE, TMP + MINECRAFT + " " + sv.FileName);
                }

                MessageBox.Show("EBOOT HEN has been created, resigner for HFW started...");

                File.Delete(TMP + MINECRAFT);
                LoadFiles(TMP + MINECRAFT, Properties.Resources.EBOOT);

                Process.Start(TMP + BATFILE);

                MessageBox.Show("EBOOT HFW done !");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }
    }
}
