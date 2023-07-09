using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PS3Lib
{
	public class PS3MAPI
	{
		public bool IsAttached
		{
			get
			{
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsAttached;
			}
		}

		public bool IsConnected
		{
			get
			{
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected;
			}
		}

		public string Log
		{
			get
			{
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Log;
			}
		}

		public PS3MAPI()
		{
			this.Core = new PS3Lib.PS3MAPI.CORE_CMD();
			this.Server = new PS3Lib.PS3MAPI.SERVER_CMD();
			this.PS3 = new PS3Lib.PS3MAPI.PS3_CMD();
			this.Process = new PS3Lib.PS3MAPI.PROCESS_CMD();
		}

		public bool AttachProcess(uint pid)
		{
			bool result;
			try
			{
				this.Process.Process_Pid = pid;
				result = true;
			}
			catch (System.Exception ex)
			{
				System.Exception ex2 = ex;
				throw new System.Exception(ex2.Message, ex2);
			}
			return result;
		}

		public bool AttachProcess()
		{
			PS3Lib.AttachDialog attachDialog = null;
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
					attachDialog = new PS3Lib.AttachDialog(this);
					System.Windows.Forms.DialogResult dialogResult = attachDialog.ShowDialog();
					if (dialogResult == System.Windows.Forms.DialogResult.OK)
					{
						break;
					}
					if (dialogResult != System.Windows.Forms.DialogResult.Retry)
					{
						goto IL_77;
					}
				}
				string[] array = attachDialog.comboBox1.Text.Split(new char[]
				{
					'_'
				});
				flag = this.AttachProcess(System.Convert.ToUInt32(array[0], 0x10));
				IL_77:
				if (attachDialog != null)
				{
					attachDialog.Dispose();
				}
				result = flag;
			}
			catch (System.Exception ex)
			{
				System.Exception ex2 = ex;
				if (attachDialog != null)
				{
					attachDialog.Dispose();
					attachDialog = null;
				}
				throw new System.Exception(ex2.Message, ex2);
			}
			return result;
		}

		public bool ConnectTarget(string ip, int port = 0x1ECF)
		{
			bool result;
			try
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Connect(ip, port);
				result = true;
			}
			catch (System.Exception ex)
			{
				System.Exception ex2 = ex;
				throw new System.Exception(ex2.Message, ex2);
			}
			return result;
		}

		public bool ConnectTarget()
		{
			PS3Lib.ConnectDialog connectDialog = new PS3Lib.ConnectDialog();
			bool result;
			try
			{
				bool flag = false;
				if (connectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
			catch (System.Exception ex)
			{
				System.Exception ex2 = ex;
				if (connectDialog != null)
				{
					connectDialog.Dispose();
					connectDialog = null;
				}
				throw new System.Exception(ex2.Message, ex2);
			}
			return result;
		}

		public void DisconnectTarget()
		{
			try
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
			}
			catch
			{
			}
		}

		public string GetLibVersion_Str()
		{
			string text = this.PS3M_API_PC_LIB_VERSION.ToString("X4");
			string str = text.Substring(1, 1) + ".";
			string str2 = text.Substring(2, 1) + ".";
			string str3 = text.Substring(3, 1);
			return str + str2 + str3;
		}

		public void ShowLog()
		{
			if (this.LogDialog == null)
			{
				this.LogDialog = new PS3Lib.LogDialog(this);
			}
			this.LogDialog.Show();
		}

		public int PS3M_API_PC_LIB_VERSION = 0x120;

		public PS3Lib.PS3MAPI.CORE_CMD Core = new PS3Lib.PS3MAPI.CORE_CMD();

		public PS3Lib.PS3MAPI.SERVER_CMD Server = new PS3Lib.PS3MAPI.SERVER_CMD();

		public PS3Lib.PS3MAPI.PS3_CMD PS3 = new PS3Lib.PS3MAPI.PS3_CMD();

		public PS3Lib.PS3MAPI.PROCESS_CMD Process = new PS3Lib.PS3MAPI.PROCESS_CMD();

		public PS3Lib.PS3MAPI.VSH_PLUGINS_CMD VSH_Plugin = new PS3Lib.PS3MAPI.VSH_PLUGINS_CMD();

		private PS3Lib.LogDialog LogDialog;

		public class CORE_CMD
		{
			public CORE_CMD()
			{
			}

			public uint GetVersion()
			{
				uint result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Core_Get_Version();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public string GetVersion_Str()
			{
				string text = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Core_Get_Version().ToString("X4");
				string str = text.Substring(1, 1) + ".";
				string str2 = text.Substring(2, 1) + ".";
				string str3 = text.Substring(3, 1);
				return str + str2 + str3;
			}
		}

		public class PROCESS_CMD
		{
			public uint Process_Pid
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Process_Pid;
				}
				set
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Process_Pid = value;
				}
			}

			public uint[] Processes_Pid
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Processes_Pid;
				}
			}

			public PROCESS_CMD()
			{
				this.Memory = new PS3Lib.PS3MAPI.PROCESS_CMD.MEMORY_CMD();
				this.Modules = new PS3Lib.PS3MAPI.PROCESS_CMD.MODULES_CMD();
			}

			public string GetName(uint pid)
			{
				string result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Process_GetName(pid);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public uint[] GetPidProcesses()
			{
				uint[] result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Process_GetPidList();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public PS3Lib.PS3MAPI.PROCESS_CMD.MEMORY_CMD Memory;

			public PS3Lib.PS3MAPI.PROCESS_CMD.MODULES_CMD Modules;

			public class MEMORY_CMD
			{
				public MEMORY_CMD()
				{
				}

				public void Get(uint Pid, ulong Address, byte[] Bytes)
				{
					try
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Memory_Get(Pid, Address, Bytes);
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						throw new System.Exception(ex2.Message, ex2);
					}
				}

				public byte[] Get(uint Pid, ulong Address, uint Length)
				{
					byte[] result = { 0 };
					try
					{
						byte[] array = new byte[Length];
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Memory_Get(Pid, Address, array);
						result = array;
					}
                    catch (System.Exception ex)
                    {
                        System.Exception ex2 = ex;
                        throw new System.Exception(ex2.Message, ex2);
                    }
                    return result;
				}

				public void Set(uint Pid, ulong Address, byte[] Bytes)
				{
					try
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Memory_Set(Pid, Address, Bytes);
                    }
                    catch (System.Exception ex)
                    {
                        System.Exception ex2 = ex;
                        throw new System.Exception(ex2.Message, ex2);
                    }
                }
            }

			public class MODULES_CMD
			{
				public int[] Modules_Prx_Id
				{
					get
					{
						return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Modules_Prx_Id;
					}
				}

				public MODULES_CMD()
				{
				}

				public string GetFilename(uint pid, int prxid)
				{
					string result;
					try
					{
						result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Module_GetFilename(pid, prxid);
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						throw new System.Exception(ex2.Message, ex2);
					}
					return result;
				}

				public string GetName(uint pid, int prxid)
				{
					string result;
					try
					{
						result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Module_GetName(pid, prxid);
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						throw new System.Exception(ex2.Message, ex2);
					}
					return result;
				}

				public int[] GetPrxIdModules(uint pid)
				{
					int[] result;
					try
					{
						result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Module_GetPrxIdList(pid);
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						throw new System.Exception(ex2.Message, ex2);
					}
					return result;
				}

				public void Load(uint pid, string path)
				{
					try
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Module_Load(pid, path);
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						throw new System.Exception(ex2.Message, ex2);
					}
				}

				public void Unload(uint pid, int prxid)
				{
					try
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Module_Unload(pid, prxid);
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						throw new System.Exception(ex2.Message, ex2);
					}
				}
			}
		}

		public class PS3_CMD
		{
			public PS3_CMD()
			{
			}

			public bool CheckSyscall(int num)
			{
				bool result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_CheckSyscall(num);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public void ClearHistory(bool include_directory = true)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_ClearHistory(include_directory);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void DisableSyscall(int num)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_DisableSyscall(num);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public string GetFirmwareType()
			{
				string result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_GetFirmwareType();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public uint GetFirmwareVersion()
			{
				uint result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_GetFwVersion();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public string GetFirmwareVersion_Str()
			{
				string text = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_GetFwVersion().ToString("X4");
				string str = text.Substring(1, 1) + ".";
				string str2 = text.Substring(2, 1);
				string str3 = text.Substring(3, 1);
				return str + str2 + str3;
			}

			public string GetIDPS()
			{
				string result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_GetIDPS();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public string GetPSID()
			{
				string result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_GetPSID();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public void GetTemperature(out uint cpu, out uint rsx)
			{
				cpu = 0U;
				rsx = 0U;
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_GetTemp(out cpu, out rsx);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void Led(PS3Lib.PS3MAPI.PS3_CMD.LedColor color, PS3Lib.PS3MAPI.PS3_CMD.LedMode mode)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_Led(System.Convert.ToInt32(color), System.Convert.ToInt32(mode));
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void Notify(string msg)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_Notify(msg);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode PartialCheckSyscall8()
			{
				PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode result;
				try
				{
					if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_PartialCheckSyscall8() == 0)
					{
						result = PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.Enabled;
					}
					else if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_PartialCheckSyscall8() != 1)
					{
						result = ((PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_PartialCheckSyscall8() != 2) ? PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.FakeDisabled : PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.Only_PS3MAPI_Enabled);
					}
					else
					{
						result = PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.Only_CobraMambaAndPS3MAPI_Enabled;
					}
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public void PartialDisableSyscall8(PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode mode)
			{
				try
				{
					if (mode == PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.Enabled)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(0);
					}
					else if (mode == PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.Only_CobraMambaAndPS3MAPI_Enabled)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(1);
					}
					else if (mode == PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.Only_PS3MAPI_Enabled)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(2);
					}
					else if (mode == PS3Lib.PS3MAPI.PS3_CMD.Syscall8Mode.FakeDisabled)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_PartialDisableSyscall8(3);
					}
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void Power(PS3Lib.PS3MAPI.PS3_CMD.PowerFlags flag)
			{
				try
				{
					if (flag == PS3Lib.PS3MAPI.PS3_CMD.PowerFlags.ShutDown)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_Shutdown();
					}
					else if (flag == PS3Lib.PS3MAPI.PS3_CMD.PowerFlags.QuickReboot)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_Reboot();
					}
					else if (flag == PS3Lib.PS3MAPI.PS3_CMD.PowerFlags.SoftReboot)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_SoftReboot();
					}
					else if (flag == PS3Lib.PS3MAPI.PS3_CMD.PowerFlags.HardReboot)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_HardReboot();
					}
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void RemoveHook()
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_RemoveHook();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void RingBuzzer(PS3Lib.PS3MAPI.PS3_CMD.BuzzerMode mode)
			{
				try
				{
					if (mode == PS3Lib.PS3MAPI.PS3_CMD.BuzzerMode.Single)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_Buzzer(1);
					}
					else if (mode == PS3Lib.PS3MAPI.PS3_CMD.BuzzerMode.Double)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_Buzzer(2);
					}
					else if (mode == PS3Lib.PS3MAPI.PS3_CMD.BuzzerMode.Triple)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_Buzzer(3);
					}
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void SetIDPS(string IDPS)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_SetIDPS(IDPS);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void SetPSID(string PSID)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3_SetPSID(PSID);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public enum BuzzerMode
			{
				Single,
				Double,
				Triple
			}

			public enum LedColor
			{
				Red,
				Green,
				Yellow
			}

			public enum LedMode
			{
				Off,
				On,
				BlinkFast,
				BlinkSlow
			}

			public enum PowerFlags
			{
				ShutDown,
				QuickReboot,
				SoftReboot,
				HardReboot
			}

			public enum Syscall8Mode
			{
				Enabled,
				Only_CobraMambaAndPS3MAPI_Enabled,
				Only_PS3MAPI_Enabled,
				FakeDisabled,
				Disabled
			}
		}

		public class PS3MAPI_Client_Server
		{
			public static bool IsAttached
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPid != 0U;
				}
			}

			public static bool IsConnected
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock != null && PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Connected;
				}
			}

			public static string Log
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog;
				}
			}

			public static int[] Modules_Prx_Id
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id;
				}
			}

			public static uint Process_Pid
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPid;
				}
				set
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPid = value;
				}
			}

			public static uint[] Processes_Pid
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid;
				}
			}

			public static int Timeout
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iTimeout;
				}
				set
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iTimeout = value;
				}
			}

			static PS3MAPI_Client_Server()
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ps3m_api_server_minversion = 0x120;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sMessages = "";
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sServerIP = "";
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPort = 0x1ECF;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sBucket = "";
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iTimeout = 0x1388;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPid = 0U;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid = new uint[0x10];
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id = new int[0x40];
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog = "";
			}

			public PS3MAPI_Client_Server()
			{
			}

			public static void CloseDataSocket()
			{
				if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock != null)
				{
					if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock.Connected)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock.Close();
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock = null;
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_ipEndPoint = null;
			}

			public static void Connect()
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Connect(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sServerIP, PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPort);
			}

			public static void Connect(string sServer, int Port)
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sServerIP = sServer;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPort = Port;
				if (Port.ToString().Length == 0)
				{
					throw new System.Exception("Unable to Connect - No Port Specified.");
				}
				if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sServerIP.Length == 0)
				{
					throw new System.Exception("Unable to Connect - No Server Specified.");
				}
				if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock == null || !PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Connected)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
