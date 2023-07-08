using System;
using System.Linq;
using System.Text;

namespace PS3Lib
{
	public class Extension
	{
		public Extension(PS3Lib.SelectAPI API)
		{
			this.CurrentAPI = API;
			if (API == PS3Lib.SelectAPI.TargetManager && PS3Lib.Extension.Common.TmApi == null)
			{
				PS3Lib.Extension.Common.TmApi = new PS3Lib.TMAPI();
			}
			if (API == PS3Lib.SelectAPI.ControlConsole && PS3Lib.Extension.Common.CcApi == null)
			{
				PS3Lib.Extension.Common.CcApi = new PS3Lib.CCAPI();
			}
			if (API == PS3Lib.SelectAPI.PS3Manager && PS3Lib.Extension.Common.MaPi == null)
			{
				PS3Lib.Extension.Common.MaPi = new PS3Lib.PS3MAPI();
			}
		}

		public sbyte ReadSByte(uint offset)
		{
			byte[] array = new byte[1];
			this.GetMem(offset, array, this.CurrentAPI);
			return (sbyte)array[0];
		}

		public bool ReadBool(uint offset)
		{
			byte[] array = new byte[1];
			this.GetMem(offset, array, this.CurrentAPI);
			return array[0] != 0;
		}

		public short ReadInt16(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 2U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 2);
			return System.BitConverter.ToInt16(bytes, 0);
		}

