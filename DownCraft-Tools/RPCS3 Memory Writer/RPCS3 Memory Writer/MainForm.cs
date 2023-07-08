using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RPCS3_Memory_Writer
{
    public partial class MainForm : Form
    {
        #region "Variables"

        string EBOOT_BIN = "//";
        string TMP = Path.GetTempPath() + "PS3";
        const string MAKE = "make.exe";
        const string UNSELF = "unself.exe";
        public static string GAME = "EBOOT.ELF";

        #endregion

        #region "Functions"

        BinaryWriter bn;
        SaveFileDialog sv;

        void ExecCmd(string file, string arg)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = file;
            pro.StartInfo.WorkingDirectory = TMP;
            pro.StartInfo.Arguments = arg;
            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pro.StartInfo.CreateNoWindow = true;
            pro.StartInfo.UseShellExecute = false;
            pro.Start();
            pro.WaitForExit();
        }

        void PatchOffset(uint Offset, byte[] value)
        {
            bn.Seek((int)Offset, SeekOrigin.Begin);
            bn.Write(value);
            bn.Flush();
            Application.DoEvents();
        }

        void LoadFiles(string path, byte[] fileBytes)
        {
            File.WriteAllBytes(path, fileBytes);
        }
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region "Form Load / Close"

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(TMP))
            {
                Directory.CreateDirectory(TMP);
            }

            TMP += "\\";

            if (!File.Exists(TMP + MAKE))
            {
                LoadFiles(TMP + MAKE, Properties.Resources.make);
            }
            if (!File.Exists(TMP + UNSELF))
            {
                LoadFiles(TMP + UNSELF, Properties.Resources.unself);
            }

            MessageBox.Show("Before load your EBOOT, make sure that EBOOT is signed as 'DEX OFW' NON-DRM EBOOT");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EBOOT (*.BIN*)|*.BIN*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                EBOOT_BIN = System.IO.Path.GetDirectoryName(openFileDialog.FileName) + @"EBOOT.BIN";

                string sourceFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(openFileDialog.FileName), @"EBOOT.BIN");
                string destFile = System.IO.Path.Combine(TMP, @"EBOOT.BIN");
                System.IO.File.Copy(sourceFile, destFile, true);

                ExecCmd(TMP + UNSELF, "EBOOT.BIN" + " " + "EBOOT.ELF");
            }

            bn = new BinaryWriter(File.Open(TMP + GAME, FileMode.Open, FileAccess.Write));
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(Path.GetTempPath() + @"\PS3", true);
        }

        #endregion

        #region "Button"
        void BuildEBOOT()
        {
            bn.Close();

            String UserName = Environment.UserName;
            sv = new SaveFileDialog();
            sv.InitialDirectory = @"C:\Users\" + UserName + @"\Desktop";
            sv.FileName = "EBOOT";
            sv.Filter = "EBOOT.BIN|*.BIN";

            if (sv.ShowDialog() == DialogResult.OK)
            {
                ExecCmd(TMP + MAKE, TMP + GAME + " " + sv.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint address = Convert.ToUInt32(textBox1.Text, 16) - 65536;
            byte[] byteArray = StringToByteArray(textBox2.Text);

            try
            {
                PatchOffset(address, new byte[] { byteArray[0], byteArray[1], byteArray[2], byteArray[3] });

                MessageBox.Show("Address: " + address.ToString() + " is now patched on EBOOT");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuildEBOOT();
        }

        #endregion
    }
}
