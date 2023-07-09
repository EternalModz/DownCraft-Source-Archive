#region "Library"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
using DiscordRpcDemo;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Net.Http;

#endregion

namespace DownCraft
{
    public class Functions
    {
        public string DefaultName;
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        public static bool CanUseMenu = false;
        public static string Username;

        public void SetDiscordRPC(string details, string state, string LargeImageText)
        {
            string[] IMG = { "misaki1", "misaki2", "misaki3", "misaki4", "misaki5", "misaki6", "misaki7" };
            string RandomIMG = IMG[new Random().Next(0, IMG.Length)];

            this.handlers = default(DiscordRpc.EventHandlers);
            this.handlers = default(DiscordRpc.EventHandlers);
            this.presence.details = details;

            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

            presence.startTimestamp = cur_time;
            this.presence.state = state;
            this.presence.largeImageKey = RandomIMG;
            this.presence.largeImageText = LargeImageText;
            DiscordRpc.UpdatePresence(ref this.presence);
        }
    }
}