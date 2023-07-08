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
    public partial class RealTimeEditing : Form
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
        public RealTimeEditing()
        {
            InitializeComponent();
        }

        private void RealTimeEditing_Load(object sender, EventArgs e)
        {
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.guna2GradientPanel1.MouseDown += this.xMouseDown;
            this.guna2GradientPanel1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;
            this.label1.MouseDown += this.xMouseDown;
            this.label1.MouseMove += this.xMouseMove;

            if (Variables.BlockSwapperSelect == 0)
            {
                guna2ComboBox1.SelectedIndex = 0;
            }
            else if (Variables.BlockSwapperSelect == 1)
            {
                guna2ComboBox1.SelectedIndex = 1;
            }
            else if (Variables.BlockSwapperSelect == 2)
            {
                guna2ComboBox1.SelectedIndex = 2;
            }
            else if (Variables.BlockSwapperSelect == 3)
            {
                guna2ComboBox1.SelectedIndex = 3;
            }
            else if (Variables.BlockSwapperSelect == 4)
            {
                guna2ComboBox1.SelectedIndex = 4;
            }
            else if (Variables.BlockSwapperSelect == 5)
            {
                guna2ComboBox1.SelectedIndex = 5;
            }
            else if (Variables.BlockSwapperSelect == 6)
            {
                guna2ComboBox1.SelectedIndex = 6;
            }
            else if (Variables.BlockSwapperSelect == 7)
            {
                guna2ComboBox1.SelectedIndex = 7;
            }

            if (Variables.BlockSwapperValue == 0)
            {
                guna2ComboBox2.SelectedIndex = 0;
            }

            if (Variables.ItemsSwapperSelect == 0)
            {
                guna2ComboBox4.SelectedIndex = 0;
            }
            else if (Variables.ItemsSwapperSelect == 1)
            {
                guna2ComboBox4.SelectedIndex = 1;
            }
            else if (Variables.ItemsSwapperSelect == 2)
            {
                guna2ComboBox4.SelectedIndex = 2;
            }
            else if (Variables.ItemsSwapperSelect == 3)
            {
                guna2ComboBox4.SelectedIndex = 3;
            }
            else if (Variables.ItemsSwapperSelect == 4)
            {
                guna2ComboBox4.SelectedIndex = 4;
            }
            else if (Variables.ItemsSwapperSelect == 5)
            {
                guna2ComboBox4.SelectedIndex = 5;
            }
            else if (Variables.ItemsSwapperSelect == 6)
            {
                guna2ComboBox4.SelectedIndex = 6;
            }
            else if (Variables.ItemsSwapperSelect == 7)
            {
                guna2ComboBox4.SelectedIndex = 7;
            }

            if (Variables.ItemsSwapperValue == 0)
            {
                guna2ComboBox3.SelectedIndex = 0;
            }
            else if (Variables.ItemsSwapperValue == 1)
            {
                guna2ComboBox3.SelectedIndex = 1;
            }
            else if (Variables.ItemsSwapperValue == 2)
            {
                guna2ComboBox3.SelectedIndex = 2;
            }
            else if (Variables.ItemsSwapperValue == 3)
            {
                guna2ComboBox3.SelectedIndex = 3;
            }
            else if (Variables.ItemsSwapperValue == 4)
            {
                guna2ComboBox3.SelectedIndex = 4;
            }
            else if (Variables.ItemsSwapperValue == 5)
            {
                guna2ComboBox3.SelectedIndex = 5;
            }
            else if (Variables.ItemsSwapperValue == 6)
            {
                guna2ComboBox3.SelectedIndex = 6;
            }
            else if (Variables.ItemsSwapperValue == 7)
            {
                guna2ComboBox3.SelectedIndex = 7;
            }
            else if (Variables.ItemsSwapperValue == 8)
            {
                guna2ComboBox3.SelectedIndex = 8;
            }
            else if (Variables.ItemsSwapperValue == 9)
            {
                guna2ComboBox3.SelectedIndex = 9;
            }
            else if (Variables.ItemsSwapperValue == 10)
            {
                guna2ComboBox3.SelectedIndex = 10;
            }
            else if (Variables.ItemsSwapperValue == 11)
            {
                guna2ComboBox3.SelectedIndex = 11;
            }
            else if (Variables.ItemsSwapperValue == 12)
            {
                guna2ComboBox3.SelectedIndex = 12;
            }
            else if (Variables.ItemsSwapperValue == 13)
            {
                guna2ComboBox3.SelectedIndex = 13;
            }
            else if (Variables.ItemsSwapperValue == 14)
            {
                guna2ComboBox3.SelectedIndex = 14;
            }
            else if (Variables.ItemsSwapperValue == 15)
            {
                guna2ComboBox3.SelectedIndex = 15;
            }
            else if (Variables.ItemsSwapperValue == 16)
            {
                guna2ComboBox3.SelectedIndex = 16;
            }
            else if (Variables.ItemsSwapperValue == 17)
            {
                guna2ComboBox3.SelectedIndex = 17;
            }
            else if (Variables.ItemsSwapperValue == 18)
            {
                guna2ComboBox3.SelectedIndex = 18;
            }
            else if (Variables.ItemsSwapperValue == 19)
            {
                guna2ComboBox3.SelectedIndex = 19;
            }
            else if (Variables.ItemsSwapperValue == 20)
            {
                guna2ComboBox3.SelectedIndex = 20;
            }
            else if (Variables.ItemsSwapperValue == 21)
            {
                guna2ComboBox3.SelectedIndex = 21;
            }
            else if (Variables.ItemsSwapperValue == 22)
            {
                guna2ComboBox3.SelectedIndex = 22;
            }
            else if (Variables.ItemsSwapperValue == 23)
            {
                guna2ComboBox3.SelectedIndex = 23;
            }
            else if (Variables.ItemsSwapperValue == 24)
            {
                guna2ComboBox3.SelectedIndex = 24;
            }
            else if (Variables.ItemsSwapperValue == 25)
            {
                guna2ComboBox3.SelectedIndex = 25;
            }
            else if (Variables.ItemsSwapperValue == 26)
            {
                guna2ComboBox3.SelectedIndex = 26;
            }
            else if (Variables.ItemsSwapperValue == 27)
            {
                guna2ComboBox3.SelectedIndex = 27;
            }
            else if (Variables.ItemsSwapperValue == 28)
            {
                guna2ComboBox3.SelectedIndex = 28;
            }
            else if (Variables.ItemsSwapperValue == 29)
            {
                guna2ComboBox3.SelectedIndex = 29;
            }
            else if (Variables.ItemsSwapperValue == 30)
            {
                guna2ComboBox3.SelectedIndex = 30;
            }
            else if (Variables.ItemsSwapperValue == 31)
            {
                guna2ComboBox3.SelectedIndex = 31;
            }
            else if (Variables.ItemsSwapperValue == 32)
            {
                guna2ComboBox3.SelectedIndex = 32;
            }
            else if (Variables.ItemsSwapperValue == 33)
            {
                guna2ComboBox3.SelectedIndex = 33;
            }
            else if (Variables.ItemsSwapperValue == 34)
            {
                guna2ComboBox3.SelectedIndex = 34;
            }

            if (Variables.OverworldSwapper == 0)
            {
                guna2ComboBox5.SelectedIndex = 0;
            }
            else if (Variables.OverworldSwapper == 1)
            {
                guna2ComboBox5.SelectedIndex = 1;
            }
            else if (Variables.OverworldSwapper == 2)
            {
                guna2ComboBox5.SelectedIndex = 2;
            }

            if (Variables.NetherSwapper == 0)
            {
                guna2ComboBox6.SelectedIndex = 0;
            }
            else if (Variables.NetherSwapper == 1)
            {
                guna2ComboBox6.SelectedIndex = 1;
            }
            else if (Variables.NetherSwapper == 2)
            {
                guna2ComboBox6.SelectedIndex = 2;
            }

            if (Variables.TheEndSwapper == 0)
            {
                guna2ComboBox7.SelectedIndex = 0;
            }
            else if (Variables.TheEndSwapper == 1)
            {
                guna2ComboBox7.SelectedIndex = 1;
            }
            else if (Variables.TheEndSwapper == 2)
            {
                guna2ComboBox7.SelectedIndex = 2;
            }

            if (Variables.RealTimeEditingPage2 == true)
            {
                guna2Button7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                guna2Button7.Checked = true;
            }
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYING_ALONE(guna2TextBox1.Text);
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYING_MULTI(guna2TextBox2.Text);
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYER_JOIN(guna2TextBox3.Text);
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            OFFSETS.TEXT_CHANGER_PLAYER_LEAVE(guna2TextBox4.Text);
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("0");
                Variables.BlockSwapperSelect = 0;
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("1");
                Variables.BlockSwapperSelect = 1;
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("2");
                Variables.BlockSwapperSelect = 2;
            }
            else if (guna2ComboBox1.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("3");
                Variables.BlockSwapperSelect = 3;
            }
            else if (guna2ComboBox1.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("4");
                Variables.BlockSwapperSelect = 4;
            }
            else if (guna2ComboBox1.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("5");
                Variables.BlockSwapperSelect = 5;
            }
            else if (guna2ComboBox1.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("6");
                Variables.BlockSwapperSelect = 6;
            }
            else if (guna2ComboBox1.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_OFFSET("7");
                Variables.BlockSwapperSelect = 7;
            }
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_BLOCKS_SWAPPER_VALUES("0");
                Variables.BlockSwapperValue = 7;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OFFSETS.PATCH_BLOCK_SWAPPER();
        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("0");
                Variables.ItemsSwapperSelect = 0;
            }
            else if (guna2ComboBox4.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("1");
                Variables.ItemsSwapperSelect = 1;
            }
            else if (guna2ComboBox4.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("2");
                Variables.ItemsSwapperSelect = 2;
            }
            else if (guna2ComboBox4.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("3");
                Variables.ItemsSwapperSelect = 3;
            }
            else if (guna2ComboBox4.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("4");
                Variables.ItemsSwapperSelect = 4;
            }
            else if (guna2ComboBox4.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("5");
                Variables.ItemsSwapperSelect = 5;
            }
            else if (guna2ComboBox4.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("6");
                Variables.ItemsSwapperSelect = 6;
            }
            else if (guna2ComboBox4.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_OFFSET("7");
                Variables.ItemsSwapperSelect = 7;
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox3.SelectedIndex == 0)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("0");
                Variables.ItemsSwapperValue = 0;
            }
            else if (guna2ComboBox3.SelectedIndex == 1)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("1");
                Variables.ItemsSwapperValue = 1;
            }
            else if (guna2ComboBox3.SelectedIndex == 2)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("2");
                Variables.ItemsSwapperValue = 2;
            }
            else if (guna2ComboBox3.SelectedIndex == 3)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("3");
                Variables.ItemsSwapperValue = 3;
            }
            else if (guna2ComboBox3.SelectedIndex == 4)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("4");
                Variables.ItemsSwapperValue = 4;
            }
            else if (guna2ComboBox3.SelectedIndex == 5)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("5");
                Variables.ItemsSwapperValue = 5;
            }
            else if (guna2ComboBox3.SelectedIndex == 6)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("6");
                Variables.ItemsSwapperValue = 6;
            }
            else if (guna2ComboBox3.SelectedIndex == 7)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("7");
                Variables.ItemsSwapperValue = 7;
            }
            else if (guna2ComboBox3.SelectedIndex == 8)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("8");
                Variables.ItemsSwapperValue = 8;
            }
            else if (guna2ComboBox3.SelectedIndex == 9)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("9");
                Variables.ItemsSwapperValue = 9;
            }
            else if (guna2ComboBox3.SelectedIndex == 10)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("10");
                Variables.ItemsSwapperValue = 10;
            }
            else if (guna2ComboBox3.SelectedIndex == 11)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("11");
                Variables.ItemsSwapperValue = 11;
            }
            else if (guna2ComboBox3.SelectedIndex == 11)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("12");
                Variables.ItemsSwapperValue = 12;
            }
            else if (guna2ComboBox3.SelectedIndex == 13)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("13");
                Variables.ItemsSwapperValue = 13;
            }
            else if (guna2ComboBox3.SelectedIndex == 14)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("14");
                Variables.ItemsSwapperValue = 14;
            }
            else if (guna2ComboBox3.SelectedIndex == 15)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("15");
                Variables.ItemsSwapperValue = 15;
            }
            else if (guna2ComboBox3.SelectedIndex == 16)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("16");
                Variables.ItemsSwapperValue = 16;
            }
            else if (guna2ComboBox3.SelectedIndex == 17)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("17");
                Variables.ItemsSwapperValue = 17;
            }
            else if (guna2ComboBox3.SelectedIndex == 18)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("18");
                Variables.ItemsSwapperValue = 18;
            }
            else if (guna2ComboBox3.SelectedIndex == 19)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("19");
                Variables.ItemsSwapperValue = 19;
            }
            else if (guna2ComboBox3.SelectedIndex == 20)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("20");
                Variables.ItemsSwapperValue = 20;
            }
            else if (guna2ComboBox3.SelectedIndex == 21)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("21");
                Variables.ItemsSwapperValue = 21;
            }
            else if (guna2ComboBox3.SelectedIndex == 22)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("22");
                Variables.ItemsSwapperValue = 22;
            }
            else if (guna2ComboBox3.SelectedIndex == 23)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("23");
                Variables.ItemsSwapperValue = 23;
            }
            else if (guna2ComboBox3.SelectedIndex == 24)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("24");
                Variables.ItemsSwapperValue = 24;
            }
            else if (guna2ComboBox3.SelectedIndex == 25)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("25");
                Variables.ItemsSwapperValue = 25;
            }
            else if (guna2ComboBox3.SelectedIndex == 26)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("26");
                Variables.ItemsSwapperValue = 26;
            }
            else if (guna2ComboBox3.SelectedIndex == 27)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("27");
                Variables.ItemsSwapperValue = 27;
            }
            else if (guna2ComboBox3.SelectedIndex == 28)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("28");
                Variables.ItemsSwapperValue = 28;
            }
            else if (guna2ComboBox3.SelectedIndex == 29)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("29");
                Variables.ItemsSwapperValue = 29;
            }
            else if (guna2ComboBox3.SelectedIndex == 30)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("30");
                Variables.ItemsSwapperValue = 30;
            }
            else if (guna2ComboBox3.SelectedIndex == 31)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("31");
                Variables.ItemsSwapperValue = 31;
            }
            else if (guna2ComboBox3.SelectedIndex == 32)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("32");
                Variables.ItemsSwapperValue = 32;
            }
            else if (guna2ComboBox3.SelectedIndex == 33)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("33");
                Variables.ItemsSwapperValue = 33;
            }
            else if (guna2ComboBox3.SelectedIndex == 34)
            {
                OFFSETS.CHANGING_ITEMS_SWAPPER_VALUES("34");
                Variables.ItemsSwapperValue = 34;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OFFSETS.PATCH_ITEMS_SWAPPER();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!Variables.RealTimeEditingPage2)
            {
                guna2Button7.ForeColor = Color.FromArgb(FUNCS.RED, FUNCS.GREEN, FUNCS.BLUE);
                RealTimeEditing1 frm = new RealTimeEditing1();
                frm.Show();
                frm.SetDesktopLocation(Functions.x + 219, Functions.y);
                Variables.RealTimeEditingPage2 = true;
            }
            else
            {
                guna2Button7.ForeColor = Color.FromArgb(169, 169, 171);
                Form frm = Application.OpenForms["RealTimeEditing1"];
                frm.Close();
                Variables.RealTimeEditingPage2 = false; 
            }
        }

        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox5.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("0");
                OFFSETS.CHANGE_NETHER_DIMENSION("0");
                OFFSETS.CHANGE_THE_END_DIMENSION("0");
                Variables.OverworldSwapper = 0;
            }
            else if (guna2ComboBox5.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("1");
                Variables.OverworldSwapper = 1;
            }
            else if (guna2ComboBox5.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("2");
                Variables.OverworldSwapper = 2;
            }
        }

        private void guna2ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox6.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("0");
                OFFSETS.CHANGE_NETHER_DIMENSION("0");
                OFFSETS.CHANGE_THE_END_DIMENSION("0");
                Variables.NetherSwapper = 0;
            }
            else if (guna2ComboBox6.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_NETHER_DIMENSION("1");
                Variables.NetherSwapper = 1;
            }
            else if (guna2ComboBox6.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_NETHER_DIMENSION("2");
                Variables.NetherSwapper = 2;
            }
        }

        private void guna2ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox7.SelectedIndex == 0)
            {
                OFFSETS.CHANGE_OVERWORLD_DIMENSION("0");
                OFFSETS.CHANGE_NETHER_DIMENSION("0");
                OFFSETS.CHANGE_THE_END_DIMENSION("0");
                Variables.TheEndSwapper = 0;
            }
            else if (guna2ComboBox7.SelectedIndex == 1)
            {
                OFFSETS.CHANGE_THE_END_DIMENSION("1");
                Variables.TheEndSwapper = 1;
            }
            else if (guna2ComboBox7.SelectedIndex == 2)
            {
                OFFSETS.CHANGE_THE_END_DIMENSION("2");
                Variables.TheEndSwapper = 2;
            }
        }
    }
}
