using System;
using System.Text;

namespace PS3Lib
{
	// Token: 0x02000003 RID: 3
	public class ArrayBuilder
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ArrayBuilder(byte[] BytesArray)
		{
			this.buffer = BytesArray;
			this.size = this.buffer.Length;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x0000206D File Offset: 0x0000026D
		public ArrayBuilder.ArrayReader Read
		{
			get
			{
				return new ArrayBuilder.ArrayReader(this.buffer);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x0000207A File Offset: 0x0000027A
		public ArrayBuilder.ArrayWriter Write
		{
			get
			{
				return new ArrayBuilder.ArrayWriter(this.buffer);
			}
		}

		// Token: 0x04000004 RID: 4
		private byte[] buffer;

		// Token: 0x04000005 RID: 5
		private int size;

		// Token: 0x02000004 RID: 4
		public class ArrayReader
		{
			// Token: 0x06000004 RID: 4 RVA: 0x00002087 File Offset: 0x00000287
			public ArrayReader(byte[] BytesArray)
			{
				this.buffer = BytesArray;
				this.size = this.buffer.Length;
			}

			// Token: 0x06000005 RID: 5 RVA: 0x000020A4 File Offset: 0x000002A4
			private sbyte GetSByte(int pos)
			{
				return (sbyte)this.buffer[pos];
			}

			// Token: 0x06000006 RID: 6 RVA: 0x000020AF File Offset: 0x000002AF
			public byte GetByte(int pos)
			{
				return this.buffer[pos];
			}

			// Token: 0x06000007 RID: 7 RVA: 0x00002930 File Offset: 0x00000B30
			public char GetChar(int pos)
			{
				string text = this.buffer[pos].ToString();
				return text[0];
			}

			// Token: 0x06000008 RID: 8 RVA: 0x000020B9 File Offset: 0x000002B9
			public bool GetBool(int pos)
			{
				return this.buffer[pos] != 0;
			}

			// Token: 0x06000009 RID: 9 RVA: 0x00002958 File Offset: 0x00000B58
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

			// Token: 0x0600000A RID: 10 RVA: 0x00002998 File Offset: 0x00000B98
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

			// Token: 0x0600000B RID: 11 RVA: 0x000029D8 File Offset: 0x00000BD8
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

			// Token: 0x0600000C RID: 12 RVA: 0x00002A18 File Offset: 0x00000C18
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

			// Token: 0x0600000D RID: 13 RVA: 0x00002A58 File Offset: 0x00000C58
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

			// Token: 0x0600000E RID: 14 RVA: 0x00002A98 File Offset: 0x00000C98
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

			// Token: 0x0600000F RID: 15 RVA: 0x00002AD8 File Offset: 0x00000CD8
			public byte[] GetBytes(int pos, int length)
			{
				byte[] array = new byte[length];
				for (int i = 0; i < length; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				return array;
			}

			// Token: 0x06000010 RID: 16 RVA: 0x00002B08 File Offset: 0x00000D08
			public string GetString(int pos)
			{
				int num = 0;
				while (this.buffer[pos + num] != 0)
				{
					num++;
				}
				byte[] array = new byte[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				return Encoding.UTF8.GetString(array);
			}

			// Token: 0x06000011 RID: 17 RVA: 0x00002B54 File Offset: 0x00000D54
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

			// Token: 0x04000006 RID: 6
			private byte[] buffer;

			// Token: 0x04000007 RID: 7
			private int size;
		}

		// Token: 0x02000005 RID: 5
		public class ArrayWriter
		{
			// Token: 0x06000012 RID: 18 RVA: 0x000020C9 File Offset: 0x000002C9
			public ArrayWriter(byte[] BytesArray)
			{
				this.buffer = BytesArray;
				this.size = this.buffer.Length;
			}

			// Token: 0x06000013 RID: 19 RVA: 0x000020E6 File Offset: 0x000002E6
			public void SetSByte(int pos, sbyte value)
			{
				this.buffer[pos] = (byte)value;
			}

			// Token: 0x06000014 RID: 20 RVA: 0x000020F2 File Offset: 0x000002F2
			public void SetByte(int pos, byte value)
			{
				this.buffer[pos] = value;
			}

			// Token: 0x06000015 RID: 21 RVA: 0x00002B90 File Offset: 0x00000D90
			public void SetChar(int pos, char value)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value.ToString());
				this.buffer[pos] = bytes[0];
			}

			// Token: 0x06000016 RID: 22 RVA: 0x00002BBC File Offset: 0x00000DBC
			public void SetBool(int pos, bool value)
			{
				byte[] b = new byte[1];
				b[0] = value ? (byte)1 : (byte)0;
				buffer[pos] = b[0];
			}

			// Token: 0x06000017 RID: 23 RVA: 0x00002BE8 File Offset: 0x00000DE8
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

			// Token: 0x06000018 RID: 24 RVA: 0x00002C24 File Offset: 0x00000E24
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

			// Token: 0x06000019 RID: 25 RVA: 0x00002C60 File Offset: 0x00000E60
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

			// Token: 0x0600001A RID: 26 RVA: 0x00002C9C File Offset: 0x00000E9C
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

			// Token: 0x0600001B RID: 27 RVA: 0x00002CD8 File Offset: 0x00000ED8
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

			// Token: 0x0600001C RID: 28 RVA: 0x00002D14 File Offset: 0x00000F14
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

			// Token: 0x0600001D RID: 29 RVA: 0x00002D50 File Offset: 0x00000F50
			public void SetBytes(int pos, byte[] value)
			{
				int num = value.Length;
				for (int i = 0; i < num; i++)
				{
					this.buffer[i + pos] = value[i];
				}
			}

			// Token: 0x0600001E RID: 30 RVA: 0x00002D7C File Offset: 0x00000F7C
			public void SetString(int pos, string value)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(value + "\0");
				for (int i = 0; i < bytes.Length; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x0600001F RID: 31 RVA: 0x00002DBC File Offset: 0x00000FBC
			public void SetFloat(int pos, float value)
			{
				byte[] bytes = BitConverter.GetBytes(value);
				Array.Reverse(bytes, 0, 4);
				for (int i = 0; i < 4; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			// Token: 0x04000008 RID: 8
			private byte[] buffer;

			// Token: 0x04000009 RID: 9
			private int size;
		}
	}
}
