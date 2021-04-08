using OutrunSharp.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OutrunSharp.Helpers
{
    public class Cryptor
    {
        //private static readonly byte[] OldCryptoKey = Encoding.UTF8.GetBytes("vMdkkY8bfVmUS6qr"); // used in versions prior to 1.1.0
        private static readonly byte[] CryptoKey = Encoding.UTF8.GetBytes("Ec7bLaTdSuXuf5pW");
        private static readonly byte[] CryptoIV = Encoding.UTF8.GetBytes("DV3G4Kb7xflNqi5x");

        public static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) &&
                   Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }
        public static string DecryptText(string text, string iv)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));
            if (!IsBase64String(text))
                throw new DecryptFailureException("The text input parameter is not base64 encoded");
            var cipherText = Convert.FromBase64String(text);
            string decryptedText;
            try
            {
                using var rijAlg = Rijndael.Create();
                rijAlg.BlockSize = 128;
                rijAlg.Padding = PaddingMode.Zeros;
                rijAlg.Key = CryptoKey;
                rijAlg.IV = Encoding.UTF8.GetBytes(iv);

                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using MemoryStream msDecrypt = new(cipherText);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);
                decryptedText = srDecrypt.ReadToEnd();
            }
            catch(Exception e)
            {
                throw new DecryptFailureException("Couldn't decrypt text", e);
            }
            return decryptedText;
        }

        public static string EncryptText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (var rijAlg = Rijndael.Create())
            {
                rijAlg.BlockSize = 128;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.Key = CryptoKey;
                rijAlg.IV = CryptoIV;

                // Create an encryptor to perform the stream transform.
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                {
                    swEncrypt.Write(text);
                }
                encrypted = msEncrypt.ToArray();
            }
            return Convert.ToBase64String(encrypted);
        }

        public static byte[] GetCryptoIV()
        {
            return CryptoIV;
        }

        public static string CalcMD5String(string plainText)
        {
            MD5CryptoServiceProvider cryptoMD5 = new();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var hashValue = cryptoMD5.ComputeHash(plainTextBytes);
            return hashValue.Select(b => b.ToString("X2")).Aggregate(string.Empty, (current, hexConv) => current + hexConv.ToLower());
        }
    }
}
