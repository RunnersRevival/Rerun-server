using Rerun.Exceptions;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Rerun.Helpers
{
    public class Cryptor
    {
        // ReSharper disable once CommentTypo
        private static readonly byte[] CryptoKey = Encoding.UTF8.GetBytes("Ec7bLaTdSuXuf5pW");
        private static readonly byte[] CryptoIV = Encoding.UTF8.GetBytes("DV3G4Kb7xflNqi5x");

        /// <summary>
        /// Determines whether or not a given string is a base64-encoded string.
        /// </summary>
        /// <param name="base64String">The string to check for base64 on.</param>
        /// <returns>A bool indicating whether or not <see cref="base64String"/> is a base64-encoded string.</returns>
        public static bool IsBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) &&
                   Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        /// <summary>
        /// Decrypts base64-encoded text with a given IV.
        /// </summary>
        /// <param name="text">The base64-encoded text to decrypt.</param>
        /// <param name="iv">The IV to use for decryption.</param>
        /// <returns>A string containing the decrypted text.</returns>
        /// <exception cref="ArgumentNullException">Thrown if text is null.</exception>
        /// <exception cref="DecryptFailureException">Thrown if something goes wrong during the decryption, or the given text is not base64.</exception>
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
                // TODO: this used to use Rijndael, which was deprecated in .NET 6; ensure this actually works
                using var aesAlg = Aes.Create();
                aesAlg.BlockSize = 128;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = CryptoKey;
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

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

        /// <summary>
        /// Encrypts given text into Xeen-compatible format with the Runners IV and key.
        /// </summary>
        /// <param name="text">The text to encrypt</param>
        /// <returns>A base64-encoded encrypted string</returns>
        /// <exception cref="ArgumentNullException">Thrown if text is null.</exception>
        public static string EncryptText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text));

            // TODO: this used to use Rijndael, which was deprecated in .NET 6; ensure this actually works

            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (var aesAlg = Aes.Create())
            {
                aesAlg.BlockSize = 128;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.Key = CryptoKey;
                aesAlg.IV = CryptoIV;

                // Create an encryptor to perform the stream transform.
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

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

        /// <summary>
        /// Gets the IV used for encryption and decryption of text - this should be game-specific.
        /// </summary>
        /// <returns>The IV for the game server that's being emulated.</returns>
        public static byte[] GetCryptoIV()
        {
            return CryptoIV;
        }

        /// <summary>
        /// Calculates the MD5 of a given string.
        /// </summary>
        /// <param name="plainText">The plaintext string to calculate the MD5 of.</param>
        /// <returns>A string containing the MD5 checksum of <see cref="plainText"/></returns>
        public static string CalcMD5String(string plainText)
        {
            //MD5CryptoServiceProvider cryptoMD5 = new();
            var md5alg = MD5.Create();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            //var hashValue = cryptoMD5.ComputeHash(plainTextBytes);
            var hashValue = md5alg.ComputeHash(plainTextBytes);
            return hashValue.Select(b => b.ToString("X2")).Aggregate(string.Empty, (current, hexConv) => current + hexConv.ToLower());
        }
    }
}
