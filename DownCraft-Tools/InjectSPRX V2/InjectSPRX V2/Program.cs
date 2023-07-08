#region "Library"
using Colorful;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Console = Colorful.Console;
#endregion

namespace injectSPRX
{
    internal class Program
    {
        #region "Variables"

        public static string debug_folder = AppDomain.CurrentDomain.BaseDirectory + "\\debug";

        WebClient web = new WebClient();
        public static void ConsoleEmpty() { Console.Write("\n"); }
        public static async Task Pause() { await Task.Delay(1000); }

        public static string filename = null;
        public static string ps3IP = null;
        public static string injectPath = null;
        public static string FileForInject = null;
        public static string ResignHEN = null;
        public static bool sprx_injected = false;
        public static bool ps3IP_found = false;

        //debug part
        public static string file_debug = null;
        public static string MAKE = "make.exe";
        public static string UNSELF = "unself.exe";

        #endregion
        #region "Get Infos"
        public static void getInfos()
        {
            try
            {
                string text = AppDomain.CurrentDomain.BaseDirectory + "\\settings.txt";

                if (File.Exists(text))
                {
                    string[] array = File.ReadAllLines(text);
                    if (array[0].EndsWith("useLoader=true"))
                    {
                        ps3IP = array[1];
                        filename = array[2];
                        FileForInject = array[3];
                        injectPath = array[4];
                        ResignHEN = array[5];
                    }
                }
            }
            catch(Exception ex)
            {

            }     
        }

        #endregion
        #region "inject SPRX"
        public static void LoadFiles(string path, byte[] fileBytes)
        {
            File.WriteAllBytes(path, fileBytes);
        }

        public static string CMD(string command)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process proc = new Process())
            {
                proc.StartInfo = procStartInfo;
                proc.Start();

                string output = proc.StandardOutput.ReadToEnd();

                if (string.IsNullOrEmpty(output))
                    output = proc.StandardError.ReadToEnd();

                return output;
            }
        }

        public static bool checkWebsite(string URL)
        {
            try
            {
                WebClient wc = new WebClient();
                string HTMLSource = wc.DownloadString(URL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async static void ResignToHEN()
        {
            if (ResignHEN == "true")
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\HEN.bat");
                await Task.Delay(5000);
            }
        }

        public async static void inject()
        {
            if (checkWebsite("http://" + ps3IP))
            {
                try
                {
                    Console.Write("[+] Connected to PS3, starting injecting to: ", Color.White);
                    Console.Write(injectPath, Color.Green);

                    var PATH = AppDomain.CurrentDomain.BaseDirectory + "\\" + filename + "";
                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential("", "");
                        client.UploadFile("ftp://" + ps3IP + injectPath + FileForInject, WebRequestMethods.Ftp.UploadFile, PATH);
                        client.DownloadString("http://" + ps3IP + "/xmb.ps3$reloadgame");
                    }

                    sprx_injected = true;
                    ConsoleEmpty();
                    Console.Write("[+] Injecting done, the game will restart", Color.White);
                }
                catch (Exception ex)
                {
                    sprx_injected = false;
                    ConsoleEmpty();
                    Console.Write("[+] Oops failed to inject to PS3, the application will close...", Color.Red);
                    await Task.Delay(5000);
                    Environment.Exit(0);
                }
            }
            else
            {
                sprx_injected = false;
                Console.Write("[+] Impossible connect to PS3... ", Color.Red);
            }
        }

        internal static async void InjectSPRX()
        {
            getInfos();
            Console.Title = "SPRX Injector by Misaki";
            Console.WriteAscii("   " + "SPRX Injector", Color.DarkMagenta);
            Console.Write("                                                version 1.0", Color.DarkMagenta);
            ConsoleEmpty();
            ConsoleEmpty();
            Console.Write("[!] Welcome to SPRX Injector, made by Misaki.", Color.MediumPurple);
            ConsoleEmpty();
            Console.Write("[!] This app has been created for inject any SPRX after have build it on VS.", Color.MediumPurple);
            ConsoleEmpty();
            ConsoleEmpty();
            Console.Write("[+] Checking file to inject...", Color.White);
            ConsoleEmpty();
            Console.Write("[+] File found: ", Color.White);
            Console.Write(filename, Color.Green);
            ConsoleEmpty();
            Console.Write("[+] Resign to HEN: ", Color.White);
            Console.Write(ResignHEN, Color.DarkMagenta);
            ConsoleEmpty();
            ResignToHEN();
            Console.Write("[+] Starting connection to PS3: ", Color.White);
            Console.Write(ps3IP, Color.Green);
            ConsoleEmpty();
            inject();
            ConsoleEmpty();
            Console.Write("[+] The app will auto close in 10 seconds...", Color.White);

            await Task.Delay(10000);
            Environment.Exit(0);
        }

        #endregion
        #region "Main"
        static void Main(string[] args)
        {
            InjectSPRX();
            Console.ReadLine();
        }
        #endregion
    }
}
