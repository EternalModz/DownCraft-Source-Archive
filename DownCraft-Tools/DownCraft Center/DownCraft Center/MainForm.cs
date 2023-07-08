using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownCraft_Center
{
    public partial class MainForm : Form
    {
        #region "Variables"

        WebClient web = new WebClient();
        string tmp = Path.GetTempPath();
        string EBOOT_CFW = Path.GetTempPath() + "CFW_EBOOT.BIN";
        string EBOOT_HEN = Path.GetTempPath() + "HEN_EBOOT.BIN";

        string SPRX_1_CFW = Path.GetTempPath() + "CFW_V2.1.sprx";
        string SPRX_1_HEN = Path.GetTempPath() + "HEN_V2.1.sprx";

        string SPRX_2_CFW = Path.GetTempPath() + "CFW_V2.2.sprx";
        string SPRX_2_HEN = Path.GetTempPath() + "HEN_V2.2.sprx";

        string SPRX_3_CFW = Path.GetTempPath() + "CFW_V3.sprx";
        string SPRX_3_HEN = Path.GetTempPath() + "HEN_V3.sprx";

        string SPRX_4_CFW = Path.GetTempPath() + "CFW_V4.sprx";
        string SPRX_4_HEN = Path.GetTempPath() + "HEN_V4.sprx";

        string dcV4 = Path.GetTempPath() + "dcV4.rar";
        string dcV1 = Path.GetTempPath() + "dcV1.rar";

        public static Point newpoint = new Point();
        public static int x;
        public static int y;

        public bool isConnected = false;
        public bool isAttached = false;
        public string isFirmware = null;
        public bool isEbootInjected = false;
        public bool isSPRXInjected = false;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region "Move Panel" 

        private void xMouseDown(object sender, MouseEventArgs e)
        {
            x = Control.MousePosition.X - base.Location.X;
            y = Control.MousePosition.Y - base.Location.Y;
        }
        private void xMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                newpoint = Control.MousePosition;
                newpoint.X -= x;
                newpoint.Y -= y;
                base.Location = newpoint;
            }
        }

        #endregion

        #region "Load File Func"
        public void LoadFiles(string path, byte[] fileBytes)
        {
            File.WriteAllBytes(path, fileBytes);
        }
        #endregion

        #region "Upload FTP Func"
        public void FTP_UPLOAD(string URL, string username, string password, string pathConsole, string filePC)
        {
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(username, password);
                client.UploadFile(URL + pathConsole, WebRequestMethods.Ftp.UploadFile, filePC);
            }
        }
        #endregion

        #region "Form Load"

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to DownCraft Center\n\nWhat is DownCraft Center ?\nDownCraft Center is a program to control all version of DownCraft (RTM & SPRX) so you don't need download a file for RTM and a another for SPRX\n\nHow i can use it ?\nJust put your PS3 IP on the program (be sure that you have WebMAN installed on your console) then select your firmware and press connect it's will automatic inject the right EBOOT for the SPRX skip this step if you don't want to use the SPRX\n\nThen press any buttons you want for SPRX V1, V2, V3 or for RTM V1 or V4 wait a moment and it's done.", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);

            gunaGradient2Panel1.MouseDown += this.xMouseDown;
            gunaGradient2Panel1.MouseMove += this.xMouseMove;
            gunaGradient2Panel1.MouseDown += this.xMouseDown;
            gunaGradient2Panel1.MouseMove += this.xMouseMove;
        }

        #endregion

        #region "Extract WinRar"
        public void ExtractRAR(string sourcefile, string destinationPath)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = @"C:\Program Files\WinRAR\unrar.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.EnableRaisingEvents = false;
            process.StartInfo.Arguments = string.Format("x -o+ \"{0}\" \"{1}\"", sourcefile, destinationPath);
            process.Start();
        }
        #endregion

        #region "App Close"
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(EBOOT_CFW);
            File.Delete(EBOOT_HEN);

            File.Delete(SPRX_1_CFW);
            File.Delete(SPRX_1_HEN);

            File.Delete(SPRX_2_CFW);
            File.Delete(SPRX_2_HEN);

            File.Delete(SPRX_3_CFW);
            File.Delete(SPRX_3_HEN);

            File.Delete(SPRX_4_CFW);
            File.Delete(SPRX_4_HEN);

            File.Delete(dcV1);
            File.Delete(dcV4);

            if (Directory.Exists(Path.GetTempPath() + @"\dcV1"))
                Directory.Delete(Path.GetTempPath() + @"\dcV1", true);

            if (Directory.Exists(Path.GetTempPath() + @"\dcV4"))
                Directory.Delete(Path.GetTempPath() + @"\dcV4", true);
        }
        #endregion

        #region "Connect Btn"
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/game/BLES01976/USRDIR/EBOOT.BIN", EBOOT_CFW);
                MessageBox.Show("EBOOT injected to the console, you can now select what SPRX you want use.", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isConnected = true; isAttached = true; isFirmware = "CFW"; isEbootInjected = true;
            }
            else if (guna2RadioButton2.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/game/BLES01976/USRDIR/EBOOT.BIN", EBOOT_HEN);
                MessageBox.Show("EBOOT injected to the console, you can now select what SPRX you want use.", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isConnected = true; isAttached = true; isFirmware = "HEN"; isEbootInjected = true;
            }
            else
            {
                MessageBox.Show("Oops you need to select your console firmware (CFW / HEN)", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateConnectInformations();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You need to enter your PS3 IP then select your firmware (CFW / HEN), press connect button and the selected EBOOT will be injected to your console for any SPRX.\n\nIf you want use the RTM select RTM V1 or RTM V4 wait 20 secondes and the tool will be ready to use.\n\n-  ̷M̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷i̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷s̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷a̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷k̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷i̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷̶̷   EternalModz", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region "Inject SPRX Btn"
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_1_CFW);
                MessageBox.Show("SPRX Demo V2.1 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else if (guna2RadioButton2.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_1_HEN);
                MessageBox.Show("SPRX Demo V2.1 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else
            {
                MessageBox.Show("Oops you need to select your console firmware (CFW / HEN)", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateConnectInformations();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_2_CFW);
                MessageBox.Show("SPRX Demo V2.2 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else if (guna2RadioButton2.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_2_HEN);
                MessageBox.Show("SPRX Demo V2.2 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else
            {
                MessageBox.Show("Oops you need to select your console firmware (CFW / HEN)", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateConnectInformations();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_3_CFW);
                MessageBox.Show("SPRX V3 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else if (guna2RadioButton2.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_3_HEN);
                MessageBox.Show("SPRX V3 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else
            {
                MessageBox.Show("Oops you need to select your console firmware (CFW / HEN)", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateConnectInformations();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            if (guna2RadioButton1.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_4_CFW);
                MessageBox.Show("SPRX V4.5 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else if (guna2RadioButton2.Checked)
            {
                FTP_UPLOAD("ftp://" + guna2TextBox1.Text, "", "", "/dev_hdd0/tmp/MC.sprx", SPRX_4_HEN);
                MessageBox.Show("SPRX V4.5 has been injected, you can start the game", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSPRXInjected = true;
            }
            else
            {
                MessageBox.Show("Oops you need to select your console firmware (CFW / HEN)", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateConnectInformations();
        }
        #endregion

        #region "Open RTM Btn"
        private async void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DownCraft RTM V4 will start in a moment please wait...", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExtractRAR(dcV4, Path.GetTempPath());
            await Task.Delay(5000);
            Process.Start(Path.GetTempPath() + @"\dcV4\DownCraft RTM Tool.exe");
        }

        private async void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DownCraft RTM V1 will start in a moment please wait...", "DownCraft Center", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ExtractRAR(dcV1, Path.GetTempPath());
            await Task.Delay(5000);
            Process.Start(Path.GetTempPath() + @"\dcV1\DownCraftUI.exe");
        }
        #endregion

        #region "Download Game Btn"
        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            Process.Start("https://mega.nz/file/kRtSwIgb#4-nWn9cO3mYJV5D2ZXQ8SvbEc1LyG1vkxGQW8NLCxI8");
        }
        #endregion

        #region "Update Connect Informations"
        public void UpdateConnectInformations()
        {
            gunaLabel8.Text = "PS3 Connect: " + isConnected + "\nGame Attach: " + isAttached + "\nSelected Firmware: " + isFirmware + "\nEboot Injected: " + isEbootInjected + "\nSPRX Inject: " + isSPRXInjected + "";
            gunaLabel8.Update();
        }
        #endregion
    }
}