using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using PS3Lib.NET;

namespace PS3Lib
{
	public class TMAPI
	{
		public TMAPI()
		{
		}

		public PS3Lib.Extension Extension
		{
			get
			{
				return new PS3Lib.Extension(PS3Lib.SelectAPI.TargetManager);
			}
		}

		public PS3Lib.TMAPI.SCECMD SCE
		{
			get
			{
				return new PS3Lib.TMAPI.SCECMD();
			}
		}

		public void InitComms()
		{
			PS3Lib.NET.PS3TMAPI.InitTargetComms();
		}

		public bool ConnectTarget(int TargetIndex = 0)
		{
			if (PS3Lib.TMAPI.AssemblyLoaded)
			{
				this.PS3TMAPI_NET();
			}
			PS3Lib.TMAPI.AssemblyLoaded = false;
			PS3Lib.TMAPI.Target = TargetIndex;
			bool flag = PS3Lib.NET.PS3TMAPI.SUCCEEDED(PS3Lib.NET.PS3TMAPI.InitTargetComms());
			return PS3Lib.NET.PS3TMAPI.SUCCEEDED(PS3Lib.NET.PS3TMAPI.Connect(TargetIndex, null));
		}

		public bool ConnectTarget(string TargetName)
		{
			if (PS3Lib.TMAPI.AssemblyLoaded)
			{
				this.PS3TMAPI_NET();
			}
			PS3Lib.TMAPI.AssemblyLoaded = false;
			bool flag = PS3Lib.NET.PS3TMAPI.SUCCEEDED(PS3Lib.NET.PS3TMAPI.InitTargetComms());
			if (flag)
			{
				flag = PS3Lib.NET.PS3TMAPI.SUCCEEDED(PS3Lib.NET.PS3TMAPI.GetTargetFromName(TargetName, out PS3Lib.TMAPI.Target));
				flag = PS3Lib.NET.PS3TMAPI.SUCCEEDED(PS3Lib.NET.PS3TMAPI.Connect(PS3Lib.TMAPI.Target, null));
			}
			return flag;
		}

		public void DisconnectTarget()
		{
			PS3Lib.NET.PS3TMAPI.Disconnect(PS3Lib.TMAPI.Target);
		}

		public void PowerOn(int numTarget = 0)
		{
			if (PS3Lib.TMAPI.Target != 0xFF)
			{
				numTarget = PS3Lib.TMAPI.Target;
			}
			PS3Lib.NET.PS3TMAPI.PowerOn(numTarget);
		}

		public void PowerOff(bool Force)
		{
			PS3Lib.NET.PS3TMAPI.PowerOff(PS3Lib.TMAPI.Target, Force);
		}

		public bool AttachProcess()
		{
			PS3Lib.NET.PS3TMAPI.GetProcessList(PS3Lib.TMAPI.Target, out PS3Lib.TMAPI.Parameters.processIDs);
			bool flag = PS3Lib.TMAPI.Parameters.processIDs.Length > 0;
			if (flag)
			{
				ulong value = (ulong)PS3Lib.TMAPI.Parameters.processIDs[0];
				PS3Lib.TMAPI.Parameters.ProcessID = System.Convert.ToUInt32(value);
				PS3Lib.NET.PS3TMAPI.ProcessAttach(PS3Lib.TMAPI.Target, PS3Lib.NET.PS3TMAPI.UnitType.PPU, PS3Lib.TMAPI.Parameters.ProcessID);
				PS3Lib.NET.PS3TMAPI.ProcessContinue(PS3Lib.TMAPI.Target, PS3Lib.TMAPI.Parameters.ProcessID);
				PS3Lib.TMAPI.Parameters.info = "The Process 0x" + PS3Lib.TMAPI.Parameters.ProcessID.ToString("X8") + " Has Been Attached !";
			}
			return flag;
		}

		public void SetMemory(uint Address, byte[] Bytes)
		{
			PS3Lib.NET.PS3TMAPI.ProcessSetMemory(PS3Lib.TMAPI.Target, PS3Lib.NET.PS3TMAPI.UnitType.PPU, PS3Lib.TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, Bytes);
		}

		public void SetMemory(uint Address, ulong value)
		{
			byte[] bytes = System.BitConverter.GetBytes(value);
			System.Array.Reverse(bytes);
			PS3Lib.NET.PS3TMAPI.ProcessSetMemory(PS3Lib.TMAPI.Target, PS3Lib.NET.PS3TMAPI.UnitType.PPU, PS3Lib.TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, bytes);
		}

