using PS3ManagerAPI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PS3Lib
{
	public partial class LogDialog : Form
	{
		public LogDialog()
		{
			this.InitializeComponent();
		}

		public LogDialog(PS3MAPI MyPS3MAPI) : this()
		{
			this.PS3MAPI = MyPS3MAPI;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		private void LogDialog_Refresh(object sender, EventArgs e)
		{
			if (this.PS3MAPI != null)
			{
				this.tB_Log.Text = this.PS3MAPI.Log;
			}
		}

		private PS3MAPI PS3MAPI;
	}
}
