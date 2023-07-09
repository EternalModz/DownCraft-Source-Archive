using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PS3Lib
{
	// Token: 0x02000133 RID: 307
	public class PS3API
	{
		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x000401D4 File Offset: 0x0003E3D4
		public Extension Extension
		{
			get
			{
				return new Extension(PS3API.SetAPI.API);
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x000401F0 File Offset: 0x0003E3F0
		public TMAPI TMAPI
		{
			get
			{
				return new TMAPI();
			}
		}

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x00040208 File Offset: 0x0003E408
		public CCAPI CCAPI
		{
			get
			{
				return new CCAPI();
			}
		}

		// Token: 0x06000CCB RID: 3275 RVA: 0x0004021F File Offset: 0x0003E41F
		public PS3API(SelectAPI API = SelectAPI.TargetManager)
		{
			PS3API.SetAPI.API = API;
			this.MakeInstanceAPI(API);
		}

		// Token: 0x06000CCC RID: 3276 RVA: 0x00040238 File Offset: 0x0003E438
		public void setTargetName(string value)
		{
			PS3API.targetName = value;
		}

		// Token: 0x06000CCD RID: 3277 RVA: 0x00040244 File Offset: 0x0003E444
		private void MakeInstanceAPI(SelectAPI API)
		{
			if (API == SelectAPI.TargetManager && PS3API.Common.TmApi == null)
			{
				PS3API.Common.TmApi = new TMAPI();
			}
			if (API == SelectAPI.ControlConsole && PS3API.Common.CcApi == null)
			{
				PS3API.Common.CcApi = new CCAPI();
			}
		}

		// Token: 0x06000CCE RID: 3278 RVA: 0x00040297 File Offset: 0x0003E497
		public void SetFormLang(Lang Language)
		{
			PS3API.SetLang.DefaultLang = Language;
		}

		// Token: 0x06000CCF RID: 3279 RVA: 0x000402A0 File Offset: 0x0003E4A0
		public void InitTarget()
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.InitComms();
			}
		}

		// Token: 0x06000CD0 RID: 3280 RVA: 0x000402CC File Offset: 0x0003E4CC
		public bool ConnectTarget(int target = 0)
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			bool result;
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				result = PS3API.Common.TmApi.ConnectTarget(target);
			}
			else
			{
				result = new PS3API.ConsoleList(this).Show();
			}
			return result;
		}

		// Token: 0x06000CD1 RID: 3281 RVA: 0x0004031C File Offset: 0x0003E51C
		public bool ConnectTarget(string ip)
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			bool result;
			if (PS3API.Common.CcApi.SUCCESS(PS3API.Common.CcApi.ConnectTarget(ip)))
			{
				PS3API.targetIp = ip;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000CD2 RID: 3282 RVA: 0x00040368 File Offset: 0x0003E568
		public void DisconnectTarget()
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.DisconnectTarget();
			}
			else
			{
				PS3API.Common.CcApi.DisconnectTarget();
			}
		}

		// Token: 0x06000CD3 RID: 3283 RVA: 0x000403A4 File Offset: 0x0003E5A4
		public bool AttachProcess()
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			bool result = false;
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				result = PS3API.Common.TmApi.AttachProcess();
			}
			else if (PS3API.SetAPI.API == SelectAPI.ControlConsole)
			{
				result = PS3API.Common.CcApi.SUCCESS(PS3API.Common.CcApi.AttachProcess());
			}
			return result;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x0004040C File Offset: 0x0003E60C
		public string GetConsoleName()
		{
			string name;
			string result;
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				name = PS3API.Common.TmApi.SCE.GetTargetName();
			}
			else if (PS3API.targetName != string.Empty)
			{
				name = PS3API.targetName;
			}
			else
			{
				if (PS3API.targetIp != string.Empty)
				{
					List<CCAPI.ConsoleInfo> list = new List<CCAPI.ConsoleInfo>();
					list = PS3API.Common.CcApi.GetConsoleList();
					if (list.Count > 0)
					{
						for (int i = 0; i < list.Count; i++)
						{
							if (list[i].Ip == PS3API.targetIp)
							{
								name = list[i].Name;
								result = name;
								return result;
							}
						}
					}
				}
				name = PS3API.targetIp;
			}
			result = name;
			return result;
		}

		// Token: 0x06000CD5 RID: 3285 RVA: 0x00040500 File Offset: 0x0003E700
		public void SetMemory(uint offset, byte[] buffer)
		{
            if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.SetMemory(offset, buffer);
			}

			else if (PS3API.SetAPI.API == SelectAPI.ControlConsole)
			{
				PS3API.Common.CcApi.SetMemory(offset, buffer);
			}
		}

		// Token: 0x06000CD6 RID: 3286 RVA: 0x0004054C File Offset: 0x0003E74C
		public void GetMemory(uint offset, byte[] buffer)
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.GetMemory(offset, buffer);
			}
			else if (PS3API.SetAPI.API == SelectAPI.ControlConsole)
			{
				PS3API.Common.CcApi.GetMemory(offset, buffer);
			}
		}

		// Token: 0x06000CD7 RID: 3287 RVA: 0x00040598 File Offset: 0x0003E798
		public byte[] GetBytes(uint offset, int length)
		{
			byte[] array = new byte[length];
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.GetMemory(offset, array);
			}
			else if (PS3API.SetAPI.API == SelectAPI.ControlConsole)
			{
				PS3API.Common.CcApi.GetMemory(offset, array);
			}
			return array;
		}

		// Token: 0x06000CD8 RID: 3288 RVA: 0x000405F0 File Offset: 0x0003E7F0
		public void ChangeAPI(SelectAPI API)
		{
			PS3API.SetAPI.API = API;
			this.MakeInstanceAPI(this.GetCurrentAPI());
		}

		// Token: 0x06000CD9 RID: 3289 RVA: 0x00040608 File Offset: 0x0003E808
		public SelectAPI GetCurrentAPI()
		{
			return PS3API.SetAPI.API;
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x00040620 File Offset: 0x0003E820
		public string GetCurrentAPIName()
		{
			string result = string.Empty;
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				result = Enum.GetName(typeof(SelectAPI), SelectAPI.TargetManager).Replace("Manager", " Manager");
			}
			else
			{
				result = Enum.GetName(typeof(SelectAPI), SelectAPI.ControlConsole).Replace("Console", " Console");
			}
			return result;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x00040698 File Offset: 0x0003E898
		public Assembly PS3TMAPI_NET()
		{
			return PS3API.Common.TmApi.PS3TMAPI_NET();
		}

		// Token: 0x04000535 RID: 1333
		private static string targetName = string.Empty;

		// Token: 0x04000536 RID: 1334
		private static string targetIp = string.Empty;

		// Token: 0x02000134 RID: 308
		private class SetLang
		{
			// Token: 0x04000537 RID: 1335
			public static Lang DefaultLang = Lang.Null;
		}

		// Token: 0x02000135 RID: 309
		private class SetAPI
		{
			// Token: 0x04000538 RID: 1336
			public static SelectAPI API;
		}

		// Token: 0x02000136 RID: 310
		private class Common
		{
			// Token: 0x04000539 RID: 1337
			public static CCAPI CcApi;

			// Token: 0x0400053A RID: 1338
			public static TMAPI TmApi;
		}

		// Token: 0x02000137 RID: 311
		public class ConsoleList
		{
			// Token: 0x06000CE1 RID: 3297 RVA: 0x000406EC File Offset: 0x0003E8EC
			public ConsoleList(PS3API f)
			{
				this.Api = f;
				this.data = this.Api.CCAPI.GetConsoleList();
			}

			// Token: 0x06000CE2 RID: 3298 RVA: 0x000407AC File Offset: 0x0003E9AC
			private Lang getSysLanguage()
			{
				Lang result;
				if (PS3API.SetLang.DefaultLang == Lang.Null)
				{
					if (CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName.StartsWith("FRA"))
					{
						result = Lang.French;
					}
					else if (CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName.StartsWith("GER"))
					{
						result = Lang.German;
					}
					else
					{
						result = Lang.English;
					}
				}
				else
				{
					result = PS3API.SetLang.DefaultLang;
				}
				return result;
			}

			// Token: 0x06000CE3 RID: 3299 RVA: 0x00040820 File Offset: 0x0003EA20
			private string strTraduction(string keyword)
			{
				Lang sysLanguage = this.getSysLanguage();
				string text;
				string result;
				if (sysLanguage == Lang.French)
				{
					switch (keyword)
					{
					case "btnConnect":
						text = "Connect To PS3";
						result = text;
						return result;
					case "btnRefresh":
						text = "Rafraîchir";
						result = text;
						return result;
					case "errorSelect":
						text = "Vous devez d'abord sélectionner une console.";
						result = text;
						return result;
					case "errorSelectTitle":
						text = "Sélectionnez une console.";
						result = text;
						return result;
					case "selectGrid":
						text = "Sélectionnez une console dans la grille.";
						result = text;
						return result;
					case "selectedLbl":
						text = "Sélection :";
						result = text;
						return result;
					case "formTitle":
						text = "Choisissez une console...";
						result = text;
						return result;
					case "noConsole":
						text = "Aucune console disponible, démarrez CCAPI Manager (v2.60+) et ajoutez une nouvelle console.";
						result = text;
						return result;
					case "noConsoleTitle":
						text = "Aucune console disponible.";
						result = text;
						return result;
					}
				}
				else if (sysLanguage == Lang.German)
				{
					switch (keyword)
					{
					case "btnConnect":
						text = "Connect To PS3";
						result = text;
						return result;
					case "btnRefresh":
						text = "Wiederholen";
						result = text;
						return result;
					case "errorSelect":
						text = "Du musst zuerst eine Konsole auswählen.";
						result = text;
						return result;
					case "errorSelectTitle":
						text = "Wähle eine Konsole.";
						result = text;
						return result;
					case "selectGrid":
						text = "Wähle eine Konsole innerhalb dieses Gitters.";
						result = text;
						return result;
					case "selectedLbl":
						text = "Ausgewählt :";
						result = text;
						return result;
					case "formTitle":
						text = "Wähle eine Konsole...";
						result = text;
						return result;
					case "noConsole":
						text = "Keine Konsolen verfügbar - starte CCAPI Manager (v2.60+) und füge eine neue Konsole hinzu.";
						result = text;
						return result;
					case "noConsoleTitle":
						text = "Keine Konsolen verfügbar.";
						result = text;
						return result;
					}
				}
				else
					switch (keyword)
					{
					case "btnConnect":
						text = "Connect To PS3";
						result = text;
						return result;
					case "btnRefresh":
						text = "Refresh List";
						result = text;
						return result;
					case "errorSelect":
						text = "You need to select a console to connect to.";
						result = text;
						return result;
					case "errorSelectTitle":
						text = "Select a console.";
						result = text;
						return result;
					case "selectGrid":
						text = "Select a console within this grid.";
						result = text;
						return result;
					case "selectedLbl":
						text = "Selected :";
						result = text;
						return result;
					case "formTitle":
						text = "Select a console...";
						result = text;
						return result;
					case "noConsole":
						text = "None consoles available, run CCAPI Manager (v2.60+) and add a new console.";
						result = text;
						return result;
					case "noConsoleTitle":
						text = "None console available.";
						result = text;
						return result;
					}
				text = "?";
				result = text;
				return result;
			}

			// Token: 0x06000CE4 RID: 3300 RVA: 0x00040C1C File Offset: 0x0003EE1C
			private void xMouseDown(object sender, MouseEventArgs e)
			{
				PS3API.ConsoleList.x = Control.MousePosition.X - this.formList.Location.X;
				PS3API.ConsoleList.y = Control.MousePosition.Y - this.formList.Location.Y;
			}

			// Token: 0x06000CE5 RID: 3301 RVA: 0x00040C78 File Offset: 0x0003EE78
			private void xMouseMove(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					PS3API.ConsoleList.newpoint = Control.MousePosition;
					PS3API.ConsoleList.newpoint.X = PS3API.ConsoleList.newpoint.X - PS3API.ConsoleList.x;
					PS3API.ConsoleList.newpoint.Y = PS3API.ConsoleList.newpoint.Y - PS3API.ConsoleList.y;
					this.formList.Location = PS3API.ConsoleList.newpoint;
				}
			}

			// Token: 0x06000CE6 RID: 3302 RVA: 0x00040CED File Offset: 0x0003EEED
			private void button1_Click(object sender, EventArgs e)
			{
				this.formList.Close();
			}

			// Token: 0x06000CE7 RID: 3303 RVA: 0x00040FC8 File Offset: 0x0003F1C8
			public bool Show()
			{
				bool Result = false;
				int tNum = -1;
				this.panel1.BackColor = Color.FromArgb(25, 25, 25);
				this.panel1.Dock = DockStyle.Left;
				this.panel1.ForeColor = Color.Black;
				this.panel1.Location = new Point(0, 0);
				this.panel1.Name = "panel1";
				this.panel1.Size = new Size(3, 195);
				this.panel1.TabIndex = 0;
				this.panel2.BackColor = Color.FromArgb(25, 25, 25);
				this.panel2.Dock = DockStyle.Right;
				this.panel2.ForeColor = Color.Black;
				this.panel2.Location = new Point(294, 0);
				this.panel2.Name = "panel2";
				this.panel2.Size = new Size(3, 195);
				this.panel2.TabIndex = 1;
				this.panel3.BackColor = Color.FromArgb(25, 25, 25);
				this.panel3.Controls.Add(this.label1);
				this.panel3.Controls.Add(this.button1);
				this.panel3.Controls.Add(this.panel5);
				this.panel3.Dock = DockStyle.Top;
				this.panel3.ForeColor = Color.Black;
				this.panel3.Location = new Point(3, 0);
				this.panel3.Name = "panel3";
				this.panel3.Size = new Size(291, 25);
				this.panel3.TabIndex = 2;
				this.panel3.MouseDown += new MouseEventHandler(this.xMouseDown);
				this.panel3.MouseMove += new MouseEventHandler(this.xMouseMove);
				this.panel4.BackColor = Color.FromArgb(25, 25, 25);
				this.panel4.Dock = DockStyle.Bottom;
				this.panel4.ForeColor = Color.Black;
				this.panel4.Location = new Point(3, 170);
				this.panel4.Name = "panel4";
				this.panel4.Size = new Size(291, 3);
				this.panel4.TabIndex = 3;
				this.button1.BackColor = Color.FromArgb(165, 165, 165);
				this.button1.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
				this.button1.FlatAppearance.BorderSize = 0;
				this.button1.FlatStyle = FlatStyle.Flat;
				this.button1.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
				this.button1.ForeColor = Color.Black;
				this.button1.Location = new Point(262, 0);
				this.button1.Name = "button1";
				this.button1.Size = new Size(30, 25);
				this.button1.TabIndex = 4;
				this.button1.Text = "X";
				this.button1.UseVisualStyleBackColor = false;
				this.button1.Click += new EventHandler(this.button1_Click);
				this.label1.AutoSize = true;
				this.label1.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
				this.label1.ForeColor = Color.White;
				this.label1.Location = new Point(32, 6);
				this.label1.Name = "label1";
				this.label1.Size = new Size(130, 15);
				this.label1.TabIndex = 0;
                this.label1.Text = "               ‎★ DownCraft RTM‎ ★";
				this.label1.MouseDown += new MouseEventHandler(this.xMouseDown);
				this.label1.MouseMove += new MouseEventHandler(this.xMouseMove);
				this.panel5.BackColor = Color.FromArgb(25, 25, 25);
				this.panel5.BackgroundImageLayout = ImageLayout.Stretch;
				this.panel5.ForeColor = Color.FromArgb(165, 165, 165);
				this.panel5.Location = new Point(3, 1);
				this.panel5.Name = "panel5";
				this.panel5.Size = new Size(30, 23);
				this.panel5.TabIndex = 4;
				this.btnConnect.Location = new Point(23, 260);
				this.btnConnect.Name = "btnConnect";
				this.btnConnect.Size = new Size(250, 33);
				this.btnConnect.BackColor = Color.FromArgb(165, 165, 165);
				this.btnConnect.ForeColor = Color.Black;
				this.btnConnect.FlatStyle = FlatStyle.Flat;
				this.btnConnect.FlatAppearance.BorderColor = Color.FromArgb(25, 25, 25);
				this.btnConnect.FlatAppearance.BorderSize = 2;
				this.btnConnect.TabIndex = 1;
				this.btnConnect.Text = this.strTraduction("btnConnect");
				this.btnConnect.UseVisualStyleBackColor = true;
				this.btnConnect.Enabled = true;
				this.btnConnect.Click += delegate(object sender, EventArgs e)
				{
					if (tNum > -1)
					{
						if (this.Api.ConnectTarget(this.data[tNum].Ip))
						{
							this.Api.setTargetName(this.data[tNum].Name);
							Result = true;
						}
						else
						{
							Result = false;
						}
						this.formList.Close();
					}
					else
					{
						MessageBox.Show(this.strTraduction("errorSelect"), "DownCraft RTM", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				};
				this.btnRefresh.Location = new Point(23, 297);
				this.btnRefresh.Name = "btnRefresh";
				this.btnRefresh.BackColor = Color.FromArgb(165, 165, 165);
				this.btnRefresh.ForeColor = Color.Black;
				this.btnRefresh.FlatStyle = FlatStyle.Flat;
				this.btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(165, 165, 165);
				this.btnRefresh.FlatAppearance.BorderSize = 2;
				this.btnRefresh.Size = new Size(250, 33);
				this.btnRefresh.TabIndex = 1;
				this.btnRefresh.Text = this.strTraduction("btnRefresh");
				this.btnRefresh.UseVisualStyleBackColor = true;
				this.btnRefresh.Click += delegate(object sender, EventArgs e)
				{
					tNum = -1;
					this.listView.Clear();
					this.btnConnect.Enabled = false;
					this.data = this.Api.CCAPI.GetConsoleList();
					int num2 = this.data.Count<CCAPI.ConsoleInfo>();
					for (int j = 0; j < num2; j++)
					{
						ListViewItem listViewItem2 = new ListViewItem(this.data[j].Name + " - " + this.data[j].Ip);
						listViewItem2.ImageIndex = 0;
						this.listView.Items.Add(listViewItem2);
					}
				};
				this.listView.BackColor = Color.FromArgb(165, 165, 165);
				this.listView.ForeColor = Color.Black;
				this.listView.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
				this.listViewGroup.Header = "Consoles";
				this.listViewGroup.Name = "consoleGroup";
				this.listView.Groups.AddRange(new ListViewGroup[]
				{
					this.listViewGroup
				});
				this.listView.HideSelection = false;
				this.listView.Location = new Point(23, 41);
				this.listView.MultiSelect = false;
				this.listView.Name = "ConsoleList";
				this.listView.ShowGroups = false;
				this.listView.Size = new Size(250, 215);
				this.listView.TabIndex = 0;
				this.listView.UseCompatibleStateImageBehavior = false;
				this.listView.View = View.List;
				this.listView.ItemSelectionChanged += delegate(object sender, ListViewItemSelectionChangedEventArgs e)
				{
					tNum = e.ItemIndex;
					this.btnConnect.Enabled = true;
					if (this.data[tNum].Name.Length > 18)
					{
						string text = this.data[tNum].Name.Substring(0, 17) + "...";
					}
					else
					{
						string text = this.data[tNum].Name;
					}
					if (this.data[tNum].Ip.Length > 16)
					{
						string text2 = this.data[tNum].Name.Substring(0, 16) + "...";
					}
					else
					{
						string text2 = this.data[tNum].Ip;
					}
				};
				this.formList.MinimizeBox = false;
				this.formList.MaximizeBox = false;
				this.formList.ClientSize = new Size(297, 350);
				this.formList.AutoScaleDimensions = new SizeF(6f, 13f);
				this.formList.AutoScaleMode = AutoScaleMode.Font;
				this.formList.BackColor = Color.FromArgb(25, 25, 25);
				this.formList.ForeColor = Color.FromArgb(25, 25, 25);
				this.formList.FormBorderStyle = FormBorderStyle.None;
				this.formList.StartPosition = FormStartPosition.CenterScreen;
				this.formList.Text = "Connect To Ps3";
				this.formList.Controls.Add(this.listView);
				this.formList.Controls.Add(this.btnConnect);
				this.formList.Controls.Add(this.btnRefresh);
				this.formList.Controls.Add(this.panel4);
				this.formList.Controls.Add(this.panel3);
				this.formList.Controls.Add(this.panel2);
				this.formList.Controls.Add(this.panel1);
				this.panel1.ResumeLayout(false);
				this.panel1.PerformLayout();
				this.panel2.ResumeLayout(false);
				this.panel2.PerformLayout();
				this.panel3.ResumeLayout(false);
				this.panel3.PerformLayout();
				this.panel4.ResumeLayout(false);
				this.panel4.PerformLayout();
				this.formList.ResumeLayout(false);
				this.formList.PerformLayout();
                this.nyX_Theme1.ResumeLayout(false);
                this.nyX_Theme1.PerformLayout();
				int num = this.data.Count<CCAPI.ConsoleInfo>();
				for (int i = 0; i < num; i++)
				{
					ListViewItem listViewItem = new ListViewItem(" " + this.data[i].Name + " - " + this.data[i].Ip);
					listViewItem.ImageIndex = 0;
					this.listView.Items.Add(listViewItem);
				}
				if (num > 0)
				{
					this.formList.ShowDialog();
				}
				else
				{
					Result = false;
					this.formList.Close();
					MessageBox.Show(this.strTraduction("noConsole"), this.strTraduction("noConsoleTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				return Result;
			}

			// Token: 0x0400053B RID: 1339
			private PS3API Api;

			// Token: 0x0400053C RID: 1340
			private List<CCAPI.ConsoleInfo> data;

			// Token: 0x0400053D RID: 1341
			public static int y;

			// Token: 0x0400053E RID: 1342
			public static int x;

			// Token: 0x0400053F RID: 1343
			public static Point newpoint = default(Point);

			// Token: 0x04000540 RID: 1344
			private Panel panel1 = new Panel();

			// Token: 0x04000541 RID: 1345
			private Panel panel2 = new Panel();

			// Token: 0x04000542 RID: 1346
			private Panel panel3 = new Panel();

			// Token: 0x04000543 RID: 1347
			private Panel panel4 = new Panel();

			// Token: 0x04000544 RID: 1348
			private Panel panel5 = new Panel();

			// Token: 0x04000545 RID: 1349
			private Button button1 = new Button();

			// Token: 0x04000546 RID: 1350
			private Label label1 = new Label();

			// Token: 0x04000547 RID: 1351
			private Button btnConnect = new Button();

			// Token: 0x04000548 RID: 1352
			private Button btnRefresh = new Button();

			// Token: 0x04000549 RID: 1353
			private ListViewGroup listViewGroup = new ListViewGroup("Consoles", HorizontalAlignment.Center);

			// Token: 0x0400054A RID: 1354
			private ListView listView = new ListView();

			// Token: 0x0400054B RID: 1355
			private Form formList = new Form();

            private Form nyX_Theme1 = new Form();
		}

        internal void SetMemory(object offset, byte[] v)
        {
            throw new NotImplementedException();
        }

        internal object SetMemory(uint offset, int v)
        {
            throw new NotImplementedException();
        }

        internal object SetMemory(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
