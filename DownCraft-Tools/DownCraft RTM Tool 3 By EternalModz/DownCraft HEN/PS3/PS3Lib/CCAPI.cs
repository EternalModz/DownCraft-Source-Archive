using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PS3ManagerAPI;

namespace PS3Lib
{
	// Token: 0x02000006 RID: 6
	public class CCAPI
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000020FD File Offset: 0x000002FD
		public CCAPI()
		{
			new PS3MAPI();
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002116 File Offset: 0x00000316
		public Extension Extension
		{
			get
			{
				return new Extension(SelectAPI.ControlConsole);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000211E File Offset: 0x0000031E
		private void CompleteInfo(ref CCAPI.TargetInfo Info, int fw, int ccapi, ulong sysTable, int consoleType, int tempCELL, int tempRSX)
		{
			Info.Firmware = fw;
			Info.CCAPI = ccapi;
			Info.SysTable = sysTable;
			Info.ConsoleType = consoleType;
			Info.TempCell = tempCELL;
			Info.TempRSX = tempRSX;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002154 File Offset: 0x00000354
		public bool SUCCESS(int Void)
		{
			return Void == 0;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000215C File Offset: 0x0000035C
		public bool ConnectTarget()
		{
			return CCAPI.PS3M_API.ConnectTarget();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002168 File Offset: 0x00000368
		public int ConnectTarget(string targetIP)
		{
			if (CCAPI.PS3M_API.ConnectTarget(targetIP, 7887))
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000217F File Offset: 0x0000037F
		public int GetConnectionStatus()
		{
			if (CCAPI.PS3M_API.IsConnected)
			{
				return 0;
			}
			return -1;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002190 File Offset: 0x00000390
		public int DisconnectTarget()
		{
			CCAPI.PS3M_API.DisconnectTarget();
			return 0;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000219D File Offset: 0x0000039D
		public int AttachProcess()
		{
			if (CCAPI.PS3M_API.AttachProcess())
			{
				CCAPI.System.processIDs = CCAPI.PS3M_API.Process.Processes_Pid;
				CCAPI.System.processID = CCAPI.PS3M_API.Process.Process_Pid;
				return 0;
			}
			return -1;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000219D File Offset: 0x0000039D
		public int AttachProcess(CCAPI.ProcessType procType)
		{
			if (CCAPI.PS3M_API.AttachProcess())
			{
				CCAPI.System.processIDs = CCAPI.PS3M_API.Process.Processes_Pid;
				CCAPI.System.processID = CCAPI.PS3M_API.Process.Process_Pid;
				return 0;
			}
			return -1;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000021D6 File Offset: 0x000003D6
		public int AttachProcess(uint process)
		{
			if (CCAPI.PS3M_API.AttachProcess(process))
			{
				CCAPI.System.processID = CCAPI.PS3M_API.Process.Process_Pid;
				return 0;
			}
			return -1;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002DF4 File Offset: 0x00000FF4
		public int GetProcessList(out uint[] processIds)
		{
			processIds = new uint[16];
			int result;
			try
			{
				processIds = CCAPI.PS3M_API.Process.GetPidProcesses();
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E38 File Offset: 0x00001038
		public int GetProcessName(uint processId, out string name)
		{
			name = "";
			int result;
			try
			{
				name = CCAPI.PS3M_API.Process.GetName(processId);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000021FC File Offset: 0x000003FC
		public uint GetAttachedProcess()
		{
			return CCAPI.System.processID;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002E78 File Offset: 0x00001078
		public int SetMemory(uint offset, byte[] buffer)
		{
			int result;
			try
			{
				CCAPI.PS3M_API.Process.Memory.Set(this.GetAttachedProcess(), (ulong)offset, buffer);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002EBC File Offset: 0x000010BC
		public int SetMemory(ulong offset, byte[] buffer)
		{
			int result;
			try
			{
				CCAPI.PS3M_API.Process.Memory.Set(this.GetAttachedProcess(), offset, buffer);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002F00 File Offset: 0x00001100
		public int SetMemory(ulong offset, string hexadecimal, EndianType Type = EndianType.BigEndian)
		{
			byte[] array = CCAPI.StringToByteArray(hexadecimal);
			if (Type == EndianType.LittleEndian)
			{
				Array.Reverse(array);
			}
			int result;
			try
			{
				CCAPI.PS3M_API.Process.Memory.Set(this.GetAttachedProcess(), offset, array);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002F54 File Offset: 0x00001154
		public int GetMemory(uint offset, byte[] buffer)
		{
			int result;
			try
			{
				CCAPI.PS3M_API.Process.Memory.Get(this.GetAttachedProcess(), (ulong)offset, buffer);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002F98 File Offset: 0x00001198
		public int GetMemory(ulong offset, byte[] buffer)
		{
			int result;
			try
			{
				CCAPI.PS3M_API.Process.Memory.Get(this.GetAttachedProcess(), offset, buffer);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002FDC File Offset: 0x000011DC
		public byte[] GetBytes(uint offset, uint length)
		{
			byte[] array = new byte[length];
			CCAPI.PS3M_API.Process.Memory.Get(this.GetAttachedProcess(), (ulong)offset, array);
			return array;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003010 File Offset: 0x00001210
		public byte[] GetBytes(ulong offset, uint length)
		{
			byte[] array = new byte[length];
			CCAPI.PS3M_API.Process.Memory.Get(this.GetAttachedProcess(), offset, array);
			return array;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003044 File Offset: 0x00001244
		public int Notify(CCAPI.NotifyIcon icon, string message)
		{
			int result;
			try
			{
				CCAPI.PS3M_API.PS3.Notify(message);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003044 File Offset: 0x00001244
		public int Notify(int icon, string message)
		{
			int result;
			try
			{
				CCAPI.PS3M_API.PS3.Notify(message);
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0000307C File Offset: 0x0000127C
		public int ShutDown(CCAPI.RebootFlags flag)
		{
			if (flag == CCAPI.RebootFlags.ShutDown)
			{
				try
				{
					CCAPI.PS3M_API.PS3.Power(PS3MAPI.PS3_CMD.PowerFlags.ShutDown);
					return 0;
				}
				catch
				{
					return -1;
				}
			}
			if (flag == CCAPI.RebootFlags.SoftReboot)
			{
				try
				{
					CCAPI.PS3M_API.PS3.Power(PS3MAPI.PS3_CMD.PowerFlags.SoftReboot);
					return 0;
				}
				catch
				{
					return -1;
				}
			}
			if (flag == CCAPI.RebootFlags.HardReboot)
			{
				try
				{
					CCAPI.PS3M_API.PS3.Power(PS3MAPI.PS3_CMD.PowerFlags.HardReboot);
					return 0;
				}
				catch
				{
					return -1;
				}
			}
			return -1;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000310C File Offset: 0x0000130C
		public int RingBuzzer(CCAPI.BuzzerMode flag)
		{
			if (flag == CCAPI.BuzzerMode.Single)
			{
				try
				{
					CCAPI.PS3M_API.PS3.RingBuzzer(PS3MAPI.PS3_CMD.BuzzerMode.Single);
					return 0;
				}
				catch
				{
					return -1;
				}
			}
			if (flag == CCAPI.BuzzerMode.Double)
			{
				try
				{
					CCAPI.PS3M_API.PS3.RingBuzzer(PS3MAPI.PS3_CMD.BuzzerMode.Double);
					return 0;
				}
				catch
				{
					return -1;
				}
			}
			if (flag == CCAPI.BuzzerMode.Continuous)
			{
				try
				{
					CCAPI.PS3M_API.PS3.RingBuzzer(PS3MAPI.PS3_CMD.BuzzerMode.Triple);
					return 0;
				}
				catch
				{
					return -1;
				}
			}
			return -1;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x0000319C File Offset: 0x0000139C
		public int SetConsoleLed(CCAPI.LedColor color, CCAPI.LedMode mode)
		{
			int result;
			try
			{
				if (color == CCAPI.LedColor.Red && mode == CCAPI.LedMode.Off)
				{
					CCAPI.PS3M_API.PS3.Led(PS3MAPI.PS3_CMD.LedColor.Red, PS3MAPI.PS3_CMD.LedMode.Off);
				}
				else if (color == CCAPI.LedColor.Red && mode == CCAPI.LedMode.On)
				{
					CCAPI.PS3M_API.PS3.Led(PS3MAPI.PS3_CMD.LedColor.Red, PS3MAPI.PS3_CMD.LedMode.On);
				}
				else if (color == CCAPI.LedColor.Red && mode == CCAPI.LedMode.Blink)
				{
					CCAPI.PS3M_API.PS3.Led(PS3MAPI.PS3_CMD.LedColor.Red, PS3MAPI.PS3_CMD.LedMode.BlinkFast);
				}
				else if (color == CCAPI.LedColor.Green && mode == CCAPI.LedMode.Off)
				{
					CCAPI.PS3M_API.PS3.Led(PS3MAPI.PS3_CMD.LedColor.Green, PS3MAPI.PS3_CMD.LedMode.Off);
				}
				else if (color == CCAPI.LedColor.Green && mode == CCAPI.LedMode.On)
				{
					CCAPI.PS3M_API.PS3.Led(PS3MAPI.PS3_CMD.LedColor.Green, PS3MAPI.PS3_CMD.LedMode.On);
				}
				else if (color == CCAPI.LedColor.Green && mode == CCAPI.LedMode.Blink)
				{
					CCAPI.PS3M_API.PS3.Led(PS3MAPI.PS3_CMD.LedColor.Green, PS3MAPI.PS3_CMD.LedMode.BlinkFast);
				}
				result = 1;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003264 File Offset: 0x00001464
		private int GetTargetInfo()
		{
			int result;
			try
			{
				uint[] array = new uint[2];
				int consoleType = 0;
				ulong sysTable = 0UL;
				int fw = Convert.ToInt32(CCAPI.PS3M_API.PS3.GetFirmwareVersion());
				int ccapi = Convert.ToInt32(CCAPI.PS3M_API.Core.GetVersion());
				string firmwareType = CCAPI.PS3M_API.PS3.GetFirmwareType();
				if (firmwareType.Contains("CEX"))
				{
					consoleType = 1;
				}
				else if (firmwareType.Contains("DEX"))
				{
					consoleType = 2;
				}
				else if (firmwareType.Contains("TOOL"))
				{
					consoleType = 3;
				}
				CCAPI.PS3M_API.PS3.GetTemperature(out array[0], out array[1]);
				this.CompleteInfo(ref this.pInfo, fw, ccapi, sysTable, consoleType, Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000334C File Offset: 0x0000154C
		public int GetTargetInfo(out CCAPI.TargetInfo Info)
		{
			Info = new CCAPI.TargetInfo();
			int result;
			try
			{
				uint[] array = new uint[2];
				int consoleType = 0;
				ulong sysTable = 0UL;
				int fw = Convert.ToInt32(CCAPI.PS3M_API.PS3.GetFirmwareVersion());
				int ccapi = Convert.ToInt32(CCAPI.PS3M_API.Core.GetVersion());
				string firmwareType = CCAPI.PS3M_API.PS3.GetFirmwareType();
				if (firmwareType.Contains("CEX"))
				{
					consoleType = 1;
				}
				else if (firmwareType.Contains("DEX"))
				{
					consoleType = 2;
				}
				else if (firmwareType.Contains("TOOL"))
				{
					consoleType = 3;
				}
				CCAPI.PS3M_API.PS3.GetTemperature(out array[0], out array[1]);
				this.CompleteInfo(ref Info, fw, ccapi, sysTable, consoleType, Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
				this.CompleteInfo(ref this.pInfo, fw, ccapi, sysTable, consoleType, Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
				result = 0;
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002203 File Offset: 0x00000403
		public string GetFirmwareVersion()
		{
			return CCAPI.PS3M_API.PS3.GetFirmwareVersion_Str();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002214 File Offset: 0x00000414
		public string GetTemperatureCELL()
		{
			if (this.pInfo.TempCell == 0)
			{
				this.GetTargetInfo(out this.pInfo);
			}
			return this.pInfo.TempCell.ToString() + " C";
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0000224A File Offset: 0x0000044A
		public string GetTemperatureRSX()
		{
			if (this.pInfo.TempRSX == 0)
			{
				this.GetTargetInfo(out this.pInfo);
			}
			return this.pInfo.TempRSX.ToString() + " C";
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002280 File Offset: 0x00000480
		public string GetFirmwareType()
		{
			return CCAPI.PS3M_API.PS3.GetFirmwareType();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002291 File Offset: 0x00000491
		public void ClearTargetInfo()
		{
			this.pInfo = new CCAPI.TargetInfo();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003458 File Offset: 0x00001658
		public int SetConsoleID(string consoleID)
		{
			if (consoleID.Length < 32)
			{
				MessageBox.Show("Invalid ConsoleID", "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return -1;
			}
			int result;
			try
			{
				string idps = "";
				if (consoleID.Length > 32)
				{
					idps = consoleID.Substring(0, 32);
				}
				CCAPI.PS3M_API.PS3.SetIDPS(idps);
				result = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000034DC File Offset: 0x000016DC
		public int SetConsoleID(byte[] consoleID)
		{
			string text = CCAPI.ByteArrayToString(consoleID);
			if (text.Length < 32)
			{
				MessageBox.Show("Invalid ConsoleID", "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return -1;
			}
			int result;
			try
			{
				if (text.Length > 32)
				{
					text = text.Substring(0, 32);
				}
				CCAPI.PS3M_API.PS3.SetIDPS(text);
				result = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003564 File Offset: 0x00001764
		public int SetPSID(string PSID)
		{
			if (PSID.Length < 32)
			{
				MessageBox.Show("Invalid ConsoleID", "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return -1;
			}
			int result;
			try
			{
				string psid = "";
				if (PSID.Length > 32)
				{
					psid = PSID.Substring(0, 32);
				}
				CCAPI.PS3M_API.PS3.SetPSID(psid);
				result = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000035E8 File Offset: 0x000017E8
		public int SetPSID(byte[] PSID)
		{
			string text = CCAPI.ByteArrayToString(PSID);
			if (text.Length < 32)
			{
				MessageBox.Show("Invalid ConsoleID", "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return -1;
			}
			int result;
			try
			{
				if (text.Length > 32)
				{
					text = text.Substring(0, 32);
				}
				CCAPI.PS3M_API.PS3.SetPSID(text);
				result = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error PS3M_API", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = -1;
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000229E File Offset: 0x0000049E
		public int SetBootConsoleID(string consoleID, CCAPI.IdType Type = CCAPI.IdType.IDPS)
		{
			MessageBox.Show("SetBootConsoleID: Unsuported By PS3M_API", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return 0;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000229E File Offset: 0x0000049E
		public int SetBootConsoleID(byte[] consoleID, CCAPI.IdType Type = CCAPI.IdType.IDPS)
		{
			MessageBox.Show("SetBootConsoleID: Unsuported By PS3M_API", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return 0;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000022B4 File Offset: 0x000004B4
		public int ResetBootConsoleID(CCAPI.IdType Type = CCAPI.IdType.IDPS)
		{
			MessageBox.Show("ResetBootConsoleID: Unsuported By PS3M_API", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return 0;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000022CA File Offset: 0x000004CA
		public int GetDllVersion()
		{
			return 260;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003670 File Offset: 0x00001870
		public List<CCAPI.ConsoleInfo> GetConsoleList()
		{
			return new List<CCAPI.ConsoleInfo>
			{
				new CCAPI.ConsoleInfo
				{
					Ip = "127.0.0.1",
					Name = "PS3MAPI"
				}
			};
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000036A8 File Offset: 0x000018A8
		internal static string ByteArrayToString(byte[] bytes)
		{
			string result;
			try
			{
				StringBuilder stringBuilder = new StringBuilder(bytes.Length * 2);
				foreach (byte b in bytes)
				{
					stringBuilder.AppendFormat("{0:x2}", b);
				}
				result = stringBuilder.ToString();
			}
			catch
			{
				throw new ArgumentException("Value not possible.", "HEX String");
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003718 File Offset: 0x00001918
		internal static byte[] StringToByteArray(string hex)
		{
			string replace = hex.Replace("0x", "");
			string Stringz = replace.Insert(replace.Length - 1, "0");
			int length = replace.Length;
			bool flag;
			if (length % 2 == 0)
			{
				flag = true;
			}
			else
			{
				flag = false;
			}
			byte[] result;
			try
			{
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
				throw new ArgumentException("Value not possible.", "Byte Array");
			}
			return result;
		}

		// Token: 0x0400000A RID: 10
		private static PS3MAPI PS3M_API = new PS3MAPI();

		// Token: 0x0400000B RID: 11
		private CCAPI.TargetInfo pInfo = new CCAPI.TargetInfo();

		// Token: 0x02000007 RID: 7
		public enum IdType
		{
			// Token: 0x0400000F RID: 15
			IDPS,
			// Token: 0x04000010 RID: 16
			PSID
		}

		// Token: 0x02000008 RID: 8
		public enum NotifyIcon
		{
			// Token: 0x04000012 RID: 18
			INFO,
			// Token: 0x04000013 RID: 19
			CAUTION,
			// Token: 0x04000014 RID: 20
			FRIEND,
			// Token: 0x04000015 RID: 21
			SLIDER,
			// Token: 0x04000016 RID: 22
			WRONGWAY,
			// Token: 0x04000017 RID: 23
			DIALOG,
			// Token: 0x04000018 RID: 24
			DIALOGSHADOW,
			// Token: 0x04000019 RID: 25
			TEXT,
			// Token: 0x0400001A RID: 26
			POINTER,
			// Token: 0x0400001B RID: 27
			GRAB,
			// Token: 0x0400001C RID: 28
			HAND,
			// Token: 0x0400001D RID: 29
			PEN,
			// Token: 0x0400001E RID: 30
			FINGER,
			// Token: 0x0400001F RID: 31
			ARROW,
			// Token: 0x04000020 RID: 32
			ARROWRIGHT,
			// Token: 0x04000021 RID: 33
			PROGRESS,
			// Token: 0x04000022 RID: 34
			TROPHY1,
			// Token: 0x04000023 RID: 35
			TROPHY2,
			// Token: 0x04000024 RID: 36
			TROPHY3,
			// Token: 0x04000025 RID: 37
			TROPHY4
		}

		// Token: 0x02000009 RID: 9
		public enum ConsoleType
		{
			// Token: 0x04000027 RID: 39
			CEX = 1,
			// Token: 0x04000028 RID: 40
			DEX,
			// Token: 0x04000029 RID: 41
			TOOL
		}

		// Token: 0x0200000A RID: 10
		public enum ProcessType
		{
			// Token: 0x0400002B RID: 43
			VSH,
			// Token: 0x0400002C RID: 44
			SYS_AGENT,
			// Token: 0x0400002D RID: 45
			CURRENTGAME
		}

		// Token: 0x0200000B RID: 11
		public enum RebootFlags
		{
			// Token: 0x0400002F RID: 47
			ShutDown = 1,
			// Token: 0x04000030 RID: 48
			SoftReboot,
			// Token: 0x04000031 RID: 49
			HardReboot
		}

		// Token: 0x0200000C RID: 12
		public enum BuzzerMode
		{
			// Token: 0x04000033 RID: 51
			Continuous,
			// Token: 0x04000034 RID: 52
			Single,
			// Token: 0x04000035 RID: 53
			Double
		}

		// Token: 0x0200000D RID: 13
		public enum LedColor
		{
			// Token: 0x04000037 RID: 55
			Green = 1,
			// Token: 0x04000038 RID: 56
			Red
		}

		// Token: 0x0200000E RID: 14
		public enum LedMode
		{
			// Token: 0x0400003A RID: 58
			Off,
			// Token: 0x0400003B RID: 59
			On,
			// Token: 0x0400003C RID: 60
			Blink
		}

		// Token: 0x0200000F RID: 15
		private class System
		{
			// Token: 0x0400003D RID: 61
			public static int connectionID = -1;

			// Token: 0x0400003E RID: 62
			public static uint processID = 0U;

			// Token: 0x0400003F RID: 63
			public static uint[] processIDs;
		}

		// Token: 0x02000010 RID: 16
		public class TargetInfo
		{
			// Token: 0x04000040 RID: 64
			public int Firmware;

			// Token: 0x04000041 RID: 65
			public int CCAPI;

			// Token: 0x04000042 RID: 66
			public int ConsoleType;

			// Token: 0x04000043 RID: 67
			public int TempCell;

			// Token: 0x04000044 RID: 68
			public int TempRSX;

			// Token: 0x04000045 RID: 69
			public ulong SysTable;
		}

		// Token: 0x02000011 RID: 17
		public class ConsoleInfo
		{
			// Token: 0x04000046 RID: 70
			public string Name;

			// Token: 0x04000047 RID: 71
			public string Ip;
		}
	}
}
