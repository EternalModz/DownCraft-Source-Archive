using System;
using System.Linq;
using System.Text;

namespace PS3Lib
{
	// Token: 0x02000013 RID: 19
	public class Extension
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00002327 File Offset: 0x00000527
		public Extension(SelectAPI API)
		{
			this.CurrentAPI = API;
			if (API == SelectAPI.TargetManager && Extension.Common.TmApi == null)
			{
				Extension.Common.TmApi = new TMAPI();
			}
			if (API == SelectAPI.ControlConsole && Extension.Common.CcApi == null)
			{
				Extension.Common.CcApi = new CCAPI();
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003854 File Offset: 0x00001A54
		public sbyte ReadSByte(uint offset)
		{
			byte[] array = new byte[1];
			this.GetMem(offset, array, this.CurrentAPI);
			return (sbyte)array[0];
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000387C File Offset: 0x00001A7C
		public bool ReadBool(uint offset)
		{
			byte[] array = new byte[1];
			this.GetMem(offset, array, this.CurrentAPI);
			return array[0] > 0;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000235F File Offset: 0x0000055F
		public short ReadInt16(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 2U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 2);
			return BitConverter.ToInt16(bytes, 0);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000237D File Offset: 0x0000057D
		public int ReadInt32(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 4);
			return BitConverter.ToInt32(bytes, 0);
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000239B File Offset: 0x0000059B
		public long ReadInt64(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 8);
			return BitConverter.ToInt64(bytes, 0);
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000023B9 File Offset: 0x000005B9
		public byte ReadByte(uint offset)
		{
			return this.GetBytes(offset, 1U, this.CurrentAPI)[0];
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000023CB File Offset: 0x000005CB
		public byte[] ReadBytes(uint offset, int length)
		{
			return this.GetBytes(offset, (uint)length, this.CurrentAPI);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000023DB File Offset: 0x000005DB
		public ushort ReadUInt16(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 2U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 2);
			return BitConverter.ToUInt16(bytes, 0);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000023F9 File Offset: 0x000005F9
		public uint ReadUInt32(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 4);
			return BitConverter.ToUInt32(bytes, 0);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002417 File Offset: 0x00000617
		public ulong ReadUInt64(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 8);
			return BitConverter.ToUInt64(bytes, 0);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002435 File Offset: 0x00000635
		public float ReadFloat(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 4);
			return BitConverter.ToSingle(bytes, 0);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000038A4 File Offset: 0x00001AA4
		public string ReadString(uint offset)
		{
			int num = 40;
			int num2 = 0;
			string text = "";
			do
			{
				byte[] bytes = this.ReadBytes(offset + (uint)num2, num);
				text += Encoding.UTF8.GetString(bytes);
				num2 += num;
			}
			while (!text.Contains('\0'));
			int length = text.IndexOf('\0');
			string result = text.Substring(0, length);
			text = string.Empty;
			return result;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002453 File Offset: 0x00000653
		public void WriteSByte(uint offset, sbyte input)
		{
			this.SetMem(offset, new byte[]
			{
				(byte)input
			}, this.CurrentAPI);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003900 File Offset: 0x00001B00
		public void WriteInt16(uint offset, short input)
		{
			byte[] array = new byte[2];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 2);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003938 File Offset: 0x00001B38
		public void WriteInt32(uint offset, int input)
		{
			byte[] array = new byte[4];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003970 File Offset: 0x00001B70
		public void WriteInt64(uint offset, long input)
		{
			byte[] array = new byte[8];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000246D File Offset: 0x0000066D
		public void WriteByte(uint offset, byte input)
		{
			this.SetMem(offset, new byte[]
			{
				input
			}, this.CurrentAPI);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002486 File Offset: 0x00000686
		public void WriteBytes(uint offset, byte[] input)
		{
			this.SetMem(offset, input, this.CurrentAPI);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000039A8 File Offset: 0x00001BA8
		public void WriteString(uint offset, string input)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			Array.Resize<byte>(ref bytes, bytes.Length + 1);
			this.SetMem(offset, bytes, this.CurrentAPI);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000039DC File Offset: 0x00001BDC
		public void WriteUInt16(uint offset, ushort input)
		{
			byte[] array = new byte[2];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 2);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003A14 File Offset: 0x00001C14
		public void WriteUInt32(uint offset, uint input)
		{
			byte[] array = new byte[4];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003A4C File Offset: 0x00001C4C
		public void WriteUInt64(uint offset, ulong input)
		{
			byte[] array = new byte[8];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003A84 File Offset: 0x00001C84
		public void WriteFloat(uint offset, float input)
		{
			byte[] array = new byte[4];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002496 File Offset: 0x00000696
		private void SetMem(uint Address, byte[] buffer, SelectAPI API)
		{
			if (API == SelectAPI.ControlConsole)
			{
				Extension.Common.CcApi.SetMemory(Address, buffer);
				return;
			}
			if (API == SelectAPI.TargetManager)
			{
				Extension.Common.TmApi.SetMemory(Address, buffer);
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000024B9 File Offset: 0x000006B9
		private void GetMem(uint offset, byte[] buffer, SelectAPI API)
		{
			if (API == SelectAPI.ControlConsole)
			{
				Extension.Common.CcApi.GetMemory(offset, buffer);
				return;
			}
			if (API == SelectAPI.TargetManager)
			{
				Extension.Common.TmApi.GetMemory(offset, buffer);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003ABC File Offset: 0x00001CBC
		private byte[] GetBytes(uint offset, uint length, SelectAPI API)
		{
			byte[] result = new byte[length];
			if (API == SelectAPI.ControlConsole)
			{
				result = Extension.Common.CcApi.GetBytes(offset, length);
			}
			else if (API == SelectAPI.TargetManager)
			{
				result = Extension.Common.TmApi.GetBytes(offset, length);
			}
			return result;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000024DC File Offset: 0x000006DC
		public double ReadDouble(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8U, this.CurrentAPI);
			Array.Reverse(bytes, 0, 8);
			return BitConverter.ToDouble(bytes, 0);
		}

		// Token: 0x0400004A RID: 74
		private SelectAPI CurrentAPI;

		// Token: 0x02000014 RID: 20
		private class Common
		{
			// Token: 0x0400004B RID: 75
			public static CCAPI CcApi;

			// Token: 0x0400004C RID: 76
			public static TMAPI TmApi;
		}
	}
}
