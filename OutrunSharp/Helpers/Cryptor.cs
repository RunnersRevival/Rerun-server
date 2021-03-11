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
        private static byte[] CryptoKey = Encoding.UTF8.GetBytes("Ec7bLaTdSuXuf5pW");
        public static byte[] CryptoIV = Encoding.UTF8.GetBytes("DV3G4Kb7xflNqi5x");

        public static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) &&
                   Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);

        }
        public static string DecryptText(string text, string iv)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");
            if (!IsBase64String(text))
                throw new DecryptFailureException("The text input parameter is not base64 encoded");
            byte[] cipherText = Convert.FromBase64String(text);
            string decryptedText = null;
            try
            {
                using (Rijndael rijAlg = Rijndael.Create())
                {
                    rijAlg.BlockSize = 128;
                    rijAlg.Padding = PaddingMode.Zeros;
                    rijAlg.Key = CryptoKey;
                    rijAlg.IV = Encoding.UTF8.GetBytes(iv);

                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                decryptedText = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
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
                throw new ArgumentNullException("text");

            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.BlockSize = 128;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.Key = CryptoKey;
                rijAlg.IV = CryptoIV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }
    }
}
