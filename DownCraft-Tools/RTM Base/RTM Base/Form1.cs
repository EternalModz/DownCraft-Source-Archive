/*RTM Base For Minecraft 1.84 (only GOD_MODE offset are here, if you want do it on a another games just change the offset for the game)
 * 
 *RTM Base Made By Misaki Dev
 * If you using this RTM for PS3 open source
 * Do the same thing like what i have make
 * All functions (void for make a options toggle in the class Function)
 * for enable a mod make: FUNCTIONS.MODSNAME(true);
 * and for disable the mod make: FUNCTIONS.MODNAME(false);
 * for any problems or questions contact me on discord
 * Misaki🎀#0001
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib; //Using PS3 Library

namespace RTM_Base
{
    public partial class Form1 : Form
    {
        #region "Variables"

        PS3API PS3 = new PS3API(); //for using PS3.
        public Functions FUNCTIONS = new Functions(); //For Call Functions

        public static Point newpoint = new Point(); //For Move the RTM
        public static int x; //For Move The RTM
        public static int y; //For Move The RTM

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region "System Move Title Panel"
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

        #region "Select API"

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole); //Changing API to CCAPI
        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager); //Changing API to TMAPI
        }

        #endregion

        #region "Connect + Attach"

        private void BTN_Connect_Click(object sender, EventArgs e) //<== Connect To PS3
        {
            try
            {
                if (PS3.ConnectTarget())
                {
                    MessageBox.Show("RTM Connected to PS3");
                }
                else
                {
                    MessageBox.Show("RTM not Connected to PS3");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("RTM Impossible to Connect To PS3");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) //<== Attach To PS3
        {
            try
            {
                if (PS3.AttachProcess())
                {
                    MessageBox.Show("RTM Attached to PS3");
                    gunaLabel3.Text = PS3.Extension.ReadString(0x3000ABE4); //Show PSN name on Welcome:
                }
                else
                {
                    MessageBox.Show("RTM not Attached to PS3");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("RTM Impossible to Attached to PS3");
            }
        }

        #endregion

        #region "Check Box Toggle Options"

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                FUNCTIONS.GOD_MODE(true); //Enable Function God Mode
            }
            else
            {
                FUNCTIONS.GOD_MODE(false); //Disable Function God Mode
            }
        }

        #endregion

        #region "Load Form"

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel2.MouseDown += this.xMouseDown; //For Move Form
            this.panel2.MouseMove += this.xMouseMove; //For Move Form
            this.panel2.MouseDown += this.xMouseDown; //For Move Form
            this.panel2.MouseMove += this.xMouseMove; //For Move Form
        }

        #endregion

        #region "Name Changer"

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x3000ABE4, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }); //reset Name to nothing

            byte[] bytes = Encoding.ASCII.GetBytes(gunaTextBox1.Text + ""); //set name with text box

            PS3.SetMemory(0x3000ABE4, bytes); //Offset of the name
            PS3.CCAPI.Notify(CCAPI.NotifyIcon.CAUTION, "DownCraft Notification\nName Changer Reset !"); //add a message on the PS3 for have change the name
        }

        #endregion

        #region "Close Btn"

        private void gunaControlBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion










































        //Nothing

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
