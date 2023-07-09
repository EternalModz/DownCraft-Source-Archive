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
using static MisakiAulait.Misaki;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using Flagsec;

#endregion

namespace DownCraft
{
    public class Functions
    {
        public string DefaultName;
        private string RPC_ID = Decrypt("e2t4MuBhxjdAHxkLgtq1WqeiYnOFh0nQpJwAoqk4lHHpbWyJNv517A==");
        public string LOGS_CONNECT = Decrypt("ME3ncj2HpTExlTZ7h2KDSwnnZxQKCKVyBTx4PXD0u9yzxfzspn+bAs+4jy6CyHlXc+SgqS5D7dx1Oieg5nwuotV0tc0sdIl1wLcussJ6QTh4UJHBBsLI1buOQsdkcEaz7zu/QszU0PJd80CwWcZhgU58gQL5YuQvqi6A1sLjOVOg0iiViGcEPqaYXk5VTpyNIZPKxNdqmg8BKJnyfeJSsqXJrBBCXe7HyPOzGdqAW3KxAmDwmJ9abfJqL3Fg3H27Vdr7Yc+ALCLHDYfsTXKI4a31khapUX7KY544eN6Gig/ehYDLIXBxtDLG/tacDdbEKq+vZiBLHiw=");
        public string LOGS_LOGIN = Decrypt("ME3ncj2HpTExlTZ7h2KDSwnnZxQKCKVyBTx4PXD0u9yzxfzspn+bAs+4jy6CyHlXc+SgqS5D7dx1Oieg5nwuotV0tc0sdIl1ZsjdB31Q04q7OqsnnH3kLel43Y5qta6iXmsFht9e3maVcrfphYkJ1aZ+V8Ldkk7aYkUkOW6D4XH/dAbFAK6hOlo8GU4PfgPynEWCuC/XWaJhvy0KK5GjqQLM7UvlXSyUiqVhRf0+8/5uMq9oaknRPJe5ujGtybvmHEP4OJaqR1u2TbBUtsYXaHYeXZHZZSzc7isjQiDIhIM2b8zkjqt3SMlcKRaG5SyuKWqLq92zO4M=");
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        public static bool CanUseMenu = false;
        public static string Username;

        public void SetDiscordRPC(string details, string state, string LargeImageText)
        {
            string[] IMG = { "misaki1", "misaki2", "misaki3", "misaki4", "misaki5", "misaki6", "misaki7" };
            string RandomIMG = IMG[new Random().Next(0, IMG.Length)];

            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize(RPC_ID, ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize(RPC_ID, ref this.handlers, true, null);
            this.presence.details = details;

            System.DateTime epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            long cur_time = (long)(System.DateTime.UtcNow - epoch).TotalSeconds;

            presence.startTimestamp = cur_time;
            this.presence.state = state;
            this.presence.largeImageKey = RandomIMG;
            this.presence.largeImageText = LargeImageText;
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        public void Send_WebHook(string link, string name, string picture, string message)
        {
            Webhook hook = new Webhook(link);
            hook.Name = name;
            hook.ProfilePictureUrl = picture;

            hook.SendMessage(message);
        }
    }
}