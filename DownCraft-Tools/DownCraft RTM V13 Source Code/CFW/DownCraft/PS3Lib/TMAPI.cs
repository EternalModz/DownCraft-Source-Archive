using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PS3Lib.NET;

namespace PS3Lib
{
	// Token: 0x02000139 RID: 313
	public class TMAPI
	{
		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x00041A94 File Offset: 0x0003FC94
		public Extension Extension
		{
			get
			{
				return new Extension(SelectAPI.TargetManager);
			}
		}

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x00041AAC File Offset: 0x0003FCAC
		public TMAPI.SCECMD SCE
		{
			get
			{
				return new TMAPI.SCECMD();
			}
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x00041AC3 File Offset: 0x0003FCC3
		public void InitComms()
		{
			PS3TMAPI.InitTargetComms();
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x00041ACC File Offset: 0x0003FCCC
		public bool ConnectTarget(int TargetIndex = 0)
		{
			if (TMAPI.AssemblyLoaded)
			{
				this.PS3TMAPI_NET();
			}
			TMAPI.AssemblyLoaded = false;
			TMAPI.Target = TargetIndex;
			bool flag = PS3TMAPI.SUCCEEDED(PS3TMAPI.InitTargetComms());
			return PS3TMAPI.SUCCEEDED(PS3TMAPI.Connect(TargetIndex, null));
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x00041B18 File Offset: 0x0003FD18
		public bool ConnectTarget(string TargetName)
		{
			if (TMAPI.AssemblyLoaded)
			{
				this.PS3TMAPI_NET();
			}
			TMAPI.AssemblyLoaded = false;
			bool flag = PS3TMAPI.SUCCEEDED(PS3TMAPI.InitTargetComms());
			if (flag)
			{
				flag = PS3TMAPI.SUCCEEDED(PS3TMAPI.GetTargetFromName(TargetName, out TMAPI.Target));
				flag = PS3TMAPI.SUCCEEDED(PS3TMAPI.Connect(TMAPI.Target, null));
			}
			return flag;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00041B7D File Offset: 0x0003FD7D
		public void DisconnectTarget()
		{
			PS3TMAPI.Disconnect(TMAPI.Target);
		}

		// Token: 0x06000CEF RID: 3311 RVA: 0x00041B8C File Offset: 0x0003FD8C
		public void PowerOn(int numTarget = 0)
		{
			if (TMAPI.Target != 255)
			{
				numTarget = TMAPI.Target;
			}
			PS3TMAPI.PowerOn(numTarget);
		}

		// Token: 0x06000CF0 RID: 3312 RVA: 0x00041BBA File Offset: 0x0003FDBA
		public void PowerOff(bool Force)
		{
			PS3TMAPI.PowerOff(TMAPI.Target, Force);
		}

		// Token: 0x06000CF1 RID: 3313 RVA: 0x00041BCC File Offset: 0x0003FDCC
		public bool AttachProcess()
		{
			PS3TMAPI.GetProcessList(TMAPI.Target, out TMAPI.Parameters.processIDs);
			bool flag = TMAPI.Parameters.processIDs.Length > 0;
			if (flag)
			{
				ulong value = (ulong)TMAPI.Parameters.processIDs[0];
				TMAPI.Parameters.ProcessID = Convert.ToUInt32(value);
				PS3TMAPI.ProcessAttach(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID);
				PS3TMAPI.ProcessContinue(TMAPI.Target, TMAPI.Parameters.ProcessID);
				TMAPI.Parameters.info = "The Process 0x" + TMAPI.Parameters.ProcessID.ToString("X8") + " Has Been Attached !";
			}
			return flag;
		}

		// Token: 0x06000CF2 RID: 3314 RVA: 0x00041C5C File Offset: 0x0003FE5C
		public void SetMemory(uint Address, byte[] Bytes)
		{
			PS3TMAPI.ProcessSetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0uL, (ulong)Address, Bytes);
		}

		// Token: 0x06000CF3 RID: 3315 RVA: 0x00041C78 File Offset: 0x0003FE78
		public void SetMemory(uint Address, ulong value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			PS3TMAPI.ProcessSetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0uL, (ulong)Address, bytes);
		}

		// Token: 0x06000CF4 RID: 3316 RVA: 0x00041CAC File Offset: 0x0003FEAC
		public void SetMemory(uint Address, string hexadecimal, EndianType Type = EndianType.BigEndian)
		{
			byte[] array = TMAPI.StringToByteArray(hexadecimal);
			if (Type == EndianType.LittleEndian)
			{
				Array.Reverse(array);
			}
			PS3TMAPI.ProcessSetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0uL, (ulong)Address, array);
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x00041CEB File Offset: 0x0003FEEB
		public void GetMemory(uint Address, byte[] Bytes)
		{
			PS3TMAPI.ProcessGetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0uL, (ulong)Address, ref Bytes);
		}

		// Token: 0x06000CF6 RID: 3318 RVA: 0x00041D08 File Offset: 0x0003FF08
		public byte[] GetBytes(uint Address, uint lengthByte)
		{
			byte[] result = new byte[lengthByte];
			PS3TMAPI.ProcessGetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0uL, (ulong)Address, ref result);
			return result;
		}

