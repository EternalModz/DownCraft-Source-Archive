using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_String_Fix_PS3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string fixString(string fixStr)
        {
            int length = fixStr.Length;
            int startIndex = 1;
            int num3 = 0;
            while (true)
            {
                if (num3 >= length)
                {
                    fixStr = fixStr.Replace(".", "");
                    return (fixStr + "");
                }
                fixStr = fixStr.Insert(startIndex, ".");
                startIndex += 2;
                num3++;
            }
        }
        static string PutLineBreak(string str, int split)
        {
            for (int a = 1; a <= str.Length; a++)
            {
                if (a % split == 0)
                    str = str.Insert(a, "\n");
            }

            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = fixString(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string findstring = textBox2.Text;
            byte[] bytesConverted = Encoding.ASCII.GetBytes(" " + findstring);

            string getCorrectByte = string.Join(" ", bytesConverted.Select(x => x.ToString("X2")));

            /*
            int lengthString = getCorrectByte.Length;
            int index = 3;
            string fix = getCorrectByte.Insert(index, "00 ");
            string fix1 = fix.Insert(index += 6, "00 ");
            string fix2 = fix1.Insert(index += 6, "00 ");
            string fix3 = fix2.Insert(index += 6, "00 ");
            string fix4 = fix3.Insert(index += 6, "00 ");
            */

            textBox2.Text = getCorrectByte;
        }
    }
}
