#region "Library"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
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
        private string RPC_ID = "914481604032864276";

        public static bool CanUseMenu = false;
        public static string Username;
    }
}