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

namespace DownCraft
{
    public class Functions
    {
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        public PS3API PS3 = new PS3API();
        public string LINK = Decrypt("ME3ncj2HpTExlTZ7h2KDSwnnZxQKCKVyim6EzFcFEyOuJZATF4Axh+aqItb3OBpGX5TnVAAZueaE05kgzfalmeSk5o7AnSVLslT2Kj32lzPcLCo2uuFwZm9TSoY+djVIFAQqSY7KVCZ+oLywFfXpWAdGS0bO+9vAHF06KXNiX+6/SMhDXn+muB7eUAagxuLRdBxTi5q37jvEnMvKSqZ+geJfJVkR/2UxdH1VgIt/+uZZyUHTcLstr12eQvs3OVXm1PasVwE8Ge1Qi2rBO6me/2fAOyHxMFgdJrcgFubVEqor2UDaiWvCaSmXb3JsSJbTd6q/30CHCEg=");

        public static string UserLogin; //Backup of the User Login
        public string DefaultName; //Backup of the PSN Name

        //USED FOR WEBHOOK
        public void WebHook(string token, string name, string picture, string message)
        {
            Webhook hook = new Webhook(token);
            hook.Name = name;
            hook.ProfilePictureUrl = picture;

            hook.SendMessage(message);
        }


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

                            this.handlers = default(DiscordRpc.EventHandlers); //FOR RPC DISCORD
                            DiscordRpc.Initialize("788124721685463063", ref this.handlers, true, null);
                            this.handlers = default(DiscordRpc.EventHandlers);
                            DiscordRpc.Initialize("788124721685463063", ref this.handlers, true, null);
                            this.presence.details = "Connected To PS3";

                            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
                            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

                            presence.startTimestamp = cur_time;
                            this.presence.state = "https://downcraft.xyz";
                            this.presence.largeImageKey = "yakui2";
                            this.presence.largeImageText = "DownCraft Premium\nUpdate V13\nhttps://downcraft.xyz\nMade By Misakiii\nPSN: " + DefaultName + "";
                            DiscordRpc.UpdatePresence(ref this.presence);

                            SendLogsAttach();

                            if (DefaultName == "")
                            {
                                DefaultName = PS3.Extension.ReadString(0x3000ABA4); //name of profils player
                            }

                            WebHook(LINK, "DownCraft Logs", "https://i.imgur.com/3QuB23Z.jpeg", "```ini\n [User: " + DefaultName + " have connect + attach the RTM DownCraft Premium Edition.]```");
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

        #endregion


        public void SendLogsAttach()
        {
            string SendLOG = new WebClient().DownloadString(Decrypt("ME3ncj2HpTExlTZ7h2KDS//t7jPwNK+TL8eG8rRihYJZc+KUbd1nGPohIFNlCLTxlfjLSIprT6gBwv0LnfZfEQQlJoU1VSQxkNEM50a4OsshawVUilITw/4n2o1wpd7T7svB0GIEBM2wMmcue23IyUaaiGWprhp+gZYjSHbNdfY="));
        }

        public void CheckedUserInDB(string Username) //check if username is registered on database
        {
            try
            {
                string db = new WebClient().DownloadString("https://downcraft.xyz/MisakiPrivateFiles/APIServer/4DZ8D0DZQDDZHZFE0EF5E4/server.php?details=userInDB&username=" + Username);
                if (db == "Yes")
                {

                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("DownCraft Server\nDownCraft have detected a problem, check if your internet is disconnected or wait server is maybe offline.\nContact support for report this bug if you can't fix that.", "SERVER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public void Disconnect()
        {
            PS3.DisconnectTarget();
        }


    }
}