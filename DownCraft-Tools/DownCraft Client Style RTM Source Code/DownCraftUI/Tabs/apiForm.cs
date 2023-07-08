using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownCraftUI.Tabs
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (DownCraftUI.Classes.Offsets.curAPI == "tm")
                    DownCraftUI.Classes.Offsets.targetIndex = Convert.ToInt32(textBox1.Text);
                else if (DownCraftUI.Classes.Offsets.curAPI == "cc")
                    DownCraftUI.Classes.Offsets.ps3IP = textBox1.Text;

                DownCraftUI.Classes.Offsets.apiForm_.DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("Invalid Entry!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownCraftUI.Classes.Offsets.apiForm_.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void setColor()
        {
            BackColor = DownCraftUI.Classes.Offsets.saveBackColor;
            button1.BackColor = DownCraftUI.Classes.Offsets.saveBackColor;
            button1.ForeColor = DownCraftUI.Classes.Offsets.saveTextColor;
            button1.FlatAppearance.BorderColor = DownCraftUI.Classes.Offsets.saveThemeColor;

            button4.BackColor = DownCraftUI.Classes.Offsets.saveBackColor;
            button4.ForeColor = DownCraftUI.Classes.Offsets.saveTextColor;
            button4.FlatAppearance.BorderColor = DownCraftUI.Classes.Offsets.saveThemeColor;

            listBox1.BackColor = DownCraftUI.Classes.Offsets.saveBackColor;

            textBox1.BackColor = DownCraftUI.Classes.Offsets.saveBackColor;
            textBox1.ForeColor = DownCraftUI.Classes.Offsets.saveTextColor;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DownCraftUI.Classes.Offsets.curAPI == "tm")
                textBox1.Text = Convert.ToString(listBox1.SelectedIndex + 1);
            else if (DownCraftUI.Classes.Offsets.curAPI == "cc")
                textBox1.Text = DownCraftUI.Classes.Offsets.cList[listBox1.SelectedIndex].Ip;
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
                                          DownCraftUI.Classes.Offsets.saveTextColor,
                                          DownCraftUI.Classes.Offsets.saveThemeColor);

            SolidBrush brush = new SolidBrush(DownCraftUI.Classes.Offsets.saveTextColor);
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
            if (DownCraftUI.Classes.Offsets.curAPI == "tm")
                textBox1.Text = "" + DownCraftUI.Classes.Offsets.targetIndex;
            else if (DownCraftUI.Classes.Offsets.curAPI == "cc")
                textBox1.Text = DownCraftUI.Classes.Offsets.ps3IP;
            listBox1.Items.Clear();
            listBox1.Items.AddRange(DownCraftUI.Classes.Offsets.listCT.ToArray());
            label10.Text = DownCraftUI.Classes.Offsets.labelTxtCT;

            if (listBox1.Items.Count != 0)
                listBox1.SelectedIndex = 0;
        }
    }
}
