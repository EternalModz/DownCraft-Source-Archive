using PS3Lib;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PS3ManagerAPI
{
	// Token: 0x02000005 RID: 5
	public class PS3MAPI
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002B74 File Offset: 0x00000D74
		public PS3MAPI()
		{
			this.Core = new PS3MAPI.CORE_CMD();
			this.Server = new PS3MAPI.SERVER_CMD();
			this.PS3 = new PS3MAPI.PS3_CMD();
			this.Process = new PS3MAPI.PROCESS_CMD();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002BF8 File Offset: 0x00000DF8
		public string GetLibVersion_Str()
		{
			string text = this.PS3M_API_PC_LIB_VERSION.ToString("X4");
			string str = text.Substring(1, 1) + ".";
			string str2 = text.Substring(2, 1) + ".";
			string str3 = text.Substring(3, 1);
			return str + str2 + str3;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002C4D File Offset: 0x00000E4D
		public bool IsConnected
		{
			get
			{
				return PS3MAPI.PS3MAPI_Client_Server.IsConnected;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002C54 File Offset: 0x00000E54
		public bool IsAttached
		{
			get
			{
				return PS3MAPI.PS3MAPI_Client_Server.IsAttached;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002C5C File Offset: 0x00000E5C
		public bool ConnectTarget(string ip, int port = 7887)
		{
			bool result;
			try
			{
				PS3MAPI.PS3MAPI_Client_Server.Connect(ip, port);
				result = true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002C94 File Offset: 0x00000E94
		public bool ConnectTarget()
		{
			ConnectDialog connectDialog = new ConnectDialog();
			bool result;
			try
			{
				bool flag = false;
				if (connectDialog.ShowDialog() == DialogResult.OK)
				{
					flag = this.ConnectTarget(connectDialog.txtIp.Text, int.Parse(connectDialog.txtPort.Text));
				}
				if (connectDialog != null)
				{
					connectDialog.Dispose();
					connectDialog = null;
				}
				result = flag;
			}
			catch (Exception ex)
			{
				if (connectDialog != null)
				{
					connectDialog.Dispose();
					connectDialog = null;
				}
				throw new Exception(ex.Message, ex);
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002D10 File Offset: 0x00000F10
		public bool AttachProcess(uint pid)
		{
			bool result;
			try
			{
				this.Process.Process_Pid = pid;
				result = true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002D4C File Offset: 0x00000F4C
		public bool AttachProcess()
		{
			AttachDialog attachDialog = null;
			bool result;
			try
			{
				bool flag;
				for (;;)
				{
					flag = false;
					if (attachDialog != null)
					{
						attachDialog.Dispose();
						attachDialog = null;
					}
					attachDialog = new AttachDialog(this);
					DialogResult dialogResult = attachDialog.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						break;
					}
					if (dialogResult != DialogResult.Retry)
					{
						goto IL_59;
					}
				}
				string[] array = attachDialog.comboBox1.Text.Split(new char[]
				{
					'_'
				});
				flag = this.AttachProcess(Convert.ToUInt32(array[0], 16));
				IL_59:
				if (attachDialog != null)
				{
					attachDialog.Dispose();
				}
				result = flag;
			}
			catch (Exception ex)
			{
				if (attachDialog != null)
				{
					attachDialog.Dispose();
					attachDialog = null;
				}
				throw new Exception(ex.Message, ex);
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public void DisconnectTarget()
		{
			try
			{
				PS3MAPI.PS3MAPI_Client_Server.Disconnect();
			}
			catch
			{
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002E18 File Offset: 0x00001018
		public void ShowLog()
		{
			if (this.LogDialog == null)
			{
				this.LogDialog = new LogDialog(this);
			}
			this.LogDialog.Show();
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002E39 File Offset: 0x00001039
		public string Log
		{
			get
			{
				return PS3MAPI.PS3MAPI_Client_Server.Log;
			}
		}

		// Token: 0x04000013 RID: 19
		public int PS3M_API_PC_LIB_VERSION = 288;

		// Token: 0x04000014 RID: 20
		public PS3MAPI.CORE_CMD Core = new PS3MAPI.CORE_CMD();

		// Token: 0x04000015 RID: 21
		public PS3MAPI.SERVER_CMD Server = new PS3MAPI.SERVER_CMD();

		// Token: 0x04000016 RID: 22
		public PS3MAPI.PS3_CMD PS3 = new PS3MAPI.PS3_CMD();

		// Token: 0x04000017 RID: 23
		public PS3MAPI.PROCESS_CMD Process = new PS3MAPI.PROCESS_CMD();

		// Token: 0x04000018 RID: 24
		public PS3MAPI.VSH_PLUGINS_CMD VSH_Plugin = new PS3MAPI.VSH_PLUGINS_CMD();

		// Token: 0x04000019 RID: 25
		private LogDialog LogDialog;

		// Token: 0x02000006 RID: 6
		public class SERVER_CMD
		{
			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000019 RID: 25 RVA: 0x00002E40 File Offset: 0x00001040
			// (set) Token: 0x0600001A RID: 26 RVA: 0x00002E47 File Offset: 0x00001047
			public int Timeout
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.Timeout;
				}
				set
				{
					PS3MAPI.PS3MAPI_Client_Server.Timeout = value;
				}
			}

			// Token: 0x0600001B RID: 27 RVA: 0x00002E50 File Offset: 0x00001050
			public uint GetVersion()
			{
				uint result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.Server_Get_Version();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x0600001C RID: 28 RVA: 0x00002E84 File Offset: 0x00001084
			public string GetVersion_Str()
			{
				string text = PS3MAPI.PS3MAPI_Client_Server.Server_Get_Version().ToString("X4");
				string str = text.Substring(1, 1) + ".";
				string str2 = text.Substring(2, 1) + ".";
				string str3 = text.Substring(3, 1);
				return str + str2 + str3;
			}
		}

		// Token: 0x02000007 RID: 7
		public class CORE_CMD
		{
			// Token: 0x0600001E RID: 30 RVA: 0x00002EE4 File Offset: 0x000010E4
			public uint GetVersion()
			{
				uint result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.Core_Get_Version();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x0600001F RID: 31 RVA: 0x00002F18 File Offset: 0x00001118
			public string GetVersion_Str()
			{
				string text = PS3MAPI.PS3MAPI_Client_Server.Core_Get_Version().ToString("X4");
				string str = text.Substring(1, 1) + ".";
				string str2 = text.Substring(2, 1) + ".";
				string str3 = text.Substring(3, 1);
				return str + str2 + str3;
			}
		}

		// Token: 0x02000008 RID: 8
		public class PS3_CMD
		{
			// Token: 0x06000021 RID: 33 RVA: 0x00002F78 File Offset: 0x00001178
			public uint GetFirmwareVersion()
			{
				uint result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.PS3_GetFwVersion();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x06000022 RID: 34 RVA: 0x00002FAC File Offset: 0x000011AC
			public string GetFirmwareVersion_Str()
			{
				string text = PS3MAPI.PS3MAPI_Client_Server.PS3_GetFwVersion().ToString("X4");
				string str = text.Substring(1, 1) + ".";
				string str2 = text.Substring(2, 1);
				string str3 = text.Substring(3, 1);
				return str + str2 + str3;
			}

			// Token: 0x06000023 RID: 35 RVA: 0x00002FFC File Offset: 0x000011FC
			public string GetFirmwareType()
			{
				string result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.PS3_GetFirmwareType();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x06000024 RID: 36 RVA: 0x00003030 File Offset: 0x00001230
			public void Power(PS3MAPI.PS3_CMD.PowerFlags flag)
			{
				try
				{
					if (flag == PS3MAPI.PS3_CMD.PowerFlags.ShutDown)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_Shutdown();
					}
					else if (flag == PS3MAPI.PS3_CMD.PowerFlags.QuickReboot)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_Reboot();
					}
					else if (flag == PS3MAPI.PS3_CMD.PowerFlags.SoftReboot)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_SoftReboot();
					}
					else if (flag == PS3MAPI.PS3_CMD.PowerFlags.HardReboot)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_HardReboot();
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000025 RID: 37 RVA: 0x00003088 File Offset: 0x00001288
			public void Notify(string msg)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_Notify(msg);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000026 RID: 38 RVA: 0x000030BC File Offset: 0x000012BC
			public void RingBuzzer(PS3MAPI.PS3_CMD.BuzzerMode mode)
			{
				try
				{
					if (mode == PS3MAPI.PS3_CMD.BuzzerMode.Single)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_Buzzer(1);
					}
					else if (mode == PS3MAPI.PS3_CMD.BuzzerMode.Double)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_Buzzer(2);
					}
					else if (mode == PS3MAPI.PS3_CMD.BuzzerMode.Triple)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_Buzzer(3);
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000027 RID: 39 RVA: 0x0000310C File Offset: 0x0000130C
			public void Led(PS3MAPI.PS3_CMD.LedColor color, PS3MAPI.PS3_CMD.LedMode mode)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_Led(Convert.ToInt32(color), Convert.ToInt32(mode));
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000028 RID: 40 RVA: 0x00003154 File Offset: 0x00001354
			public void GetTemperature(out uint cpu, out uint rsx)
			{
				cpu = 0U;
				rsx = 0U;
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_GetTemp(out cpu, out rsx);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000029 RID: 41 RVA: 0x00003190 File Offset: 0x00001390
			public void DisableSyscall(int num)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_DisableSyscall(num);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x0600002A RID: 42 RVA: 0x000031C4 File Offset: 0x000013C4
			public bool CheckSyscall(int num)
			{
				bool result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.PS3_CheckSyscall(num);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x0600002B RID: 43 RVA: 0x000031FC File Offset: 0x000013FC
			public void PartialDisableSyscall8(PS3MAPI.PS3_CMD.Syscall8Mode mode)
			{
				try
				{
					if (mode == PS3MAPI.PS3_CMD.Syscall8Mode.Enabled)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(0);
					}
					else if (mode == PS3MAPI.PS3_CMD.Syscall8Mode.Only_CobraMambaAndPS3MAPI_Enabled)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(1);
					}
					else if (mode == PS3MAPI.PS3_CMD.Syscall8Mode.Only_PS3MAPI_Enabled)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(2);
					}
					else if (mode == PS3MAPI.PS3_CMD.Syscall8Mode.FakeDisabled)
					{
						PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(3);
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x0600002C RID: 44 RVA: 0x00003258 File Offset: 0x00001458
			public PS3MAPI.PS3_CMD.Syscall8Mode PartialCheckSyscall8()
			{
				PS3MAPI.PS3_CMD.Syscall8Mode result;
				try
				{
					if (PS3MAPI.PS3MAPI_Client_Server.PS3_PartialCheckSyscall8() == 0)
					{
						result = PS3MAPI.PS3_CMD.Syscall8Mode.Enabled;
					}
					else if (PS3MAPI.PS3MAPI_Client_Server.PS3_PartialCheckSyscall8() == 1)
					{
						result = PS3MAPI.PS3_CMD.Syscall8Mode.Only_CobraMambaAndPS3MAPI_Enabled;
					}
					else if (PS3MAPI.PS3MAPI_Client_Server.PS3_PartialCheckSyscall8() == 2)
					{
						result = PS3MAPI.PS3_CMD.Syscall8Mode.Only_PS3MAPI_Enabled;
					}
					else
					{
						result = PS3MAPI.PS3_CMD.Syscall8Mode.FakeDisabled;
					}
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x0600002D RID: 45 RVA: 0x000032AC File Offset: 0x000014AC
			public void RemoveHook()
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_RemoveHook();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x0600002E RID: 46 RVA: 0x000032E0 File Offset: 0x000014E0
			public void ClearHistory(bool include_directory = true)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_ClearHistory(include_directory);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x0600002F RID: 47 RVA: 0x00003314 File Offset: 0x00001514
			public string GetPSID()
			{
				string result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.PS3_GetPSID();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x06000030 RID: 48 RVA: 0x00003348 File Offset: 0x00001548
			public void SetPSID(string PSID)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_SetPSID(PSID);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000031 RID: 49 RVA: 0x0000337C File Offset: 0x0000157C
			public string GetIDPS()
			{
				string result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.PS3_GetIDPS();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x06000032 RID: 50 RVA: 0x000033B0 File Offset: 0x000015B0
			public void SetIDPS(string IDPS)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.PS3_SetIDPS(IDPS);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x02000009 RID: 9
			public enum PowerFlags
			{
				// Token: 0x0400001B RID: 27
				ShutDown,
				// Token: 0x0400001C RID: 28
				QuickReboot,
				// Token: 0x0400001D RID: 29
				SoftReboot,
				// Token: 0x0400001E RID: 30
				HardReboot
			}

			// Token: 0x0200000A RID: 10
			public enum BuzzerMode
			{
				// Token: 0x04000020 RID: 32
				Single,
				// Token: 0x04000021 RID: 33
				Double,
				// Token: 0x04000022 RID: 34
				Triple
			}

			// Token: 0x0200000B RID: 11
			public enum LedColor
			{
				// Token: 0x04000024 RID: 36
				Red,
				// Token: 0x04000025 RID: 37
				Green,
				// Token: 0x04000026 RID: 38
				Yellow
			}

			// Token: 0x0200000C RID: 12
			public enum LedMode
			{
				// Token: 0x04000028 RID: 40
				Off,
				// Token: 0x04000029 RID: 41
				On,
				// Token: 0x0400002A RID: 42
				BlinkFast,
				// Token: 0x0400002B RID: 43
				BlinkSlow
			}

			// Token: 0x0200000D RID: 13
			public enum Syscall8Mode
			{
				// Token: 0x0400002D RID: 45
				Enabled,
				// Token: 0x0400002E RID: 46
				Only_CobraMambaAndPS3MAPI_Enabled,
				// Token: 0x0400002F RID: 47
				Only_PS3MAPI_Enabled,
				// Token: 0x04000030 RID: 48
				FakeDisabled,
				// Token: 0x04000031 RID: 49
				Disabled
			}
		}

		// Token: 0x0200000E RID: 14
		public class PROCESS_CMD
		{
			// Token: 0x06000034 RID: 52 RVA: 0x000033EC File Offset: 0x000015EC
			public PROCESS_CMD()
			{
				this.Memory = new PS3MAPI.PROCESS_CMD.MEMORY_CMD();
				this.Modules = new PS3MAPI.PROCESS_CMD.MODULES_CMD();
			}

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000035 RID: 53 RVA: 0x00003420 File Offset: 0x00001620
			public uint[] Processes_Pid
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.Processes_Pid;
				}
			}

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000036 RID: 54 RVA: 0x00003427 File Offset: 0x00001627
			// (set) Token: 0x06000037 RID: 55 RVA: 0x0000342E File Offset: 0x0000162E
			public uint Process_Pid
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.Process_Pid;
				}
				set
				{
					PS3MAPI.PS3MAPI_Client_Server.Process_Pid = value;
				}
			}

			// Token: 0x06000038 RID: 56 RVA: 0x00003438 File Offset: 0x00001638
			public uint[] GetPidProcesses()
			{
				uint[] result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.Process_GetPidList();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x06000039 RID: 57 RVA: 0x0000346C File Offset: 0x0000166C
			public string GetName(uint pid)
			{
				string result;
				try
				{
					result = PS3MAPI.PS3MAPI_Client_Server.Process_GetName(pid);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				return result;
			}

			// Token: 0x04000032 RID: 50
			public PS3MAPI.PROCESS_CMD.MEMORY_CMD Memory = new PS3MAPI.PROCESS_CMD.MEMORY_CMD();

			// Token: 0x04000033 RID: 51
			public PS3MAPI.PROCESS_CMD.MODULES_CMD Modules = new PS3MAPI.PROCESS_CMD.MODULES_CMD();

			// Token: 0x0200000F RID: 15
			public class MEMORY_CMD
			{
				// Token: 0x0600003A RID: 58 RVA: 0x000034A4 File Offset: 0x000016A4
				public void Set(uint Pid, ulong Address, byte[] Bytes)
				{
					try
					{
						PS3MAPI.PS3MAPI_Client_Server.Memory_Set(Pid, Address, Bytes);
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
				}

				// Token: 0x0600003B RID: 59 RVA: 0x000034DC File Offset: 0x000016DC
				public void Get(uint Pid, ulong Address, byte[] Bytes)
				{
					try
					{
						PS3MAPI.PS3MAPI_Client_Server.Memory_Get(Pid, Address, Bytes);
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
				}

				// Token: 0x0600003C RID: 60 RVA: 0x00003514 File Offset: 0x00001714
				public byte[] Get(uint Pid, ulong Address, uint Length)
				{
					byte[] result;
					try
					{
						byte[] array = new byte[Length];
						PS3MAPI.PS3MAPI_Client_Server.Memory_Get(Pid, Address, array);
						result = array;
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
					return result;
				}
			}

			// Token: 0x02000010 RID: 16
			public class MODULES_CMD
			{
				// Token: 0x17000007 RID: 7
				// (get) Token: 0x0600003E RID: 62 RVA: 0x0000355C File Offset: 0x0000175C
				public int[] Modules_Prx_Id
				{
					get
					{
						return PS3MAPI.PS3MAPI_Client_Server.Modules_Prx_Id;
					}
				}

				// Token: 0x0600003F RID: 63 RVA: 0x00003564 File Offset: 0x00001764
				public int[] GetPrxIdModules(uint pid)
				{
					int[] result;
					try
					{
						result = PS3MAPI.PS3MAPI_Client_Server.Module_GetPrxIdList(pid);
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
					return result;
				}

				// Token: 0x06000040 RID: 64 RVA: 0x0000359C File Offset: 0x0000179C
				public string GetName(uint pid, int prxid)
				{
					string result;
					try
					{
						result = PS3MAPI.PS3MAPI_Client_Server.Module_GetName(pid, prxid);
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
					return result;
				}

				// Token: 0x06000041 RID: 65 RVA: 0x000035D4 File Offset: 0x000017D4
				public string GetFilename(uint pid, int prxid)
				{
					string result;
					try
					{
						result = PS3MAPI.PS3MAPI_Client_Server.Module_GetFilename(pid, prxid);
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
					return result;
				}

				// Token: 0x06000042 RID: 66 RVA: 0x0000360C File Offset: 0x0000180C
				public void Load(uint pid, string path)
				{
					try
					{
						PS3MAPI.PS3MAPI_Client_Server.Module_Load(pid, path);
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
				}

				// Token: 0x06000043 RID: 67 RVA: 0x00003640 File Offset: 0x00001840
				public void Unload(uint pid, int prxid)
				{
					try
					{
						PS3MAPI.PS3MAPI_Client_Server.Module_Unload(pid, prxid);
					}
					catch (Exception ex)
					{
						throw new Exception(ex.Message, ex);
					}
				}
			}
		}

		// Token: 0x02000011 RID: 17
		public class VSH_PLUGINS_CMD
		{
			// Token: 0x06000045 RID: 69 RVA: 0x0000367C File Offset: 0x0000187C
			public void Load(uint slot, string path)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.VSHPlugins_Load(slot, path);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000046 RID: 70 RVA: 0x000036B0 File Offset: 0x000018B0
			public void Unload(uint slot)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.VSHPlugins_Unload(slot);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}

			// Token: 0x06000047 RID: 71 RVA: 0x000036E4 File Offset: 0x000018E4
			public void GetInfoBySlot(uint slot, out string name, out string path)
			{
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.VSHPlugins_GetInfoBySlot(slot, out name, out path);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
			}
		}

		// Token: 0x02000012 RID: 18
		internal class PS3MAPI_Client_Web
		{
		}

		// Token: 0x02000013 RID: 19
		internal class PS3MAPI_Client_Server
		{
			// Token: 0x17000008 RID: 8
			// (get) Token: 0x0600004A RID: 74 RVA: 0x0000372C File Offset: 0x0000192C
			public static string Log
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.sLog;
				}
			}

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x0600004B RID: 75 RVA: 0x00003733 File Offset: 0x00001933
			public static uint[] Processes_Pid
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid;
				}
			}

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x0600004C RID: 76 RVA: 0x0000373A File Offset: 0x0000193A
			// (set) Token: 0x0600004D RID: 77 RVA: 0x00003741 File Offset: 0x00001941
			public static uint Process_Pid
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.iPid;
				}
				set
				{
					PS3MAPI.PS3MAPI_Client_Server.iPid = value;
				}
			}

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600004E RID: 78 RVA: 0x00003749 File Offset: 0x00001949
			public static int[] Modules_Prx_Id
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id;
				}
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600004F RID: 79 RVA: 0x00003750 File Offset: 0x00001950
			// (set) Token: 0x06000050 RID: 80 RVA: 0x00003757 File Offset: 0x00001957
			public static int Timeout
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.iTimeout;
				}
				set
				{
					PS3MAPI.PS3MAPI_Client_Server.iTimeout = value;
				}
			}

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000051 RID: 81 RVA: 0x0000375F File Offset: 0x0000195F
			public static bool IsConnected
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.main_sock != null && PS3MAPI.PS3MAPI_Client_Server.main_sock.Connected;
				}
			}

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000052 RID: 82 RVA: 0x00003774 File Offset: 0x00001974
			public static bool IsAttached
			{
				get
				{
					return PS3MAPI.PS3MAPI_Client_Server.iPid != 0U;
				}
			}

			// Token: 0x06000053 RID: 83 RVA: 0x00003780 File Offset: 0x00001980
			internal static void Connect()
			{
				PS3MAPI.PS3MAPI_Client_Server.Connect(PS3MAPI.PS3MAPI_Client_Server.sServerIP, PS3MAPI.PS3MAPI_Client_Server.iPort);
			}

			// Token: 0x06000054 RID: 84 RVA: 0x00003794 File Offset: 0x00001994
			internal static void Connect(string sServer, int Port)
			{
				PS3MAPI.PS3MAPI_Client_Server.sServerIP = sServer;
				PS3MAPI.PS3MAPI_Client_Server.iPort = Port;
				if (Port.ToString().Length == 0)
				{
					throw new Exception("Unable to Connect - No Port Specified.");
				}
				if (PS3MAPI.PS3MAPI_Client_Server.sServerIP.Length == 0)
				{
					throw new Exception("Unable to Connect - No Server Specified.");
				}
				if (PS3MAPI.PS3MAPI_Client_Server.main_sock != null && PS3MAPI.PS3MAPI_Client_Server.main_sock.Connected)
				{
					return;
				}
				PS3MAPI.PS3MAPI_Client_Server.main_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				PS3MAPI.PS3MAPI_Client_Server.main_ipEndPoint = new IPEndPoint(Dns.GetHostByName(PS3MAPI.PS3MAPI_Client_Server.sServerIP).AddressList[0], Port);
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.main_sock.Connect(PS3MAPI.PS3MAPI_Client_Server.main_ipEndPoint);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message, ex);
				}
				PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
				if (PS3MAPI.PS3MAPI_Client_Server.eResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.PS3MAPIConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
				if (PS3MAPI.PS3MAPI_Client_Server.eResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.PS3MAPIConnectedOK)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				if ((ulong)PS3MAPI.PS3MAPI_Client_Server.Server_GetMinVersion() < (ulong)((long)PS3MAPI.PS3MAPI_Client_Server.ps3m_api_server_minversion))
				{
					PS3MAPI.PS3MAPI_Client_Server.Disconnect();
					throw new Exception("PS3M_API SERVER (webMAN-MOD) OUTDATED! PLEASE UPDATE.");
				}
				if ((ulong)PS3MAPI.PS3MAPI_Client_Server.Server_GetMinVersion() > (ulong)((long)PS3MAPI.PS3MAPI_Client_Server.ps3m_api_server_minversion))
				{
					PS3MAPI.PS3MAPI_Client_Server.Disconnect();
					throw new Exception("PS3M_API PC_LIB (PS3ManagerAPI.dll) OUTDATED! PLEASE UPDATE.");
				}
			}

			// Token: 0x06000055 RID: 85 RVA: 0x000038B4 File Offset: 0x00001AB4
			internal static void Disconnect()
			{
				PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
				if (PS3MAPI.PS3MAPI_Client_Server.main_sock != null)
				{
					if (PS3MAPI.PS3MAPI_Client_Server.main_sock.Connected)
					{
						PS3MAPI.PS3MAPI_Client_Server.SendCommand("DISCONNECT");
						PS3MAPI.PS3MAPI_Client_Server.iPid = 0U;
						PS3MAPI.PS3MAPI_Client_Server.main_sock.Close();
					}
					PS3MAPI.PS3MAPI_Client_Server.main_sock = null;
				}
				PS3MAPI.PS3MAPI_Client_Server.main_ipEndPoint = null;
			}

			// Token: 0x06000056 RID: 86 RVA: 0x000038F4 File Offset: 0x00001AF4
			internal static uint Server_Get_Version()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("SERVER GETVERSION");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return Convert.ToUInt32(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000057 RID: 87 RVA: 0x00003944 File Offset: 0x00001B44
			internal static uint Server_GetMinVersion()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("SERVER GETMINVERSION");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return Convert.ToUInt32(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000058 RID: 88 RVA: 0x00003994 File Offset: 0x00001B94
			internal static uint Core_Get_Version()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("CORE GETVERSION");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return Convert.ToUInt32(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000059 RID: 89 RVA: 0x000039E4 File Offset: 0x00001BE4
			internal static uint Core_GetMinVersion()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("CORE GETMINVERSION");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return Convert.ToUInt32(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x0600005A RID: 90 RVA: 0x00003A34 File Offset: 0x00001C34
			internal static uint PS3_GetFwVersion()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETFWVERSION");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return Convert.ToUInt32(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x0600005B RID: 91 RVA: 0x00003A84 File Offset: 0x00001C84
			internal static string PS3_GetFirmwareType()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETFWTYPE");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return PS3MAPI.PS3MAPI_Client_Server.sResponse;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x0600005C RID: 92 RVA: 0x00003AD0 File Offset: 0x00001CD0
			internal static void PS3_Shutdown()
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SHUTDOWN");
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK || ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Disconnect();
					return;
				}
				PS3MAPI.PS3MAPI_Client_Server.Fail();
			}

			// Token: 0x0600005D RID: 93 RVA: 0x00003B1C File Offset: 0x00001D1C
			internal static void PS3_Reboot()
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 REBOOT");
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK || ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Disconnect();
					return;
				}
				PS3MAPI.PS3MAPI_Client_Server.Fail();
			}

			// Token: 0x0600005E RID: 94 RVA: 0x00003B68 File Offset: 0x00001D68
			internal static void PS3_SoftReboot()
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SOFTREBOOT");
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK || ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Disconnect();
					return;
				}
				PS3MAPI.PS3MAPI_Client_Server.Fail();
			}

			// Token: 0x0600005F RID: 95 RVA: 0x00003BB4 File Offset: 0x00001DB4
			internal static void PS3_HardReboot()
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 HARDREBOOT");
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK || ps3MAPI_ResponseCode == PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Disconnect();
					return;
				}
				PS3MAPI.PS3MAPI_Client_Server.Fail();
			}

			// Token: 0x06000060 RID: 96 RVA: 0x00003C00 File Offset: 0x00001E00
			internal static void PS3_Notify(string msg)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 NOTIFY  " + msg);
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000061 RID: 97 RVA: 0x00003C4C File Offset: 0x00001E4C
			internal static void PS3_Buzzer(int mode)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 BUZZER" + mode.ToString());
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000062 RID: 98 RVA: 0x00003CA0 File Offset: 0x00001EA0
			internal static void PS3_Led(int color, int mode)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 LED " + color.ToString() + " " + mode.ToString());
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000063 RID: 99 RVA: 0x00003D00 File Offset: 0x00001F00
			internal static void PS3_GetTemp(out uint cpu, out uint rsx)
			{
				cpu = 0U;
				rsx = 0U;
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETTEMP");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					string[] array = PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
					{
						'|'
					});
					cpu = Convert.ToUInt32(array[0], 10);
					rsx = Convert.ToUInt32(array[1], 10);
					return;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000064 RID: 100 RVA: 0x00003D7C File Offset: 0x00001F7C
			internal static void PS3_DisableSyscall(int num)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 DISABLESYSCALL " + num.ToString());
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000065 RID: 101 RVA: 0x00003DD0 File Offset: 0x00001FD0
			internal static void PS3_ClearHistory(bool include_directory)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				if (include_directory)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 DELHISTORY+D");
				}
				else
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 DELHISTORY");
				}
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000066 RID: 102 RVA: 0x00003E24 File Offset: 0x00002024
			internal static bool PS3_CheckSyscall(int num)
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 CHECKSYSCALL " + num.ToString());
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return Convert.ToInt32(PS3MAPI.PS3MAPI_Client_Server.sResponse) == 0;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000067 RID: 103 RVA: 0x00003E84 File Offset: 0x00002084
			internal static void PS3_PartialDisableSyscall8(int mode)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 PDISABLESYSCALL8 " + mode.ToString());
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000068 RID: 104 RVA: 0x00003ED8 File Offset: 0x000020D8
			internal static int PS3_PartialCheckSyscall8()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 PCHECKSYSCALL8");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return Convert.ToInt32(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000069 RID: 105 RVA: 0x00003F28 File Offset: 0x00002128
			internal static void PS3_RemoveHook()
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 REMOVEHOOK");
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x0600006A RID: 106 RVA: 0x00003F70 File Offset: 0x00002170
			internal static string PS3_GetIDPS()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETIDPS");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return PS3MAPI.PS3MAPI_Client_Server.sResponse;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x0600006B RID: 107 RVA: 0x00003FBC File Offset: 0x000021BC
			internal static void PS3_SetIDPS(string IDPS)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SETIDPS " + IDPS.Substring(0, 16) + " " + IDPS.Substring(16, 16));
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x0600006C RID: 108 RVA: 0x00004020 File Offset: 0x00002220
			internal static string PS3_GetPSID()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETPSID");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return PS3MAPI.PS3MAPI_Client_Server.sResponse;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x0600006D RID: 109 RVA: 0x0000406C File Offset: 0x0000226C
			internal static void PS3_SetPSID(string PSID)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SETPSID " + PSID.Substring(0, 16) + " " + PSID.Substring(16, 16));
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x0600006E RID: 110 RVA: 0x000040D0 File Offset: 0x000022D0
			internal static string Process_GetName(uint pid)
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PROCESS GETNAME " + string.Format("{0}", pid));
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return PS3MAPI.PS3MAPI_Client_Server.sResponse;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x0600006F RID: 111 RVA: 0x00004130 File Offset: 0x00002330
			internal static uint[] Process_GetPidList()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("PROCESS GETALLPID");
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					int num = 0;
					PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid = new uint[16];
					foreach (string text in PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
					{
						'|'
					}))
					{
						if (text.Length != 0 && text != null && text != "" && text != " " && text != "0")
						{
							PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid[num] = Convert.ToUInt32(text, 10);
							num++;
						}
					}
					return PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000070 RID: 112 RVA: 0x00004204 File Offset: 0x00002404
			internal static void Memory_Get(uint Pid, ulong Address, byte[] Bytes)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(true);
				int num = Bytes.Length;
				long num2 = 0L;
				bool flag = false;
				PS3MAPI.PS3MAPI_Client_Server.OpenDataSocket();
				PS3MAPI.PS3MAPI_Client_Server.SendCommand(string.Concat(new string[]
				{
					"MEMORY GET ",
					string.Format("{0}", Pid),
					" ",
					string.Format("{0:X16}", Address),
					" ",
					string.Format("{0}", Bytes.Length)
				}));
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.DataConnectionAlreadyOpen && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryStatusOK)
				{
					throw new Exception(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				PS3MAPI.PS3MAPI_Client_Server.ConnectDataSocket();
				byte[] array = new byte[Bytes.Length];
				while (!flag)
				{
					try
					{
						long num3 = (long)PS3MAPI.PS3MAPI_Client_Server.data_sock.Receive(array, num, SocketFlags.None);
						if (num3 > 0L)
						{
							Buffer.BlockCopy(array, 0, Bytes, (int)num2, (int)num3);
							num2 += num3;
							if ((int)(num2 * 100L / (long)num) >= 100)
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
						if (flag)
						{
							PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
							PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
							PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode2 = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
							if (ps3MAPI_ResponseCode2 != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful && ps3MAPI_ResponseCode2 != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryActionCompleted)
							{
								throw new Exception(PS3MAPI.PS3MAPI_Client_Server.sResponse);
							}
							PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
						}
					}
					catch (Exception ex)
					{
						PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
						PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
						PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
						throw ex;
					}
				}
			}

			// Token: 0x06000071 RID: 113 RVA: 0x0000437C File Offset: 0x0000257C
			internal static void Memory_Set(uint Pid, ulong Address, byte[] Bytes)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(true);
				int num = Bytes.Length;
				long num2 = 0L;
				long num3 = 0L;
				bool flag = false;
				PS3MAPI.PS3MAPI_Client_Server.OpenDataSocket();
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("MEMORY SET " + string.Format("{0}", Pid) + " " + string.Format("{0:X16}", Address));
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.DataConnectionAlreadyOpen && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryStatusOK)
				{
					throw new Exception(PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				PS3MAPI.PS3MAPI_Client_Server.ConnectDataSocket();
				while (!flag)
				{
					try
					{
						byte[] array = new byte[num - (int)num2];
						Buffer.BlockCopy(Bytes, (int)num3, array, 0, num - (int)num2);
						num3 = (long)PS3MAPI.PS3MAPI_Client_Server.data_sock.Send(array, Bytes.Length - (int)num2, SocketFlags.None);
						flag = false;
						if (num3 > 0L)
						{
							num2 += num3;
							if ((int)(num2 * 100L / (long)num) >= 100)
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
						if (flag)
						{
							PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
							PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
							PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode2 = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
							if (ps3MAPI_ResponseCode2 != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful && ps3MAPI_ResponseCode2 != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryActionCompleted)
							{
								throw new Exception(PS3MAPI.PS3MAPI_Client_Server.sResponse);
							}
							PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
						}
					}
					catch (Exception ex)
					{
						PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
						PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
						PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
						throw ex;
					}
				}
			}

			// Token: 0x06000072 RID: 114 RVA: 0x000044C8 File Offset: 0x000026C8
			internal static int[] Module_GetPrxIdList(uint pid)
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETALLPRXID " + string.Format("{0}", pid));
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					int num = 0;
					PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id = new int[128];
					foreach (string text in PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
					{
						'|'
					}))
					{
						if (text.Length != 0 && text != null && text != "" && text != " " && text != "0")
						{
							PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id[num] = Convert.ToInt32(text, 10);
							num++;
						}
					}
					return PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000073 RID: 115 RVA: 0x000045B4 File Offset: 0x000027B4
			internal static string Module_GetName(uint pid, int prxid)
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETNAME " + string.Format("{0}", pid) + " " + prxid.ToString());
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return PS3MAPI.PS3MAPI_Client_Server.sResponse;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000074 RID: 116 RVA: 0x00004620 File Offset: 0x00002820
			internal static string Module_GetFilename(uint pid, int prxid)
			{
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETFILENAME " + string.Format("{0}", pid) + " " + prxid.ToString());
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					return PS3MAPI.PS3MAPI_Client_Server.sResponse;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000075 RID: 117 RVA: 0x0000468C File Offset: 0x0000288C
			internal static void Module_Load(uint pid, string path)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE LOAD " + string.Format("{0}", pid) + " " + path);
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000076 RID: 118 RVA: 0x000046EC File Offset: 0x000028EC
			internal static void Module_Unload(uint pid, int prx_id)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE UNLOAD " + string.Format("{0}", pid) + " " + prx_id.ToString());
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000077 RID: 119 RVA: 0x00004754 File Offset: 0x00002954
			internal static void VSHPlugins_GetInfoBySlot(uint slot, out string name, out string path)
			{
				name = "";
				path = "";
				if (PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETVSHPLUGINFO " + string.Format("{0}", slot));
					PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					string[] array = PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
					{
						'|'
					});
					name = array[0];
					path = array[1];
					return;
				}
				throw new Exception("PS3MAPI not connected!");
			}

			// Token: 0x06000078 RID: 120 RVA: 0x000047E0 File Offset: 0x000029E0
			internal static void VSHPlugins_Load(uint slot, string path)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE LOADVSHPLUG " + string.Format("{0}", slot) + " " + path);
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x06000079 RID: 121 RVA: 0x00004840 File Offset: 0x00002A40
			internal static void VSHPlugins_Unload(uint slot)
			{
				if (!PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new Exception("PS3MAPI not connected!");
				}
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE UNLOADVSHPLUGS " + string.Format("{0}", slot));
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
					return;
				}
			}

			// Token: 0x0600007A RID: 122 RVA: 0x0000489A File Offset: 0x00002A9A
			internal static void Fail()
			{
				PS3MAPI.PS3MAPI_Client_Server.Fail(new Exception("[" + PS3MAPI.PS3MAPI_Client_Server.eResponseCode.ToString() + "] " + PS3MAPI.PS3MAPI_Client_Server.sResponse));
			}

			// Token: 0x0600007B RID: 123 RVA: 0x000048C9 File Offset: 0x00002AC9
			internal static void Fail(Exception e)
			{
				PS3MAPI.PS3MAPI_Client_Server.Disconnect();
				throw e;
			}

			// Token: 0x0600007C RID: 124 RVA: 0x000048D4 File Offset: 0x00002AD4
			internal static void SetBinaryMode(bool bMode)
			{
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("TYPE" + (bMode ? " I" : " A"));
				PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			// Token: 0x0600007D RID: 125 RVA: 0x0000491C File Offset: 0x00002B1C
			internal static void OpenDataSocket()
			{
				PS3MAPI.PS3MAPI_Client_Server.Connect();
				PS3MAPI.PS3MAPI_Client_Server.SendCommand("PASV");
				if (PS3MAPI.PS3MAPI_Client_Server.eResponseCode != PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.EnteringPassiveMode)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				string[] array;
				try
				{
					int num = PS3MAPI.PS3MAPI_Client_Server.sResponse.IndexOf('(') + 1;
					int length = PS3MAPI.PS3MAPI_Client_Server.sResponse.IndexOf(')') - num;
					array = PS3MAPI.PS3MAPI_Client_Server.sResponse.Substring(num, length).Split(new char[]
					{
						','
					});
				}
				catch (Exception)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail(new Exception("Malformed PASV response: " + PS3MAPI.PS3MAPI_Client_Server.sResponse));
					throw new Exception("Malformed PASV response: " + PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				if (array.Length < 6)
				{
					PS3MAPI.PS3MAPI_Client_Server.Fail(new Exception("Malformed PASV response: " + PS3MAPI.PS3MAPI_Client_Server.sResponse));
				}
				string.Format("{0}.{1}.{2}.{3}", new object[]
				{
					array[0],
					array[1],
					array[2],
					array[3]
				});
				int port = (int.Parse(array[4]) << 8) + int.Parse(array[5]);
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
					PS3MAPI.PS3MAPI_Client_Server.data_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					PS3MAPI.PS3MAPI_Client_Server.data_ipEndPoint = new IPEndPoint(Dns.GetHostByName(PS3MAPI.PS3MAPI_Client_Server.sServerIP).AddressList[0], port);
					PS3MAPI.PS3MAPI_Client_Server.data_sock.Connect(PS3MAPI.PS3MAPI_Client_Server.data_ipEndPoint);
				}
				catch (Exception ex)
				{
					throw new Exception("Failed to connect for data transfer: " + ex.Message);
				}
			}

			// Token: 0x0600007E RID: 126 RVA: 0x00004A94 File Offset: 0x00002C94
			internal static void ConnectDataSocket()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.data_sock != null)
				{
					return;
				}
				try
				{
					PS3MAPI.PS3MAPI_Client_Server.data_sock = PS3MAPI.PS3MAPI_Client_Server.listening_sock.Accept();
					PS3MAPI.PS3MAPI_Client_Server.listening_sock.Close();
					PS3MAPI.PS3MAPI_Client_Server.listening_sock = null;
					if (PS3MAPI.PS3MAPI_Client_Server.data_sock == null)
					{
						throw new Exception("Winsock error: " + Convert.ToString(Marshal.GetLastWin32Error()));
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Failed to connect for data transfer: " + ex.Message);
				}
			}

			// Token: 0x0600007F RID: 127 RVA: 0x00004B14 File Offset: 0x00002D14
			internal static void CloseDataSocket()
			{
				if (PS3MAPI.PS3MAPI_Client_Server.data_sock != null)
				{
					if (PS3MAPI.PS3MAPI_Client_Server.data_sock.Connected)
					{
						PS3MAPI.PS3MAPI_Client_Server.data_sock.Close();
					}
					PS3MAPI.PS3MAPI_Client_Server.data_sock = null;
				}
				PS3MAPI.PS3MAPI_Client_Server.data_ipEndPoint = null;
			}

			// Token: 0x06000080 RID: 128 RVA: 0x00004B40 File Offset: 0x00002D40
			internal static void ReadResponse()
			{
				PS3MAPI.PS3MAPI_Client_Server.sMessages = "";
				string lineFromBucket;
				for (;;)
				{
					lineFromBucket = PS3MAPI.PS3MAPI_Client_Server.GetLineFromBucket();
					if (Regex.Match(lineFromBucket, "^[0-9]+ ").Success)
					{
						break;
					}
					PS3MAPI.PS3MAPI_Client_Server.sMessages = PS3MAPI.PS3MAPI_Client_Server.sMessages + Regex.Replace(lineFromBucket, "^[0-9]+-", "") + "\n";
				}
				PS3MAPI.PS3MAPI_Client_Server.sResponse = lineFromBucket.Substring(4).Replace("\r", "").Replace("\n", "");
				PS3MAPI.PS3MAPI_Client_Server.eResponseCode = (PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode)int.Parse(lineFromBucket.Substring(0, 3));
				PS3MAPI.PS3MAPI_Client_Server.sLog = PS3MAPI.PS3MAPI_Client_Server.sLog + "RESPONSE CODE: " + PS3MAPI.PS3MAPI_Client_Server.eResponseCode.ToString() + Environment.NewLine;
				PS3MAPI.PS3MAPI_Client_Server.sLog = string.Concat(new string[]
				{
					PS3MAPI.PS3MAPI_Client_Server.sLog,
					"RESPONSE MSG: ",
					PS3MAPI.PS3MAPI_Client_Server.sResponse,
					Environment.NewLine,
					Environment.NewLine
				});
			}

			// Token: 0x06000081 RID: 129 RVA: 0x00004C3C File Offset: 0x00002E3C
			internal static void SendCommand(string sCommand)
			{
				PS3MAPI.PS3MAPI_Client_Server.sLog = PS3MAPI.PS3MAPI_Client_Server.sLog + "COMMAND: " + sCommand + Environment.NewLine;
				PS3MAPI.PS3MAPI_Client_Server.Connect();
				byte[] bytes = Encoding.ASCII.GetBytes((sCommand + "\r\n").ToCharArray());
				PS3MAPI.PS3MAPI_Client_Server.main_sock.Send(bytes, bytes.Length, SocketFlags.None);
				PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
			}

			// Token: 0x06000082 RID: 130 RVA: 0x00004C98 File Offset: 0x00002E98
			internal static void FillBucket()
			{
				byte[] array = new byte[512];
				int num = 0;
				while (PS3MAPI.PS3MAPI_Client_Server.main_sock.Available < 1)
				{
					Thread.Sleep(50);
					num += 50;
					if (num > PS3MAPI.PS3MAPI_Client_Server.Timeout)
					{
						PS3MAPI.PS3MAPI_Client_Server.Fail(new Exception("Timed out waiting on server to respond."));
					}
				}
				while (PS3MAPI.PS3MAPI_Client_Server.main_sock.Available > 0)
				{
					long num2 = (long)PS3MAPI.PS3MAPI_Client_Server.main_sock.Receive(array, 512, SocketFlags.None);
					PS3MAPI.PS3MAPI_Client_Server.sBucket += Encoding.ASCII.GetString(array, 0, (int)num2);
					Thread.Sleep(50);
				}
			}

			// Token: 0x06000083 RID: 131 RVA: 0x00004D2C File Offset: 0x00002F2C
			internal static string GetLineFromBucket()
			{
				int i;
				for (i = PS3MAPI.PS3MAPI_Client_Server.sBucket.IndexOf('\n'); i < 0; i = PS3MAPI.PS3MAPI_Client_Server.sBucket.IndexOf('\n'))
				{
					PS3MAPI.PS3MAPI_Client_Server.FillBucket();
				}
				string result = PS3MAPI.PS3MAPI_Client_Server.sBucket.Substring(0, i);
				PS3MAPI.PS3MAPI_Client_Server.sBucket = PS3MAPI.PS3MAPI_Client_Server.sBucket.Substring(i + 1);
				return result;
			}

			// Token: 0x04000034 RID: 52
			private static int ps3m_api_server_minversion = 288;

			// Token: 0x04000035 RID: 53
			private static PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode eResponseCode;

			// Token: 0x04000036 RID: 54
			private static string sResponse;

			// Token: 0x04000037 RID: 55
			private static string sMessages = "";

			// Token: 0x04000038 RID: 56
			private static string sServerIP = "";

			// Token: 0x04000039 RID: 57
			private static int iPort = 7887;

			// Token: 0x0400003A RID: 58
			private static string sBucket = "";

			// Token: 0x0400003B RID: 59
			private static int iTimeout = 5000;

			// Token: 0x0400003C RID: 60
			private static uint iPid = 0U;

			// Token: 0x0400003D RID: 61
			private static uint[] iprocesses_pid = new uint[16];

			// Token: 0x0400003E RID: 62
			private static int[] imodules_prx_id = new int[64];

			// Token: 0x0400003F RID: 63
			private static string sLog = "";

			// Token: 0x04000040 RID: 64
			internal static Socket main_sock;

			// Token: 0x04000041 RID: 65
			internal static Socket listening_sock;

			// Token: 0x04000042 RID: 66
			internal static Socket data_sock;

			// Token: 0x04000043 RID: 67
			internal static IPEndPoint main_ipEndPoint;

			// Token: 0x04000044 RID: 68
			internal static IPEndPoint data_ipEndPoint;

			// Token: 0x02000014 RID: 20
			internal enum PS3MAPI_ResponseCode
			{
				// Token: 0x04000046 RID: 70
				DataConnectionAlreadyOpen = 125,
				// Token: 0x04000047 RID: 71
				MemoryStatusOK = 150,
				// Token: 0x04000048 RID: 72
				CommandOK = 200,
				// Token: 0x04000049 RID: 73
				RequestSuccessful = 226,
				// Token: 0x0400004A RID: 74
				EnteringPassiveMode,
				// Token: 0x0400004B RID: 75
				PS3MAPIConnected = 220,
				// Token: 0x0400004C RID: 76
				PS3MAPIConnectedOK = 230,
				// Token: 0x0400004D RID: 77
				MemoryActionCompleted = 250,
				// Token: 0x0400004E RID: 78
				MemoryActionPended = 350
			}
		}
	}
}
