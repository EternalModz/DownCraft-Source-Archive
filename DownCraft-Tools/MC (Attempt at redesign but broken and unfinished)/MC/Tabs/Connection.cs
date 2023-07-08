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
    public partial class Connection : Form
    {
        Offsets OFFSETS = new Offsets();
        public Connection()
        {
            InitializeComponent();
        }

        #region "Choose API"
        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OFFSETS.API = "CCAPI";
        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            OFFSETS.API = "TMAPI";
        }

        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            OFFSETS.API = "HEN";
        }
        #endregion
        #region "Connect Btn"
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OFFSETS.ChangeAPI();
            OFFSETS.doConnect();
        }
        #endregion
    }
}
