using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minecraft_Draw_UI
{
    public partial class MainForm : Form
    {
        int HudX;
        int HudY;
        int HudSizeW;
        int HudSizeH;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //SET HUD POSITION
        private void button5_Click(object sender, EventArgs e)
        {
            HudX = Int16.Parse(textBox1.Text);
            HudY = Int16.Parse(textBox2.Text);

            panel1.Location = new Point(HudX, HudY);
        }

        //SET HUD SIZE
        private void button2_Click(object sender, EventArgs e)
        {
            HudSizeW = Int16.Parse(textBox6.Text);
            HudSizeH = Int16.Parse(textBox5.Text);

            panel1.Size = new Size(HudSizeW, HudSizeH);
        }

        //GET HUD POSITION / 2
        private void button3_Click(object sender, EventArgs e)
        {
            int HudPositionX = panel1.Location.X / 2;
            int HudPositionY = panel1.Location.Y / 2;

            textBox8.Text = HudPositionX.ToString();
            textBox7.Text = HudPositionY.ToString();
        }

        //GET HUD SIZE / 2
        private void button1_Click(object sender, EventArgs e)
        {
            int HudSizeW = panel1.Size.Width / 2;
            int HudSizeH = panel1.Size.Height / 2;

            textBox3.Text = HudSizeW.ToString();
            textBox4.Text = HudSizeH.ToString();
        }

        //SET A COLOR
        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.ShowDialog();

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDlg.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int HudPositionX = panel1.Location.X / 2;
            int HudPositionY = panel1.Location.Y / 2;
            int HudSizeW = panel1.Size.Width / 2;
            int HudSizeH = panel1.Size.Height / 2;

            textBox9.Text = "DrawRectangle(" + HudPositionX + ", " + HudPositionY + ", " + HudSizeW + ", " + HudSizeH + ", MC_Color::ColorTheme);";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int TextPositionX = label1.Location.X / 2;
            int TextPositionY = label1.Location.Y / 2;

            textBox10.Text = "DrawText(L'', " + TextPositionX + ", " + TextPositionY + ", color(MC_Color::White));";
        }
    }
}
