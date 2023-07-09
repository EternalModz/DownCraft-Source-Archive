using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PS3Lib
{
	// Token: 0x02000110 RID: 272
	public class CCAPI
	{
		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000C29 RID: 3113 RVA: 0x0003E620 File Offset: 0x0003C820
		public Extension Extension
		{
			get
			{
				return new Extension(SelectAPI.ControlConsole);
			}
		}

		// Token: 0x06000C2A RID: 3114
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string dllName);

		// Token: 0x06000C2B RID: 3115
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x06000C2C RID: 3116 RVA: 0x0003E638 File Offset: 0x0003C838
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
							this.libModule = CCAPI.LoadLibrary(text2);
						}
						if (this.libModule != IntPtr.Zero)
						{
							this.CCAPIFunctionsList.Clear();
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIConnectConsole"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIDisconnectConsole"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetConnectionStatus"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetConsoleInfo"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetDllVersion"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetFirmwareInfo"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetNumberOfConsoles"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetProcessList"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetMemory"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetProcessName"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIGetTemperature"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIVshNotify"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIRingBuzzer"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPISetBootConsoleIds"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPISetConsoleIds"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPISetConsoleLed"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPISetMemory"));
							this.CCAPIFunctionsList.Add(CCAPI.GetProcAddress(this.libModule, "CCAPIShutdown"));
							if (this.IsCCAPILoaded())
							{
								this.connectConsole = (CCAPI.connectConsoleDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.ConnectConsole), typeof(CCAPI.connectConsoleDelegate));
								this.disconnectConsole = (CCAPI.disconnectConsoleDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.DisconnectConsole), typeof(CCAPI.disconnectConsoleDelegate));
								this.getConnectionStatus = (CCAPI.getConnectionStatusDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetConnectionStatus), typeof(CCAPI.getConnectionStatusDelegate));
								this.getConsoleInfo = (CCAPI.getConsoleInfoDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetConsoleInfo), typeof(CCAPI.getConsoleInfoDelegate));
								this.getDllVersion = (CCAPI.getDllVersionDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetDllVersion), typeof(CCAPI.getDllVersionDelegate));
								this.getFirmwareInfo = (CCAPI.getFirmwareInfoDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetFirmwareInfo), typeof(CCAPI.getFirmwareInfoDelegate));
								this.getNumberOfConsoles = (CCAPI.getNumberOfConsolesDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetNumberOfConsoles), typeof(CCAPI.getNumberOfConsolesDelegate));
								this.getProcessList = (CCAPI.getProcessListDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetProcessList), typeof(CCAPI.getProcessListDelegate));
								this.getProcessMemory = (CCAPI.getProcessMemoryDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetMemory), typeof(CCAPI.getProcessMemoryDelegate));
								this.getProcessName = (CCAPI.getProcessNameDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetProcessName), typeof(CCAPI.getProcessNameDelegate));
								this.getTemperature = (CCAPI.getTemperatureDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.GetTemperature), typeof(CCAPI.getTemperatureDelegate));
								this.notify = (CCAPI.notifyDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.VshNotify), typeof(CCAPI.notifyDelegate));
								this.ringBuzzer = (CCAPI.ringBuzzerDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.RingBuzzer), typeof(CCAPI.ringBuzzerDelegate));
								this.setBootConsoleIds = (CCAPI.setBootConsoleIdsDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.SetBootConsoleIds), typeof(CCAPI.setBootConsoleIdsDelegate));
								this.setConsoleIds = (CCAPI.setConsoleIdsDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.SetConsoleIds), typeof(CCAPI.setConsoleIdsDelegate));
								this.setConsoleLed = (CCAPI.setConsoleLedDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.SetConsoleLed), typeof(CCAPI.setConsoleLedDelegate));
								this.setProcessMemory = (CCAPI.setProcessMemoryDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.SetMemory), typeof(CCAPI.setProcessMemoryDelegate));
								this.shutdown = (CCAPI.shutdownDelegate)Marshal.GetDelegateForFunctionPointer(this.GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions.ShutDown), typeof(CCAPI.shutdownDelegate));
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

		// Token: 0x06000C2D RID: 3117 RVA: 0x0003EBF0 File Offset: 0x0003CDF0
		private IntPtr ReadDataFromUnBufPtr<T>(IntPtr unBuf, ref T storage)
		{
			storage = (T)((object)Marshal.PtrToStructure(unBuf, typeof(T)));
			return new IntPtr(unBuf.ToInt64() + (long)Marshal.SizeOf(storage));
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x0003EC3C File Offset: 0x0003CE3C
		private IntPtr GetCCAPIFunctionPtr(CCAPI.CCAPIFunctions Function)
		{
			return this.CCAPIFunctionsList.ElementAt((int)Function);
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0003EC5C File Offset: 0x0003CE5C
		private bool IsCCAPILoaded()
		{
			bool flag;
			bool result;
			for (int i = 0; i < this.CCAPIFunctionsList.Count; i++)
			{
				if (this.CCAPIFunctionsList.ElementAt(i) == IntPtr.Zero)
				{
					flag = false;
					result = flag;
					return result;
				}
			}
			flag = true;
			result = flag;
			return result;
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0003ECB1 File Offset: 0x0003CEB1
		private void CompleteInfo(ref CCAPI.TargetInfo Info, int fw, int ccapi, ulong sysTable, int consoleType, int tempCELL, int tempRSX)
		{
			Info.Firmware = fw;
			Info.CCAPI = ccapi;
			Info.SysTable = sysTable;
			Info.ConsoleType = consoleType;
			Info.TempCell = tempCELL;
			Info.TempRSX = tempRSX;
		}

		// Token: 0x06000C31 RID: 3121 RVA: 0x0003ECE8 File Offset: 0x0003CEE8
		public bool SUCCESS(int Void)
		{
			return Void == 0;
		}

		// Token: 0x06000C32 RID: 3122 RVA: 0x0003ED00 File Offset: 0x0003CF00
		public bool ConnectTarget()
		{
			return new PS3API.ConsoleList(new PS3API(SelectAPI.ControlConsole)).Show();
		}

		// Token: 0x06000C33 RID: 3123 RVA: 0x0003ED24 File Offset: 0x0003CF24
		public int ConnectTarget(string targetIP)
		{
			return this.connectConsole(targetIP);
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x0003ED44 File Offset: 0x0003CF44
		public int GetConnectionStatus()
		{
			int result = 0;
			this.getConnectionStatus(ref result);
			return result;
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x0003ED68 File Offset: 0x0003CF68
		public int DisconnectTarget()
		{
			return this.disconnectConsole();
		}

		// Token: 0x06000C36 RID: 3126 RVA: 0x0003ED88 File Offset: 0x0003CF88
		public int AttachProcess()
		{
			CCAPI.System.processID = 0u;
			int num = this.GetProcessList(out CCAPI.System.processIDs);
			if (this.SUCCESS(num) && CCAPI.System.processIDs.Length > 0)
			{
				for (int i = 0; i < CCAPI.System.processIDs.Length; i++)
				{
					string empty = string.Empty;
					num = this.GetProcessName(CCAPI.System.processIDs[i], out empty);
					if (!this.SUCCESS(num))
					{
						break;
					}
					if (!empty.Contains("flash"))
					{
						CCAPI.System.processID = CCAPI.System.processIDs[i];
						break;
					}
					num = -1;
				}
				if (CCAPI.System.processID == 0u)
				{
					CCAPI.System.processID = CCAPI.System.processIDs[CCAPI.System.processIDs.Length - 1];
				}
			}
			else
			{
				num = -1;
			}
			return num;
		}

        

        // Token: 0x06000C37 RID: 3127 RVA: 0x0003EE64 File Offset: 0x0003D064
        public int AttachProcess(CCAPI.ProcessType procType)
		{
			CCAPI.System.processID = 0u;
			int num = this.GetProcessList(out CCAPI.System.processIDs);
			if (num >= 0 && CCAPI.System.processIDs.Length > 0)
			{
				for (int i = 0; i < CCAPI.System.processIDs.Length; i++)
				{
					string empty = string.Empty;
					num = this.GetProcessName(CCAPI.System.processIDs[i], out empty);
					if (num < 0)
					{
						break;
					}
					if (procType == CCAPI.ProcessType.VSH && empty.Contains("vsh"))
					{
						CCAPI.System.processID = CCAPI.System.processIDs[i];
						break;
					}
					if (procType == CCAPI.ProcessType.SYS_AGENT && empty.Contains("agent"))
					{
						CCAPI.System.processID = CCAPI.System.processIDs[i];
						break;
					}
					if (procType == CCAPI.ProcessType.CURRENTGAME && !empty.Contains("flash"))
					{
						CCAPI.System.processID = CCAPI.System.processIDs[i];
						break;
					}
				}
				if (CCAPI.System.processID == 0u)
				{
					CCAPI.System.processID = CCAPI.System.processIDs[CCAPI.System.processIDs.Length - 1];
				}
			}
			else
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x06000C38 RID: 3128 RVA: 0x0003EF9C File Offset: 0x0003D19C
		public int AttachProcess(uint process)
		{
			uint[] array = new uint[64];
			int num = this.GetProcessList(out array);
			if (this.SUCCESS(num))
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == process)
					{
						num = 0;
						CCAPI.System.processID = process;
						break;
					}
					num = -1;
				}
			}
			array = null;
			return num;
		}

		// Token: 0x06000C39 RID: 3129 RVA: 0x0003F008 File Offset: 0x0003D208
		public int GetProcessList(out uint[] processIds)
		{
			uint num = 64u;
			IntPtr intPtr = Marshal.AllocHGlobal(256);
			int num2 = this.getProcessList(ref num, intPtr);
			processIds = new uint[num];
			if (this.SUCCESS(num2))
			{
				IntPtr unBuf = intPtr;
				for (uint num3 = 0u; num3 < num; num3 += 1u)
				{
					unBuf = this.ReadDataFromUnBufPtr<uint>(unBuf, ref processIds[(int)((uint)((UIntPtr)num3))]);
				}
			}
			Marshal.FreeHGlobal(intPtr);
			return num2;
		}

		// Token: 0x06000C3A RID: 3130 RVA: 0x0003F094 File Offset: 0x0003D294
		public int GetProcessName(uint processId, out string name)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(529);
			int num = this.getProcessName(processId, intPtr);
			name = string.Empty;
			if (this.SUCCESS(num))
			{
				name = Marshal.PtrToStringAnsi(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x06000C3B RID: 3131 RVA: 0x0003F0E8 File Offset: 0x0003D2E8
		public uint GetAttachedProcess()
		{
			return CCAPI.System.processID;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x0003F100 File Offset: 0x0003D300
		public int SetMemory(uint offset, byte[] buffer)
		{
			return this.setProcessMemory(CCAPI.System.processID, (ulong)offset, (uint)buffer.Length, buffer);
		}

		// Token: 0x06000C3D RID: 3133 RVA: 0x0003F128 File Offset: 0x0003D328
		public int SetMemory(ulong offset, byte[] buffer)
		{
			return this.setProcessMemory(CCAPI.System.processID, offset, (uint)buffer.Length, buffer);
		}

		// Token: 0x06000C3E RID: 3134 RVA: 0x0003F150 File Offset: 0x0003D350
		public int SetMemory(ulong offset, string hexadecimal, EndianType Type = EndianType.BigEndian)
		{
			byte[] array = CCAPI.StringToByteArray(hexadecimal);
			if (Type == EndianType.LittleEndian)
			{
				Array.Reverse(array);
			}
			return this.setProcessMemory(CCAPI.System.processID, offset, (uint)array.Length, array);
		}

		// Token: 0x06000C3F RID: 3135 RVA: 0x0003F194 File Offset: 0x0003D394
		public int GetMemory(uint offset, byte[] buffer)
		{
			return this.getProcessMemory(CCAPI.System.processID, (ulong)offset, (uint)buffer.Length, buffer);
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x0003F1BC File Offset: 0x0003D3BC
		public int GetMemory(ulong offset, byte[] buffer)
		{
			return this.getProcessMemory(CCAPI.System.processID, offset, (uint)buffer.Length, buffer);
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x0003F1E4 File Offset: 0x0003D3E4
		public byte[] GetBytes(uint offset, uint length)
		{
			byte[] array = new byte[length];
			this.GetMemory(offset, array);
			return array;
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x0003F208 File Offset: 0x0003D408
		public byte[] GetBytes(ulong offset, uint length)
		{
			byte[] array = new byte[length];
			this.GetMemory(offset, array);
			return array;
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x0003F22C File Offset: 0x0003D42C
		public int Notify(CCAPI.NotifyIcon icon, string message)
		{
			return this.notify((int)icon, message);
		}

		// Token: 0x06000C44 RID: 3140 RVA: 0x0003F24C File Offset: 0x0003D44C
		public int Notify(int icon, string message)
		{
			return this.notify(icon, message);
		}

		// Token: 0x06000C45 RID: 3141 RVA: 0x0003F26C File Offset: 0x0003D46C
		public int ShutDown(CCAPI.RebootFlags flag)
		{
			return this.shutdown((int)flag);
		}

		// Token: 0x06000C46 RID: 3142 RVA: 0x0003F28C File Offset: 0x0003D48C
		public int RingBuzzer(CCAPI.BuzzerMode flag)
		{
			return this.ringBuzzer((int)flag);
		}

		// Token: 0x06000C47 RID: 3143 RVA: 0x0003F2AC File Offset: 0x0003D4AC
		public int SetConsoleLed(CCAPI.LedColor color, CCAPI.LedMode mode)
		{
			return this.setConsoleLed((int)color, (int)mode);
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0003F2CC File Offset: 0x0003D4CC
		private int GetTargetInfo()
		{
			int[] array = new int[2];
			int fw = 0;
			int ccapi = 0;
			int consoleType = 0;
			ulong sysTable = 0uL;
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

		// Token: 0x06000C49 RID: 3145 RVA: 0x0003F354 File Offset: 0x0003D554
		public int GetTargetInfo(out CCAPI.TargetInfo Info)
		{
			Info = new CCAPI.TargetInfo();
			int[] array = new int[2];
			int fw = 0;
			int ccapi = 0;
			int consoleType = 0;
			ulong sysTable = 0uL;
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

		// Token: 0x06000C4A RID: 3146 RVA: 0x0003F3F8 File Offset: 0x0003D5F8
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

		// Token: 0x06000C4B RID: 3147 RVA: 0x0003F470 File Offset: 0x0003D670
		public string GetTemperatureCELL()
		{
			if (this.pInfo.TempCell == 0)
			{
				this.GetTargetInfo(out this.pInfo);
			}
			return this.pInfo.TempCell.ToString() + " C";
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0003F4C0 File Offset: 0x0003D6C0
		public string GetTemperatureRSX()
		{
			if (this.pInfo.TempRSX == 0)
			{
				this.GetTargetInfo(out this.pInfo);
			}
			return this.pInfo.TempRSX.ToString() + " C";
		}

		// Token: 0x06000C4D RID: 3149 RVA: 0x0003F510 File Offset: 0x0003D710
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

		// Token: 0x06000C4E RID: 3150 RVA: 0x0003F5A8 File Offset: 0x0003D7A8
		public void ClearTargetInfo()
		{
			this.pInfo = new CCAPI.TargetInfo();
		}

		// Token: 0x06000C4F RID: 3151 RVA: 0x0003F5B8 File Offset: 0x0003D7B8
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
				if (consoleID.Length >= 32)
				{
					hex = consoleID.Substring(0, 32);
				}
				result = this.SetConsoleID(CCAPI.StringToByteArray(hex));
			}
			return result;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0003F620 File Offset: 0x0003D820
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

		// Token: 0x06000C51 RID: 3153 RVA: 0x0003F668 File Offset: 0x0003D868
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
				if (PSID.Length >= 32)
				{
					hex = PSID.Substring(0, 32);
				}
				result = this.SetPSID(CCAPI.StringToByteArray(hex));
			}
			return result;
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x0003F6D0 File Offset: 0x0003D8D0
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

		// Token: 0x06000C53 RID: 3155 RVA: 0x0003F718 File Offset: 0x0003D918
		public int SetBootConsoleID(string consoleID, CCAPI.IdType Type = CCAPI.IdType.IDPS)
		{
			string text = string.Empty;
			if (consoleID.Length >= 32)
			{
				text = consoleID.Substring(0, 32);
			}
			return this.SetBootConsoleID(CCAPI.StringToByteArray(consoleID), Type);
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x0003F758 File Offset: 0x0003D958
		public int SetBootConsoleID(byte[] consoleID, CCAPI.IdType Type = CCAPI.IdType.IDPS)
		{
			return this.setBootConsoleIds((int)Type, 1, consoleID);
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x0003F778 File Offset: 0x0003D978
		public int ResetBootConsoleID(CCAPI.IdType Type = CCAPI.IdType.IDPS)
		{
			return this.setBootConsoleIds((int)Type, 0, null);
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0003F798 File Offset: 0x0003D998
		public int GetDllVersion()
		{
			return this.getDllVersion();
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x0003F7B8 File Offset: 0x0003D9B8
		public List<CCAPI.ConsoleInfo> GetConsoleList()
		{
			List<CCAPI.ConsoleInfo> list = new List<CCAPI.ConsoleInfo>();
			int num = this.getNumberOfConsoles();
			IntPtr intPtr = Marshal.AllocHGlobal(512);
			IntPtr intPtr2 = Marshal.AllocHGlobal(512);
			for (int i = 0; i < num; i++)
			{
				CCAPI.ConsoleInfo consoleInfo = new CCAPI.ConsoleInfo();
				this.getConsoleInfo(i, intPtr, intPtr2);
				consoleInfo.Name = Marshal.PtrToStringAnsi(intPtr);
				consoleInfo.Ip = Marshal.PtrToStringAnsi(intPtr2);
				list.Add(consoleInfo);
			}
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			return list;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x0003F8E0 File Offset: 0x0003DAE0
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
					select Convert.ToByte(replace.Substring(x, 2), 16)).ToArray<byte>();
				}
				else
				{
					result = (from x in Enumerable.Range(0, replace.Length)
					where x % 2 == 0
					select Convert.ToByte(Stringz.Substring(x, 2), 16)).ToArray<byte>();
				}
			}
			catch
			{
				MessageBox.Show("Incorrect value (empty)", "StringToByteArray Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = new byte[1];
			}
			return result;
		}

		// Token: 0x040004C5 RID: 1221
		private CCAPI.connectConsoleDelegate connectConsole;

		// Token: 0x040004C6 RID: 1222
		private CCAPI.disconnectConsoleDelegate disconnectConsole;

		// Token: 0x040004C7 RID: 1223
		private CCAPI.getConnectionStatusDelegate getConnectionStatus;

		// Token: 0x040004C8 RID: 1224
		private CCAPI.getConsoleInfoDelegate getConsoleInfo;

		// Token: 0x040004C9 RID: 1225
		private CCAPI.getDllVersionDelegate getDllVersion;

		// Token: 0x040004CA RID: 1226
		private CCAPI.getFirmwareInfoDelegate getFirmwareInfo;

		// Token: 0x040004CB RID: 1227
		private CCAPI.getNumberOfConsolesDelegate getNumberOfConsoles;

		// Token: 0x040004CC RID: 1228
		private CCAPI.getProcessListDelegate getProcessList;

		// Token: 0x040004CD RID: 1229
		private CCAPI.getProcessMemoryDelegate getProcessMemory;

		// Token: 0x040004CE RID: 1230
		private CCAPI.getProcessNameDelegate getProcessName;

		// Token: 0x040004CF RID: 1231
		private CCAPI.getTemperatureDelegate getTemperature;

		// Token: 0x040004D0 RID: 1232
		private CCAPI.notifyDelegate notify;

		// Token: 0x040004D1 RID: 1233
		private CCAPI.ringBuzzerDelegate ringBuzzer;

		// Token: 0x040004D2 RID: 1234
		private CCAPI.setBootConsoleIdsDelegate setBootConsoleIds;

		// Token: 0x040004D3 RID: 1235
		private CCAPI.setConsoleIdsDelegate setConsoleIds;

		// Token: 0x040004D4 RID: 1236
		private CCAPI.setConsoleLedDelegate setConsoleLed;

		// Token: 0x040004D5 RID: 1237
		private CCAPI.setProcessMemoryDelegate setProcessMemory;

		// Token: 0x040004D6 RID: 1238
		private CCAPI.shutdownDelegate shutdown;

		// Token: 0x040004D7 RID: 1239
		private IntPtr libModule = IntPtr.Zero;

		// Token: 0x040004D8 RID: 1240
		private List<IntPtr> CCAPIFunctionsList = new List<IntPtr>();

		// Token: 0x040004D9 RID: 1241
		private CCAPI.TargetInfo pInfo = new CCAPI.TargetInfo();

		// Token: 0x02000111 RID: 273
		// (Invoke) Token: 0x06000C5C RID: 3164
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int connectConsoleDelegate(string targetIP);

		// Token: 0x02000112 RID: 274
		// (Invoke) Token: 0x06000C60 RID: 3168
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int disconnectConsoleDelegate();

		// Token: 0x02000113 RID: 275
		// (Invoke) Token: 0x06000C64 RID: 3172
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getConnectionStatusDelegate(ref int status);

		// Token: 0x02000114 RID: 276
		// (Invoke) Token: 0x06000C68 RID: 3176
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getConsoleInfoDelegate(int index, IntPtr ptrN, IntPtr ptrI);

		// Token: 0x02000115 RID: 277
		// (Invoke) Token: 0x06000C6C RID: 3180
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getDllVersionDelegate();

		// Token: 0x02000116 RID: 278
		// (Invoke) Token: 0x06000C70 RID: 3184
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getFirmwareInfoDelegate(ref int firmware, ref int ccapi, ref int consoleType);

		// Token: 0x02000117 RID: 279
		// (Invoke) Token: 0x06000C74 RID: 3188
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getNumberOfConsolesDelegate();

		// Token: 0x02000118 RID: 280
		// (Invoke) Token: 0x06000C78 RID: 3192
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getProcessListDelegate(ref uint numberProcesses, IntPtr processIdPtr);

		// Token: 0x02000119 RID: 281
		// (Invoke) Token: 0x06000C7C RID: 3196
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getProcessMemoryDelegate(uint processID, ulong offset, uint size, byte[] buffOut);

		// Token: 0x0200011A RID: 282
		// (Invoke) Token: 0x06000C80 RID: 3200
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getProcessNameDelegate(uint processID, IntPtr strPtr);

		// Token: 0x0200011B RID: 283
		// (Invoke) Token: 0x06000C84 RID: 3204
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int getTemperatureDelegate(ref int cell, ref int rsx);

		// Token: 0x0200011C RID: 284
		// (Invoke) Token: 0x06000C88 RID: 3208
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int notifyDelegate(int mode, string msgWChar);

		// Token: 0x0200011D RID: 285
		// (Invoke) Token: 0x06000C8C RID: 3212
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int ringBuzzerDelegate(int type);

		// Token: 0x0200011E RID: 286
		// (Invoke) Token: 0x06000C90 RID: 3216
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setBootConsoleIdsDelegate(int idType, int on, byte[] ID);

		// Token: 0x0200011F RID: 287
		// (Invoke) Token: 0x06000C94 RID: 3220
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setConsoleIdsDelegate(int idType, byte[] consoleID);

		// Token: 0x02000120 RID: 288
		// (Invoke) Token: 0x06000C98 RID: 3224
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setConsoleLedDelegate(int color, int status);

		// Token: 0x02000121 RID: 289
		// (Invoke) Token: 0x06000C9C RID: 3228
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int setProcessMemoryDelegate(uint processID, ulong offset, uint size, byte[] buffIn);

		// Token: 0x02000122 RID: 290
		// (Invoke) Token: 0x06000CA0 RID: 3232
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int shutdownDelegate(int mode);

		// Token: 0x02000123 RID: 291
		private enum CCAPIFunctions
		{
			// Token: 0x040004DD RID: 1245
			ConnectConsole,
			// Token: 0x040004DE RID: 1246
			DisconnectConsole,
			// Token: 0x040004DF RID: 1247
			GetConnectionStatus,
			// Token: 0x040004E0 RID: 1248
			GetConsoleInfo,
			// Token: 0x040004E1 RID: 1249
			GetDllVersion,
			// Token: 0x040004E2 RID: 1250
			GetFirmwareInfo,
			// Token: 0x040004E3 RID: 1251
			GetNumberOfConsoles,
			// Token: 0x040004E4 RID: 1252
			GetProcessList,
			// Token: 0x040004E5 RID: 1253
			GetMemory,
			// Token: 0x040004E6 RID: 1254
			GetProcessName,
			// Token: 0x040004E7 RID: 1255
			GetTemperature,
			// Token: 0x040004E8 RID: 1256
			VshNotify,
			// Token: 0x040004E9 RID: 1257
			RingBuzzer,
			// Token: 0x040004EA RID: 1258
			SetBootConsoleIds,
			// Token: 0x040004EB RID: 1259
			SetConsoleIds,
			// Token: 0x040004EC RID: 1260
			SetConsoleLed,
			// Token: 0x040004ED RID: 1261
			SetMemory,
			// Token: 0x040004EE RID: 1262
			ShutDown
		}

		// Token: 0x02000124 RID: 292
		public enum IdType
		{
			// Token: 0x040004F0 RID: 1264
			IDPS,
			// Token: 0x040004F1 RID: 1265
			PSID
		}

		// Token: 0x02000125 RID: 293
		public enum NotifyIcon
		{
			// Token: 0x040004F3 RID: 1267
			INFO,
			// Token: 0x040004F4 RID: 1268
			CAUTION,
			// Token: 0x040004F5 RID: 1269
			FRIEND,
			// Token: 0x040004F6 RID: 1270
			SLIDER,
			// Token: 0x040004F7 RID: 1271
			WRONGWAY,
			// Token: 0x040004F8 RID: 1272
			DIALOG,
			// Token: 0x040004F9 RID: 1273
			DIALOGSHADOW,
			// Token: 0x040004FA RID: 1274
			TEXT,
			// Token: 0x040004FB RID: 1275
			POINTER,
			// Token: 0x040004FC RID: 1276
			GRAB,
			// Token: 0x040004FD RID: 1277
			HAND,
			// Token: 0x040004FE RID: 1278
			PEN,
			// Token: 0x040004FF RID: 1279
			FINGER,
			// Token: 0x04000500 RID: 1280
			ARROW,
			// Token: 0x04000501 RID: 1281
			ARROWRIGHT,
			// Token: 0x04000502 RID: 1282
			PROGRESS,
			// Token: 0x04000503 RID: 1283
			TROPHY1,
			// Token: 0x04000504 RID: 1284
			TROPHY2,
			// Token: 0x04000505 RID: 1285
			TROPHY3,
			// Token: 0x04000506 RID: 1286
			TROPHY4
		}

		// Token: 0x02000126 RID: 294
		public enum ConsoleType
		{
			// Token: 0x04000508 RID: 1288
			CEX = 1,
			// Token: 0x04000509 RID: 1289
			DEX,
			// Token: 0x0400050A RID: 1290
			TOOL
		}

		// Token: 0x02000127 RID: 295
		public enum ProcessType
		{
			// Token: 0x0400050C RID: 1292
			VSH,
			// Token: 0x0400050D RID: 1293
			SYS_AGENT,
			// Token: 0x0400050E RID: 1294
			CURRENTGAME
		}

		// Token: 0x02000128 RID: 296
		public enum RebootFlags
		{
			// Token: 0x04000510 RID: 1296
			ShutDown = 1,
			// Token: 0x04000511 RID: 1297
			SoftReboot,
			// Token: 0x04000512 RID: 1298
			HardReboot
		}

		// Token: 0x02000129 RID: 297
		public enum BuzzerMode
		{
			// Token: 0x04000514 RID: 1300
			Continuous,
			// Token: 0x04000515 RID: 1301
			Single,
			// Token: 0x04000516 RID: 1302
			Double,
			// Token: 0x04000517 RID: 1303
			Triple
		}

		// Token: 0x0200012A RID: 298
		public enum LedColor
		{
			// Token: 0x04000519 RID: 1305
			Green = 1,
			// Token: 0x0400051A RID: 1306
			Red
		}

		// Token: 0x0200012B RID: 299
		public enum LedMode
		{
			// Token: 0x0400051C RID: 1308
			Off,
			// Token: 0x0400051D RID: 1309
			On,
			// Token: 0x0400051E RID: 1310
			Blink
		}

		// Token: 0x0200012C RID: 300
		private class System
		{
			// Token: 0x0400051F RID: 1311
			public static int connectionID = -1;

			// Token: 0x04000520 RID: 1312
			public static uint processID = 0u;

			// Token: 0x04000521 RID: 1313
			public static uint[] processIDs;
		}

		// Token: 0x0200012D RID: 301
		public class TargetInfo
		{
			// Token: 0x04000522 RID: 1314
			public int Firmware = 0;

			// Token: 0x04000523 RID: 1315
			public int CCAPI = 0;

			// Token: 0x04000524 RID: 1316
			public int ConsoleType = 0;

			// Token: 0x04000525 RID: 1317
			public int TempCell = 0;

			// Token: 0x04000526 RID: 1318
			public int TempRSX = 0;

			// Token: 0x04000527 RID: 1319
			public ulong SysTable = 0uL;
		}

		// Token: 0x0200012E RID: 302
		public class ConsoleInfo
		{
			// Token: 0x04000528 RID: 1320
			public string Name;

			// Token: 0x04000529 RID: 1321
			public string Ip;
		}
	}
}
