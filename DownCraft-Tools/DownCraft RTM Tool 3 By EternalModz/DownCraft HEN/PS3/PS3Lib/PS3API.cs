using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PS3Lib
{
	// Token: 0x02000017 RID: 23
	public class PS3API
	{
		// Token: 0x06000073 RID: 115 RVA: 0x00002502 File Offset: 0x00000702
		public PS3API(SelectAPI API = SelectAPI.TargetManager)
		{
			PS3API.SetAPI.API = API;
			this.MakeInstanceAPI(API);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002517 File Offset: 0x00000717
		public void setTargetName(string value)
		{
			PS3API.targetName = value;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000251F File Offset: 0x0000071F
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

		// Token: 0x06000076 RID: 118 RVA: 0x0000254A File Offset: 0x0000074A
		public void SetFormLang(Lang Language)
		{
			PS3API.SetLang.defaultLang = Language;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002552 File Offset: 0x00000752
		public void InitTarget()
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.InitComms();
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003AF4 File Offset: 0x00001CF4
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
				result = PS3API.Common.CcApi.ConnectTarget();
			}
			return result;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002566 File Offset: 0x00000766
		public bool ConnectTarget(string ip)
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			if (PS3API.Common.CcApi.SUCCESS(PS3API.Common.CcApi.ConnectTarget(ip)))
			{
				PS3API.targetIp = ip;
				return true;
			}
			return false;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002594 File Offset: 0x00000794
		public void DisconnectTarget()
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.DisconnectTarget();
				return;
			}
			PS3API.Common.CcApi.DisconnectTarget();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003B34 File Offset: 0x00001D34
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

		// Token: 0x0600007C RID: 124 RVA: 0x00003B84 File Offset: 0x00001D84
		public string GetConsoleName()
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				return PS3API.Common.TmApi.SCE.GetTargetName();
			}
			if (PS3API.targetName != string.Empty)
			{
				return PS3API.targetName;
			}
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
							return list[i].Name;
						}
					}
				}
			}
			return PS3API.targetIp;
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000025B4 File Offset: 0x000007B4
		public void SetMemory(uint offset, byte[] buffer)
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.SetMemory(offset, buffer);
				return;
			}
			if (PS3API.SetAPI.API == SelectAPI.ControlConsole)
			{
				PS3API.Common.CcApi.SetMemory(offset, buffer);
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000025DF File Offset: 0x000007DF
		public void GetMemory(uint offset, byte[] buffer)
		{
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				PS3API.Common.TmApi.GetMemory(offset, buffer);
				return;
			}
			if (PS3API.SetAPI.API == SelectAPI.ControlConsole)
			{
				PS3API.Common.CcApi.GetMemory(offset, buffer);
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003C28 File Offset: 0x00001E28
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

		// Token: 0x06000080 RID: 128 RVA: 0x0000260A File Offset: 0x0000080A
		public void ChangeAPI(SelectAPI API)
		{
			PS3API.SetAPI.API = API;
			this.MakeInstanceAPI(this.GetCurrentAPI());
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000261E File Offset: 0x0000081E
		public SelectAPI GetCurrentAPI()
		{
			return PS3API.SetAPI.API;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003C68 File Offset: 0x00001E68
		public string GetCurrentAPIName()
		{
			string result = string.Empty;
			if (PS3API.SetAPI.API == SelectAPI.TargetManager)
			{
				result = Enum.GetName(typeof(SelectAPI), SelectAPI.TargetManager).Replace("Manager", " Manager");
			}
			else
			{
				result = "PS3M_API";
			}
			return result;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00002625 File Offset: 0x00000825
		public Assembly PS3TMAPI_NET()
		{
			return PS3API.Common.TmApi.PS3TMAPI_NET();
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00002631 File Offset: 0x00000831
		public Extension Extension
		{
			get
			{
				return new Extension(PS3API.SetAPI.API);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000263D File Offset: 0x0000083D
		public TMAPI TMAPI
		{
			get
			{
				return new TMAPI();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00002644 File Offset: 0x00000844
		public CCAPI CCAPI
		{
			get
			{
				return new CCAPI();
			}
		}

		// Token: 0x04000054 RID: 84
		private static string targetName = string.Empty;

		// Token: 0x04000055 RID: 85
		private static string targetIp = string.Empty;

		// Token: 0x02000018 RID: 24
		private class SetLang
		{
			// Token: 0x04000056 RID: 86
			public static Lang defaultLang;
		}

		// Token: 0x02000019 RID: 25
		private class SetAPI
		{
			// Token: 0x04000057 RID: 87
			public static SelectAPI API;
		}

		// Token: 0x0200001A RID: 26
		private class Common
		{
			// Token: 0x04000058 RID: 88
			public static CCAPI CcApi;

			// Token: 0x04000059 RID: 89
			public static TMAPI TmApi;
		}

		// Token: 0x0200001B RID: 27
		public class ConsoleList
		{
			// Token: 0x0600008C RID: 140 RVA: 0x00002663 File Offset: 0x00000863
			public ConsoleList(PS3API f)
			{
				this.Api = f;
				this.data = this.Api.CCAPI.GetConsoleList();
			}

			// Token: 0x0600008D RID: 141 RVA: 0x00002688 File Offset: 0x00000888
			private Lang getSysLanguage()
			{
				if (PS3API.SetLang.defaultLang != Lang.Null)
				{
					return PS3API.SetLang.defaultLang;
				}
				if (CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName.StartsWith("FRA"))
				{
					return Lang.French;
				}
				return Lang.English;
			}

			// Token: 0x0600008E RID: 142 RVA: 0x00003CB4 File Offset: 0x00001EB4
			private string strTraduction(string keyword)
			{
				if (this.getSysLanguage() == Lang.French)
				{
					switch (keyword)
					{
					case "btnConnect":
						return "Connexion";
					case "btnRefresh":
						return "Rafraîchir";
					case "errorSelect":
						return "Vous devez d'abord sélectionner une console.";
					case "errorSelectTitle":
						return "Sélectionnez une console.";
					case "selectGrid":
						return "Sélectionnez une console dans la grille.";
					case "selectedLbl":
						return "Sélection :";
					case "formTitle":
						return "Choisissez une console...";
					case "noConsole":
						return "Aucune console disponible, démarrez CCAPI Manager (v2.5) et ajoutez une nouvelle console.";
					case "noConsoleTitle":
						return "Aucune console disponible.";
					}
				}
				else
					switch (keyword)
					{
					case "btnConnect":
						return "Connection";
					case "btnRefresh":
						return "Refresh";
					case "errorSelect":
						return "You need to select a console first.";
					case "errorSelectTitle":
						return "Select a console.";
					case "selectGrid":
						return "Select a console within this grid.";
					case "selectedLbl":
						return "Selected :";
					case "formTitle":
						return "Select a console...";
					case "noConsole":
						return "None consoles available, run CCAPI Manager (v2.5) and add a new console.";
					case "noConsoleTitle":
						return "None console available.";
					}
				return "?";
			}

			// Token: 0x0600008F RID: 143 RVA: 0x00003ED4 File Offset: 0x000020D4
			public bool Show()
			{
				bool Result = false;
				int tNum = -1;
				Label lblInfo = new Label();
				Button btnConnect = new Button();
				Button button = new Button();
				ListViewGroup listViewGroup = new ListViewGroup("Consoles", HorizontalAlignment.Left);
				ListView listView = new ListView();
				Form formList = new Form();
				btnConnect.Location = new Point(12, 254);
				btnConnect.Name = "btnConnect";
				btnConnect.Size = new Size(198, 23);
				btnConnect.TabIndex = 1;
				btnConnect.Text = this.strTraduction("btnConnect");
				btnConnect.UseVisualStyleBackColor = true;
				btnConnect.Enabled = false;
				btnConnect.Click += delegate(object sender, EventArgs e)
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
						formList.Close();
						return;
					}
					MessageBox.Show(this.strTraduction("errorSelect"), this.strTraduction("errorSelectTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				};
				button.Location = new Point(216, 254);
				button.Name = "btnRefresh";
				button.Size = new Size(86, 23);
				button.TabIndex = 1;
				button.Text = this.strTraduction("btnRefresh");
				button.UseVisualStyleBackColor = true;
				button.Click += delegate(object sender, EventArgs e)
				{
					tNum = -1;
					listView.Clear();
					lblInfo.Text = this.strTraduction("selectGrid");
					btnConnect.Enabled = false;
					this.data = this.Api.CCAPI.GetConsoleList();
					int num2 = this.data.Count<CCAPI.ConsoleInfo>();
					for (int j = 0; j < num2; j++)
					{
						ListViewItem listViewItem2 = new ListViewItem(" " + this.data[j].Name + " - " + this.data[j].Ip);
						listViewItem2.ImageIndex = 0;
						listView.Items.Add(listViewItem2);
					}
				};
				listView.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
				listViewGroup.Header = "Consoles";
				listViewGroup.Name = "consoleGroup";
				listView.Groups.AddRange(new ListViewGroup[]
				{
					listViewGroup
				});
				listView.HideSelection = false;
				listView.Location = new Point(12, 12);
				listView.MultiSelect = false;
				listView.Name = "ConsoleList";
				listView.ShowGroups = false;
				listView.Size = new Size(290, 215);
				listView.TabIndex = 0;
				listView.UseCompatibleStateImageBehavior = false;
				listView.View = View.List;
				listView.ItemSelectionChanged += delegate(object sender, ListViewItemSelectionChangedEventArgs e)
				{
					tNum = e.ItemIndex;
					btnConnect.Enabled = true;
					string text;
					if (this.data[tNum].Name.Length > 18)
					{
						text = this.data[tNum].Name.Substring(0, 17) + "...";
					}
					else
					{
						text = this.data[tNum].Name;
					}
					string text2;
					if (this.data[tNum].Ip.Length > 16)
					{
						text2 = this.data[tNum].Name.Substring(0, 16) + "...";
					}
					else
					{
						text2 = this.data[tNum].Ip;
					}
					lblInfo.Text = string.Concat(new string[]
					{
						this.strTraduction("selectedLbl"),
						" ",
						text,
						" / ",
						text2
					});
				};
				lblInfo.AutoSize = true;
				lblInfo.Location = new Point(12, 234);
				lblInfo.Name = "lblInfo";
				lblInfo.Size = new Size(158, 13);
				lblInfo.TabIndex = 3;
				lblInfo.Text = this.strTraduction("selectGrid");
				formList.MinimizeBox = false;
				formList.MaximizeBox = false;
				formList.ClientSize = new Size(314, 285);
				formList.AutoScaleDimensions = new SizeF(6f, 13f);
				formList.AutoScaleMode = AutoScaleMode.Font;
				formList.FormBorderStyle = FormBorderStyle.FixedSingle;
				formList.StartPosition = FormStartPosition.CenterScreen;
				formList.Text = this.strTraduction("formTitle");
				formList.Controls.Add(listView);
				formList.Controls.Add(lblInfo);
				formList.Controls.Add(btnConnect);
				formList.Controls.Add(button);
				ImageList smallImageList = new ImageList();
				listView.SmallImageList = smallImageList;
				int num = this.data.Count<CCAPI.ConsoleInfo>();
				for (int i = 0; i < num; i++)
				{
					ListViewItem listViewItem = new ListViewItem(" " + this.data[i].Name + " - " + this.data[i].Ip);
					listViewItem.ImageIndex = 0;
					listView.Items.Add(listViewItem);
				}
				if (num > 0)
				{
					formList.ShowDialog();
				}
				else
				{
					Result = false;
					formList.Close();
					MessageBox.Show(this.strTraduction("noConsole"), this.strTraduction("noConsoleTitle"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				return Result;
			}

			// Token: 0x0400005A RID: 90
			private PS3API Api;

			// Token: 0x0400005B RID: 91
			private List<CCAPI.ConsoleInfo> data;
		}
	}
}
