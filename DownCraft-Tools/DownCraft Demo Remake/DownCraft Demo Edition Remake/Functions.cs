using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
using ForNiegil;

namespace DownCraft_Demo_Edition_Remake
{
    public class Functions
    {
        PS3API PS3 = new PS3API();


        #region "Send Webhook Discord"
        public void SEND_WEBHOOK(string token, string name, string picture, string message)
        {
            Webhook hook = new Webhook(token);
            hook.Name = name;
            hook.ProfilePictureUrl = picture;

            hook.SendMessage(message);
        }

        #endregion
    }
}
