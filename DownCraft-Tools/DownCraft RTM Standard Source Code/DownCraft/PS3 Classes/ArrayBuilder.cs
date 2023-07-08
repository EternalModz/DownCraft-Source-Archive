using System;
using System.Linq;
using System.Text;

namespace PS3Lib
{
	public class ArrayBuilder
	{
		public ArrayBuilder(byte[] BytesArray)
		{
			this.buffer = BytesArray;
			this.size = this.buffer.Length;
		}

		public ArrayBuilder(int arraySize)
		{
			this.buffer = new byte[arraySize];
			this.size = this.buffer.Length;
		}

		public byte[] ToArray()
		{
			return this.buffer;
		}

		public PS3Lib.ArrayBuilder.ArrayReader Read
		{
			get
			{
				return new PS3Lib.ArrayBuilder.ArrayReader(this.buffer);
			}
		}

		public PS3Lib.ArrayBuilder.ArrayWriter Write
		{
			get
			{
				return new PS3Lib.ArrayBuilder.ArrayWriter(this.buffer);
			}
		}

		private byte[] buffer;

		private int size;

		public class ArrayReader
		{
			public ArrayReader(byte[] BytesArray)
			{
				this.buffer = BytesArray;
				this.size = this.buffer.Length;
			}

			public sbyte GetSByte(int pos)
			{
				return (sbyte)this.buffer[pos];
			}

			public byte GetByte(int pos)
			{
				return this.buffer[pos];
			}

			public char GetChar(int pos)
			{
				string text = this.buffer[pos].ToString();
				return text[0];
			}

			public bool GetBool(int pos)
			{
				return this.buffer[pos] != 0;
			}

			public short GetInt16(int pos, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] array = new byte[2];
				for (int i = 0; i < 2; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(array, 0, 2);
				}
				return System.BitConverter.ToInt16(array, 0);
			}

			public int GetInt32(int pos, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] array = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(array, 0, 4);
				}
				return System.BitConverter.ToInt32(array, 0);
			}

			public long GetInt64(int pos, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] array = new byte[8];
				for (int i = 0; i < 8; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(array, 0, 8);
				}
				return System.BitConverter.ToInt64(array, 0);
			}

			public ushort GetUInt16(int pos, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] array = new byte[2];
				for (int i = 0; i < 2; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(array, 0, 2);
				}
				return System.BitConverter.ToUInt16(array, 0);
			}

			public uint GetUInt32(int pos, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] array = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(array, 0, 4);
				}
				return System.BitConverter.ToUInt32(array, 0);
			}

			public ulong GetUInt64(int pos, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] array = new byte[8];
				for (int i = 0; i < 8; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(array, 0, 8);
				}
				return System.BitConverter.ToUInt64(array, 0);
			}

			public byte[] GetBytes(int pos, int length)
			{
				byte[] array = new byte[length];
				for (int i = 0; i < length; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				return array;
			}

			public string GetString(int pos)
			{
				int num = 0;
				while (pos + num != this.buffer.Length)
				{
					if (this.buffer[pos + num] == 0)
					{
#pragma warning disable CS0164 // This label has not been referenced
						IL_3A:
#pragma warning restore CS0164 // This label has not been referenced
						return System.Text.Encoding.UTF8.GetString(this.buffer.ToList<byte>().GetRange(pos, num).ToArray());
					}
					num++;
				}
				return "";
			}

			public float GetFloat(int pos)
			{
				byte[] array = new byte[4];
				for (int i = 0; i < 4; i++)
				{
					array[i] = this.buffer[pos + i];
				}
				System.Array.Reverse(array, 0, 4);
				return System.BitConverter.ToSingle(array, 0);
			}

			private byte[] buffer;

			private int size;
		}

		public class ArrayWriter
		{
			public ArrayWriter(byte[] BytesArray)
			{
				this.buffer = BytesArray;
				this.size = this.buffer.Length;
			}

			public void SetSByte(int pos, sbyte value)
			{
				this.buffer[pos] = (byte)value;
			}

			public void SetByte(int pos, byte value)
			{
				this.buffer[pos] = value;
			}

			public void SetChar(int pos, char value)
			{
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value.ToString());
				this.buffer[pos] = bytes[0];
			}

			public void SetBool(int pos, bool value)
			{
				byte[] array = new byte[0];
				this.buffer[pos] = array[0];
			}

			public void SetInt16(int pos, short value, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] bytes = System.BitConverter.GetBytes(value);
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(bytes, 0, 2);
				}
				for (int i = 0; i < 2; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			public void SetInt32(int pos, int value, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] bytes = System.BitConverter.GetBytes(value);
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(bytes, 0, 4);
				}
				for (int i = 0; i < 4; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			public void SetInt64(int pos, long value, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] bytes = System.BitConverter.GetBytes(value);
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(bytes, 0, 8);
				}
				for (int i = 0; i < 8; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			public void SetUInt16(int pos, ushort value, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] bytes = System.BitConverter.GetBytes(value);
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(bytes, 0, 2);
				}
				for (int i = 0; i < 2; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			public void SetUInt32(int pos, uint value, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] bytes = System.BitConverter.GetBytes(value);
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(bytes, 0, 4);
				}
				for (int i = 0; i < 4; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			public void SetUInt64(int pos, ulong value, PS3Lib.EndianType Type = PS3Lib.EndianType.BigEndian)
			{
				byte[] bytes = System.BitConverter.GetBytes(value);
				if (Type == PS3Lib.EndianType.BigEndian)
				{
					System.Array.Reverse(bytes, 0, 8);
				}
				for (int i = 0; i < 8; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			public void SetBytes(int pos, byte[] value)
			{
				int num = value.Length;
				for (int i = 0; i < num; i++)
				{
					this.buffer[i + pos] = value[i];
				}
			}

			public void SetString(int pos, string value)
			{
				byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value + "\0");
				for (int i = 0; i < bytes.Length; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			public void SetFloat(int pos, float value)
			{
				byte[] bytes = System.BitConverter.GetBytes(value);
				System.Array.Reverse(bytes, 0, 4);
				for (int i = 0; i < 4; i++)
				{
					this.buffer[i + pos] = bytes[i];
				}
			}

			private byte[] buffer;

			private int size;
		}
	}
}
