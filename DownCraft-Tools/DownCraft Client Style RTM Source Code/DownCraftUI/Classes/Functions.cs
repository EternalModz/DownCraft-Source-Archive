using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownCraftUI.Classes
{
    public class Functions
    {
        public static int x;
        public static int y;

        public static Color getTheme;
        public int RED = 65;
        public int GREEN = 87;
        public int BLUE = 208;

        public void ClickSound()
        {
            SoundPlayer audio = new SoundPlayer(DownCraftUI.Properties.Resources.click);
            audio.Play();
        }

        public static bool BadProcess = true;
        public static void CheckBadProcess()
        {
            while (BadProcess == true)
            {
                try
                {
                    bool process1 = Process.GetProcessesByName("processhacker").Any();
                    bool process2 = Process.GetProcessesByName("taskmgr").Any();
                    bool process3 = Process.GetProcessesByName("ida").Any();
                    bool process4 = Process.GetProcessesByName("ida64").Any();
                    bool process5 = Process.GetProcessesByName("dnspy").Any();
                    bool process6 = Process.GetProcessesByName("hxd").Any();
                    bool process7 = Process.GetProcessesByName("procmon64").Any();
                    bool process8 = Process.GetProcessesByName("codecracker").Any();
                    bool process9 = Process.GetProcessesByName("idag").Any();
                    bool process10 = Process.GetProcessesByName("idaw").Any();
                    bool process11 = Process.GetProcessesByName("idaq").Any();
                    bool process12 = Process.GetProcessesByName("idau").Any();
                    bool process13 = Process.GetProcessesByName("scylla").Any();
                    bool process14 = Process.GetProcessesByName("de4dot").Any();
                    bool process15 = Process.GetProcessesByName("de4dotmodded").Any();
                    bool process16 = Process.GetProcessesByName("protection_id").Any();
                    bool process17 = Process.GetProcessesByName("ollydbg").Any();
                    bool process18 = Process.GetProcessesByName("x64dbg").Any();
                    bool process19 = Process.GetProcessesByName("x32dbg").Any();
                    bool process20 = Process.GetProcessesByName("x96dbg").Any();
                    bool process21 = Process.GetProcessesByName("x64netdumper").Any();
                    bool process22 = Process.GetProcessesByName("petools").Any();
                    bool process23 = Process.GetProcessesByName("windbg").Any();
                    bool process24 = Process.GetProcessesByName("reshacker").Any();
                    bool process25 = Process.GetProcessesByName("simpleassembly").Any();
                    bool process26 = Process.GetProcessesByName("process hacker").Any();
                    bool process27 = Process.GetProcessesByName("process monitor").Any();
                    bool process28 = Process.GetProcessesByName("qt5core").Any();
                    bool process29 = Process.GetProcessesByName("importREC").Any();
                    bool process30 = Process.GetProcessesByName("immunitydebugger").Any();
                    bool process31 = Process.GetProcessesByName("megadumper").Any();
                    bool process32 = Process.GetProcessesByName("cheatengine-x86_64").Any();
                    bool process33 = Process.GetProcessesByName("dump").Any();
                    bool process34 = Process.GetProcessesByName("dbgclr").Any();
                    bool process35 = Process.GetProcessesByName("wireshark").Any();
                    bool process36 = Process.GetProcessesByName("Fiddler Everywhere").Any();
                    bool process37 = Process.GetProcessesByName("FiddlerCap").Any();
                    bool process38 = Process.GetProcessesByName("Fiddler").Any();

                    if (process1 || process2 || process3 || process4 || process5 || process6 || process7 || process8 || process9 || process10 || process11 || process12 || process13 || process14 || process15 || process16 || process17 || process18 || process19 || process20 || process21 || process22 || process23 || process24 || process25 || process26 || process27 || process28 || process29 || process30 || process31 || process32 || process33 || process34 || process35 || process36 || process37 || process38)
                    {
                        System.Environment.Exit(1);
                    }
                }
                catch
                {

                }
            }
        }
    }
}
