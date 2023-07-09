using System;
using System.Linq;
using System.Text;

namespace PS3Lib
{
	// Token: 0x02000130 RID: 304
	public class Extension
	{
		// Token: 0x06000CA7 RID: 3239 RVA: 0x0003FAA4 File Offset: 0x0003DCA4
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

		// Token: 0x06000CA8 RID: 3240 RVA: 0x0003FB08 File Offset: 0x0003DD08
		public sbyte ReadSByte(uint offset)
		{
			byte[] array = new byte[1];
			this.GetMem(offset, array, this.CurrentAPI);
			return (sbyte)array[0];
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x0003FB34 File Offset: 0x0003DD34
		public bool ReadBool(uint offset)
		{
			byte[] array = new byte[1];
			this.GetMem(offset, array, this.CurrentAPI);
			return array[0] != 0;
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x0003FB68 File Offset: 0x0003DD68
		public short ReadInt16(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 2u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 2);
			return BitConverter.ToInt16(bytes, 0);
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x0003FB9C File Offset: 0x0003DD9C
		public int ReadInt32(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 4);
			return BitConverter.ToInt32(bytes, 0);
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x0003FBD0 File Offset: 0x0003DDD0
		public long ReadInt64(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 8);
			return BitConverter.ToInt64(bytes, 0);
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x0003FC04 File Offset: 0x0003DE04
		public byte ReadByte(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 1u, this.CurrentAPI);
			return bytes[0];
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x0003FC28 File Offset: 0x0003DE28
		public byte[] ReadBytes(uint offset, int length)
		{
			return this.GetBytes(offset, (uint)length, this.CurrentAPI);
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x0003FC48 File Offset: 0x0003DE48
		public ushort ReadUInt16(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 2u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 2);
			return BitConverter.ToUInt16(bytes, 0);
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x0003FC7C File Offset: 0x0003DE7C
		public uint ReadUInt32(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 4);
			return BitConverter.ToUInt32(bytes, 0);
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x0003FCB0 File Offset: 0x0003DEB0
		public ulong ReadUInt64(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 8);
			return BitConverter.ToUInt64(bytes, 0);
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x0003FCE4 File Offset: 0x0003DEE4
		public float ReadFloat(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 4);
			return BitConverter.ToSingle(bytes, 0);
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x0003FD18 File Offset: 0x0003DF18
		public float[] ReadFloats(uint offset, int arrayLength = 3)
		{
			float[] array = new float[arrayLength];
			for (int i = 0; i < arrayLength; i++)
			{
				byte[] bytes = this.GetBytes(offset + (uint)(i * 4), 4u, this.CurrentAPI);
				Array.Reverse(bytes, 0, 4);
				array[i] = BitConverter.ToSingle(bytes, 0);
			}
			return array;
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x0003FD6C File Offset: 0x0003DF6C
		public double ReadDouble(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8u, this.CurrentAPI);
			Array.Reverse(bytes, 0, 8);
			return BitConverter.ToDouble(bytes, 0);
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x0003FDA0 File Offset: 0x0003DFA0
		public string ReadString(uint offset)
		{
			int num = 40;
			int num2 = 0;
			string text = string.Empty;
			while (!text.Contains('\0'))
			{
				byte[] bytes = this.ReadBytes(offset + (uint)num2, num);
				text += Encoding.UTF8.GetString(bytes);
				num2 += num;
			}
			return text.Substring(0, text.IndexOf('\0'));
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0003FE04 File Offset: 0x0003E004
		public void WriteSByte(uint offset, sbyte input)
		{
			this.SetMem(offset, new byte[]
			{
				(byte)input
			}, this.CurrentAPI);
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x0003FE2D File Offset: 0x0003E02D
		public void WriteBool(uint offset, bool input)
		{
			this.SetMem(offset, new byte[0], this.CurrentAPI);
		}

		// Token: 0x06000CB8 RID: 3256 RVA: 0x0003FE44 File Offset: 0x0003E044
		public void WriteInt16(uint offset, short input)
		{
			byte[] array = new byte[2];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 2);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CB9 RID: 3257 RVA: 0x0003FE80 File Offset: 0x0003E080
		public void WriteInt32(uint offset, int input)
		{
			byte[] array = new byte[4];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0003FEBC File Offset: 0x0003E0BC
		public void WriteInt64(uint offset, long input)
		{
			byte[] array = new byte[8];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x0003FEF8 File Offset: 0x0003E0F8
		public void WriteByte(uint offset, byte input)
		{
			this.SetMem(offset, new byte[]
			{
				input
			}, this.CurrentAPI);
		}

		// Token: 0x06000CBC RID: 3260 RVA: 0x0003FF20 File Offset: 0x0003E120
		public void WriteBytes(uint offset, byte[] input)
		{
			this.SetMem(offset, input, this.CurrentAPI);
		}

        internal void WriteInt16(int v1, int v2, int v3, int v4, int v5)
        {
            throw new NotImplementedException();
        }

        // Token: 0x06000CBD RID: 3261 RVA: 0x0003FF34 File Offset: 0x0003E134
        public void WriteString(uint offset, string input)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			Array.Resize<byte>(ref bytes, bytes.Length + 1);
			this.SetMem(offset, bytes, this.CurrentAPI);
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x0003FF6C File Offset: 0x0003E16C
		public void WriteUInt16(uint offset, ushort input)
		{
			byte[] array = new byte[2];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 2);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CBF RID: 3263 RVA: 0x0003FFA8 File Offset: 0x0003E1A8
		public void WriteUInt32(uint offset, uint input)
		{
			byte[] array = new byte[4];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x0003FFE4 File Offset: 0x0003E1E4
		public void WriteUInt64(uint offset, ulong input)
		{
			byte[] array = new byte[8];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x00040020 File Offset: 0x0003E220
		public void WriteFloat(uint offset, float input)
		{
			byte[] array = new byte[4];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CC2 RID: 3266 RVA: 0x0004005C File Offset: 0x0003E25C
		public void WriteFloats(uint offset, float[] input)
		{
			byte[] array = new byte[4];
			for (int i = 0; i < input.Length; i++)
			{
				BitConverter.GetBytes(input[i]).CopyTo(array, 0);
				Array.Reverse(array, 0, 4);
				this.SetMem(offset + (uint)(i * 4), array, this.CurrentAPI);
			}
		}

		// Token: 0x06000CC3 RID: 3267 RVA: 0x000400B4 File Offset: 0x0003E2B4
		public void WriteDouble(uint offset, double input)
		{
			byte[] array = new byte[8];
			BitConverter.GetBytes(input).CopyTo(array, 0);
			Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		// Token: 0x06000CC4 RID: 3268 RVA: 0x000400F0 File Offset: 0x0003E2F0
		private void SetMem(uint Address, byte[] buffer, SelectAPI API)
		{
			if (API == SelectAPI.ControlConsole)
			{
				Extension.Common.CcApi.SetMemory(Address, buffer);
			}
			else if (API == SelectAPI.TargetManager)
			{
				Extension.Common.TmApi.SetMemory(Address, buffer);
			}
		}

		// Token: 0x06000CC5 RID: 3269 RVA: 0x00040134 File Offset: 0x0003E334
		private void GetMem(uint offset, byte[] buffer, SelectAPI API)
		{
			if (API == SelectAPI.ControlConsole)
			{
				Extension.Common.CcApi.GetMemory(offset, buffer);
			}
			else if (API == SelectAPI.TargetManager)
			{
				Extension.Common.TmApi.GetMemory(offset, buffer);
			}
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00040178 File Offset: 0x0003E378
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

		// Token: 0x0400052D RID: 1325
		private SelectAPI CurrentAPI;

		// Token: 0x02000131 RID: 305
		private class Common
		{
			// Token: 0x0400052E RID: 1326
			public static CCAPI CcApi;

			// Token: 0x0400052F RID: 1327
			public static TMAPI TmApi;
		}
	}
}
