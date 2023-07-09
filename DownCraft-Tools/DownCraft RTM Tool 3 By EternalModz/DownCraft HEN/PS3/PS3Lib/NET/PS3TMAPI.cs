using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace PS3Lib.NET
{
	// Token: 0x02000022 RID: 34
	public class PS3TMAPI
	{
		// Token: 0x060000B8 RID: 184
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3InitTargetComms")]
		private static extern PS3TMAPI.SNRESULT InitTargetCommsX64();

		// Token: 0x060000B9 RID: 185
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3InitTargetComms")]
		private static extern PS3TMAPI.SNRESULT InitTargetCommsX86();

		// Token: 0x060000BA RID: 186
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOn")]
		private static extern PS3TMAPI.SNRESULT PowerOnX64(int target);

		// Token: 0x060000BB RID: 187
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOn")]
		private static extern PS3TMAPI.SNRESULT PowerOnX86(int target);

		// Token: 0x060000BC RID: 188
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOff")]
		private static extern PS3TMAPI.SNRESULT PowerOffX64(int target, uint force);

		// Token: 0x060000BD RID: 189
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3PowerOff")]
		private static extern PS3TMAPI.SNRESULT PowerOffX86(int target, uint force);

		// Token: 0x060000BE RID: 190
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Connect")]
		private static extern PS3TMAPI.SNRESULT ConnectX64(int target, string application);

		// Token: 0x060000BF RID: 191
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Connect")]
		private static extern PS3TMAPI.SNRESULT ConnectX86(int target, string application);

		// Token: 0x060000C0 RID: 192
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectionInfo")]
		private static extern PS3TMAPI.SNRESULT GetConnectionInfoX64(int target, IntPtr connectProperties);

		// Token: 0x060000C1 RID: 193
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectionInfo")]
		private static extern PS3TMAPI.SNRESULT GetConnectionInfoX86(int target, IntPtr connectProperties);

		// Token: 0x060000C2 RID: 194
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectStatus")]
		private static extern PS3TMAPI.SNRESULT GetConnectStatusX64(int target, out uint status, out IntPtr usage);

		// Token: 0x060000C3 RID: 195
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetConnectStatus")]
		private static extern PS3TMAPI.SNRESULT GetConnectStatusX86(int target, out uint status, out IntPtr usage);

		// Token: 0x060000C4 RID: 196
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int MultiByteToWideChar(int codepage, int flags, IntPtr utf8, int utf8len, StringBuilder buffer, int buflen);

		// Token: 0x060000C5 RID: 197
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessList")]
		private static extern PS3TMAPI.SNRESULT GetProcessListX64(int target, ref uint count, IntPtr processIdArray);

		// Token: 0x060000C6 RID: 198
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessList")]
		private static extern PS3TMAPI.SNRESULT GetProcessListX86(int target, ref uint count, IntPtr processIdArray);

		// Token: 0x060000C7 RID: 199
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessContinue")]
		private static extern PS3TMAPI.SNRESULT ProcessContinueX64(int target, uint processId);

		// Token: 0x060000C8 RID: 200
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessContinue")]
		private static extern PS3TMAPI.SNRESULT ProcessContinueX86(int target, uint processId);

		// Token: 0x060000C9 RID: 201
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessAttach")]
		private static extern PS3TMAPI.SNRESULT ProcessAttachX64(int target, uint unitId, uint processId);

		// Token: 0x060000CA RID: 202
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessAttach")]
		private static extern PS3TMAPI.SNRESULT ProcessAttachX86(int target, uint unitId, uint processId);

		// Token: 0x060000CB RID: 203
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessGetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessGetMemoryX64(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x060000CC RID: 204
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessGetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessGetMemoryX86(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x060000CD RID: 205
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetFromName")]
		private static extern PS3TMAPI.SNRESULT GetTargetFromNameX64(IntPtr name, out int target);

		// Token: 0x060000CE RID: 206
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetFromName")]
		private static extern PS3TMAPI.SNRESULT GetTargetFromNameX86(IntPtr name, out int target);

		// Token: 0x060000CF RID: 207
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Reset")]
		private static extern PS3TMAPI.SNRESULT ResetX64(int target, ulong resetParameter);

		// Token: 0x060000D0 RID: 208
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Reset")]
		private static extern PS3TMAPI.SNRESULT ResetX86(int target, ulong resetParameter);

		// Token: 0x060000D1 RID: 209
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessSetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessSetMemoryX64(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x060000D2 RID: 210
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3ProcessSetMemory")]
		private static extern PS3TMAPI.SNRESULT ProcessSetMemoryX86(int target, PS3TMAPI.UnitType unit, uint processId, ulong threadId, ulong address, int count, byte[] buffer);

		// Token: 0x060000D3 RID: 211
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetInfo")]
		private static extern PS3TMAPI.SNRESULT GetTargetInfoX64(ref PS3TMAPI.TargetInfoPriv targetInfoPriv);

		// Token: 0x060000D4 RID: 212
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3GetTargetInfo")]
		private static extern PS3TMAPI.SNRESULT GetTargetInfoX86(ref PS3TMAPI.TargetInfoPriv targetInfoPriv);

		// Token: 0x060000D5 RID: 213
		[DllImport("PS3TMAPIX64.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Disconnect")]
		private static extern PS3TMAPI.SNRESULT DisconnectX64(int target);

		// Token: 0x060000D6 RID: 214
		[DllImport("PS3TMAPI.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SNPS3Disconnect")]
		private static extern PS3TMAPI.SNRESULT DisconnectX86(int target);

		// Token: 0x060000D7 RID: 215 RVA: 0x000027B7 File Offset: 0x000009B7
		private static bool Is32Bit()
		{
			return IntPtr.Size == 4;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000027C1 File Offset: 0x000009C1
		public static bool FAILED(PS3TMAPI.SNRESULT res)
		{
			return !PS3TMAPI.SUCCEEDED(res);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000027CC File Offset: 0x000009CC
		public static bool SUCCEEDED(PS3TMAPI.SNRESULT res)
		{
			return res >= PS3TMAPI.SNRESULT.SN_S_OK;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004BD4 File Offset: 0x00002DD4
		private static IntPtr AllocUtf8FromString(string wcharString)
		{
			if (wcharString == null)
			{
				return IntPtr.Zero;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(wcharString);
			IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length + 1);
			Marshal.Copy(bytes, 0, intPtr, bytes.Length);
			Marshal.WriteByte((IntPtr)(intPtr.ToInt64() + (long)bytes.Length), 0);
			return intPtr;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004C24 File Offset: 0x00002E24
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

		// Token: 0x060000DC RID: 220 RVA: 0x000027D5 File Offset: 0x000009D5
		private static IntPtr ReadDataFromUnmanagedIncPtr<T>(IntPtr unmanagedBuf, ref T storage)
		{
			storage = (T)((object)Marshal.PtrToStructure(unmanagedBuf, typeof(T)));
			return new IntPtr(unmanagedBuf.ToInt64() + (long)Marshal.SizeOf(storage));
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002810 File Offset: 0x00000A10
		public static PS3TMAPI.SNRESULT InitTargetComms()
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.InitTargetCommsX64();
			}
			return PS3TMAPI.InitTargetCommsX86();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00002824 File Offset: 0x00000A24
		public static PS3TMAPI.SNRESULT Connect(int target, string application)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.ConnectX64(target, application);
			}
			return PS3TMAPI.ConnectX86(target, application);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000283C File Offset: 0x00000A3C
		public static PS3TMAPI.SNRESULT PowerOn(int target)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.PowerOnX64(target);
			}
			return PS3TMAPI.PowerOnX86(target);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004C68 File Offset: 0x00002E68
		public static PS3TMAPI.SNRESULT PowerOff(int target, bool bForce)
		{
			uint force = bForce ? 1U : 0U;
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.PowerOffX64(target, force);
			}
			return PS3TMAPI.PowerOffX86(target, force);
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00004C94 File Offset: 0x00002E94
		public static PS3TMAPI.SNRESULT GetProcessList(int target, out uint[] processIDs)
		{
			processIDs = null;
			uint num = 0U;
			PS3TMAPI.SNRESULT snresult = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetProcessListX86(target, ref num, IntPtr.Zero) : PS3TMAPI.GetProcessListX64(target, ref num, IntPtr.Zero);
			if (!PS3TMAPI.FAILED(snresult))
			{
				PS3TMAPI.ScopedGlobalHeapPtr scopedGlobalHeapPtr = new PS3TMAPI.ScopedGlobalHeapPtr(Marshal.AllocHGlobal((int)(4U * num)));
				snresult = (PS3TMAPI.Is32Bit() ? PS3TMAPI.GetProcessListX86(target, ref num, scopedGlobalHeapPtr.Get()) : PS3TMAPI.GetProcessListX64(target, ref num, scopedGlobalHeapPtr.Get()));
				if (PS3TMAPI.FAILED(snresult))
				{
					return snresult;
				}
				IntPtr unmanagedBuf = scopedGlobalHeapPtr.Get();
				processIDs = new uint[num];
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					unmanagedBuf = PS3TMAPI.ReadDataFromUnmanagedIncPtr<uint>(unmanagedBuf, ref processIDs[(int)((UIntPtr)num2)]);
				}
			}
			return snresult;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00002852 File Offset: 0x00000A52
		public static PS3TMAPI.SNRESULT ProcessAttach(int target, PS3TMAPI.UnitType unit, uint processID)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.ProcessAttachX64(target, (uint)unit, processID);
			}
			return PS3TMAPI.ProcessAttachX86(target, (uint)unit, processID);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000286C File Offset: 0x00000A6C
		public static PS3TMAPI.SNRESULT ProcessContinue(int target, uint processID)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.ProcessContinueX64(target, processID);
			}
			return PS3TMAPI.ProcessContinueX86(target, processID);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004D44 File Offset: 0x00002F44
		public static PS3TMAPI.SNRESULT GetTargetInfo(ref PS3TMAPI.TargetInfo targetInfo)
		{
			PS3TMAPI.TargetInfoPriv targetInfoPriv = new PS3TMAPI.TargetInfoPriv
			{
				Flags = targetInfo.Flags,
				Target = targetInfo.Target
			};
			PS3TMAPI.SNRESULT snresult = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetTargetInfoX86(ref targetInfoPriv) : PS3TMAPI.GetTargetInfoX64(ref targetInfoPriv);
			if (!PS3TMAPI.FAILED(snresult))
			{
				targetInfo.Flags = targetInfoPriv.Flags;
				targetInfo.Target = targetInfoPriv.Target;
				targetInfo.Name = PS3TMAPI.Utf8ToString(targetInfoPriv.Name, uint.MaxValue);
				targetInfo.Type = PS3TMAPI.Utf8ToString(targetInfoPriv.Type, uint.MaxValue);
				targetInfo.Info = PS3TMAPI.Utf8ToString(targetInfoPriv.Info, uint.MaxValue);
				targetInfo.HomeDir = PS3TMAPI.Utf8ToString(targetInfoPriv.HomeDir, uint.MaxValue);
				targetInfo.FSDir = PS3TMAPI.Utf8ToString(targetInfoPriv.FSDir, uint.MaxValue);
				targetInfo.Boot = targetInfoPriv.Boot;
			}
			return snresult;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00004E20 File Offset: 0x00003020
		public static PS3TMAPI.SNRESULT GetTargetFromName(string name, out int target)
		{
			PS3TMAPI.ScopedGlobalHeapPtr scopedGlobalHeapPtr = new PS3TMAPI.ScopedGlobalHeapPtr(PS3TMAPI.AllocUtf8FromString(name));
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.GetTargetFromNameX64(scopedGlobalHeapPtr.Get(), out target);
			}
			return PS3TMAPI.GetTargetFromNameX86(scopedGlobalHeapPtr.Get(), out target);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004E5C File Offset: 0x0000305C
		public static PS3TMAPI.SNRESULT GetConnectionInfo(int target, out PS3TMAPI.TCPIPConnectProperties connectProperties)
		{
			connectProperties = null;
			PS3TMAPI.ScopedGlobalHeapPtr scopedGlobalHeapPtr = new PS3TMAPI.ScopedGlobalHeapPtr(Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PS3TMAPI.TCPIPConnectProperties))));
			PS3TMAPI.SNRESULT snresult = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetConnectionInfoX86(target, scopedGlobalHeapPtr.Get()) : PS3TMAPI.GetConnectionInfoX64(target, scopedGlobalHeapPtr.Get());
			if (PS3TMAPI.SUCCEEDED(snresult))
			{
				connectProperties = new PS3TMAPI.TCPIPConnectProperties();
				Marshal.PtrToStructure(scopedGlobalHeapPtr.Get(), connectProperties);
			}
			return snresult;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00004EC8 File Offset: 0x000030C8
		public static PS3TMAPI.SNRESULT GetConnectStatus(int target, out PS3TMAPI.ConnectStatus status, out string usage)
		{
			uint num;
			IntPtr utf;
			PS3TMAPI.SNRESULT result = PS3TMAPI.Is32Bit() ? PS3TMAPI.GetConnectStatusX86(target, out num, out utf) : PS3TMAPI.GetConnectStatusX64(target, out num, out utf);
			status = (PS3TMAPI.ConnectStatus)num;
			usage = PS3TMAPI.Utf8ToString(utf, uint.MaxValue);
			return result;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00002884 File Offset: 0x00000A84
		public static PS3TMAPI.SNRESULT Reset(int target, PS3TMAPI.ResetParameter resetParameter)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.ResetX64(target, (ulong)resetParameter);
			}
			return PS3TMAPI.ResetX86(target, (ulong)resetParameter);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000289C File Offset: 0x00000A9C
		public static PS3TMAPI.SNRESULT ProcessGetMemory(int target, PS3TMAPI.UnitType unit, uint processID, ulong threadID, ulong address, ref byte[] buffer)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.ProcessGetMemoryX64(target, unit, processID, threadID, address, buffer.Length, buffer);
			}
			return PS3TMAPI.ProcessGetMemoryX86(target, unit, processID, threadID, address, buffer.Length, buffer);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000028CC File Offset: 0x00000ACC
		public static PS3TMAPI.SNRESULT ProcessSetMemory(int target, PS3TMAPI.UnitType unit, uint processID, ulong threadID, ulong address, byte[] buffer)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.ProcessSetMemoryX64(target, unit, processID, threadID, address, buffer.Length, buffer);
			}
			return PS3TMAPI.ProcessSetMemoryX86(target, unit, processID, threadID, address, buffer.Length, buffer);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000028F8 File Offset: 0x00000AF8
		public static PS3TMAPI.SNRESULT Disconnect(int target)
		{
			if (!PS3TMAPI.Is32Bit())
			{
				return PS3TMAPI.DisconnectX64(target);
			}
			return PS3TMAPI.DisconnectX86(target);
		}

		// Token: 0x02000023 RID: 35
		public enum SNRESULT
		{
			// Token: 0x0400007C RID: 124
			SN_E_BAD_ALIGN = -28,
			// Token: 0x0400007D RID: 125
			SN_E_BAD_MEMSPACE = -18,
			// Token: 0x0400007E RID: 126
			SN_E_BAD_PARAM = -21,
			// Token: 0x0400007F RID: 127
			SN_E_BAD_TARGET = -3,
			// Token: 0x04000080 RID: 128
			SN_E_BAD_UNIT = -11,
			// Token: 0x04000081 RID: 129
			SN_E_BUSY = -22,
			// Token: 0x04000082 RID: 130
			SN_E_CHECK_TARGET_CONFIGURATION = -33,
			// Token: 0x04000083 RID: 131
			SN_E_COMMAND_CANCELLED = -36,
			// Token: 0x04000084 RID: 132
			SN_E_COMMS_ERR = -5,
			// Token: 0x04000085 RID: 133
			SN_E_COMMS_EVENT_MISMATCHED_ERR = -39,
			// Token: 0x04000086 RID: 134
			SN_E_CONNECT_TO_GAMEPORT_FAILED = -35,
			// Token: 0x04000087 RID: 135
			SN_E_CONNECTED = -38,
			// Token: 0x04000088 RID: 136
			SN_E_DATA_TOO_LONG = -26,
			// Token: 0x04000089 RID: 137
			SN_E_DECI_ERROR = -23,
			// Token: 0x0400008A RID: 138
			SN_E_DEPRECATED = -27,
			// Token: 0x0400008B RID: 139
			SN_E_DLL_NOT_INITIALISED = -15,
			// Token: 0x0400008C RID: 140
			SN_E_ERROR = -2147483648,
			// Token: 0x0400008D RID: 141
			SN_E_EXISTING_CALLBACK = -24,
			// Token: 0x0400008E RID: 142
			SN_E_FILE_ERROR = -29,
			// Token: 0x0400008F RID: 143
			SN_E_HOST_NOT_FOUND = -8,
			// Token: 0x04000090 RID: 144
			SN_E_INSUFFICIENT_DATA = -25,
			// Token: 0x04000091 RID: 145
			SN_E_LICENSE_ERROR = -32,
			// Token: 0x04000092 RID: 146
			SN_E_LOAD_ELF_FAILED = -10,
			// Token: 0x04000093 RID: 147
			SN_E_LOAD_MODULE_FAILED = -31,
			// Token: 0x04000094 RID: 148
			SN_E_MODULE_NOT_FOUND = -34,
			// Token: 0x04000095 RID: 149
			SN_E_NO_SEL = -20,
			// Token: 0x04000096 RID: 150
			SN_E_NO_TARGETS,
			// Token: 0x04000097 RID: 151
			SN_E_NOT_CONNECTED = -4,
			// Token: 0x04000098 RID: 152
			SN_E_NOT_IMPL = -1,
			// Token: 0x04000099 RID: 153
			SN_E_NOT_LISTED = -13,
			// Token: 0x0400009A RID: 154
			SN_E_NOT_SUPPORTED_IN_SDK_VERSION = -30,
			// Token: 0x0400009B RID: 155
			SN_E_OUT_OF_MEM = -12,
			// Token: 0x0400009C RID: 156
			SN_E_PROTOCOL_ALREADY_REGISTERED = -37,
			// Token: 0x0400009D RID: 157
			SN_E_TARGET_IN_USE = -9,
			// Token: 0x0400009E RID: 158
			SN_E_TARGET_RUNNING = -17,
			// Token: 0x0400009F RID: 159
			SN_E_TIMEOUT = -7,
			// Token: 0x040000A0 RID: 160
			SN_E_TM_COMMS_ERR,
			// Token: 0x040000A1 RID: 161
			SN_E_TM_NOT_RUNNING = -2,
			// Token: 0x040000A2 RID: 162
			SN_E_TM_VERSION = -14,
			// Token: 0x040000A3 RID: 163
			SN_S_NO_ACTION = 6,
			// Token: 0x040000A4 RID: 164
			SN_S_NO_MSG = 3,
			// Token: 0x040000A5 RID: 165
			SN_S_OK = 0,
			// Token: 0x040000A6 RID: 166
			SN_S_PENDING,
			// Token: 0x040000A7 RID: 167
			SN_S_REPLACED = 5,
			// Token: 0x040000A8 RID: 168
			SN_S_TARGET_STILL_REGISTERED = 7,
			// Token: 0x040000A9 RID: 169
			SN_S_TM_VERSION = 4
		}

		// Token: 0x02000024 RID: 36
		public enum UnitType
		{
			// Token: 0x040000AB RID: 171
			PPU,
			// Token: 0x040000AC RID: 172
			SPU,
			// Token: 0x040000AD RID: 173
			SPURAW
		}

		// Token: 0x02000025 RID: 37
		[Flags]
		public enum ResetParameter : ulong
		{
			// Token: 0x040000AF RID: 175
			Hard = 1UL,
			// Token: 0x040000B0 RID: 176
			Quick = 2UL,
			// Token: 0x040000B1 RID: 177
			ResetEx = 9223372036854775808UL,
			// Token: 0x040000B2 RID: 178
			Soft = 0UL
		}

		// Token: 0x02000026 RID: 38
		private class ScopedGlobalHeapPtr
		{
			// Token: 0x060000ED RID: 237 RVA: 0x0000290E File Offset: 0x00000B0E
			public ScopedGlobalHeapPtr(IntPtr intPtr)
			{
				this.m_intPtr = intPtr;
			}

			// Token: 0x060000EE RID: 238 RVA: 0x00004F00 File Offset: 0x00003100
			~ScopedGlobalHeapPtr()
			{
				if (this.m_intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.m_intPtr);
				}
			}

			// Token: 0x060000EF RID: 239 RVA: 0x00002928 File Offset: 0x00000B28
			public IntPtr Get()
			{
				return this.m_intPtr;
			}

			// Token: 0x040000B3 RID: 179
			private IntPtr m_intPtr = IntPtr.Zero;
		}

		// Token: 0x02000027 RID: 39
		public enum ConnectStatus
		{
			// Token: 0x040000B5 RID: 181
			Connected,
			// Token: 0x040000B6 RID: 182
			Connecting,
			// Token: 0x040000B7 RID: 183
			NotConnected,
			// Token: 0x040000B8 RID: 184
			InUse,
			// Token: 0x040000B9 RID: 185
			Unavailable
		}

		// Token: 0x02000028 RID: 40
		[StructLayout(LayoutKind.Sequential)]
		public class TCPIPConnectProperties
		{
			// Token: 0x040000BA RID: 186
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
			public string IPAddress;

			// Token: 0x040000BB RID: 187
			public uint Port;
		}

		// Token: 0x02000029 RID: 41
		[Flags]
		public enum TargetInfoFlag : uint
		{
			// Token: 0x040000BD RID: 189
			Boot = 32U,
			// Token: 0x040000BE RID: 190
			FileServingDir = 16U,
			// Token: 0x040000BF RID: 191
			HomeDir = 8U,
			// Token: 0x040000C0 RID: 192
			Info = 4U,
			// Token: 0x040000C1 RID: 193
			Name = 2U,
			// Token: 0x040000C2 RID: 194
			TargetID = 1U
		}

		// Token: 0x0200002A RID: 42
		private struct TargetInfoPriv
		{
			// Token: 0x040000C3 RID: 195
			public PS3TMAPI.TargetInfoFlag Flags;

			// Token: 0x040000C4 RID: 196
			public int Target;

			// Token: 0x040000C5 RID: 197
			public IntPtr Name;

			// Token: 0x040000C6 RID: 198
			public IntPtr Type;

			// Token: 0x040000C7 RID: 199
			public IntPtr Info;

			// Token: 0x040000C8 RID: 200
			public IntPtr HomeDir;

			// Token: 0x040000C9 RID: 201
			public IntPtr FSDir;

			// Token: 0x040000CA RID: 202
			public PS3TMAPI.BootParameter Boot;
		}

		// Token: 0x0200002B RID: 43
		[Flags]
		public enum BootParameter : ulong
		{
			// Token: 0x040000CC RID: 204
			BluRayEmuOff = 4UL,
			// Token: 0x040000CD RID: 205
			BluRayEmuUSB = 32UL,
			// Token: 0x040000CE RID: 206
			DebugMode = 16UL,
			// Token: 0x040000CF RID: 207
			Default = 0UL,
			// Token: 0x040000D0 RID: 208
			DualNIC = 128UL,
			// Token: 0x040000D1 RID: 209
			HDDSpeedBluRayEmu = 8UL,
			// Token: 0x040000D2 RID: 210
			HostFSTarget = 64UL,
			// Token: 0x040000D3 RID: 211
			MemSizeConsole = 2UL,
			// Token: 0x040000D4 RID: 212
			ReleaseMode = 1UL,
			// Token: 0x040000D5 RID: 213
			SystemMode = 17UL
		}

		// Token: 0x0200002C RID: 44
		public struct TargetInfo
		{
			// Token: 0x040000D6 RID: 214
			public PS3TMAPI.TargetInfoFlag Flags;

			// Token: 0x040000D7 RID: 215
			public int Target;

			// Token: 0x040000D8 RID: 216
			public string Name;

			// Token: 0x040000D9 RID: 217
			public string Type;

			// Token: 0x040000DA RID: 218
			public string Info;

			// Token: 0x040000DB RID: 219
			public string HomeDir;

			// Token: 0x040000DC RID: 220
			public string FSDir;

			// Token: 0x040000DD RID: 221
			public PS3TMAPI.BootParameter Boot;
		}
	}
}
