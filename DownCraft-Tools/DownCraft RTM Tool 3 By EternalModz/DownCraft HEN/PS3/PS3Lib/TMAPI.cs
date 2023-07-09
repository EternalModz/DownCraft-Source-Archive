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
	// Token: 0x0200001D RID: 29
	public class TMAPI
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000026B0 File Offset: 0x000008B0
		public Extension Extension
		{
			get
			{
				return new Extension(SelectAPI.TargetManager);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000026B8 File Offset: 0x000008B8
		public TMAPI.SCECMD SCE
		{
			get
			{
				return new TMAPI.SCECMD();
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000026BF File Offset: 0x000008BF
		public void InitComms()
		{
			PS3TMAPI.InitTargetComms();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004648 File Offset: 0x00002848
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

		// Token: 0x06000099 RID: 153 RVA: 0x0000468C File Offset: 0x0000288C
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

		// Token: 0x0600009A RID: 154 RVA: 0x000026C7 File Offset: 0x000008C7
		public void DisconnectTarget()
		{
			PS3TMAPI.Disconnect(TMAPI.Target);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000026D4 File Offset: 0x000008D4
		public void PowerOn(int numTarget = 0)
		{
			if (TMAPI.Target != 255)
			{
				numTarget = TMAPI.Target;
			}
			PS3TMAPI.PowerOn(numTarget);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000026F0 File Offset: 0x000008F0
		public void PowerOff(bool Force)
		{
			PS3TMAPI.PowerOff(TMAPI.Target, Force);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000046E0 File Offset: 0x000028E0
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

		// Token: 0x0600009E RID: 158 RVA: 0x000026FE File Offset: 0x000008FE
		public void SetMemory(uint Address, byte[] Bytes)
		{
			PS3TMAPI.ProcessSetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, Bytes);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000476C File Offset: 0x0000296C
		public void SetMemory(uint Address, ulong value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			PS3TMAPI.ProcessSetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, bytes);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000479C File Offset: 0x0000299C
		public void SetMemory(uint Address, string hexadecimal, EndianType Type = EndianType.BigEndian)
		{
			byte[] array = TMAPI.StringToByteArray(hexadecimal);
			if (Type == EndianType.LittleEndian)
			{
				Array.Reverse(array);
			}
			PS3TMAPI.ProcessSetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, array);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002716 File Offset: 0x00000916
		public void GetMemory(uint Address, byte[] Bytes)
		{
			PS3TMAPI.ProcessGetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, ref Bytes);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000047D0 File Offset: 0x000029D0
		public byte[] GetBytes(uint Address, uint lengthByte)
		{
			byte[] result = new byte[lengthByte];
			PS3TMAPI.ProcessGetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, ref result);
			return result;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004800 File Offset: 0x00002A00
		public string GetString(uint Address, uint lengthString)
		{
			byte[] bytes = new byte[lengthString];
			PS3TMAPI.ProcessGetMemory(TMAPI.Target, PS3TMAPI.UnitType.PPU, TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, ref bytes);
			return TMAPI.Hex2Ascii(TMAPI.ReplaceString(bytes));
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000483C File Offset: 0x00002A3C
		internal static string Hex2Ascii(string iMCSxString)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i <= iMCSxString.Length - 2; i += 2)
			{
				stringBuilder.Append(Convert.ToString(Convert.ToChar(int.Parse(iMCSxString.Substring(i, 2), NumberStyles.HexNumber))));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000488C File Offset: 0x00002A8C
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

		// Token: 0x060000A6 RID: 166 RVA: 0x000049C8 File Offset: 0x00002BC8
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

		// Token: 0x060000A7 RID: 167 RVA: 0x00004A2C File Offset: 0x00002C2C
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

		// Token: 0x060000A8 RID: 168 RVA: 0x0000272F File Offset: 0x0000092F
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

		// Token: 0x04000063 RID: 99
		public static int Target = 255;

		// Token: 0x04000064 RID: 100
		public static bool AssemblyLoaded = true;

		// Token: 0x04000065 RID: 101
		public static PS3TMAPI.ResetParameter resetParameter;

		// Token: 0x04000066 RID: 102
		internal static Assembly LoadApi;

		// Token: 0x0200001E RID: 30
		public class SCECMD
		{
			// Token: 0x060000AD RID: 173 RVA: 0x0000276F File Offset: 0x0000096F
			public string SNRESULT()
			{
				return TMAPI.Parameters.snresult;
			}

			// Token: 0x060000AE RID: 174 RVA: 0x00004B24 File Offset: 0x00002D24
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

			// Token: 0x060000AF RID: 175 RVA: 0x00004B84 File Offset: 0x00002D84
			public string GetStatus()
			{
				if (TMAPI.AssemblyLoaded)
				{
					return "NotConnected";
				}
				TMAPI.Parameters.connectStatus = PS3TMAPI.ConnectStatus.Connected;
				PS3TMAPI.GetConnectStatus(TMAPI.Target, out TMAPI.Parameters.connectStatus, out TMAPI.Parameters.usage);
				TMAPI.Parameters.Status = TMAPI.Parameters.connectStatus.ToString();
				return TMAPI.Parameters.Status;
			}

			// Token: 0x060000B0 RID: 176 RVA: 0x00002776 File Offset: 0x00000976
			public uint ProcessID()
			{
				return TMAPI.Parameters.ProcessID;
			}

			// Token: 0x060000B1 RID: 177 RVA: 0x0000277D File Offset: 0x0000097D
			public uint[] ProcessIDs()
			{
				return TMAPI.Parameters.processIDs;
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x00002784 File Offset: 0x00000984
			public PS3TMAPI.ConnectStatus DetailStatus()
			{
				return TMAPI.Parameters.connectStatus;
			}
		}

		// Token: 0x0200001F RID: 31
		public class Parameters
		{
			// Token: 0x0400006A RID: 106
			public static string usage;

			// Token: 0x0400006B RID: 107
			public static string info;

			// Token: 0x0400006C RID: 108
			public static string snresult;

			// Token: 0x0400006D RID: 109
			public static string Status;

			// Token: 0x0400006E RID: 110
			public static string MemStatus;

			// Token: 0x0400006F RID: 111
			public static string ConsoleName;

			// Token: 0x04000070 RID: 112
			public static uint ProcessID;

			// Token: 0x04000071 RID: 113
			public static uint[] processIDs;

			// Token: 0x04000072 RID: 114
			public static byte[] Retour;

			// Token: 0x04000073 RID: 115
			public static PS3TMAPI.ConnectStatus connectStatus;
		}

		// Token: 0x02000020 RID: 32
		public enum ResetTarget
		{
			// Token: 0x04000075 RID: 117
			Hard,
			// Token: 0x04000076 RID: 118
			Quick,
			// Token: 0x04000077 RID: 119
			ResetEx,
			// Token: 0x04000078 RID: 120
			Soft
		}
	}
}
