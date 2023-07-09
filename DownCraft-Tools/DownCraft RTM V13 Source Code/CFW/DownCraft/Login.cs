using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRpcDemo;
using Flagsec;
using Microsoft.Win32;
using static DownCraft.Functions;
using static MisakiAulait.Misaki;

namespace DownCraft
{
    public partial class Login : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        Functions FUNCTIONS = new Functions();
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        public string User; //Backup of the username

        public Login()
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

        #region "Login Form Load"

        private void Login_Load(object sender, EventArgs e)
        {
            this.GunaPanelTop.MouseDown += this.xMouseDown; //For Move Form
            this.GunaPanelTop.MouseMove += this.xMouseMove; //For Move Form
            this.GunaPanelTop.MouseDown += this.xMouseDown; //For Move Form
            this.GunaPanelTop.MouseMove += this.xMouseMove; //For Move Form

            try
            {
                //AUTO DOWNLOAD NEW
                WebClient webClientUpdate = new WebClient(); //FOR UPDATER

                if (!webClientUpdate.DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGPohIFNlCLTxlfjLSIprT6gBwv0LnfZfEQQlJoU1VSQx7iAB1Puk4pHmajtDHjDDsxxnGFTz5R4z")).Contains("13.1"))
                {
                    if (MessageBox.Show("NEW UPDATE\n\nDownCraft have a new update, download it on the website.", "New Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("DownCraft Server\nDownCraft have detected a problem, check if your internet is disconnected or wait server is maybe offline.\nContact support for report this bug if you can't fix that.", "SERVER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            this.handlers = default(DiscordRpc.EventHandlers); //FOR RPC DISCORD
            DiscordRpc.Initialize("788124721685463063", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("788124721685463063", ref this.handlers, true, null);
            this.presence.details = "Waiting for login..";

            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

            presence.startTimestamp = cur_time;
            this.presence.state = "https://downcraft.xyz";
            this.presence.largeImageKey = "yakui2";
            this.presence.largeImageText = "RTM Starting, waiting for login";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        #endregion

        #region "Login Button"

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            LoginBTN.Text = "Loading..";
            try
            {
                if (Execute("loginAccount", "username=" + Username.Text + "&password=" + Password.Text + "&key=" + "LOL") == 1)
                {
                    Username.Text = Username.Text; //To pass it to any other froms (=global)
                    //same for pass

                    string premiumState = new WebClient().DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRWgsD9xjm0r42W2URP5JTZ+aibL1DYsSKrWJqBF1t/PSE/9nDdAmuy3ug2IyjrMfH+F7opqXGzLZphooOOvRipUw==") + Username.Text);

                    if (premiumState == "PREMIUM")
                    {
                        HWIDReset();
                        GETIP();
                    }

                    else if (premiumState == "BANNED")
                    {
                        MessageBox.Show("You are banned of DownCraft RTM Premium.", "DownCraft RTM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }

                    else if (premiumState == "FREE")
                    {
                        MessageBox.Show("You are a Free Member, you need purchase the Premium.", "DownCraft RTM", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("API is offline, contact Misaki Dev or wait.", "SERVER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginBTN.Text = "Login";
            }
        }

        #endregion

        #region "HWID + Encryptions"
        private static string para3()
        {
            string str = "";
            ManagementObjectCollection.ManagementObjectEnumerator objA = new ManagementObjectSearcher("Select * From Win32_processor").Get().GetEnumerator();
            try
            {
                while (true)
                {
                    if (!objA.MoveNext())
                    {
                        break;
                    }
                    ManagementObject current = (ManagementObject)objA.Current;
                    str = current["ProcessorID"].ToString();
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Dispose();
                }
            }
            ManagementObject obj3 = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            obj3.Get();
            return (str + obj3["VolumeSerialNumber"].ToString());
        }

        //Encrypt Strings
        public static string StringToHex(string hexstring)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char t in hexstring)
            {
                //Note: X for upper, x for lower case letters
                sb.Append(Convert.ToInt32(t).ToString("x"));
            }
            return sb.ToString();
        }


        #endregion

        #region "HWID Reset"

        void HWIDReset()
        {
            try
            {
                string Search = new WebClient().DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRWgsD9xjm0r42W2URP5JTZ+dk9qA18SIJ4EV/Djef89nOkFIihbR8b8gFmuncH/Ubv") + Username.Text);

                if (Search == "RESET")
                {
                    string Change = new WebClient().DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRWgsD9xjm0r42W2URP5JTZ+bH9xZlwfN6X+AyCVzKCY3K7faZIepxpkYMhD1qpUmsc2OdF+x+/uT8=") + Username.Text + "&hwid=" + para3());

                    MessageBox.Show("" + Username.Text + " account reset, you can now use DownCraft for this PC, restart the tool !", "DownCraft RTM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    HWIDAllowed(); //+ Allowed
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible to get / change HWID, contact Misaki Dev !");
                Application.Exit();
            }
        }

        #endregion

        #region "Void HWID Is Allowed"
        void HWIDAllowed()
        {
            string HWID1 = para3();
            try
            {
                WebClient HWID = new WebClient();
                string secure = HWID.DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRWgsD9xjm0r42W2URP5JTZ+dk9qA18SIJ4EV/Djef89nOkFIihbR8b8gFmuncH/Ubv") + Username.Text);

                if (secure == HWID1)
                {
                    AllowAccess();
                }
                else
                {
                    MessageBox.Show("This account is registered to a another PC.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("API is offline, contact Misaki DEV or wait.", "SERVER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        #endregion

        #region "AllowAccess"

        void AllowAccess()
        {
            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");
            string country = new WebClient().DownloadString("http://ipinfo.io/country");
            string region = new WebClient().DownloadString("https://ipinfo.io/region");

            //check last time 
            string premiumState = new WebClient().DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRWgsD9xjm0r42W2URP5JTZ+aibL1DYsSKrWJqBF1t/PSE/9nDdAmuy3ug2IyjrMfH+F7opqXGzLZphooOOvRipUw==") + Username.Text);
            if (premiumState == "PREMIUM")
            {
                User = Username.Text; //Send USERNAME in functions

                FUNCTIONS.CheckedUserInDB(User);
                string LINK = Decrypt("ME3ncj2HpTExlTZ7h2KDSwnnZxQKCKVyim6EzFcFEyOuJZATF4Axh+aqItb3OBpGX5TnVAAZueaE05kgzfalmcYs14Z6Ho04fSbAHE2aPQfJ2jbCGNsAF+dPwWDdlVeiwXyHBELEybCQMCHVIVnOhMn6ANNGQYfD0OtnHC6duLXqU8tbERUoDNaFRBQ0+QmJeMDxlCaD9ko6EqLLTcYlYw1lE2EkpTYT77rVgekJv8MghnEF+x7cl4Jwq7lqY9o/vdSyvJmO6tyyj4iTXQ+oK33u3+2ihfcEigChbN2SUWMCO8VvS0H2zBSvyNoq5WbYgQh7Dq845Y8=");
                FUNCTIONS.WebHook(LINK, "DownCraft Log", "https://m.media-amazon.com/images/I/81eGwpF5WEL._SS500_.jpg", "```Login from user: " + Username.Text + "\nwith IP: " + externalip + " \nCountry: " + country + "Region: " + region + "```");

                MessageBox.Show("Welcome " + Username.Text + " To DownCraft RTM Premium.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 YES = new Form1();
                YES.Show();
                this.Hide();
            }
            else
            {
                Application.Exit();
            }
        }

        #endregion

        #region "Get Last IP + Send New"

        void GETIP()
        {
            try
            {
                string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");

                string GET = new WebClient().DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRWgsD9xjm0r42W2URP5JTZ+fHMSoQIcHvhqLkrmuP/1y8FGfDd7D7vTF0rjd3PISvhwLaVbY3uJ4M=") + Username.Text + "");
                string SEND = new WebClient().DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRWgsD9xjm0r42W2URP5JTZ+axSra7Nqk/Ezxc7+8rB6Kn8AvjDny8SpKoFnWUP0i0C") + Username.Text + "&IP=" + externalip + "");
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible to get / change IP, contact Misaki Dev !");
                Application.Exit();
            }
        }



        #endregion

        #region "Some APIs"
        //====================================END OF API===========================================//

        //The main function
        //1 level

        public static int Execute(string action, string args)
        {

            WebClient requests = new WebClient();
            string url = Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGP1Mf2gQI5WW+SM9SOyQjw676Srbau3hpQ0fHmhLCkQMtCCSJDW9Se+yY1nGXHv+WRGY4XoeOMxTxZwwkFVQC7o/oVoP7QIGSGgvV21gxZhg17Lop/zemEfkwe6mPjJ3UvEF6zgQll8XJBHemDSj3R3LQiJfud2/fW5ASIiDXuRW5Z5TTEHc5DU="); //the real
            string urlaction = "?details=" + action;
            string urlargs = "&" + args;
            string buildurl = url + urlaction + urlargs;

            string response = requests.DownloadString(buildurl);
            if (response == null)
            {
                return 0;
            }

            if (!response.StartsWith("GETLOGS57")) //START FOR WORKING LOGIN ON API
            {
                CheckError(response);
                return 0;
            }

            return 1;
        }

        public static void RaiseError(string error)
        {
            MessageBox.Show(error, "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static int CheckError(string error)
        {
            Dictionary<string, string> Errors = new Dictionary<string, string>();
            Errors.Add("MISSING_PARAMETERS", "Missing parameters");
            Errors.Add("INVALID_KEY", "The registration key is not valid");
            Errors.Add("USERNAME_TOO_SHORT", "Your username is too short");
            Errors.Add("PASSWORD_TOO_SHORT", "Your password is too short");
            Errors.Add("USERNAME_TAKEN", "The username you choose is already taken");
            Errors.Add("PASSWORDS_NOT_MATCH", "Passwords do not match");
            Errors.Add("USER_BANNED", "You are banned.");
            Errors.Add("NO_ACTION", "No action");
            Errors.Add("NOT_ENOUGH_PRIVILEGES", "You do not have enough privileges");
            Errors.Add("INVALID_CREDENTIALS", "Wrong username or password, try again.");
            Errors.Add("KEY_IS_NOW_CORRECT", "Sorry, you can't login to DownCraft Premium");

            if (!error.StartsWith("RESULT")) //START ERROR LOGS
            {
                RaiseError(error);
                return 0;
            }

            string message = "Undefined error";
            string[] array = error.Split(':');
            if (array.Length == 2 && Errors.ContainsKey(array[1]))
            {
                string key = array[1];
                message = Errors[key];
            }

            RaiseError(message);
            return 1;
        }



        #endregion

        private void GunaControlClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