		public int ReadInt32(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 4);
			return System.BitConverter.ToInt32(bytes, 0);
		}

		public long ReadInt64(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 8);
			return System.BitConverter.ToInt64(bytes, 0);
		}

		public byte ReadByte(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 1U, this.CurrentAPI);
			return bytes[0];
		}

		public byte[] ReadBytes(uint offset, int length)
		{
			return this.GetBytes(offset, (uint)length, this.CurrentAPI);
		}

		public ushort ReadUInt16(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 2U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 2);
			return System.BitConverter.ToUInt16(bytes, 0);
		}

		public uint ReadUInt32(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 4);
			return System.BitConverter.ToUInt32(bytes, 0);
		}

		public ulong ReadUInt64(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 8);
			return System.BitConverter.ToUInt64(bytes, 0);
		}

		public float ReadFloat(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 4U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 4);
			return System.BitConverter.ToSingle(bytes, 0);
		}

		public float[] ReadFloats(uint offset, int arrayLength = 3)
		{
			float[] array = new float[arrayLength];
			for (int i = 0; i < arrayLength; i++)
			{
				byte[] bytes = this.GetBytes(offset + (uint)(i * 4), 4U, this.CurrentAPI);
				System.Array.Reverse(bytes, 0, 4);
				array[i] = System.BitConverter.ToSingle(bytes, 0);
			}
			return array;
		}

		public double ReadDouble(uint offset)
		{
			byte[] bytes = this.GetBytes(offset, 8U, this.CurrentAPI);
			System.Array.Reverse(bytes, 0, 8);
			return System.BitConverter.ToDouble(bytes, 0);
		}

		public string ReadString(uint offset)
		{
			int num = 0x28;
			int num2 = 0;
			string text = string.Empty;
			while (!text.Contains('\0'))
			{
				byte[] bytes = this.ReadBytes(offset + (uint)num2, num);
				text += System.Text.Encoding.UTF8.GetString(bytes);
				num2 += num;
			}
			return text.Substring(0, text.IndexOf('\0'));
		}

		public void WriteSByte(uint offset, sbyte input)
		{
			this.SetMem(offset, new byte[]
			{
				(byte)input
			}, this.CurrentAPI);
		}

		public void WriteBool(uint offset, bool input)
		{
			this.SetMem(offset, new byte[] { Convert.ToByte(input) }, this.CurrentAPI);
		}

		public void WriteInt16(uint offset, short input)
		{
			byte[] array = new byte[2];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 2);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		public void WriteInt32(uint offset, int input)
		{
			byte[] array = new byte[4];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		public void WriteInt64(uint offset, long input)
		{
			byte[] array = new byte[8];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		public void WriteByte(uint offset, byte input)
		{
			this.SetMem(offset, new byte[]
			{
				input
			}, this.CurrentAPI);
		}

		public void WriteBytes(uint offset, byte[] input)
		{
			this.SetMem(offset, input, this.CurrentAPI);
		}

		public void WriteString(uint offset, string input)
		{
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
			System.Array.Resize<byte>(ref bytes, bytes.Length + 1);
			this.SetMem(offset, bytes, this.CurrentAPI);
		}

		public void WriteUInt16(uint offset, ushort input)
		{
			byte[] array = new byte[2];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 2);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		public void WriteUInt32(uint offset, uint input)
		{
			byte[] array = new byte[4];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		public void WriteUInt64(uint offset, ulong input)
		{
			byte[] array = new byte[8];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		public void WriteFloat(uint offset, float input)
		{
			byte[] array = new byte[4];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 4);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		public void WriteFloats(uint offset, float[] input)
		{
			byte[] array = new byte[4];
			for (int i = 0; i < input.Length; i++)
			{
				System.BitConverter.GetBytes(input[i]).CopyTo(array, 0);
				System.Array.Reverse(array, 0, 4);
				this.SetMem(offset + (uint)(i * 4), array, this.CurrentAPI);
			}
		}

		public void WriteDouble(uint offset, double input)
		{
			byte[] array = new byte[8];
			System.BitConverter.GetBytes(input).CopyTo(array, 0);
			System.Array.Reverse(array, 0, 8);
			this.SetMem(offset, array, this.CurrentAPI);
		}

		private void SetMem(uint Address, byte[] buffer, PS3Lib.SelectAPI API)
		{
			if (API == PS3Lib.SelectAPI.ControlConsole)
			{
				PS3Lib.Extension.Common.CcApi.SetMemory(Address, buffer);
			}
			else if (API == PS3Lib.SelectAPI.TargetManager)
			{
				PS3Lib.Extension.Common.TmApi.SetMemory(Address, buffer);
			}
			else if (API == PS3Lib.SelectAPI.PS3Manager)
			{
				PS3Lib.Extension.Common.MaPi.Process.Memory.Set(PS3Lib.PS3API.p_id, (ulong)Address, buffer);
			}
		}

		private void GetMem(uint offset, byte[] buffer, PS3Lib.SelectAPI API)
		{
			if (API == PS3Lib.SelectAPI.ControlConsole)
			{
				PS3Lib.Extension.Common.CcApi.GetMemory(offset, buffer);
			}
			else if (API == PS3Lib.SelectAPI.TargetManager)
			{
				PS3Lib.Extension.Common.TmApi.GetMemory(offset, buffer);
			}
			else if (API == PS3Lib.SelectAPI.PS3Manager)
			{
				PS3Lib.Extension.Common.MaPi.Process.Memory.Get(PS3Lib.PS3API.p_id, (ulong)offset, buffer);
			}
		}

		public int GetMemX(uint offset)
		{
			byte[] buffer = new byte[1];
			return PS3Lib.Extension.Common.CcApi.GetMemory(offset, buffer);
		}

		private byte[] GetBytes(uint offset, uint length, PS3Lib.SelectAPI API)
		{
			byte[] result = new byte[length];
			if (API == PS3Lib.SelectAPI.ControlConsole)
			{
				result = PS3Lib.Extension.Common.CcApi.GetBytes(offset, length);
			}
			else if (API == PS3Lib.SelectAPI.TargetManager)
			{
				result = PS3Lib.Extension.Common.TmApi.GetBytes(offset, length);
			}
			else if (API == PS3Lib.SelectAPI.PS3Manager)
			{
				result = PS3Lib.Extension.Common.MaPi.Process.Memory.Get(PS3Lib.PS3API.p_id, (ulong)offset, length);
			}
			return result;
		}

		private PS3Lib.SelectAPI CurrentAPI;

		private class Common
		{
			public Common()
			{
			}

			public static PS3Lib.CCAPI CcApi;

			public static PS3Lib.TMAPI TmApi;

			public static PS3Lib.PS3MAPI MaPi;
		}
	}
}
