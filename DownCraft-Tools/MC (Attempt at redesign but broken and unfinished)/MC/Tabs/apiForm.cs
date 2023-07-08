using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mc.Tabs
{
    public partial class apiForm : Form
    {
        public static Point newpoint = new Point();
        public static int x;
        public static int y;

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

        public apiForm()
        {
            InitializeComponent();
        }

        private void setColor()
        {
            BackColor = Offsets.saveBackColor;
            button1.BackColor = Offsets.saveBackColor;
            button1.ForeColor = Offsets.saveTextColor;
            button1.FlatAppearance.BorderColor = Offsets.saveThemeColor;

            button4.BackColor = Offsets.saveBackColor;
            button4.ForeColor = Offsets.saveTextColor;
            button4.FlatAppearance.BorderColor = Offsets.saveThemeColor;

            listBox1.BackColor = Offsets.saveBackColor;

            textBox1.BackColor = Offsets.saveBackColor;
            textBox1.ForeColor = Offsets.saveTextColor;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Offsets.curAPI == "tm")
                textBox1.Text = Convert.ToString(listBox1.SelectedIndex + 1);
            else if (Offsets.curAPI == "cc")
                textBox1.Text = Offsets.cList[listBox1.SelectedIndex].Ip;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          Offsets.saveTextColor,
                                          Offsets.saveThemeColor);

            SolidBrush brush = new SolidBrush(Offsets.saveTextColor);
            e.DrawBackground();
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void apiForm_Load(object sender, EventArgs e)
        {
            this.label10.MouseDown += this.xMouseDown;
            this.label10.MouseMove += this.xMouseMove;
            this.label10.MouseDown += this.xMouseDown;
            this.label10.MouseMove += this.xMouseMove;

            setColor();
            if (Offsets.curAPI == "tm")
                textBox1.Text = "" + Offsets.targetIndex;
            else if (Offsets.curAPI == "cc")
                textBox1.Text = Offsets.ps3IP;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Offsets.listCT.ToArray());
            label10.Text = Offsets.labelTxtCT;

            if (listBox1.Items.Count != 0)
                listBox1.SelectedIndex = 0;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Offsets.curAPI == "tm")
                    Offsets.targetIndex = Convert.ToInt32(textBox1.Text);
                else if (Offsets.curAPI == "cc")
                    Offsets.ps3IP = textBox1.Text;

                Offsets.apiForm_.DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Invalid Entry!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Offsets.apiForm_.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
