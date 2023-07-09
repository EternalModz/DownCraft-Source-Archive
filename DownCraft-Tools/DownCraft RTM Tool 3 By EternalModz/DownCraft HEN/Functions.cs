#region "Library"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
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
        public PS3API PS3 = new PS3API();
        public string DefaultName; //Backup of the PSN Name

        #region "Connect & Attach"

        public void Connect()
        {
            if (MessageBox.Show("Press 'YES' for HEN & CCAPI and press 'NO' for TMAPI", "DownCraft Premium", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            string externalip = new WebClient().DownloadString("http://ipinfo.io/ip");

                            MessageBox.Show("Attached to PS3 !", "DownCraft Premium", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DefaultName = PS3.Extension.ReadString(0x3000AD34); //////NAME SLOT OF MINECRAFT

                            //RPC DISCORD
                            string[] IMG = { "zero", "rena", "owo", "misaki", "misaaa", "misa", "kiss", "fuck", "yakui" };
                            string RandomIMG = IMG[new Random().Next(0, IMG.Length)];

                            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
                            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

                            if (DefaultName == "")
                            {
                                DefaultName = PS3.Extension.ReadString(0x3000ABA4); //name of profils player
                            }

                            string[] AVATAR = { "https://pbs.twimg.com/media/Cw6mWuqWIAAQx_5.jpg", "https://imgcloud.pw/images/2019/06/19/yvumaobmgfeb376003c61ff3ba9d.jpg", "https://i.imgur.com/7PdJUhd.jpg", "https://i.imgur.com/kRzV4hu.png" };
                            string RandomAvatar = AVATAR[new Random().Next(0, AVATAR.Length)];

                            string[] Emojis = { "🍁", "🌲", "☄️", "⚡️", "❄️", "🔥", "🌪", "🌸", "🌹", "🍣", "🧃", "🌌", "💊", "💉", "🩸", "🔪", "🧸", "🎀", "❤️", "🔰", "🩹" };
                            string RandomEmojis = Emojis[new Random().Next(0, Emojis.Length)];

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