using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PS3Lib
{
	public class CCAPI
	{
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string dllName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		public CCAPI()
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\FrenchModdingTeam\\CCAPI\\InstallFolder");
			if (registryKey != null)
			{
				string text = registryKey.GetValue("path") as string;
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = text + "\\CCAPI.dll";
					if (File.Exists(text2))
					{
						if (this.libModule == IntPtr.Zero)
						{
							this.libModule = PS3Lib.CCAPI.LoadLibrary(text2);
						}
						if (this.libModule != IntPtr.Zero)
						{
							this.CCAPIFunctionsList.Clear();
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIConnectConsole"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIDisconnectConsole"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetConnectionStatus"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetConsoleInfo"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetDllVersion"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetFirmwareInfo"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetNumberOfConsoles"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetProcessList"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetMemory"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetProcessName"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIGetTemperature"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIVshNotify"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIRingBuzzer"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPISetBootConsoleIds"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPISetConsoleIds"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPISetConsoleLed"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPISetMemory"));
							this.CCAPIFunctionsList.Add(PS3Lib.CCAPI.GetProcAddress(this.libModule, "CCAPIShutdown"));
							if (this.IsCCAPILoaded())
							{
								this.connectConsole = (PS3Lib.CCAPI.connectConsoleDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.ConnectConsole), typeof(PS3Lib.CCAPI.connectConsoleDelegate));
								this.disconnectConsole = (PS3Lib.CCAPI.disconnectConsoleDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.DisconnectConsole), typeof(PS3Lib.CCAPI.disconnectConsoleDelegate));
								this.getConnectionStatus = (PS3Lib.CCAPI.getConnectionStatusDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetConnectionStatus), typeof(PS3Lib.CCAPI.getConnectionStatusDelegate));
								this.getConsoleInfo = (PS3Lib.CCAPI.getConsoleInfoDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetConsoleInfo), typeof(PS3Lib.CCAPI.getConsoleInfoDelegate));
								this.getDllVersion = (PS3Lib.CCAPI.getDllVersionDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetDllVersion), typeof(PS3Lib.CCAPI.getDllVersionDelegate));
								this.getFirmwareInfo = (PS3Lib.CCAPI.getFirmwareInfoDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetFirmwareInfo), typeof(PS3Lib.CCAPI.getFirmwareInfoDelegate));
								this.getNumberOfConsoles = (PS3Lib.CCAPI.getNumberOfConsolesDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetNumberOfConsoles), typeof(PS3Lib.CCAPI.getNumberOfConsolesDelegate));
								this.getProcessList = (PS3Lib.CCAPI.getProcessListDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetProcessList), typeof(PS3Lib.CCAPI.getProcessListDelegate));
								this.getProcessMemory = (PS3Lib.CCAPI.getProcessMemoryDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetMemory), typeof(PS3Lib.CCAPI.getProcessMemoryDelegate));
								this.getProcessName = (PS3Lib.CCAPI.getProcessNameDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetProcessName), typeof(PS3Lib.CCAPI.getProcessNameDelegate));
								this.getTemperature = (PS3Lib.CCAPI.getTemperatureDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.GetTemperature), typeof(PS3Lib.CCAPI.getTemperatureDelegate));
								this.notify = (PS3Lib.CCAPI.notifyDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.VshNotify), typeof(PS3Lib.CCAPI.notifyDelegate));
								this.ringBuzzer = (PS3Lib.CCAPI.ringBuzzerDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.RingBuzzer), typeof(PS3Lib.CCAPI.ringBuzzerDelegate));
								this.setBootConsoleIds = (PS3Lib.CCAPI.setBootConsoleIdsDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.SetBootConsoleIds), typeof(PS3Lib.CCAPI.setBootConsoleIdsDelegate));
								this.setConsoleIds = (PS3Lib.CCAPI.setConsoleIdsDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.SetConsoleIds), typeof(PS3Lib.CCAPI.setConsoleIdsDelegate));
								this.setConsoleLed = (PS3Lib.CCAPI.setConsoleLedDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.SetConsoleLed), typeof(PS3Lib.CCAPI.setConsoleLedDelegate));
								this.setProcessMemory = (PS3Lib.CCAPI.setProcessMemoryDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.SetMemory), typeof(PS3Lib.CCAPI.setProcessMemoryDelegate));
								this.shutdown = (PS3Lib.CCAPI.shutdownDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions.ShutDown), typeof(PS3Lib.CCAPI.shutdownDelegate));
							}
							else
							{
								MessageBox.Show("Impossible to load CCAPI 2.60+", "This CCAPI.dll is not compatible", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Impossible to load CCAPI 2.60+", "CCAPI.dll cannot be loaded", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("You need to install CCAPI 2.60+ to use this library.", "CCAPI.dll not found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Invalid CCAPI folder, please re-install it.", "CCAPI not installed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("You need to install CCAPI 2.60+ to use this library.", "CCAPI not installed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private IntPtr ReadDataFromUnBufPtr<T>(IntPtr unBuf, ref T storage)
		{
			storage = (T)((object)Marshal.PtrToStructure(unBuf, typeof(T)));
			return new IntPtr(unBuf.ToInt64() + (long)Marshal.SizeOf(storage));
		}

		public PS3Lib.Extension Extension
		{
			get
			{
				return new PS3Lib.Extension(PS3Lib.SelectAPI.ControlConsole);
			}
		}

		private IntPtr GetCCAPIFunctionPtr(PS3Lib.CCAPI.CCAPIFunctions Function)
		{
			return this.CCAPIFunctionsList.ElementAt((int)Function);
		}

		private bool IsCCAPILoaded()
		{
			for (int i = 0; i < this.CCAPIFunctionsList.Count; i++)
			{
				if (this.CCAPIFunctionsList.ElementAt(i) == IntPtr.Zero)
				{
					return false;
				}
			}
			return true;
		}

		private void CompleteInfo(ref PS3Lib.CCAPI.TargetInfo Info, int fw, int ccapi, ulong sysTable, int consoleType, int tempCELL, int tempRSX)
		{
			Info.Firmware = fw;
			Info.CCAPI = ccapi;
			Info.SysTable = sysTable;
			Info.ConsoleType = consoleType;
			Info.TempCell = tempCELL;
			Info.TempRSX = tempRSX;
		}

		public bool SUCCESS(int Void)
		{
			return Void == 0;
		}

		public bool ConnectTarget()
		{
			return new PS3Lib.PS3API.ConsoleList(new PS3Lib.PS3API(PS3Lib.SelectAPI.ControlConsole)).Show();
		}

		public int ConnectTarget(string targetIP)
		{
			return this.connectConsole(targetIP);
		}

		public int GetConnectionStatus()
		{
			int result = 0;
			this.getConnectionStatus(ref result);
			return result;
		}

		public int DisconnectTarget()
		{
			return this.disconnectConsole();
		}

		public int AttachProcess()
		{
			PS3Lib.CCAPI.System.processID = 0U;
			int num = this.GetProcessList(out PS3Lib.CCAPI.System.processIDs);
			if (this.SUCCESS(num) && PS3Lib.CCAPI.System.processIDs.Length > 0)
			{
				for (int i = 0; i < PS3Lib.CCAPI.System.processIDs.Length; i++)
				{
					string empty = string.Empty;
					num = this.GetProcessName(PS3Lib.CCAPI.System.processIDs[i], out empty);
					if (!this.SUCCESS(num))
					{
						break;
					}
					if (!empty.Contains("flash"))
					{
						PS3Lib.CCAPI.System.processID = PS3Lib.CCAPI.System.processIDs[i];
						break;
					}
					num = -1;
				}
				if (PS3Lib.CCAPI.System.processID == 0U)
				{
					PS3Lib.CCAPI.System.processID = PS3Lib.CCAPI.System.processIDs[PS3Lib.CCAPI.System.processIDs.Length - 1];
				}
			}
			else
			{
				num = -1;
			}
			return num;
		}

		public int AttachProcess(PS3Lib.CCAPI.ProcessType procType)
		{
			PS3Lib.CCAPI.System.processID = 0U;
			int num = this.GetProcessList(out PS3Lib.CCAPI.System.processIDs);
			if (num >= 0 && PS3Lib.CCAPI.System.processIDs.Length > 0)
			{
				for (int i = 0; i < PS3Lib.CCAPI.System.processIDs.Length; i++)
				{
					string empty = string.Empty;
					num = this.GetProcessName(PS3Lib.CCAPI.System.processIDs[i], out empty);
					if (num < 0)
					{
						break;
					}
					if (procType == PS3Lib.CCAPI.ProcessType.VSH && empty.Contains("vsh"))
					{
						PS3Lib.CCAPI.System.processID = PS3Lib.CCAPI.System.processIDs[i];
						break;
					}
					if (procType == PS3Lib.CCAPI.ProcessType.SYS_AGENT && empty.Contains("agent"))
					{
						PS3Lib.CCAPI.System.processID = PS3Lib.CCAPI.System.processIDs[i];
						break;
					}
					if (procType == PS3Lib.CCAPI.ProcessType.CURRENTGAME && !empty.Contains("flash"))
					{
						PS3Lib.CCAPI.System.processID = PS3Lib.CCAPI.System.processIDs[i];
						break;
					}
				}
				if (PS3Lib.CCAPI.System.processID == 0U)
				{
					PS3Lib.CCAPI.System.processID = PS3Lib.CCAPI.System.processIDs[PS3Lib.CCAPI.System.processIDs.Length - 1];
				}
			}
			else
			{
				num = -1;
			}
			return num;
		}

		public int AttachProcess(uint process)
		{
			uint[] array = new uint[0x40];
			int num = this.GetProcessList(out array);
			if (this.SUCCESS(num))
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == process)
					{
						num = 0;
						PS3Lib.CCAPI.System.processID = process;
						break;
					}
					num = -1;
				}
			}
			array = null;
			return num;
		}

		public int GetProcessList(out uint[] processIds)
		{
			uint num = 0x40U;
			IntPtr intPtr = Marshal.AllocHGlobal(0x100);
			int num2 = this.getProcessList(ref num, intPtr);
			processIds = new uint[num];
			if (this.SUCCESS(num2))
			{
				IntPtr unBuf = intPtr;
				for (uint num3 = 0U; num3 < num; num3 += 1U)
				{
					unBuf = this.ReadDataFromUnBufPtr<uint>(unBuf, ref processIds[(int)((UIntPtr)num3)]);
				}
			}
			Marshal.FreeHGlobal(intPtr);
			return num2;
		}

		public int GetProcessName(uint processId, out string name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(0x211);
			int num = this.getProcessName(processId, intPtr);
			name = string.Empty;
			if (this.SUCCESS(num))
			{
				name = Marshal.PtrToStringAnsi(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		public uint GetAttachedProcess()
		{
			return PS3Lib.CCAPI.System.processID;
		}

		public int SetMemory(uint offset, byte[] buffer)
		{
			return this.setProcessMemory(PS3Lib.CCAPI.System.processID, (ulong)offset, (uint)buffer.Length, buffer);
		}

		public int SetMemory(ulong offset, byte[] buffer)
		{
			return this.setProcessMemory(PS3Lib.CCAPI.System.processID, offset, (uint)buffer.Length, buffer);
		}

		public int SetMemory(ulong offset, string hexadecimal, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
		{
			byte[] array = PS3Lib.CCAPI.StringToByteArray(hexadecimal);
			if (Type == PS3Lib.EndianType.LittleEndian)
			{
				Array.Reverse(array);
			}
			return this.setProcessMemory(PS3Lib.CCAPI.System.processID, offset, (uint)array.Length, array);
		}

		public int GetMemory(uint offset, byte[] buffer)
		{
			return this.getProcessMemory(PS3Lib.CCAPI.System.processID, (ulong)offset, (uint)buffer.Length, buffer);
		}

		public int GetMemory(ulong offset, byte[] buffer)
		{
			return this.getProcessMemory(PS3Lib.CCAPI.System.processID, offset, (uint)buffer.Length, buffer);
		}

		public byte[] GetBytes(uint offset, uint length)
		{
			byte[] array = new byte[length];
			this.GetMemory(offset, array);
			return array;
		}

		public byte[] GetBytes(ulong offset, uint length)
		{
			byte[] array = new byte[length];
			this.GetMemory(offset, array);
			return array;
		}

		public int Notify(PS3Lib.CCAPI.NotifyIcon icon, string message)
		{
			return this.notify((int)icon, message);
		}

		public int Notify(int icon, string message)
		{
			return this.notify(icon, message);
		}

		public int ShutDown(PS3Lib.CCAPI.RebootFlags flag)
		{
			return this.shutdown((int)flag);
		}

		public int RingBuzzer(PS3Lib.CCAPI.BuzzerMode flag)
		{
			return this.ringBuzzer((int)flag);
		}

		public int SetConsoleLed(PS3Lib.CCAPI.LedColor color, PS3Lib.CCAPI.LedMode mode)
		{
			return this.setConsoleLed((int)color, (int)mode);
		}

		private int GetTargetInfo()
		{
			int[] array = new int[2];
			int fw = 0;
			int ccapi = 0;
			int consoleType = 0;
			ulong sysTable = 0UL;
			int num = this.getFirmwareInfo(ref fw, ref ccapi, ref consoleType);
			if (num >= 0)
			{
				num = this.getTemperature(ref array[0], ref array[1]);
				if (num >= 0)
				{
					this.CompleteInfo(ref this.pInfo, fw, ccapi, sysTable, consoleType, array[0], array[1]);
				}
			}
			return num;
		}

		public int GetTargetInfo(out PS3Lib.CCAPI.TargetInfo Info)
		{
			Info = new PS3Lib.CCAPI.TargetInfo();
			int[] array = new int[2];
			int fw = 0;
			int ccapi = 0;
			int consoleType = 0;
			ulong sysTable = 0UL;
			int num = this.getFirmwareInfo(ref fw, ref ccapi, ref consoleType);
			if (num >= 0)
			{
				num = this.getTemperature(ref array[0], ref array[1]);
				if (num >= 0)
				{
					this.CompleteInfo(ref Info, fw, ccapi, sysTable, consoleType, array[0], array[1]);
					this.CompleteInfo(ref this.pInfo, fw, ccapi, sysTable, consoleType, array[0], array[1]);
				}
			}
			return num;
		}

		public string GetFirmwareVersion()
		{
			if (this.pInfo.Firmware == 0)
			{
				this.GetTargetInfo();
			}
			string text = this.pInfo.Firmware.ToString("X8");
			string str = text.Substring(1, 1) + ".";
			string str2 = text.Substring(3, 1);
			string str3 = text.Substring(4, 1);
			return str + str2 + str3;
		}

		public string GetTemperatureCELL()
		{
			if (this.pInfo.TempCell == 0)
			{
				this.GetTargetInfo(out this.pInfo);
			}
			return this.pInfo.TempCell.ToString() + " C";
		}

		public string GetTemperatureRSX()
		{
			if (this.pInfo.TempRSX == 0)
			{
				this.GetTargetInfo(out this.pInfo);
			}
			return this.pInfo.TempRSX.ToString() + " C";
		}

		public string GetFirmwareType()
		{
			if (this.pInfo.ConsoleType == 0)
			{
				this.GetTargetInfo(out this.pInfo);
			}
			string result = "UNK";
			if (this.pInfo.ConsoleType == 1)
			{
				result = "CEX";
			}
			else if (this.pInfo.ConsoleType == 2)
			{
				result = "DEX";
			}
			else if (this.pInfo.ConsoleType == 3)
			{
				result = "TOOL";
			}
			return result;
		}

		public void ClearTargetInfo()
		{
			this.pInfo = new PS3Lib.CCAPI.TargetInfo();
		}

		public int SetConsoleID(string consoleID)
		{
			int result;
			if (string.IsNullOrEmpty(consoleID))
			{
				MessageBox.Show("Cannot send an empty value", "Empty or null console id", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			else
			{
				string hex = string.Empty;
				if (consoleID.Length >= 0x20)
				{
					hex = consoleID.Substring(0, 0x20);
				}
				result = this.SetConsoleID(PS3Lib.CCAPI.StringToByteArray(hex));
			}
			return result;
		}

		public int SetConsoleID(byte[] consoleID)
		{
			int result;
			if (consoleID.Length <= 0)
			{
				MessageBox.Show("Cannot send an empty value", "Empty or null console id", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			else
			{
				result = this.setConsoleIds(0, consoleID);
			}
			return result;
		}

		public int SetPSID(string PSID)
		{
			int result;
			if (string.IsNullOrEmpty(PSID))
			{
				MessageBox.Show("Cannot send an empty value", "Empty or null psid", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			else
			{
				string hex = string.Empty;
				if (PSID.Length >= 0x20)
				{
					hex = PSID.Substring(0, 0x20);
				}
				result = this.SetPSID(PS3Lib.CCAPI.StringToByteArray(hex));
			}
			return result;
		}

		public int SetPSID(byte[] consoleID)
		{
			int result;
			if (consoleID.Length <= 0)
			{
				MessageBox.Show("Cannot send an empty value", "Empty or null psid", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			else
			{
				result = this.setConsoleIds(1, consoleID);
			}
			return result;
		}

		public int SetBootConsoleID(string consoleID, PS3Lib.CCAPI.IdType Type = PS3Lib.CCAPI.IdType.IDPS)
		{
			string text = string.Empty;
			if (consoleID.Length >= 0x20)
			{
				text = consoleID.Substring(0, 0x20);
			}
			return this.SetBootConsoleID(PS3Lib.CCAPI.StringToByteArray(consoleID), Type);
		}

		public int SetBootConsoleID(byte[] consoleID, PS3Lib.CCAPI.IdType Type = PS3Lib.CCAPI.IdType.IDPS)
		{
			return this.setBootConsoleIds((int)Type, 1, consoleID);
		}

		public int ResetBootConsoleID(PS3Lib.CCAPI.IdType Type = PS3Lib.CCAPI.IdType.IDPS)
		{
			return this.setBootConsoleIds((int)Type, 0, null);
		}

		public int GetDllVersion()
		{
			return this.getDllVersion();
		}

		public List<PS3Lib.CCAPI.ConsoleInfo> GetConsoleList()
		{
			List<PS3Lib.CCAPI.ConsoleInfo> list = new List<PS3Lib.CCAPI.ConsoleInfo>();
			int num = this.getNumberOfConsoles();
			IntPtr intPtr = Marshal.AllocHGlobal(0x200);
			IntPtr intPtr2 = Marshal.AllocHGlobal(0x200);
			for (int i = 0; i < num; i++)
			{
				PS3Lib.CCAPI.ConsoleInfo consoleInfo = new PS3Lib.CCAPI.ConsoleInfo();
				this.getConsoleInfo(i, intPtr, intPtr2);
				consoleInfo.Name = Marshal.PtrToStringAnsi(intPtr);
				consoleInfo.Ip = Marshal.PtrToStringAnsi(intPtr2);
				list.Add(consoleInfo);
			}
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			return list;
		}

		internal static byte[] StringToByteArray(string hex)
		{
			byte[] result;
			try
			{
				string replace = hex.Replace("0x", "");
				string Stringz = replace.Insert(replace.Length - 1, "0");
				int length = replace.Length;
				bool flag = length % 2 == 0;
				if (flag)
				{
					result = (from x in Enumerable.Range(0, replace.Length)
					where x % 2 == 0
					select Convert.ToByte(replace.Substring(x, 2), 0x10)).ToArray<byte>();
				}
				else
				{
					result = (from x in Enumerable.Range(0, replace.Length)
					where x % 2 == 0
					select Convert.ToByte(Stringz.Substring(x, 2), 0x10)).ToArray<byte>();
				}
			}
			catch
			{
				MessageBox.Show("Incorrect value (empty)", "StringToByteArray Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = new byte[1];
			}
			return result;
		}

		private PS3Lib.CCAPI.connectConsoleDelegate connectConsole;

		private PS3Lib.CCAPI.disconnectConsoleDelegate disconnectConsole;

		private PS3Lib.CCAPI.getConnectionStatusDelegate getConnectionStatus;

		private PS3Lib.CCAPI.getConsoleInfoDelegate getConsoleInfo;

		private PS3Lib.CCAPI.getDllVersionDelegate getDllVersion;

		private PS3Lib.CCAPI.getFirmwareInfoDelegate getFirmwareInfo;

		private PS3Lib.CCAPI.getNumberOfConsolesDelegate getNumberOfConsoles;

		private PS3Lib.CCAPI.getProcessListDelegate getProcessList;

		private PS3Lib.CCAPI.getProcessMemoryDelegate getProcessMemory;

		private PS3Lib.CCAPI.getProcessNameDelegate getProcessName;

		private PS3Lib.CCAPI.getTemperatureDelegate getTemperature;

		private PS3Lib.CCAPI.notifyDelegate notify;

		private PS3Lib.CCAPI.ringBuzzerDelegate ringBuzzer;

		private PS3Lib.CCAPI.setBootConsoleIdsDelegate setBootConsoleIds;

		private PS3Lib.CCAPI.setConsoleIdsDelegate setConsoleIds;

		private PS3Lib.CCAPI.setConsoleLedDelegate setConsoleLed;

		private PS3Lib.CCAPI.setProcessMemoryDelegate setProcessMemory;

		private PS3Lib.CCAPI.shutdownDelegate shutdown;

		private IntPtr libModule = IntPtr.Zero;

		private List<IntPtr> CCAPIFunctionsList = new List<IntPtr>();

		private PS3Lib.CCAPI.TargetInfo pInfo = new PS3Lib.CCAPI.TargetInfo();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int connectConsoleDelegate(string targetIP);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int disconnectConsoleDelegate();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getConnectionStatusDelegate(ref int status);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getConsoleInfoDelegate(int index, IntPtr ptrN, IntPtr ptrI);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getDllVersionDelegate();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getFirmwareInfoDelegate(ref int firmware, ref int ccapi, ref int consoleType);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getNumberOfConsolesDelegate();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getProcessListDelegate(ref uint numberProcesses, IntPtr processIdPtr);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getProcessMemoryDelegate(uint processID, ulong offset, uint size, byte[] buffOut);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getProcessNameDelegate(uint processID, IntPtr strPtr);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getTemperatureDelegate(ref int cell, ref int rsx);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int notifyDelegate(int mode, string msgWChar);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int ringBuzzerDelegate(int type);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setBootConsoleIdsDelegate(int idType, int on, byte[] ID);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setConsoleIdsDelegate(int idType, byte[] consoleID);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setConsoleLedDelegate(int color, int status);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setProcessMemoryDelegate(uint processID, ulong offset, uint size, byte[] buffIn);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int shutdownDelegate(int mode);

		private enum CCAPIFunctions
		{
			ConnectConsole,
			DisconnectConsole,
			GetConnectionStatus,
			GetConsoleInfo,
			GetDllVersion,
			GetFirmwareInfo,
			GetNumberOfConsoles,
			GetProcessList,
			GetMemory,
			GetProcessName,
			GetTemperature,
			VshNotify,
			RingBuzzer,
			SetBootConsoleIds,
			SetConsoleIds,
			SetConsoleLed,
			SetMemory,
			ShutDown
		}

		public enum IdType
		{
			IDPS,
			PSID
		}

		public enum NotifyIcon
		{
			INFO,
			CAUTION,
			FRIEND,
			SLIDER,
			WRONGWAY,
			DIALOG,
			DIALOGSHADOW,
			TEXT,
			POINTER,
			GRAB,
			HAND,
			PEN,
			FINGER,
			ARROW,
			ARROWRIGHT,
			PROGRESS,
			TROPHY1,
			TROPHY2,
			TROPHY3,
			TROPHY4
		}

		public enum ConsoleType
		{
			CEX = 1,
			DEX,
			TOOL
		}

		public enum ProcessType
		{
			VSH,
			SYS_AGENT,
			CURRENTGAME
		}

		public enum RebootFlags
		{
			ShutDown = 1,
			SoftReboot,
			HardReboot
		}

		public enum BuzzerMode
		{
			Continuous,
			Single,
			Double,
			Triple
		}

		public enum LedColor
		{
			Green = 1,
			Red
		}

		public enum LedMode
		{
			Off,
			On,
			Blink
		}

		private class System
		{
			public System()
			{
			}

			// Note: this type is marked as 'beforefieldinit'.
			static System()
			{
			}

			public static int connectionID = -1;

			public static uint processID = 0U;

			public static uint[] processIDs;
		}

		public class TargetInfo
		{
			public TargetInfo()
			{
			}

			public int Firmware = 0;

			public int CCAPI = 0;

			public int ConsoleType = 0;

			public int TempCell = 0;

			public int TempRSX = 0;

			public ulong SysTable = 0UL;
		}

		public class ConsoleInfo
		{
			public ConsoleInfo()
			{
			}

			public string Name;

			public string Ip;
		}

	}
}
