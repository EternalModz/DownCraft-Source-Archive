using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace PS3Lib.NET
{
	// Token: 0x02000102 RID: 258
	public class PS3TMAPI
	{
		// Token: 0x06000BD0 RID: 3024
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3InitTargetComms")]
		private static extern PS3TMAPI.SNRESULT InitTargetCommsX64();

		// Token: 0x06000BD1 RID: 3025
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3InitTargetComms")]
		private static extern PS3TMAPI.SNRESULT InitTargetCommsX86();

		// Token: 0x06000BD2 RID: 3026
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOn")]
		private static extern PS3TMAPI.SNRESULT PowerOnX64(int target);

		// Token: 0x06000BD3 RID: 3027
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOn")]
		private static extern PS3TMAPI.SNRESULT PowerOnX86(int target);

		// Token: 0x06000BD4 RID: 3028
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOff")]
		private static extern PS3TMAPI.SNRESULT PowerOffX64(int target, uint force);

		// Token: 0x06000BD5 RID: 3029
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOff")]
		private static extern PS3TMAPI.SNRESULT PowerOffX86(int target, uint force);

		// Token: 0x06000BD6 RID: 3030
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Connect")]
		private static extern PS3TMAPI.SNRESULT ConnectX64(int target, string application);

		// Token: 0x06000BD7 RID: 3031
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Connect")]
		private static extern PS3TMAPI.SNRESULT ConnectX86(int target, string application);

		// Token: 0x06000BD8 RID: 3032
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectionInfo")]
		private static extern PS3TMAPI.SNRESULT GetConnectionInfoX64(int target, IntPtr connectProperties);

		// Token: 0x06000BD9 RID: 3033
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectionInfo")]
		private static extern PS3TMAPI.SNRESULT GetConnectionInfoX86(int target, IntPtr connectProperties);

		// Token: 0x06000BDA RID: 3034
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectStatus")]
		private static extern PS3TMAPI.SNRESULT GetConnectStatusX64(int target, out uint status, out IntPtr usage);

		// Token: 0x06000BDB RID: 3035
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectStatus")]
		private static extern PS3TMAPI.SNRESULT GetConnectStatusX86(int target, out uint status, out IntPtr usage);

		// Token: 0x06000BDC RID: 3036
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int MultiByteToWideChar(int codepage, int flags, IntPtr utf8, int utf8len, StringBuilder buffer, int buflen);

		// Token: 0x06000BDD RID: 3037
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessList")]
		private static extern PS3TMAPI.SNRESULT GetProcessListX64(int target, ref uint count, IntPtr processIdArray);

		// Token: 0x06000BDE RID: 3038
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessList")]
		private static extern PS3TMAPI.SNRESULT GetProcessListX86(int target, ref uint count, IntPtr processIdArray);

		// Token: 0x06000BDF RID: 3039
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessContinue")]
		private static extern PS3TMAPI.SNRESULT ProcessContinueX64(int target, uint processId);

		// Token: 0x06000BE0 RID: 3040
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessContinue")]
		private static extern PS3TMAPI.SNRESULT ProcessContinueX86(int target, uint processId);

		// Token: 0x06000BE1 RID: 3041
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessAttach")]
		private static extern PS3TMAPI.SNRESULT ProcessAttachX64(int target, uint unitId, uint processId);

		// Token: 0x06000BE2 RID: 3042
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessAttach")]
		private static extern PS3TMAPI.SNRESULT ProcessAttachX86(int target, uint unitId, uint processId);

		// Token: 0x06000BE3 RID: 3043
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessGetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessGetMemoryX64(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x06000BE4 RID: 3044
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessGetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessGetMemoryX86(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x06000BE5 RID: 3045
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetFromName")]
		private static extern PS3TMAPI.SNRESULT GetTargetFromNameX64(IntPtr name, out int target);

		// Token: 0x06000BE6 RID: 3046
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetFromName")]
		private static extern PS3TMAPI.SNRESULT GetTargetFromNameX86(IntPtr name, out int target);

		// Token: 0x06000BE7 RID: 3047
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Reset")]
		private static extern PS3TMAPI.SNRESULT ResetX64(int target, ulong resetParameter);

		// Token: 0x06000BE8 RID: 3048
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Reset")]
		private static extern PS3TMAPI.SNRESULT ResetX86(int target, ulong resetParameter);

		// Token: 0x06000BE9 RID: 3049
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessSetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessSetMemoryX64(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x06000BEA RID: 3050
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessSetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessSetMemoryX86(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x06000BEB RID: 3051
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetInfo")]
		private static extern PS3TMAPI.SNRESULT GetTargetInfoX64(ref PS3TMAPI.TargetInfoPriv targetInfoPriv);

		// Token: 0x06000BEC RID: 3052
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetInfo")]
		private static extern PS3TMAPI.SNRESULT GetTargetInfoX86(ref PS3TMAPI.TargetInfoPriv targetInfoPriv);

		// Token: 0x06000BED RID: 3053
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Disconnect")]
		private static extern PS3TMAPI.SNRESULT DisconnectX64(int target);

		// Token: 0x06000BEE RID: 3054
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Disconnect")]
		private static extern PS3TMAPI.SNRESULT DisconnectX86(int target);

		// Token: 0x06000BEF RID: 3055 RVA: 0x0003D84C File Offset: 0x0003BA4C
		private static bool Is32Bit()
		{
			return IntPtr.Size == 4;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0003D868 File Offset: 0x0003BA68
		public static bool FAILED(PS3TMAPI.SNRESULT res)
		{
			return !PS3TMAPI.SUCCEEDED(res);
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0003D884 File Offset: 0x0003BA84
		public static bool SUCCEEDED(PS3TMAPI.SNRESULT res)
		{
			return res >= PS3TMAPI.SNRESULT.SN_S_OK;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x0003D8A0 File Offset: 0x0003BAA0
		private static IntPtr AllocUtf8FromString(string wcharString)
		{
			IntPtr result;
			if (wcharString == null)
			{
				result = IntPtr.Zero;
			}
			else
			{
				byte[] bytes = Encoding.UTF8.GetBytes(wcharString);
				IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length + 1);
				Marshal.Copy(bytes, 0, intPtr, bytes.Length);
				Marshal.WriteByte((IntPtr)(intPtr.ToInt64() + (long)bytes.Length), 0);
				result = intPtr;
			}
			return result;
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x0003D90C File Offset: 0x0003BB0C
		public static string Utf8ToString(IntPtr utf8, uint maxLength)
		{
			int num = PS3TMAPI.MultiByteToWideChar(65001, 0, utf8, -1, null, 0);
			if (num == 0)
			{
				throw new Win32Exception();
			}
			StringBuilder stringBuilder = new StringBuilder(num);
			num = PS3TMAPI.MultiByteToWideChar(65001, 0, utf8, -1, stringBuilder, num);
			return stringBuilder.ToString();
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x0003D960 File Offset: 0x0003BB60
		private static IntPtr ReadDataFromUnmanagedIncPtr<T>(IntPtr unmanagedBuf, ref T storage)
		{
			storage = (T)((object)Marshal.PtrToStructure(unmanagedBuf, typeof(T)));
			return new IntPtr(unmanagedBuf.ToInt64() + (long)Marshal.SizeOf(storage));
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x0003D9AC File Offset: 0x0003BBAC
		public static PS3TMAPI.SNRESULT InitTargetComms()
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.InitTargetCommsX64();
			}
			else
			{
				result = PS3TMAPI.InitTargetCommsX86();
			}
			return result;
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0003D9DC File Offset: 0x0003BBDC
		public static PS3TMAPI.SNRESULT Connect(int target, string application)
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.ConnectX64(target, application);
			}
			else
			{
				result = PS3TMAPI.ConnectX86(target, application);
			}
			return result;
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0003DA10 File Offset: 0x0003BC10
		public static PS3TMAPI.SNRESULT PowerOn(int target)
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.PowerOnX64(target);
			}
			else
			{
				result = PS3TMAPI.PowerOnX86(target);
			}
			return result;
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x0003DA40 File Offset: 0x0003BC40
		public static PS3TMAPI.SNRESULT PowerOff(int target, bool bForce)
		{
			uint force = bForce ? 1u : 0u;
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.PowerOffX64(target, force);
			}
			else
			{
				result = PS3TMAPI.PowerOffX86(target, force);
			}
			return result;
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x0003DA7C File Offset: 0x0003BC7C
		public static PS3TMAPI.SNRESULT GetProcessList(int target, out uint[] processIDs)
		{
			processIDs = null;
			uint num = 0u;
			PS3TMAPI.SNRESULT sNRESULT = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetProcessListX86(target, ref num, IntPtr.Zero) : PS3TMAPI.GetProcessListX64(target, ref num, IntPtr.Zero);
			PS3TMAPI.SNRESULT sNRESULT2;
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.FAILED(sNRESULT))
			{
				PS3TMAPI.ScopedGlobalHeapPtr scopedGlobalHeapPtr = new PS3TMAPI.ScopedGlobalHeapPtr(Marshal.AllocHGlobal((int)(4u * num)));
				sNRESULT = (PS3TMAPI.Is32Bit() ? PS3TMAPI.GetProcessListX86(target, ref num, scopedGlobalHeapPtr.Get()) : PS3TMAPI.GetProcessListX64(target, ref num, scopedGlobalHeapPtr.Get()));
				if (PS3TMAPI.FAILED(sNRESULT))
				{
					sNRESULT2 = sNRESULT;
					result = sNRESULT2;
					return result;
				}
				IntPtr unmanagedBuf = scopedGlobalHeapPtr.Get();
				processIDs = new uint[num];
				for (uint num2 = 0u; num2 < num; num2 += 1u)
				{
					unmanagedBuf = PS3TMAPI.ReadDataFromUnmanagedIncPtr<uint>(unmanagedBuf, ref processIDs[(int)((uint)((UIntPtr)num2))]);
				}
			}
			sNRESULT2 = sNRESULT;
			result = sNRESULT2;
			return result;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0003DB60 File Offset: 0x0003BD60
		public static PS3TMAPI.SNRESULT ProcessAttach(int target, PS3TMAPI.UnitType unit, uint processID)
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.ProcessAttachX64(target, (uint)unit, processID);
			}
			else
			{
				result = PS3TMAPI.ProcessAttachX86(target, (uint)unit, processID);
			}
			return result;
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x0003DB94 File Offset: 0x0003BD94
		public static PS3TMAPI.SNRESULT ProcessContinue(int target, uint processID)
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.ProcessContinueX64(target, processID);
			}
			else
			{
				result = PS3TMAPI.ProcessContinueX86(target, processID);
			}
			return result;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x0003DBC8 File Offset: 0x0003BDC8
		public static PS3TMAPI.SNRESULT GetTargetInfo(ref PS3TMAPI.TargetInfo targetInfo)
		{
			PS3TMAPI.TargetInfoPriv targetInfoPriv = new PS3TMAPI.TargetInfoPriv
			{
				Flags = targetInfo.Flags,
				Target = targetInfo.Target
			};
			PS3TMAPI.SNRESULT sNRESULT = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetTargetInfoX86(ref targetInfoPriv) : PS3TMAPI.GetTargetInfoX64(ref targetInfoPriv);
			if (!PS3TMAPI.FAILED(sNRESULT))
			{
				targetInfo.Flags = targetInfoPriv.Flags;
				targetInfo.Target = targetInfoPriv.Target;
				targetInfo.Name = PS3TMAPI.Utf8ToString(targetInfoPriv.Name, 4294967295u);
				targetInfo.Type = PS3TMAPI.Utf8ToString(targetInfoPriv.Type, 4294967295u);
				targetInfo.Info = PS3TMAPI.Utf8ToString(targetInfoPriv.Info, 4294967295u);
				targetInfo.HomeDir = PS3TMAPI.Utf8ToString(targetInfoPriv.HomeDir, 4294967295u);
				targetInfo.FSDir = PS3TMAPI.Utf8ToString(targetInfoPriv.FSDir, 4294967295u);
				targetInfo.Boot = targetInfoPriv.Boot;
			}
			return sNRESULT;
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x0003DCB0 File Offset: 0x0003BEB0
		public static PS3TMAPI.SNRESULT GetTargetFromName(string name, out int target)
		{
			PS3TMAPI.ScopedGlobalHeapPtr scopedGlobalHeapPtr = new PS3TMAPI.ScopedGlobalHeapPtr(PS3TMAPI.AllocUtf8FromString(name));
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.GetTargetFromNameX64(scopedGlobalHeapPtr.Get(), out target);
			}
			else
			{
				result = PS3TMAPI.GetTargetFromNameX86(scopedGlobalHeapPtr.Get(), out target);
			}
			return result;
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x0003DCF8 File Offset: 0x0003BEF8
		public static PS3TMAPI.SNRESULT GetConnectionInfo(int target, out PS3TMAPI.TCPIPConnectProperties connectProperties)
		{
			connectProperties = null;
			PS3TMAPI.ScopedGlobalHeapPtr scopedGlobalHeapPtr = new PS3TMAPI.ScopedGlobalHeapPtr(Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PS3TMAPI.TCPIPConnectProperties))));
			PS3TMAPI.SNRESULT sNRESULT = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetConnectionInfoX86(target, scopedGlobalHeapPtr.Get()) : PS3TMAPI.GetConnectionInfoX64(target, scopedGlobalHeapPtr.Get());
			if (PS3TMAPI.SUCCEEDED(sNRESULT))
			{
				connectProperties = new PS3TMAPI.TCPIPConnectProperties();
				Marshal.PtrToStructure(scopedGlobalHeapPtr.Get(), connectProperties);
			}
			return sNRESULT;
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x0003DD70 File Offset: 0x0003BF70
		public static PS3TMAPI.SNRESULT GetConnectStatus(int target, out PS3TMAPI.ConnectStatus status, out string usage)
		{
			uint num;
			IntPtr utf;
			PS3TMAPI.SNRESULT result = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetConnectStatusX86(target, out num, out utf) : PS3TMAPI.GetConnectStatusX64(target, out num, out utf);
			status = (PS3TMAPI.ConnectStatus)num;
			usage = PS3TMAPI.Utf8ToString(utf, 4294967295u);
			return result;
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0003DDB0 File Offset: 0x0003BFB0
		public static PS3TMAPI.SNRESULT Reset(int target, PS3TMAPI.ResetParameter resetParameter)
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.ResetX64(target, (ulong)resetParameter);
			}
			else
			{
				result = PS3TMAPI.ResetX86(target, (ulong)resetParameter);
			}
			return result;
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0003DDE4 File Offset: 0x0003BFE4
		public static PS3TMAPI.SNRESULT ProcessGetMemory(int target, PS3TMAPI.UnitType unit, uint processID, ulong threadID, ulong address, ref byte[] buffer)
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.ProcessGetMemoryX64(target, unit, processID, threadID, address, buffer.Length, buffer);
			}
			else
			{
				result = PS3TMAPI.ProcessGetMemoryX86(target, unit, processID, threadID, address, buffer.Length, buffer);
			}
			return result;
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x0003DE30 File Offset: 0x0003C030
		public static PS3TMAPI.SNRESULT ProcessSetMemory(int target, PS3TMAPI.UnitType unit, uint processID, ulong threadID, ulong address, byte[] buffer)
		{
            PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.ProcessSetMemoryX64(target, unit, processID, threadID, address, buffer.Length, buffer);
			}
			else
			{
				result = PS3TMAPI.ProcessSetMemoryX86(target, unit, processID, threadID, address, buffer.Length, buffer);
			}
			return result;
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x0003DE78 File Offset: 0x0003C078
		public static PS3TMAPI.SNRESULT Disconnect(int target)
		{
			PS3TMAPI.SNRESULT result;
			if (!PS3TMAPI.Is32Bit())
			{
				result = PS3TMAPI.DisconnectX64(target);
			}
			else
			{
				result = PS3TMAPI.DisconnectX86(target);
			}
			return result;
		}

		// Token: 0x02000103 RID: 259
		public enum SNRESULT
		{
			// Token: 0x0400045D RID: 1117
			SN_E_BAD_ALIGN = -28,
			// Token: 0x0400045E RID: 1118
			SN_E_BAD_MEMSPACE = -18,
			// Token: 0x0400045F RID: 1119
			SN_E_BAD_PARAM = -21,
			// Token: 0x04000460 RID: 1120
			SN_E_BAD_TARGET = -3,
			// Token: 0x04000461 RID: 1121
			SN_E_BAD_UNIT = -11,
			// Token: 0x04000462 RID: 1122
			SN_E_BUSY = -22,
			// Token: 0x04000463 RID: 1123
			SN_E_CHECK_TARGET_CONFIGURATION = -33,
			// Token: 0x04000464 RID: 1124
			SN_E_COMMAND_CANCELLED = -36,
			// Token: 0x04000465 RID: 1125
			SN_E_COMMS_ERR = -5,
			// Token: 0x04000466 RID: 1126
			SN_E_COMMS_EVENT_MISMATCHED_ERR = -39,
			// Token: 0x04000467 RID: 1127
			SN_E_CONNECT_TO_GAMEPORT_FAILED = -35,
			// Token: 0x04000468 RID: 1128
			SN_E_CONNECTED = -38,
			// Token: 0x04000469 RID: 1129
			SN_E_DATA_TOO_LONG = -26,
			// Token: 0x0400046A RID: 1130
			SN_E_DECI_ERROR = -23,
			// Token: 0x0400046B RID: 1131
			SN_E_DEPRECATED = -27,
			// Token: 0x0400046C RID: 1132
			SN_E_DLL_NOT_INITIALISED = -15,
			// Token: 0x0400046D RID: 1133
			SN_E_ERROR = -2147483648,
			// Token: 0x0400046E RID: 1134
			SN_E_EXISTING_CALLBACK = -24,
			// Token: 0x0400046F RID: 1135
			SN_E_FILE_ERROR = -29,
			// Token: 0x04000470 RID: 1136
			SN_E_HOST_NOT_FOUND = -8,
			// Token: 0x04000471 RID: 1137
			SN_E_INSUFFICIENT_DATA = -25,
			// Token: 0x04000472 RID: 1138
			SN_E_LICENSE_ERROR = -32,
			// Token: 0x04000473 RID: 1139
			SN_E_LOAD_ELF_FAILED = -10,
			// Token: 0x04000474 RID: 1140
			SN_E_LOAD_MODULE_FAILED = -31,
			// Token: 0x04000475 RID: 1141
			SN_E_MODULE_NOT_FOUND = -34,
			// Token: 0x04000476 RID: 1142
			SN_E_NO_SEL = -20,
			// Token: 0x04000477 RID: 1143
			SN_E_NO_TARGETS,
			// Token: 0x04000478 RID: 1144
			SN_E_NOT_CONNECTED = -4,
			// Token: 0x04000479 RID: 1145
			SN_E_NOT_IMPL = -1,
			// Token: 0x0400047A RID: 1146
			SN_E_NOT_LISTED = -13,
			// Token: 0x0400047B RID: 1147
			SN_E_NOT_SUPPORTED_IN_SDK_VERSION = -30,
			// Token: 0x0400047C RID: 1148
			SN_E_OUT_OF_MEM = -12,
			// Token: 0x0400047D RID: 1149
			SN_E_PROTOCOL_ALREADY_REGISTERED = -37,
			// Token: 0x0400047E RID: 1150
			SN_E_TARGET_IN_USE = -9,
			// Token: 0x0400047F RID: 1151
			SN_E_TARGET_RUNNING = -17,
			// Token: 0x04000480 RID: 1152
			SN_E_TIMEOUT = -7,
			// Token: 0x04000481 RID: 1153
			SN_E_TM_COMMS_ERR,
			// Token: 0x04000482 RID: 1154
			SN_E_TM_NOT_RUNNING = -2,
			// Token: 0x04000483 RID: 1155
			SN_E_TM_VERSION = -14,
			// Token: 0x04000484 RID: 1156
			SN_S_NO_ACTION = 6,
			// Token: 0x04000485 RID: 1157
			SN_S_NO_MSG = 3,
			// Token: 0x04000486 RID: 1158
			SN_S_OK = 0,
			// Token: 0x04000487 RID: 1159
			SN_S_PENDING,
			// Token: 0x04000488 RID: 1160
			SN_S_REPLACED = 5,
			// Token: 0x04000489 RID: 1161
			SN_S_TARGET_STILL_REGISTERED = 7,
			// Token: 0x0400048A RID: 1162
			SN_S_TM_VERSION = 4
		}

		// Token: 0x02000104 RID: 260
		public enum UnitType
		{
			// Token: 0x0400048C RID: 1164
			PPU,
			// Token: 0x0400048D RID: 1165
			SPU,
			// Token: 0x0400048E RID: 1166
			SPURAW
		}

		// Token: 0x02000105 RID: 261
		[Flags]
		public enum ResetParameter : ulong
		{
			// Token: 0x04000490 RID: 1168
			Hard = 1uL,
			// Token: 0x04000491 RID: 1169
			Quick = 2uL,
			// Token: 0x04000492 RID: 1170
			ResetEx = 9223372036854775808uL,
			// Token: 0x04000493 RID: 1171
			Soft = 0uL
		}

		// Token: 0x02000106 RID: 262
		private class ScopedGlobalHeapPtr
		{
			// Token: 0x06000C05 RID: 3077 RVA: 0x0003DEB0 File Offset: 0x0003C0B0
			public ScopedGlobalHeapPtr(IntPtr intPtr)
			{
				this.m_intPtr = intPtr;
			}

			// Token: 0x06000C06 RID: 3078 RVA: 0x0003DED0 File Offset: 0x0003C0D0
			~ScopedGlobalHeapPtr()
			{
				if (this.m_intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.m_intPtr);
				}
			}

			// Token: 0x06000C07 RID: 3079 RVA: 0x0003DF20 File Offset: 0x0003C120
			public IntPtr Get()
			{
				return this.m_intPtr;
			}

			// Token: 0x04000494 RID: 1172
			private IntPtr m_intPtr = IntPtr.Zero;
		}

		// Token: 0x02000107 RID: 263
		public enum ConnectStatus
		{
			// Token: 0x04000496 RID: 1174
			Connected,
			// Token: 0x04000497 RID: 1175
			Connecting,
			// Token: 0x04000498 RID: 1176
			NotConnected,
			// Token: 0x04000499 RID: 1177
			InUse,
			// Token: 0x0400049A RID: 1178
			Unavailable
		}

		// Token: 0x02000108 RID: 264
		[StructLayout(LayoutKind.Sequential)]
		public class TCPIPConnectProperties
		{
			// Token: 0x0400049B RID: 1179
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string IPAddress;

			// Token: 0x0400049C RID: 1180
			public uint Port;
		}

		// Token: 0x02000109 RID: 265
		[Flags]
		public enum TargetInfoFlag : uint
		{
			// Token: 0x0400049E RID: 1182
			Boot = 32u,
			// Token: 0x0400049F RID: 1183
			FileServingDir = 16u,
			// Token: 0x040004A0 RID: 1184
			HomeDir = 8u,
			// Token: 0x040004A1 RID: 1185
			Info = 4u,
			// Token: 0x040004A2 RID: 1186
			Name = 2u,
			// Token: 0x040004A3 RID: 1187
			TargetID = 1u
		}

		// Token: 0x0200010A RID: 266
		private struct TargetInfoPriv
		{
			// Token: 0x040004A4 RID: 1188
			public PS3TMAPI.TargetInfoFlag Flags;

			// Token: 0x040004A5 RID: 1189
			public int Target;

			// Token: 0x040004A6 RID: 1190
			public IntPtr Name;

			// Token: 0x040004A7 RID: 1191
			public IntPtr Type;

			// Token: 0x040004A8 RID: 1192
			public IntPtr Info;

			// Token: 0x040004A9 RID: 1193
			public IntPtr HomeDir;

			// Token: 0x040004AA RID: 1194
			public IntPtr FSDir;

			// Token: 0x040004AB RID: 1195
			public PS3TMAPI.BootParameter Boot;
		}

		// Token: 0x0200010B RID: 267
		[Flags]
		public enum BootParameter : ulong
		{
			// Token: 0x040004AD RID: 1197
			BluRayEmuOff = 4uL,
			// Token: 0x040004AE RID: 1198
			BluRayEmuUSB = 32uL,
			// Token: 0x040004AF RID: 1199
			DebugMode = 16uL,
			// Token: 0x040004B0 RID: 1200
			Default = 0uL,
			// Token: 0x040004B1 RID: 1201
			DualNIC = 128uL,
			// Token: 0x040004B2 RID: 1202
			HDDSpeedBluRayEmu = 8uL,
			// Token: 0x040004B3 RID: 1203
			HostFSTarget = 64uL,
			// Token: 0x040004B4 RID: 1204
			MemSizeConsole = 2uL,
			// Token: 0x040004B5 RID: 1205
			ReleaseMode = 1uL,
			// Token: 0x040004B6 RID: 1206
			SystemMode = 17uL
		}

		// Token: 0x0200010C RID: 268
		public struct TargetInfo
		{
			// Token: 0x040004B7 RID: 1207
			public PS3TMAPI.TargetInfoFlag Flags;

			// Token: 0x040004B8 RID: 1208
			public int Target;

			// Token: 0x040004B9 RID: 1209
			public string Name;

			// Token: 0x040004BA RID: 1210
			public string Type;

			// Token: 0x040004BB RID: 1211
			public string Info;

			// Token: 0x040004BC RID: 1212
			public string HomeDir;

			// Token: 0x040004BD RID: 1213
			public string FSDir;

			// Token: 0x040004BE RID: 1214
			public PS3TMAPI.BootParameter Boot;
		}
	}
}
