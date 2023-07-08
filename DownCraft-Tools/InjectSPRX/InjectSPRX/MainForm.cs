using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InjectSPRX
{
    public partial class MainForm : Form
    {
        WebClient web = new WebClient();
        public MainForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        void Notify(string title, string text)
        {
            var notify = new NotifyIcon();
            notify.Visible = true;
            notify.Icon = Properties.Resources.image;
            notify.ShowBalloonTip(1000, title, text, ToolTipIcon.Info);
        }

        internal async void InjectSPRX()
        {
            string text = Application.StartupPath + "\\settings.txt";

            if (File.Exists(text))
            {
                string[] array = File.ReadAllLines(text);
                if (array[0].EndsWith("useLoader=true"))
                {
                    string ConsoleIP = array[1];
                    string FileName = array[2];
                    string FileForInject = array[3];
                    string PathLocation = array[4];
                    var PATH = Application.StartupPath + "\\" + FileName + "";
                    {
                        if (File.Exists(PATH) is true)
                        {
                            label2.Text = "File Found " + FileName;
                            await Task.Delay(2000);
                            using (var client = new WebClient())
                            {
                                label3.Text = "Starting connection to " + ConsoleIP;
                                await Task.Delay(2000);
                                client.Credentials = new NetworkCredential("", "");
                                client.UploadFile("ftp://" + ConsoleIP + PathLocation + FileForInject, WebRequestMethods.Ftp.UploadFile, PATH);
                                label4.Text = "Successfuly inject SPRX to " + PathLocation;
                                await Task.Delay(2000);
                                label5.Text = "Reload the game and exiting app";
                                var reload = new WebClient();
                                reload.DownloadString("http://" + ConsoleIP + "/xmb.ps3$reloadgame");
                                Notify("SPRX Injector By Misakiii", "SPRX injected, the game will restart!");
                                await Task.Delay(4000);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Oops i cannot find the SPRX file.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing settings file.");
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Delay(200);
            InjectSPRX();
        }
    }
}