		// Token: 0x06000CF7 RID: 3319 RVA: 0x00041D3C File Offset: 0x0003FF3C
		public string GetString(uint Address, uint lengthString)
		{
			byte[] bytes = new byte[lengthString];
			PS3TMAPI.ProcessGetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0uL, (ulong)Address, ref bytes);
			return TMAPI.Hex2Ascii(TMAPI.ReplaceString(bytes));
		}

		// Token: 0x06000CF8 RID: 3320 RVA: 0x00041D78 File Offset: 0x0003FF78
		internal static string Hex2Ascii(string iMCSxString)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i <= iMCSxString.Length - 2; i += 2)
			{
				stringBuilder.Append(Convert.ToString(Convert.ToChar(int.Parse(iMCSxString.Substring(i, 2), NumberStyles.HexNumber))));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000CF9 RID: 3321 RVA: 0x00041E38 File Offset: 0x00040038
		internal static byte[] StringToByteArray(string hex)
		{
			string replace = hex.Replace("0x", "");
			string Stringz = replace.Insert(replace.Length - 1, "0");
			int length = replace.Length;
			bool Nombre = false;
			if (length % 2 == 0)
			{
				Nombre = true;
			}
			byte[] result;
			try
			{
				result = (from x in Enumerable.Range(0, replace.Length)
				where x % 2 == 0
				select Convert.ToByte(Nombre ? replace.Substring(x, 2) : Stringz.Substring(x, 2), 16)).ToArray<byte>();
			}
			catch
			{
				throw new ArgumentException("Value not possible.", "Byte Array");
			}
			return result;
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x00041F34 File Offset: 0x00040134
		internal static string ReplaceString(byte[] bytes)
		{
			string text = BitConverter.ToString(bytes);
			text = text.Replace("00", string.Empty);
			text = text.Replace("-", string.Empty);
			for (int i = 0; i < 10; i++)
			{
				text = text.Replace("^" + i.ToString(), string.Empty);
			}
			return text;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00041FA0 File Offset: 0x000401A0
		public void ResetToXMB(TMAPI.ResetTarget flag)
		{
			if (flag == TMAPI.ResetTarget.Hard)
			{
				TMAPI.resetParameter = PS3TMAPI.ResetParameter.Hard;
			}
			else if (flag == TMAPI.ResetTarget.Quick)
			{
				TMAPI.resetParameter = PS3TMAPI.ResetParameter.Quick;
			}
			else if (flag == TMAPI.ResetTarget.ResetEx)
			{
				TMAPI.resetParameter = PS3TMAPI.ResetParameter.ResetEx;
			}
			else if (flag == TMAPI.ResetTarget.Soft)
			{
				TMAPI.resetParameter = PS3TMAPI.ResetParameter.Soft;
			}
			PS3TMAPI.Reset(TMAPI.Target, TMAPI.resetParameter);
		}

		// Token: 0x06000CFC RID: 3324 RVA: 0x000420E0 File Offset: 0x000402E0
		public Assembly PS3TMAPI_NET()
		{
			AppDomain.CurrentDomain.AssemblyResolve += delegate(object s, ResolveEventArgs e)
			{
				string name = new AssemblyName(e.Name).Name;
				string path = string.Format("C:\\Program Files\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
				string path2 = string.Format("C:\\Program Files (x64)\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
				string text = string.Format("C:\\Program Files (x86)\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
				if (File.Exists(path))
				{
					TMAPI.LoadApi = Assembly.LoadFile(path);
				}
				else if (File.Exists(path2))
				{
					TMAPI.LoadApi = Assembly.LoadFile(path2);
				}
				else if (File.Exists(text))
				{
					TMAPI.LoadApi = Assembly.LoadFile(text);
				}
				else
				{
					MessageBox.Show("Target Manager API cannot be founded to:\r\n\r\n" + text, "Error with PS3 API!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				return TMAPI.LoadApi;
			};
			return TMAPI.LoadApi;
		}

		// Token: 0x0400054F RID: 1359
		public static int Target = 255;

		// Token: 0x04000550 RID: 1360
		public static bool AssemblyLoaded = true;

		// Token: 0x04000551 RID: 1361
		public static PS3TMAPI.ResetParameter resetParameter;

		// Token: 0x04000552 RID: 1362
		internal static Assembly LoadApi;

		// Token: 0x0200013A RID: 314
		public class SCECMD
		{
			// Token: 0x06000D01 RID: 3329 RVA: 0x0004213C File Offset: 0x0004033C
			public string SNRESULT()
			{
				return TMAPI.Parameters.snresult;
			}

			// Token: 0x06000D02 RID: 3330 RVA: 0x00042154 File Offset: 0x00040354
			public string GetTargetName()
			{
				if (TMAPI.Parameters.ConsoleName == null || TMAPI.Parameters.ConsoleName == string.Empty)
				{
					PS3TMAPI.InitTargetComms();
					PS3TMAPI.TargetInfo targetInfo = default(PS3TMAPI.TargetInfo);
					targetInfo.Flags = PS3TMAPI.TargetInfoFlag.TargetID;
					targetInfo.Target = TMAPI.Target;
					PS3TMAPI.GetTargetInfo(ref targetInfo);
					TMAPI.Parameters.ConsoleName = targetInfo.Name;
				}
				return TMAPI.Parameters.ConsoleName;
			}

			// Token: 0x06000D03 RID: 3331 RVA: 0x000421C4 File Offset: 0x000403C4
			public string GetStatus()
			{
				string result;
				if (TMAPI.AssemblyLoaded)
				{
					result = "NotConnected";
				}
				else
				{
					TMAPI.Parameters.connectStatus = PS3TMAPI.ConnectStatus.Connected;
					PS3TMAPI.GetConnectStatus(TMAPI.Target, out TMAPI.Parameters.connectStatus, out TMAPI.Parameters.usage);
					TMAPI.Parameters.Status = TMAPI.Parameters.connectStatus.ToString();
					result = TMAPI.Parameters.Status;
				}
				return result;
			}

			// Token: 0x06000D04 RID: 3332 RVA: 0x00042224 File Offset: 0x00040424
			public uint ProcessID()
			{
				return TMAPI.Parameters.ProcessID;
			}

			// Token: 0x06000D05 RID: 3333 RVA: 0x0004223C File Offset: 0x0004043C
			public uint[] ProcessIDs()
			{
				return TMAPI.Parameters.processIDs;
			}

			// Token: 0x06000D06 RID: 3334 RVA: 0x00042254 File Offset: 0x00040454
			public PS3TMAPI.ConnectStatus DetailStatus()
			{
				return TMAPI.Parameters.connectStatus;
			}
		}

		// Token: 0x0200013B RID: 315
		public class Parameters
		{
			// Token: 0x04000555 RID: 1365
			public static string usage;

			// Token: 0x04000556 RID: 1366
			public static string info;

			// Token: 0x04000557 RID: 1367
			public static string snresult;

			// Token: 0x04000558 RID: 1368
			public static string Status;

			// Token: 0x04000559 RID: 1369
			public static string MemStatus;

			// Token: 0x0400055A RID: 1370
			public static string ConsoleName;

			// Token: 0x0400055B RID: 1371
			public static uint ProcessID;

			// Token: 0x0400055C RID: 1372
			public static uint[] processIDs;

			// Token: 0x0400055D RID: 1373
			public static byte[] Retour;

			// Token: 0x0400055E RID: 1374
			public static PS3TMAPI.ConnectStatus connectStatus;
		}

		// Token: 0x0200013C RID: 316
		public enum ResetTarget
		{
			// Token: 0x04000560 RID: 1376
			Hard,
			// Token: 0x04000561 RID: 1377
			Quick,
			// Token: 0x04000562 RID: 1378
			ResetEx,
			// Token: 0x04000563 RID: 1379
			Soft
		}
	}
}