		public void SetMemory(uint Address, string hexadecimal, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
		{
			byte[] array = PS3Lib.TMAPI.StringToByteArray(hexadecimal);
			if (Type == PS3Lib.EndianType.LittleEndian)
			{
				System.Array.Reverse(array);
			}
			PS3Lib.NET.PS3TMAPI.ProcessSetMemory(PS3Lib.TMAPI.Target, PS3Lib.NET.PS3TMAPI.UnitType.PPU, PS3Lib.TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, array);
		}

		public void GetMemory(uint Address, byte[] Bytes)
		{
			PS3Lib.NET.PS3TMAPI.ProcessGetMemory(PS3Lib.TMAPI.Target, PS3Lib.NET.PS3TMAPI.UnitType.PPU, PS3Lib.TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, ref Bytes);
		}

		public byte[] GetBytes(uint Address, uint lengthByte)
		{
			byte[] result = new byte[lengthByte];
			PS3Lib.NET.PS3TMAPI.ProcessGetMemory(PS3Lib.TMAPI.Target, PS3Lib.NET.PS3TMAPI.UnitType.PPU, PS3Lib.TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, ref result);
			return result;
		}

		public string GetString(uint Address, uint lengthString)
		{
			byte[] bytes = new byte[lengthString];
			PS3Lib.NET.PS3TMAPI.ProcessGetMemory(PS3Lib.TMAPI.Target, PS3Lib.NET.PS3TMAPI.UnitType.PPU, PS3Lib.TMAPI.Parameters.ProcessID, 0UL, (ulong)Address, ref bytes);
			return PS3Lib.TMAPI.Hex2Ascii(PS3Lib.TMAPI.ReplaceString(bytes));
		}

		internal static string Hex2Ascii(string iMCSxString)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			for (int i = 0; i <= iMCSxString.Length - 2; i += 2)
			{
				stringBuilder.Append(System.Convert.ToString(System.Convert.ToChar(int.Parse(iMCSxString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
			}
			return stringBuilder.ToString();
		}

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
				result = (from x in System.Linq.Enumerable.Range(0, replace.Length)
				where x % 2 == 0
				select System.Convert.ToByte(Nombre ? replace.Substring(x, 2) : Stringz.Substring(x, 2), 0x10)).ToArray<byte>();
			}
			catch
			{
				throw new System.ArgumentException("Value not possible.", "Byte Array");
			}
			return result;
		}

		internal static string ReplaceString(byte[] bytes)
		{
			string text = System.BitConverter.ToString(bytes);
			text = text.Replace("00", string.Empty);
			text = text.Replace("-", string.Empty);
			for (int i = 0; i < 0xA; i++)
			{
				text = text.Replace("^" + i.ToString(), string.Empty);
			}
			return text;
		}

		public void ResetToXMB(PS3Lib.TMAPI.ResetTarget flag)
		{
			if (flag == PS3Lib.TMAPI.ResetTarget.Hard)
			{
				PS3Lib.TMAPI.resetParameter = PS3Lib.NET.PS3TMAPI.ResetParameter.Hard;
			}
			else if (flag == PS3Lib.TMAPI.ResetTarget.Quick)
			{
				PS3Lib.TMAPI.resetParameter = PS3Lib.NET.PS3TMAPI.ResetParameter.Quick;
			}
			else if (flag == PS3Lib.TMAPI.ResetTarget.ResetEx)
			{
				PS3Lib.TMAPI.resetParameter = PS3Lib.NET.PS3TMAPI.ResetParameter.ResetEx;
			}
			else if (flag == PS3Lib.TMAPI.ResetTarget.Soft)
			{
				PS3Lib.TMAPI.resetParameter = PS3Lib.NET.PS3TMAPI.ResetParameter.Soft;
			}
			PS3Lib.NET.PS3TMAPI.Reset(PS3Lib.TMAPI.Target, PS3Lib.TMAPI.resetParameter);
		}

		public System.Reflection.Assembly PS3TMAPI_NET()
		{
			System.AppDomain.CurrentDomain.AssemblyResolve += delegate(object s, System.ResolveEventArgs e)
			{
				string name = new System.Reflection.AssemblyName(e.Name).Name;
				string path = string.Format("C:\\Program Files\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
				string path2 = string.Format("C:\\Program Files (x64)\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
				string text = string.Format("C:\\Program Files (x86)\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
				if (System.IO.File.Exists(path))
				{
					PS3Lib.TMAPI.LoadApi = System.Reflection.Assembly.LoadFile(path);
				}
				else if (System.IO.File.Exists(path2))
				{
					PS3Lib.TMAPI.LoadApi = System.Reflection.Assembly.LoadFile(path2);
				}
				else if (System.IO.File.Exists(text))
				{
					PS3Lib.TMAPI.LoadApi = System.Reflection.Assembly.LoadFile(text);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("Target Manager API cannot be founded to:\r\n\r\n" + text, "Error with PS3 API!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
				return PS3Lib.TMAPI.LoadApi;
			};
			return PS3Lib.TMAPI.LoadApi;
		}


		[System.Runtime.CompilerServices.CompilerGenerated]
		private static System.Reflection.Assembly PS3TMAPI_NET(object s, System.ResolveEventArgs e)
		{
			string name = new System.Reflection.AssemblyName(e.Name).Name;
			string path = string.Format("C:\\Program Files\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
			string path2 = string.Format("C:\\Program Files (x64)\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
			string text = string.Format("C:\\Program Files (x86)\\SN Systems\\PS3\\bin\\ps3tmapi_net.dll", name);
			if (System.IO.File.Exists(path))
			{
				PS3Lib.TMAPI.LoadApi = System.Reflection.Assembly.LoadFile(path);
			}
			else if (System.IO.File.Exists(path2))
			{
				PS3Lib.TMAPI.LoadApi = System.Reflection.Assembly.LoadFile(path2);
			}
			else if (System.IO.File.Exists(text))
			{
				PS3Lib.TMAPI.LoadApi = System.Reflection.Assembly.LoadFile(text);
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("Target Manager API cannot be founded to:\r\n\r\n" + text, "Error with PS3 API!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
			return PS3Lib.TMAPI.LoadApi;
		}

		// Note: this type is marked as 'beforefieldinit'.
		static TMAPI()
		{
		}

		public static int Target = 0xFF;

		public static bool AssemblyLoaded = true;

		public static PS3Lib.NET.PS3TMAPI.ResetParameter resetParameter;

		internal static System.Reflection.Assembly LoadApi;

		[System.Runtime.CompilerServices.CompilerGenerated]
#pragma warning disable CS0169 // The field 'TMAPI.CSCachedAnonymousMethodDelegate2' is never used
		private static System.Func<int, bool> CSCachedAnonymousMethodDelegate2;
#pragma warning restore CS0169 // The field 'TMAPI.CSCachedAnonymousMethodDelegate2' is never used

		[System.Runtime.CompilerServices.CompilerGenerated]
#pragma warning disable CS0169 // The field 'TMAPI.CSCachedAnonymousMethodDelegate7' is never used
		private static System.ResolveEventHandler CSCachedAnonymousMethodDelegate7;
#pragma warning restore CS0169 // The field 'TMAPI.CSCachedAnonymousMethodDelegate7' is never used

		public class SCECMD
		{
			public string SNRESULT()
			{
				return PS3Lib.TMAPI.Parameters.snresult;
			}

			public string GetTargetName()
			{
				if (PS3Lib.TMAPI.Parameters.ConsoleName == null || PS3Lib.TMAPI.Parameters.ConsoleName == string.Empty)
				{
					PS3Lib.NET.PS3TMAPI.InitTargetComms();
					PS3Lib.NET.PS3TMAPI.TargetInfo targetInfo = default(PS3Lib.NET.PS3TMAPI.TargetInfo);
					targetInfo.Flags = PS3Lib.NET.PS3TMAPI.TargetInfoFlag.TargetID;
					targetInfo.Target = PS3Lib.TMAPI.Target;
					PS3Lib.NET.PS3TMAPI.GetTargetInfo(ref targetInfo);
					PS3Lib.TMAPI.Parameters.ConsoleName = targetInfo.Name;
				}
				return PS3Lib.TMAPI.Parameters.ConsoleName;
			}

			public string GetStatus()
			{
				string result;
				if (PS3Lib.TMAPI.AssemblyLoaded)
				{
					result = "NotConnected";
				}
				else
				{
					PS3Lib.TMAPI.Parameters.connectStatus = PS3Lib.NET.PS3TMAPI.ConnectStatus.Connected;
					PS3Lib.NET.PS3TMAPI.GetConnectStatus(PS3Lib.TMAPI.Target, out PS3Lib.TMAPI.Parameters.connectStatus, out PS3Lib.TMAPI.Parameters.usage);
					PS3Lib.TMAPI.Parameters.Status = PS3Lib.TMAPI.Parameters.connectStatus.ToString();
					result = PS3Lib.TMAPI.Parameters.Status;
				}
				return result;
			}

			public uint ProcessID()
			{
				return PS3Lib.TMAPI.Parameters.ProcessID;
			}

			public uint[] ProcessIDs()
			{
				return PS3Lib.TMAPI.Parameters.processIDs;
			}

			public PS3Lib.NET.PS3TMAPI.ConnectStatus DetailStatus()
			{
				return PS3Lib.TMAPI.Parameters.connectStatus;
			}

			public SCECMD()
			{
			}
		}

		public class Parameters
		{
			public Parameters()
			{
			}

			public static string usage;

			public static string info;

			public static string snresult;

			public static string Status;

			public static string MemStatus;

			public static string ConsoleName;

			public static uint ProcessID;

			public static uint[] processIDs;

			public static byte[] Retour;

			public static PS3Lib.NET.PS3TMAPI.ConnectStatus connectStatus;
		}

		public enum ResetTarget
		{
			Hard,
			Quick,
			ResetEx,
			Soft
		}

	}
}
