using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownCraftUI.Classes;

namespace DownCraftUI.Tabs.Real_Time_Editing
{
    public partial class RealTimeEditing1 : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;
        Offsets OFFSETS = new Offsets();
        Functions FUNCS = new Functions();

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

        public RealTimeEditing1()
        {
            InitializeComponent();
        }

        private void RealTimeEditing1_Load(object sender, EventArgs e)
        {
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;

            if (Variables.RegenerationSwapper == 0)
            {
                guna2ComboBox5.SelectedIndex = 0;
            }
            else if (Variables.RegenerationSwapper == 1)
            {
                guna2ComboBox5.SelectedIndex = 1;
            }
            else if (Variables.RegenerationSwapper == 2)
            {
                guna2ComboBox5.SelectedIndex = 2;
            }
            else if (Variables.RegenerationSwapper == 3)
            {
                guna2ComboBox5.SelectedIndex = 3;
            }
            else if (Variables.RegenerationSwapper == 4)
            {
                guna2ComboBox5.SelectedIndex = 4;
            }
            else if (Variables.RegenerationSwapper == 5)
            {
                guna2ComboBox5.SelectedIndex = 5;
            }
            else if (Variables.RegenerationSwapper == 6)
            {
                guna2ComboBox5.SelectedIndex = 6;
            }
            else if (Variables.RegenerationSwapper == 7)
            {
                guna2ComboBox5.SelectedIndex = 7;
            }
            else if (Variables.RegenerationSwapper == 8)
            {
                guna2ComboBox5.SelectedIndex = 8;
            }
            else if (Variables.RegenerationSwapper == 9)
            {
                guna2ComboBox5.SelectedIndex = 9;
            }
            else if (Variables.RegenerationSwapper == 10)
            {
                guna2ComboBox5.SelectedIndex = 10;
            }
            else if (Variables.RegenerationSwapper == 11)
            {
                guna2ComboBox5.SelectedIndex = 11;
            }
            else if (Variables.RegenerationSwapper == 12)
            {
                guna2ComboBox5.SelectedIndex = 12;
            }
            else if (Variables.RegenerationSwapper == 13)
            {
                guna2ComboBox5.SelectedIndex = 13;
            }
            else if (Variables.RegenerationSwapper == 14)
            {
                guna2ComboBox5.SelectedIndex = 14;
            }
            else if (Variables.RegenerationSwapper == 15)
            {
                guna2ComboBox5.SelectedIndex = 15;
            }
            else if (Variables.RegenerationSwapper == 16)
            {
                guna2ComboBox5.SelectedIndex = 16;
            }
            else if (Variables.RegenerationSwapper == 17)
            {
                guna2ComboBox5.SelectedIndex = 17;
            }
            else if (Variables.RegenerationSwapper == 18)
            {
                guna2ComboBox5.SelectedIndex = 18;
            }
            else if (Variables.RegenerationSwapper == 19)
            {
                guna2ComboBox5.SelectedIndex = 19;
            }
            else if (Variables.RegenerationSwapper == 20)
            {
                guna2ComboBox5.SelectedIndex = 20;
            }
            else if (Variables.RegenerationSwapper == 21)
            {
                guna2ComboBox5.SelectedIndex = 21;
            }
            else if (Variables.RegenerationSwapper == 22)
            {
                guna2ComboBox5.SelectedIndex = 22;
            }
            else if (Variables.RegenerationSwapper == 23)
            {
                guna2ComboBox5.SelectedIndex = 23;
            }
            else if (Variables.RegenerationSwapper == 24)
            {
                guna2ComboBox5.SelectedIndex = 24;
            }
            else if (Variables.RegenerationSwapper == 25)
            {
                guna2ComboBox5.SelectedIndex = 25;
            }
            else if (Variables.RegenerationSwapper == 26)
            {
                guna2ComboBox5.SelectedIndex = 26;
            }
            else if (Variables.RegenerationSwapper == 27)
            {
                guna2ComboBox5.SelectedIndex = 27;
            }
            else if (Variables.RegenerationSwapper == 28)
            {
                guna2ComboBox5.SelectedIndex = 28;
            }


            if (Variables.RegenerationTimesSwapper == 0)
            {
                guna2ComboBox6.SelectedIndex = 0;
            }
            else if (Variables.RegenerationTimesSwapper == 1)
            {
                guna2ComboBox6.SelectedIndex = 1;
            }
            else if (Variables.RegenerationTimesSwapper == 2)
            {
                guna2ComboBox6.SelectedIndex = 2;
            }
            else if (Variables.RegenerationTimesSwapper == 3)
            {
                guna2ComboBox6.SelectedIndex = 3;
            }
            else if (Variables.RegenerationTimesSwapper == 4)
            {
                guna2ComboBox6.SelectedIndex = 4;
            }
            else if (Variables.RegenerationTimesSwapper == 5)
            {
                guna2ComboBox6.SelectedIndex = 5;
            }
            else if (Variables.RegenerationTimesSwapper == 6)
            {
                guna2ComboBox6.SelectedIndex = 6;
            }
            else if (Variables.RegenerationTimesSwapper == 7)
            {
                guna2ComboBox6.SelectedIndex = 7;
            }
            else if (Variables.RegenerationTimesSwapper == 8)
            {
                guna2ComboBox6.SelectedIndex = 8;
            }

            if (Variables.ChangeKillSource == 0)
            {
                guna2ComboBox1.SelectedIndex = 0;
            }
            else if (Variables.ChangeKillSource == 1)
            {
                guna2ComboBox1.SelectedIndex = 1;
            }
            else if (Variables.ChangeKillSource == 2)
            {
                guna2ComboBox1.SelectedIndex = 2;
            }

            if (Variables.ChangeItemsOn2Hand == 0)
            {
                guna2ComboBox2.SelectedIndex = 0;
            }
            else if (Variables.ChangeItemsOn2Hand == 1)
            {
                guna2ComboBox2.SelectedIndex = 1;
            }
            else if (Variables.ChangeItemsOn2Hand == 2)
            {
                guna2ComboBox2.SelectedIndex = 2;
            }
            else if (Variables.ChangeItemsOn2Hand == 3)
            {
                guna2ComboBox2.SelectedIndex = 3;
            }

            if (Variables.ChangeDrawMode == 0)
            {
                guna2ComboBox3.SelectedIndex = 0;
            }
            else if (Variables.ChangeDrawMode == 1)
            {
                guna2ComboBox3.SelectedIndex = 1;
            }
        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox5.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("0");
                Variables.RegenerationSwapper = 0;
            }
            else if (guna2ComboBox5.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("1");
                Variables.RegenerationSwapper = 1;
            }
            else if (guna2ComboBox5.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("2");
                Variables.RegenerationSwapper = 2;
            }
            else if (guna2ComboBox5.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("3");
                Variables.RegenerationSwapper = 3;
            }
            else if (guna2ComboBox5.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("4");
                Variables.RegenerationSwapper = 4;
            }
            else if (guna2ComboBox5.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("5");
                Variables.RegenerationSwapper = 5;
            }
            else if (guna2ComboBox5.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("6");
                Variables.RegenerationSwapper = 6;
            }
            else if (guna2ComboBox5.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("7");
                Variables.RegenerationSwapper = 7;
            }
            else if (guna2ComboBox5.SelectedIndex == 8)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("8");
                Variables.RegenerationSwapper = 8;
            }
            else if (guna2ComboBox5.SelectedIndex == 9)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("9");
                Variables.RegenerationSwapper = 9;
            }
            else if (guna2ComboBox5.SelectedIndex == 10)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("10");
                Variables.RegenerationSwapper = 10;
            }
            else if (guna2ComboBox5.SelectedIndex == 11)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("11");
                Variables.RegenerationSwapper = 11;
            }
            else if (guna2ComboBox5.SelectedIndex == 12)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("12");
                Variables.RegenerationSwapper = 12;
            }
            else if (guna2ComboBox5.SelectedIndex == 13)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("13");
                Variables.RegenerationSwapper = 13;
            }
            else if (guna2ComboBox5.SelectedIndex == 14)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("14");
                Variables.RegenerationSwapper = 14;
            }
            else if (guna2ComboBox5.SelectedIndex == 15)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("15");
                Variables.RegenerationSwapper = 15;
            }
            else if (guna2ComboBox5.SelectedIndex == 16)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("16");
                Variables.RegenerationSwapper = 16;
            }
            else if (guna2ComboBox5.SelectedIndex == 17)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("17");
                Variables.RegenerationSwapper = 17;
            }
            else if (guna2ComboBox5.SelectedIndex == 18)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("18");
                Variables.RegenerationSwapper = 18;
            }
            else if (guna2ComboBox5.SelectedIndex == 19)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("19");
                Variables.RegenerationSwapper = 19;
            }
            else if (guna2ComboBox5.SelectedIndex == 20)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("20");
                Variables.RegenerationSwapper = 20;
            }
            else if (guna2ComboBox5.SelectedIndex == 21)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("21");
                Variables.RegenerationSwapper = 21;
            }
            else if (guna2ComboBox5.SelectedIndex == 22)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("22");
                Variables.RegenerationSwapper = 22;
            }
            else if (guna2ComboBox5.SelectedIndex == 23)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("23");
                Variables.RegenerationSwapper = 23;
            }
            else if (guna2ComboBox5.SelectedIndex == 24)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("24");
                Variables.RegenerationSwapper = 24;
            }
            else if (guna2ComboBox5.SelectedIndex == 25)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("25");
                Variables.RegenerationSwapper = 25;
            }
            else if (guna2ComboBox5.SelectedIndex == 26)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("26");
                Variables.RegenerationSwapper = 26;
            }
            else if (guna2ComboBox5.SelectedIndex == 27)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("27");
                Variables.RegenerationSwapper = 27;
            }
            else if (guna2ComboBox5.SelectedIndex == 28)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION("28");
                Variables.RegenerationSwapper = 28;
            }
        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox6.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("0");
                Variables.RegenerationTimesSwapper = 0;
            }
            else if (guna2ComboBox6.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("1");
                Variables.RegenerationTimesSwapper = 1;
            }
            else if (guna2ComboBox6.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("2");
                Variables.RegenerationTimesSwapper = 2;
            }
            else if (guna2ComboBox6.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("3");
                Variables.RegenerationTimesSwapper = 3;
            }
            else if (guna2ComboBox6.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("4");
                Variables.RegenerationTimesSwapper = 4;
            }
            else if (guna2ComboBox6.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("5");
                Variables.RegenerationTimesSwapper = 5;
            }
            else if (guna2ComboBox6.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("6");
                Variables.RegenerationTimesSwapper = 6;
            }
            else if (guna2ComboBox6.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("7");
                Variables.RegenerationTimesSwapper = 7;
            }
            else if (guna2ComboBox6.SelectedIndex == 8)
            {
                OFFSETS.CHANGING_EFFECT_REGENERATION_TIME("8");
                Variables.RegenerationTimesSwapper = 8;
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_SOURCE_KILL("0");
                Variables.ChangeKillSource = 0;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_SOURCE_KILL("1");
                Variables.ChangeKillSource = 1;
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_SOURCE_KILL("2");
                Variables.ChangeKillSource = 2;
            }
            else if (guna2ComboBox1.SelectedIndex == 3)
            {
                OFFSETS.CHANGE_SOURCE_KILL("3");
                Variables.ChangeKillSource = 3;
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == 0)
            {
                OFFSETS.ITEMS_2TH_HAND("0");
                Variables.ChangeItemsOn2Hand = 0;
            }
            else if (guna2ComboBox2.SelectedIndex == 1)
            {
                OFFSETS.ITEMS_2TH_HAND("1");
                Variables.ChangeItemsOn2Hand = 1;
            }
            else if (guna2ComboBox2.SelectedIndex == 2)
            {
                OFFSETS.ITEMS_2TH_HAND("2");
                Variables.ChangeItemsOn2Hand = 2;
            }
            else if (guna2ComboBox2.SelectedIndex == 3)
            {
                OFFSETS.ITEMS_2TH_HAND("3");
                Variables.ChangeItemsOn2Hand = 3;
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.guna2ComboBox3.SelectedIndex == 0)
            {
                OFFSETS.DRAW_MODE("0");
                Variables.ChangeDrawMode = 0;
            }
            else if (guna2ComboBox3.SelectedIndex == 1)
            {
                OFFSETS.DRAW_MODE("1");
                Variables.ChangeDrawMode = 1;
            }
        }
    }
}
