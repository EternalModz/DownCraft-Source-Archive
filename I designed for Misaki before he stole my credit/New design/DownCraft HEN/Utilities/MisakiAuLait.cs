using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MisakiAulait
{
	public static class Misaki
	{
		public static bool IsBase64String(string x)
		{
			x = x.Trim();
			return x.Length % 4 == 0 && Regex.IsMatch(x, "^[a-zA-Z0-9\\+/]*={0,3}$", RegexOptions.None);
		}

		public static string Decrypt(string data, [Optional] uint mode)
		{
			SymmetricAlgorithm symmetricAlgorithm = DES.Create();
			ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateDecryptor(Misaki.keyvault, Misaki.iv);
			byte[] array = Convert.FromBase64String(data);
			byte[] bytes = cryptoTransform.TransformFinalBlock(array, 0, array.Length);
			return Encoding.Unicode.GetString(bytes);
		}

		private static byte[] keyvault = new byte[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8
		};

		private static byte[] iv = new byte[]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8
		};
	}
}