#pragma warning disable CS0618 // 'Dns.GetHostByName(string)' is obsolete: 'GetHostByName is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202'
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_ipEndPoint = new System.Net.IPEndPoint(System.Net.Dns.GetHostByName(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sServerIP).AddressList[0], Port);
#pragma warning restore CS0618 // 'Dns.GetHostByName(string)' is obsolete: 'GetHostByName is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202'
					try
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Connect(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_ipEndPoint);
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						throw new System.Exception(ex2.Message, ex2);
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
					if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.PS3MAPIConnected)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
					if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.PS3MAPIConnectedOK)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
					}
					if ((ulong)PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Server_GetMinVersion() < (ulong)((long)PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ps3m_api_server_minversion))
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
						throw new System.Exception("PS3M_API SERVER (webMAN-MOD) OUTDATED! PLEASE UPDATE.");
					}
					if ((ulong)PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Server_GetMinVersion() > (ulong)((long)PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ps3m_api_server_minversion))
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
						throw new System.Exception("PS3M_API PC_LIB (PS3ManagerAPI.dll) OUTDATED! PLEASE UPDATE.");
					}
				}
			}

			public static void ConnectDataSocket()
			{
				if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock == null)
				{
					try
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.listening_sock.Accept();
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.listening_sock.Close();
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.listening_sock = null;
						if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock == null)
						{
							throw new System.Exception("Winsock error: " + System.Convert.ToString(System.Runtime.InteropServices.Marshal.GetLastWin32Error()));
						}
					}
					catch (System.Exception ex)
					{
						throw new System.Exception("Failed to connect for data transfer: " + ex.Message);
					}
				}
			}

			public static uint Core_Get_Version()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("CORE GETVERSION");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return System.Convert.ToUInt32(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
			}

			public static uint Core_GetMinVersion()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("CORE GETMINVERSION");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return System.Convert.ToUInt32(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
			}

			public static void Disconnect()
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
				if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock != null)
				{
					if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Connected)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("DISCONNECT");
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iPid = 0U;
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Close();
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock = null;
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_ipEndPoint = null;
			}

			public static void Fail()
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail(new System.Exception("[" + PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode.ToString() + "] " + PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse));
			}

			public static void Fail(System.Exception e)
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
				throw e;
			}

			public static void FillBucket()
			{
				byte[] array = new byte[0x200];
				int num = 0;
				while (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Available < 1)
				{
					System.Threading.Thread.Sleep(0x32);
					num += 0x32;
					if (num > PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Timeout)
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail(new System.Exception("Timed out waiting on server to respond."));
					}
				}
				while (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Available > 0)
				{
					long num2 = (long)PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Receive(array, 0x200, System.Net.Sockets.SocketFlags.None);
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sBucket += System.Text.Encoding.ASCII.GetString(array, 0, (int)num2);
					System.Threading.Thread.Sleep(0x32);
				}
			}

			public static string GetLineFromBucket()
			{
				int i;
				for (i = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sBucket.IndexOf('\n'); i < 0; i = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sBucket.IndexOf('\n'))
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.FillBucket();
				}
				string result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sBucket.Substring(0, i);
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sBucket = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sBucket.Substring(i + 1);
				return result;
			}

			public static void Memory_Get(uint Pid, ulong Address, byte[] Bytes)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.usingMem)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.usingMem = true;
					if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
					{
						throw new System.Exception("PS3MAPI not connected!");
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(true);
					int num = Bytes.Length;
					long num2 = 0L;
					bool flag = false;
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.OpenDataSocket();
					string[] values = new string[]
					{
						"MEMORY GET ",
						string.Format("{0}", Pid),
						" ",
						string.Format("{0:X16}", Address),
						" ",
						string.Format("{0}", Bytes.Length)
					};
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand(string.Concat(values));
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
					if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.DataConnectionAlreadyOpen && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryStatusOK)
					{
						throw new System.Exception(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ConnectDataSocket();
					byte[] array = new byte[Bytes.Length];
					while (!flag)
					{
						try
						{
							long num3 = (long)PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock.Receive(array, num, System.Net.Sockets.SocketFlags.None);
							if (num3 <= 0L)
							{
								flag = true;
							}
							else
							{
								System.Buffer.BlockCopy(array, 0, Bytes, (int)num2, (int)num3);
								num2 += num3;
								if ((int)(num2 * 0x64L / (long)num) >= 0x64)
								{
									flag = true;
								}
							}
							if (flag)
							{
								PS3Lib.PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
								PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
								PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode2 = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
								if (ps3MAPI_ResponseCode2 != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful && ps3MAPI_ResponseCode2 != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryActionCompleted)
								{
									throw new System.Exception(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
								}
								PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
							}
						}
						catch (System.Exception ex)
						{
							System.Exception ex2 = ex;
							PS3Lib.PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
							PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
							PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
							throw ex2;
						}
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.usingMem = false;
				}
			}

			public static void Memory_Set(uint Pid, ulong Address, byte[] Bytes)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(true);
				int num = Bytes.Length;
				long num2 = 0L;
				long num3 = 0L;
				bool flag = false;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.OpenDataSocket();
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MEMORY SET " + string.Format("{0}", Pid) + " " + string.Format("{0:X16}", Address));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.DataConnectionAlreadyOpen && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryStatusOK)
				{
					throw new System.Exception(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ConnectDataSocket();
				while (!flag)
				{
					try
					{
						byte[] array = new byte[num - (int)num2];
						System.Buffer.BlockCopy(Bytes, (int)num3, array, 0, num - (int)num2);
						num3 = (long)PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock.Send(array, Bytes.Length - (int)num2, System.Net.Sockets.SocketFlags.None);
						flag = false;
						if (num3 <= 0L)
						{
							flag = true;
						}
						else
						{
							num2 += num3;
							if ((int)(num2 * 0x64L / (long)num) >= 0x64)
							{
								flag = true;
							}
						}
						if (flag)
						{
							PS3Lib.PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
							PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
							PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode2 = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
							if (ps3MAPI_ResponseCode2 != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful && ps3MAPI_ResponseCode2 != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.MemoryActionCompleted)
							{
								throw new System.Exception(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
							}
							PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
						}
					}
					catch (System.Exception ex)
					{
						System.Exception ex2 = ex;
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SetBinaryMode(false);
						throw ex2;
					}
				}
			}

			public static string Module_GetFilename(uint pid, int prxid)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETFILENAME " + string.Format("{0}", pid) + " " + prxid.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse;
			}

			public static string Module_GetName(uint pid, int prxid)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETNAME " + string.Format("{0}", pid) + " " + prxid.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse;
			}

			public static int[] Module_GetPrxIdList(uint pid)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETALLPRXID " + string.Format("{0}", pid));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				int num = 0;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id = new int[0x80];
				foreach (string text in PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
				{
					'|'
				}))
				{
					if (text.Length != 0 && text != null && text != "" && text != " " && text != "0")
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id[num] = System.Convert.ToInt32(text, 0xA);
						num++;
					}
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.imodules_prx_id;
			}

			public static void Module_Load(uint pid, string path)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE LOAD " + string.Format("{0}", pid) + " " + path);
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void Module_Unload(uint pid, int prx_id)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE UNLOAD " + string.Format("{0}", pid) + " " + prx_id.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void OpenDataSocket()
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Connect();
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PASV");
				if (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.EnteringPassiveMode)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				string[] array;
				try
				{
					int num = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse.IndexOf('(') + 1;
					int length = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse.IndexOf(')') - num;
					array = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse.Substring(num, length).Split(new char[]
					{
						','
					});
				}
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
				catch (System.Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail(new System.Exception("Malformed PASV response: " + PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse));
					throw new System.Exception("Malformed PASV response: " + PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
				}
				if (array.Length < 6)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail(new System.Exception("Malformed PASV response: " + PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse));
				}
				object[] args = new object[]
				{
					array[0],
					array[1],
					array[2],
					array[3]
				};
				string.Format("{0}.{1}.{2}.{3}", args);
				int port = (int.Parse(array[4]) << 8) + int.Parse(array[5]);
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.CloseDataSocket();
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
#pragma warning disable CS0618 // 'Dns.GetHostByName(string)' is obsolete: 'GetHostByName is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202'
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_ipEndPoint = new System.Net.IPEndPoint(System.Net.Dns.GetHostByName(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sServerIP).AddressList[0], port);
#pragma warning restore CS0618 // 'Dns.GetHostByName(string)' is obsolete: 'GetHostByName is obsoleted for this type, please use GetHostEntry instead. http://go.microsoft.com/fwlink/?linkid=14202'
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_sock.Connect(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.data_ipEndPoint);
				}
				catch (System.Exception ex2)
				{
					throw new System.Exception("Failed to connect for data transfer: " + ex2.Message);
				}
			}

			public static string Process_GetName(uint pid)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PROCESS GETNAME " + string.Format("{0}", pid));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse;
			}

			public static uint[] Process_GetPidList()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PROCESS GETALLPID");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				int num = 0;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid = new uint[0x10];
				foreach (string text in PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
				{
					'|'
				}))
				{
					if (text.Length != 0 && text != null && text != "" && text != " " && text != "0")
					{
						PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid[num] = System.Convert.ToUInt32(text, 0xA);
						num++;
					}
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.iprocesses_pid;
			}

			public static void PS3_Buzzer(int mode)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 BUZZER" + mode.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static bool PS3_CheckSyscall(int num)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 CHECKSYSCALL " + num.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return System.Convert.ToInt32(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse) == 0;
			}

			public static void PS3_ClearHistory(bool include_directory)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				if (!include_directory)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 DELHISTORY");
				}
				else
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 DELHISTORY+D");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void PS3_DisableSyscall(int num)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 DISABLESYSCALL " + num.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static string PS3_GetFirmwareType()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETFWTYPE");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse;
			}

			public static uint PS3_GetFwVersion()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETFWVERSION");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return System.Convert.ToUInt32(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
			}

			public static string PS3_GetIDPS()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETIDPS");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse;
			}

			public static string PS3_GetPSID()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETPSID");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse;
			}

			public static void PS3_GetTemp(out uint cpu, out uint rsx)
			{
				cpu = 0U;
				rsx = 0U;
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 GETTEMP");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				string[] array = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
				{
					'|'
				});
				cpu = System.Convert.ToUInt32(array[0], 0xA);
				rsx = System.Convert.ToUInt32(array[1], 0xA);
			}

			public static void PS3_HardReboot()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 HARDREBOOT");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				else
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
				}
			}

			public static void PS3_Led(int color, int mode)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 LED " + color.ToString() + " " + mode.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void PS3_Notify(string msg)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 NOTIFY  " + msg);
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static int PS3_PartialCheckSyscall8()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 PCHECKSYSCALL8");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return System.Convert.ToInt32(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
			}

			public static void PS3_PartialDisableSyscall8(int mode)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 PDISABLESYSCALL8 " + mode.ToString());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void PS3_Reboot()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 REBOOT");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				else
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
				}
			}

			public static void PS3_RemoveHook()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 REMOVEHOOK");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void PS3_SetIDPS(string IDPS)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SETIDPS " + IDPS.Substring(0, 0x10) + " " + IDPS.Substring(0x10, 0x10));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void PS3_SetPSID(string PSID)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SETPSID " + PSID.Substring(0, 0x10) + " " + PSID.Substring(0x10, 0x10));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void PS3_Shutdown()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SHUTDOWN");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				else
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
				}
			}

			public static void PS3_SoftReboot()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("PS3 SOFTREBOOT");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				else
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Disconnect();
				}
			}

			public static void ReadResponse()
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sMessages = "";
				string lineFromBucket;
				for (;;)
				{
					lineFromBucket = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.GetLineFromBucket();
					if (System.Text.RegularExpressions.Regex.Match(lineFromBucket, "^[0-9]+ ").Success)
					{
						break;
					}
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sMessages = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sMessages + System.Text.RegularExpressions.Regex.Replace(lineFromBucket, "^[0-9]+-", "") + "\n";
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse = lineFromBucket.Substring(4).Replace("\r", "").Replace("\n", "");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode = (PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode)int.Parse(lineFromBucket.Substring(0, 3));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog + "RESPONSE CODE: " + PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode.ToString() + System.Environment.NewLine;
				string[] values = new string[]
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog,
					"RESPONSE MSG: ",
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse,
					System.Environment.NewLine,
					System.Environment.NewLine
				};
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog = string.Concat(values);
			}

			public static void SendCommand(string sCommand)
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sLog + "COMMAND: " + sCommand + System.Environment.NewLine;
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Connect();
				byte[] bytes = System.Text.Encoding.ASCII.GetBytes((sCommand + "\r\n").ToCharArray());
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.main_sock.Send(bytes, bytes.Length, System.Net.Sockets.SocketFlags.None);
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.ReadResponse();
			}

			public static uint Server_Get_Version()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("SERVER GETVERSION");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return System.Convert.ToUInt32(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
			}

			public static uint Server_GetMinVersion()
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("SERVER GETMINVERSION");
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				return System.Convert.ToUInt32(PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse);
			}

			public static void SetBinaryMode(bool bMode)
			{
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("TYPE" + (bMode ? " I" : " A"));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void VSHPlugins_GetInfoBySlot(uint slot, out string name, out string path)
			{
				name = "";
				path = "";
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE GETVSHPLUGINFO " + string.Format("{0}", slot));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
				string[] array = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.sResponse.Split(new char[]
				{
					'|'
				});
				name = array[0];
				path = array[1];
			}

			public static void VSHPlugins_Load(uint slot, string path)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE LOADVSHPLUG " + string.Format("{0}", slot) + " " + path);
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			public static void VSHPlugins_Unload(uint slot)
			{
				if (!PS3Lib.PS3MAPI.PS3MAPI_Client_Server.IsConnected)
				{
					throw new System.Exception("PS3MAPI not connected!");
				}
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.SendCommand("MODULE UNLOADVSHPLUGS " + string.Format("{0}", slot));
				PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode ps3MAPI_ResponseCode = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.eResponseCode;
				if (ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.CommandOK && ps3MAPI_ResponseCode != PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode.RequestSuccessful)
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Fail();
				}
			}

			private static int ps3m_api_server_minversion;

			private static PS3Lib.PS3MAPI.PS3MAPI_Client_Server.PS3MAPI_ResponseCode eResponseCode;

			private static string sResponse;

			private static string sMessages;

			private static string sServerIP;

			private static int iPort;

			private static string sBucket;

			private static int iTimeout;

			private static uint iPid;

			private static uint[] iprocesses_pid;

			private static int[] imodules_prx_id;

			private static string sLog;

			public static System.Net.Sockets.Socket main_sock;

			public static System.Net.Sockets.Socket listening_sock;

			public static System.Net.Sockets.Socket data_sock;

			public static System.Net.IPEndPoint main_ipEndPoint;

			public static System.Net.IPEndPoint data_ipEndPoint;

			public static bool usingMem = false;

			public enum PS3MAPI_ResponseCode
			{
				DataConnectionAlreadyOpen = 0x7D,
				MemoryStatusOK = 0x96,
				CommandOK = 0xC8,
				PS3MAPIConnected = 0xDC,
				RequestSuccessful = 0xE2,
				EnteringPassiveMode,
				PS3MAPIConnectedOK = 0xE6,
				MemoryActionCompleted = 0xFA,
				MemoryActionPended = 0x15E
			}
		}

		public class PS3MAPI_Client_Web
		{
			public PS3MAPI_Client_Web()
			{
			}
		}

		public class SERVER_CMD
		{
			public int Timeout
			{
				get
				{
					return PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Timeout;
				}
				set
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Timeout = value;
				}
			}

			public SERVER_CMD()
			{
			}

			public uint GetVersion()
			{
				uint result;
				try
				{
					result = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Server_Get_Version();
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
				return result;
			}

			public string GetVersion_Str()
			{
				string text = PS3Lib.PS3MAPI.PS3MAPI_Client_Server.Server_Get_Version().ToString("X4");
				string str = text.Substring(1, 1) + ".";
				string str2 = text.Substring(2, 1) + ".";
				string str3 = text.Substring(3, 1);
				return str + str2 + str3;
			}
		}

		public class VSH_PLUGINS_CMD
		{
			public VSH_PLUGINS_CMD()
			{
			}

			public void GetInfoBySlot(uint slot, out string name, out string path)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.VSHPlugins_GetInfoBySlot(slot, out name, out path);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void Load(uint slot, string path)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.VSHPlugins_Load(slot, path);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}

			public void Unload(uint slot)
			{
				try
				{
					PS3Lib.PS3MAPI.PS3MAPI_Client_Server.VSHPlugins_Unload(slot);
				}
				catch (System.Exception ex)
				{
					System.Exception ex2 = ex;
					throw new System.Exception(ex2.Message, ex2);
				}
			}
		}
	}
}
