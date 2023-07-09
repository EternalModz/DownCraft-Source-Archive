using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace PS3Lib
{
	public class PS3API
	{
		public PS3API(PS3Lib.SelectAPI API = PS3Lib.SelectAPI.TargetManager)
		{
			PS3Lib.PS3API.SetAPI.API = API;
			this.MakeInstanceAPI(API);
		}

		public void setTargetName(string value)
		{
			PS3Lib.PS3API.targetName = value;
		}

		private void MakeInstanceAPI(PS3Lib.SelectAPI API)
		{
			if (API == PS3Lib.SelectAPI.TargetManager && PS3Lib.PS3API.Common.TmApi == null)
			{
				PS3Lib.PS3API.Common.TmApi = new PS3Lib.TMAPI();
			}
			if (API == PS3Lib.SelectAPI.ControlConsole && PS3Lib.PS3API.Common.CcApi == null)
			{
				PS3Lib.PS3API.Common.CcApi = new PS3Lib.CCAPI();
			}
			if (API == PS3Lib.SelectAPI.PS3Manager && PS3Lib.PS3API.Common.MaPi == null)
			{
				PS3Lib.PS3API.Common.MaPi = new PS3Lib.PS3MAPI();
			}
		}

		public void SetFormLang(PS3Lib.Lang Language)
		{
			PS3Lib.PS3API.SetLang.DefaultLang = Language;
		}

		public void InitTarget()
		{
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				PS3Lib.PS3API.Common.TmApi.InitComms();
			}
		}

		public bool ConnectTarget(int target = 0)
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			bool result;
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				result = PS3Lib.PS3API.Common.TmApi.ConnectTarget(target);
			}
			else
			{
				result = new PS3Lib.PS3API.ConsoleList(this).Show();
			}
			return result;
		}

		public bool ConnectTarget(string ip)
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			bool result;
			if (PS3Lib.PS3API.Common.CcApi.SUCCESS(PS3Lib.PS3API.Common.CcApi.ConnectTarget(ip)))
			{
				PS3Lib.PS3API.targetIp = ip;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool ConnectTarget(string ip, bool isMapi)
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			bool result = false;
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.PS3Manager)
			{
				result = PS3Lib.PS3API.Common.MaPi.ConnectTarget(ip, 0x1ECF);
			}
			return result;
		}

		public void DisconnectTarget()
		{
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				PS3Lib.PS3API.Common.TmApi.DisconnectTarget();
			}
			else
			{
				PS3Lib.PS3API.Common.CcApi.DisconnectTarget();
			}
		}

		public bool AttachProcess()
		{
			this.MakeInstanceAPI(this.GetCurrentAPI());
			bool result = false;
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				result = PS3Lib.PS3API.Common.TmApi.AttachProcess();
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.ControlConsole)
			{
				result = PS3Lib.PS3API.Common.CcApi.SUCCESS(PS3Lib.PS3API.Common.CcApi.AttachProcess());
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.PS3Manager)
			{
				PS3Lib.PS3API.p_id = PS3Lib.PS3API.Common.MaPi.Process.GetPidProcesses()[0];
				result = PS3Lib.PS3API.Common.MaPi.AttachProcess(PS3Lib.PS3API.p_id);
			}
			return result;
		}

		public string GetConsoleName()
		{
			string result;
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				result = PS3Lib.PS3API.Common.TmApi.SCE.GetTargetName();
			}
			else if (PS3Lib.PS3API.targetName != string.Empty)
			{
				result = PS3Lib.PS3API.targetName;
			}
			else
			{
				if (PS3Lib.PS3API.targetIp != string.Empty)
				{
					System.Collections.Generic.List<PS3Lib.CCAPI.ConsoleInfo> list = new System.Collections.Generic.List<PS3Lib.CCAPI.ConsoleInfo>();
					list = PS3Lib.PS3API.Common.CcApi.GetConsoleList();
					if (list.Count > 0)
					{
						for (int i = 0; i < list.Count; i++)
						{
							if (list[i].Ip == PS3Lib.PS3API.targetIp)
							{
								return list[i].Name;
							}
						}
					}
				}
				result = PS3Lib.PS3API.targetIp;
			}
			return result;
		}

		public void SetMemory(uint offset, byte[] buffer)
		{
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				PS3Lib.PS3API.Common.TmApi.SetMemory(offset, buffer);
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.ControlConsole)
			{
				PS3Lib.PS3API.Common.CcApi.SetMemory(offset, buffer);
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.PS3Manager)
			{
				PS3Lib.PS3API.Common.MaPi.Process.Memory.Set(PS3Lib.PS3API.p_id, (ulong)offset, buffer);
			}
		}

		public void GetMemory(uint offset, byte[] buffer)
		{
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				PS3Lib.PS3API.Common.TmApi.GetMemory(offset, buffer);
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.ControlConsole)
			{
				PS3Lib.PS3API.Common.CcApi.GetMemory(offset, buffer);
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.PS3Manager)
			{
				PS3Lib.PS3API.Common.MaPi.Process.Memory.Get(PS3Lib.PS3API.p_id, (ulong)offset, buffer);
			}
		}

		public byte[] GetBytes(uint offset, int length)
		{
			byte[] array = new byte[length];
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				PS3Lib.PS3API.Common.TmApi.GetMemory(offset, array);
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.ControlConsole)
			{
				PS3Lib.PS3API.Common.CcApi.GetMemory(offset, array);
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.PS3Manager)
			{
				PS3Lib.PS3API.Common.MaPi.Process.Memory.Get(PS3Lib.PS3API.p_id, (ulong)offset, array);
			}
			return array;
		}

		public void ChangeAPI(PS3Lib.SelectAPI API)
		{
			PS3Lib.PS3API.SetAPI.API = API;
			this.MakeInstanceAPI(this.GetCurrentAPI());
		}

		public PS3Lib.SelectAPI GetCurrentAPI()
		{
			return PS3Lib.PS3API.SetAPI.API;
		}

		public string GetCurrentAPIName()
		{
			string result = string.Empty;
			if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.TargetManager)
			{
				result = System.Enum.GetName(typeof(PS3Lib.SelectAPI), PS3Lib.SelectAPI.TargetManager).Replace("Manager", " Manager");
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.ControlConsole)
			{
				result = System.Enum.GetName(typeof(PS3Lib.SelectAPI), PS3Lib.SelectAPI.ControlConsole).Replace("Console", " Console");
			}
			else if (PS3Lib.PS3API.SetAPI.API == PS3Lib.SelectAPI.PS3Manager)
			{
				result = System.Enum.GetName(typeof(PS3Lib.SelectAPI), PS3Lib.SelectAPI.PS3Manager).Replace("Manager", " Manager");
			}
			return result;
		}

		public System.Reflection.Assembly PS3TMAPI_NET()
		{
			return PS3Lib.PS3API.Common.TmApi.PS3TMAPI_NET();
		}

		public PS3Lib.Extension Extension
		{
			get
			{
				return new PS3Lib.Extension(PS3Lib.PS3API.SetAPI.API);
			}
		}

		public PS3Lib.TMAPI TMAPI
		{
			get
			{
				return new PS3Lib.TMAPI();
			}
		}

		public PS3Lib.CCAPI CCAPI
		{
			get
			{
				return new PS3Lib.CCAPI();
			}
		}

		public PS3Lib.PS3MAPI MAPI
		{
			get
			{
				return new PS3Lib.PS3MAPI();
			}
		}

		// Note: this type is marked as 'beforefieldinit'.
		static PS3API()
		{
		}

		private static string targetName = string.Empty;

		private static string targetIp = string.Empty;

		public static uint p_id = 0U;

		private class SetLang
		{
			public SetLang()
			{
			}

			// Note: this type is marked as 'beforefieldinit'.
			static SetLang()
			{
			}

			public static PS3Lib.Lang DefaultLang = PS3Lib.Lang.Null;
		}

		private class SetAPI
		{
			public SetAPI()
			{
			}

			public static PS3Lib.SelectAPI API;
		}

		private class Common
		{
			public Common()
			{
			}

			public static PS3Lib.CCAPI CcApi;

			public static PS3Lib.TMAPI TmApi;

			public static PS3Lib.PS3MAPI MaPi;
		}

		public class ConsoleList
		{
			public ConsoleList(PS3Lib.PS3API f)
			{
				this.Api = f;
				this.data = this.Api.CCAPI.GetConsoleList();
			}

			private PS3Lib.Lang getSysLanguage()
			{
				PS3Lib.Lang result;
				if (PS3Lib.PS3API.SetLang.DefaultLang == PS3Lib.Lang.Null)
				{
					if (CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName.StartsWith("FRA"))
					{
						result = PS3Lib.Lang.French;
					}
					else if (CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName.StartsWith("GER"))
					{
						result = PS3Lib.Lang.German;
					}
					else
					{
						result = PS3Lib.Lang.English;
					}
				}
				else
				{
					result = PS3Lib.PS3API.SetLang.DefaultLang;
				}
				return result;
			}

			private string strTraduction(string keyword)
			{
				PS3Lib.Lang sysLanguage = this.getSysLanguage();
				if (sysLanguage == PS3Lib.Lang.French)
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
						return "Aucune console disponible, démarrez CCAPI Manager (v2.60+) et ajoutez une nouvelle console.";
					case "noConsoleTitle":
						return "Aucune console disponible.";
					}
				}
				else if (sysLanguage == PS3Lib.Lang.German)
				{
					switch (keyword)
					{
					case "btnConnect":
						return "Verbinde";
					case "btnRefresh":
						return "Wiederholen";
					case "errorSelect":
						return "Du musst zuerst eine Konsole auswählen.";
					case "errorSelectTitle":
						return "Wähle eine Konsole.";
					case "selectGrid":
						return "Wähle eine Konsole innerhalb dieses Gitters.";
					case "selectedLbl":
						return "Ausgewählt :";
					case "formTitle":
						return "Wähle eine Konsole...";
					case "noConsole":
						return "Keine Konsolen verfügbar - starte CCAPI Manager (v2.60+) und füge eine neue Konsole hinzu.";
					case "noConsoleTitle":
						return "Keine Konsolen verfügbar.";
					}
				}
				else
					switch (keyword)
					{
					case "btnConnect":
						return "Connect To PS3";
					case "btnRefresh":
						return "Refresh List";
					case "errorSelect":
						return "You need to select a console to connect to.";
					case "errorSelectTitle":
						return "Select a console.";
					case "selectGrid":
						return "Select a console within this grid.";
					case "selectedLbl":
						return "Selected :";
					case "formTitle":
						return "Select a console...";
					case "noConsole":
						return "None consoles available, run CCAPI Manager (v2.60+) and add a new console.";
					case "noConsoleTitle":
						return "None console available.";
					}
				return "?";
			}

			private void xMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				PS3Lib.PS3API.ConsoleList.x = System.Windows.Forms.Control.MousePosition.X - this.formList.Location.X;
				PS3Lib.PS3API.ConsoleList.y = System.Windows.Forms.Control.MousePosition.Y - this.formList.Location.Y;
			}

			private void xMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					PS3Lib.PS3API.ConsoleList.newpoint = System.Windows.Forms.Control.MousePosition;
					PS3Lib.PS3API.ConsoleList.newpoint.X = PS3Lib.PS3API.ConsoleList.newpoint.X - PS3Lib.PS3API.ConsoleList.x;
					PS3Lib.PS3API.ConsoleList.newpoint.Y = PS3Lib.PS3API.ConsoleList.newpoint.Y - PS3Lib.PS3API.ConsoleList.y;
					this.formList.Location = PS3Lib.PS3API.ConsoleList.newpoint;
				}
			}

			private void button1_Click(object sender, System.EventArgs e)
			{
				this.formList.Close();
			}

			public bool Show()
			{
				bool Result = false;
				int tNum = -1;
				this.panel1.BackColor = System.Drawing.Color.FromArgb(0x35, 0x64, 0xB9);
				this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
				this.panel1.ForeColor = System.Drawing.Color.Black;
				this.panel1.Location = new System.Drawing.Point(0, 0);
				this.panel1.Name = "panel1";
				this.panel1.Size = new System.Drawing.Size(3, 0xC3);
				this.panel1.TabIndex = 0;
				this.panel2.BackColor = System.Drawing.Color.FromArgb(0x35, 0x64, 0xB9);
				this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
				this.panel2.ForeColor = System.Drawing.Color.Black;
				this.panel2.Location = new System.Drawing.Point(0x126, 0);
				this.panel2.Name = "panel2";
				this.panel2.Size = new System.Drawing.Size(3, 0xC3);
				this.panel2.TabIndex = 1;
				this.panel3.BackColor = System.Drawing.Color.FromArgb(0x35, 0x64, 0xB9);
				this.panel3.Controls.Add(this.label1);
				this.panel3.Controls.Add(this.button1);
				this.panel3.Controls.Add(this.panel5);
				this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
				this.panel3.ForeColor = System.Drawing.Color.Black;
				this.panel3.Location = new System.Drawing.Point(3, 0);
				this.panel3.Name = "panel3";
				this.panel3.Size = new System.Drawing.Size(0x123, 0x19);
				this.panel3.TabIndex = 2;
				this.panel3.MouseDown += this.xMouseDown;
				this.panel3.MouseMove += this.xMouseMove;
				this.panel4.BackColor = System.Drawing.Color.FromArgb(0x35, 0x64, 0xB9);
				this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
				this.panel4.ForeColor = System.Drawing.Color.Black;
				this.panel4.Location = new System.Drawing.Point(3, 0xAA);
				this.panel4.Name = "panel4";
				this.panel4.Size = new System.Drawing.Size(0x123, 3);
				this.panel4.TabIndex = 3;
				this.button1.BackColor = System.Drawing.Color.FromArgb(0x35, 0x64, 0xB9);
				this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0x18, 0x3E, 0x4D);
				this.button1.FlatAppearance.BorderSize = 0;
				this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				this.button1.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
				this.button1.ForeColor = System.Drawing.Color.DarkGray;
				this.button1.Location = new System.Drawing.Point(0x106, 0);
				this.button1.Name = "button1";
				this.button1.Size = new System.Drawing.Size(0x1E, 0x19);
				this.button1.TabIndex = 4;
				this.button1.Text = "X";
				this.button1.UseVisualStyleBackColor = false;
				this.button1.Click += this.button1_Click;
				this.label1.AutoSize = true;
				this.label1.Font = new System.Drawing.Font("Agency FB", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
				this.label1.ForeColor = System.Drawing.Color.DarkGray;
				this.label1.Location = new System.Drawing.Point(0x20, 6);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(0x82, 0xF);
				this.label1.TabIndex = 0;
				this.label1.Text = "Demonic V1";
				this.label1.MouseDown += this.xMouseDown;
				this.label1.MouseMove += this.xMouseMove;
				this.panel5.BackColor = System.Drawing.Color.FromArgb(0x35, 0x64, 0xB9);
				this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
				this.panel5.ForeColor = System.Drawing.Color.FromArgb(0x18, 0x91, 0xE3);
				this.panel5.Location = new System.Drawing.Point(3, 1);
				this.panel5.Name = "panel5";
				this.panel5.Size = new System.Drawing.Size(0x1E, 0x17);
				this.panel5.TabIndex = 4;
				this.btnConnect.Location = new System.Drawing.Point(0x17, 0x104);
				this.btnConnect.Name = "btnConnect";
				this.btnConnect.Size = new System.Drawing.Size(0xFA, 0x21);
				this.btnConnect.BackColor = System.Drawing.Color.FromArgb(0x21, 0x40, 0x77);
				this.btnConnect.ForeColor = System.Drawing.Color.DarkGray;
				this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0x16, 0x2B, 0x50);
				this.btnConnect.FlatAppearance.BorderSize = 2;
				this.btnConnect.TabIndex = 1;
				this.btnConnect.Text = this.strTraduction("btnConnect");
				this.btnConnect.UseVisualStyleBackColor = true;
				this.btnConnect.Enabled = true;
				this.btnConnect.Click += delegate(object sender, System.EventArgs e)
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
						System.Windows.Forms.MessageBox.Show(this.strTraduction("errorSelect"), "SkullGrabber", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
				};
				this.btnRefresh.Location = new System.Drawing.Point(0x17, 0x129);
				this.btnRefresh.Name = "btnRefresh";
				this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(0x21, 0x40, 0x77);
				this.btnRefresh.ForeColor = System.Drawing.Color.DarkGray;
				this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0x16, 0x2B, 0x50);
				this.btnRefresh.FlatAppearance.BorderSize = 2;
				this.btnRefresh.Size = new System.Drawing.Size(0xFA, 0x21);
				this.btnRefresh.TabIndex = 1;
				this.btnRefresh.Text = this.strTraduction("btnRefresh");
				this.btnRefresh.UseVisualStyleBackColor = true;
				this.btnRefresh.Click += delegate(object sender, System.EventArgs e)
				{
					tNum = -1;
					this.listView.Clear();
					this.btnConnect.Enabled = false;
					this.data = this.Api.CCAPI.GetConsoleList();
					int num2 = this.data.Count<PS3Lib.CCAPI.ConsoleInfo>();
					for (int j = 0; j < num2; j++)
					{
						System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(this.data[j].Name + " - " + this.data[j].Ip);
						listViewItem2.ImageIndex = 0;
						this.listView.Items.Add(listViewItem2);
					}
				};
				this.listView.BackColor = System.Drawing.Color.FromArgb(0x16, 0x2B, 0x50);
				this.listView.ForeColor = System.Drawing.Color.DarkGray;
				this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
				this.listViewGroup.Header = "Consoles";
				this.listViewGroup.Name = "consoleGroup";
				this.listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[]
				{
					this.listViewGroup
				});
				this.listView.HideSelection = false;
				this.listView.Location = new System.Drawing.Point(0x17, 0x29);
				this.listView.MultiSelect = false;
				this.listView.Name = "ConsoleList";
				this.listView.ShowGroups = false;
				this.listView.Size = new System.Drawing.Size(0xFA, 0xD7);
				this.listView.TabIndex = 0;
				this.listView.UseCompatibleStateImageBehavior = false;
				this.listView.View = System.Windows.Forms.View.List;
				this.listView.ItemSelectionChanged += delegate(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
				{
					tNum = e.ItemIndex;
					this.btnConnect.Enabled = true;
					if (this.data[tNum].Name.Length > 0x12)
					{
						string text = this.data[tNum].Name.Substring(0, 0x11) + "...";
					}
					else
					{
						string text = this.data[tNum].Name;
					}
					if (this.data[tNum].Ip.Length > 0x10)
					{
						string text2 = this.data[tNum].Name.Substring(0, 0x10) + "...";
					}
					else
					{
						string text2 = this.data[tNum].Ip;
					}
				};
				this.formList.MinimizeBox = false;
				this.formList.MaximizeBox = false;
				this.formList.ClientSize = new System.Drawing.Size(0x129, 0x15E);
				this.formList.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
				this.formList.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.formList.BackColor = System.Drawing.Color.FromArgb(0x19, 0x19, 0x19);
				this.formList.ForeColor = System.Drawing.Color.FromArgb(0x35, 0x64, 0xB9);
				this.formList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				this.formList.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.formList.Text = "SkullGrabber";
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
				int num = this.data.Count<PS3Lib.CCAPI.ConsoleInfo>();
				for (int i = 0; i < num; i++)
				{
					System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem(" " + this.data[i].Name + " - " + this.data[i].Ip);
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
					System.Windows.Forms.MessageBox.Show(this.strTraduction("noConsole"), this.strTraduction("noConsoleTitle"), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
				return Result;
			}

			// Note: this type is marked as 'beforefieldinit'.
			static ConsoleList()
			{
			}

			private PS3Lib.PS3API Api;

			private System.Collections.Generic.List<PS3Lib.CCAPI.ConsoleInfo> data;

			public static int y;

			public static int x;

			public static System.Drawing.Point newpoint = default(System.Drawing.Point);

			private System.Windows.Forms.Panel panel1 = new System.Windows.Forms.Panel();

			private System.Windows.Forms.Panel panel2 = new System.Windows.Forms.Panel();

			private System.Windows.Forms.Panel panel3 = new System.Windows.Forms.Panel();

			private System.Windows.Forms.Panel panel4 = new System.Windows.Forms.Panel();

			private System.Windows.Forms.Panel panel5 = new System.Windows.Forms.Panel();

			private System.Windows.Forms.Button button1 = new System.Windows.Forms.Button();

			private System.Windows.Forms.Label label1 = new System.Windows.Forms.Label();

			private System.Windows.Forms.Button btnConnect = new System.Windows.Forms.Button();

			private System.Windows.Forms.Button btnRefresh = new System.Windows.Forms.Button();

			private System.Windows.Forms.ListViewGroup listViewGroup = new System.Windows.Forms.ListViewGroup("Consoles", System.Windows.Forms.HorizontalAlignment.Center);

			private System.Windows.Forms.ListView listView = new System.Windows.Forms.ListView();

			private System.Windows.Forms.Form formList = new System.Windows.Forms.Form();

			
		}
	}
}
