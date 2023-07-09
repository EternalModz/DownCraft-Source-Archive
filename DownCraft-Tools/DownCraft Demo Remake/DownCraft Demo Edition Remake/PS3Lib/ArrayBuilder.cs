using System;
using System.Text;

namespace PS3Lib
{
	// Token: 0x0200010D RID: 269
	public class ArrayBuilder
	{
		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000C09 RID: 3081 RVA: 0x0003DF40 File Offset: 0x0003C140
		public ArrayBuilder.ArrayReader Read
		{
			get
			{
				return new ArrayBuilder.ArrayReader(this.buffer);
			}
		}

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x0003DF60 File Offset: 0x0003C160
		public ArrayBuilder.ArrayWriter Write
		{
			get
			{
				return new ArrayBuilder.ArrayWriter(this.buffer);
			}
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0003DF7D File Offset: 0x0003C17D
		public ArrayBuilder(byte[] BytesArray)
		{
			this.buffer = BytesArray;
			this.size = this.buffer.Length;
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x0003DF9D File Offset: 0x0003C19D
		public ArrayBuilder(int arraySize)
		{
			this.buffer = new byte[arraySize];
			this.size = this.buffer.Length;
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x0003DFC4 File Offset: 0x0003C1C4
		public byte[] ToArray()
		{
			return this.buffer;
		}

		// Token: 0x040004BF RID: 1215
		private byte[] buffer;

		// Token: 0x040004C0 RID: 1216
		private int size;

		// Token: 0x0200010E RID: 270
		public class ArrayReader
		{
			// Token: 0x06000C0E RID: 3086 RVA: 0x0003DFDC File Offset: 0x0003C1DC
			public ArrayReader(byte[] BytesArray)
			{
				this.buffer = BytesArray;
				this.size = this.buffer.Length;
			}

			// Token: 0x06000C0F RID: 3087 RVA: 0x0003DFFC File Offset: 0x0003C1FC
			public sbyte GetSByte(int pos)
			{
				return (sbyte)this.buffer[pos];
			}

			// Token: 0x06000C10 RID: 3088 RVA: 0x0003E018 File Offset: 0x0003C218
			public byte GetByte(int pos)
			{
				return this.buffer[pos];
			}

			// Token: 0x06000C11 RID: 3089 RVA: 0x0003E034 File Offset: 0x0003C234
			public char GetChar(int pos)
			{
				string text = this.buffer[pos].ToString();
				return text[0];
			}

			// Token: 0x06000C12 RID: 3090 RVA: 0x0003E060 File Offset: 0x0003C260
			public bool GetBool(int pos)
			{
				return this.buffer[pos] != 0;
			}

			// Token: 0x06000C13 RID: 3091 RVA: 0x0003E080 File Offset: 0x0003C280
			public short GetInt16(int pos, EndianType Type = EndianType.BigEndian)
			{
				byte[] array = new byte[2];
				for (int i = 0; i < 2; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(array, 0, 2);
				}
				return BitConverter.ToInt16(array, 0);
			}

			// Token: 0x06000C14 RID: 3092 RVA: 0x0003E0D8 File Offset: 0x0003C2D8
			public int GetInt32(int pos, EndianType Type = EndianType.BigEndian)
			{
				byte[] array = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(array, 0, 4);
				}
				return BitConverter.ToInt32(array, 0);
			}

			// Token: 0x06000C15 RID: 3093 RVA: 0x0003E130 File Offset: 0x0003C330
			public long GetInt64(int pos, EndianType Type = EndianType.BigEndian)
			{
				byte[] array = new byte[8];
				for (int i = 0; i < 8; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(array, 0, 8);
				}
				return BitConverter.ToInt64(array, 0);
			}

			// Token: 0x06000C16 RID: 3094 RVA: 0x0003E188 File Offset: 0x0003C388
			public ushort GetUInt16(int pos, EndianType Type = EndianType.BigEndian)
			{
				byte[] array = new byte[2];
				for (int i = 0; i < 2; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(array, 0, 2);
				}
				return BitConverter.ToUInt16(array, 0);
			}

			// Token: 0x06000C17 RID: 3095 RVA: 0x0003E1E0 File Offset: 0x0003C3E0
			public uint GetUInt32(int pos, EndianType Type = EndianType.BigEndian)
			{
				byte[] array = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(array, 0, 4);
				}
				return BitConverter.ToUInt32(array, 0);
			}

			// Token: 0x06000C18 RID: 3096 RVA: 0x0003E238 File Offset: 0x0003C438
			public ulong GetUInt64(int pos, EndianType Type = EndianType.BigEndian)
			{
				byte[] array = new byte[8];
				for (int i = 0; i < 8; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(array, 0, 8);
				}
				return BitConverter.ToUInt64(array, 0);
			}

			// Token: 0x06000C19 RID: 3097 RVA: 0x0003E290 File Offset: 0x0003C490
			public byte[] GetBytes(int pos, int length)
			{
				byte[] array = new byte[length];
				for (int i = 0; i < length; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				return array;
			}

			// Token: 0x06000C1A RID: 3098 RVA: 0x0003E2CC File Offset: 0x0003C4CC
			public float GetFloat(int pos)
			{
				byte[] array = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				Array.Reverse(array, 0, 4);
				return BitConverter.ToSingle(array, 0);
			}

			// Token: 0x040004C1 RID: 1217
			private byte[] buffer;

			// Token: 0x040004C2 RID: 1218
			private int size;
		}

		// Token: 0x0200010F RID: 271
		public class ArrayWriter
		{
			// Token: 0x06000C1B RID: 3099 RVA: 0x0003E314 File Offset: 0x0003C514
			public ArrayWriter(byte[] BytesArray)
			{
				this.buffer = BytesArray;
				this.size = this.buffer.Length;
			}

			// Token: 0x06000C1C RID: 3100 RVA: 0x0003E334 File Offset: 0x0003C534
			public void SetSByte(int pos, sbyte value)
			{
				this.buffer[pos] = (byte)value;
			}

			// Token: 0x06000C1D RID: 3101 RVA: 0x0003E341 File Offset: 0x0003C541
			public void SetByte(int pos, byte value)
			{
				this.buffer[pos] = value;
			}

			// Token: 0x06000C1E RID: 3102 RVA: 0x0003E350 File Offset: 0x0003C550
			public void SetChar(int pos, char value)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value.ToString());
				this.buffer[pos] = bytes[0];
			}

			// Token: 0x06000C1F RID: 3103 RVA: 0x0003E37C File Offset: 0x0003C57C
			public void SetBool(int pos, bool value)
			{
				byte[] array = new byte[0];
				this.buffer[pos] = array[0];
			}

			// Token: 0x06000C20 RID: 3104 RVA: 0x0003E39C File Offset: 0x0003C59C
			public void SetInt16(int pos, short value, EndianType Type = EndianType.BigEndian)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(bytes, 0, 2);
				}
				for (int i = 0; i < 2; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x06000C21 RID: 3105 RVA: 0x0003E3E8 File Offset: 0x0003C5E8
			public void SetInt32(int pos, int value, EndianType Type = EndianType.BigEndian)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(bytes, 0, 4);
				}
				for (int i = 0; i < 4; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x06000C22 RID: 3106 RVA: 0x0003E434 File Offset: 0x0003C634
			public void SetInt64(int pos, long value, EndianType Type = EndianType.BigEndian)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(bytes, 0, 8);
				}
				for (int i = 0; i < 8; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x06000C23 RID: 3107 RVA: 0x0003E480 File Offset: 0x0003C680
			public void SetUInt16(int pos, ushort value, EndianType Type = EndianType.BigEndian)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(bytes, 0, 2);
				}
				for (int i = 0; i < 2; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x06000C24 RID: 3108 RVA: 0x0003E4CC File Offset: 0x0003C6CC
			public void SetUInt32(int pos, uint value, EndianType Type = EndianType.BigEndian)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(bytes, 0, 4);
				}
				for (int i = 0; i < 4; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x06000C25 RID: 3109 RVA: 0x0003E518 File Offset: 0x0003C718
			public void SetUInt64(int pos, ulong value, EndianType Type = EndianType.BigEndian)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				if (Type == EndianType.BigEndian)
				{
					Array.Reverse(bytes, 0, 8);
				}
				for (int i = 0; i < 8; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x06000C26 RID: 3110 RVA: 0x0003E564 File Offset: 0x0003C764
			public void SetBytes(int pos, byte[] value)
			{
				int num = value.Length;
				for (int i = 0; i < num; i++)
				{
					this.buffer[i + pos] = value[i];
				}
			}

			// Token: 0x06000C27 RID: 3111 RVA: 0x0003E598 File Offset: 0x0003C798
			public void SetString(int pos, string value)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value + "\0");
				for (int i = 0; i < bytes.Length; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x06000C28 RID: 3112 RVA: 0x0003E5E0 File Offset: 0x0003C7E0
			public void SetFloat(int pos, float value)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				Array.Reverse(bytes, 0, 4);
				for (int i = 0; i < 4; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x040004C3 RID: 1219
			private byte[] buffer;

			// Token: 0x040004C4 RID: 1220
			private int size;
		}
	}
}
