using System.Security.Cryptography;
using System.Text;

namespace Encryption
{
    public class AES
    {
        private static readonly string _key = "my_16bytes_key_!";

        public static string Encrypt(string plainText)
        {
            byte[] strToEncryptByte = Encoding.UTF8.GetBytes(plainText);
            byte[] result = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, AesConfig().CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(strToEncryptByte, 0, strToEncryptByte.Length);
                    cs.FlushFinalBlock();
                    result = ms.ToArray();
                }
            }
            string cipherText = Convert.ToBase64String(result);
            return cipherText;
        }

        public static string Decrypt(string cipherText)
        {
            byte[] strToDecryptByte = Convert.FromBase64String(cipherText);
            string plainText = string.Empty;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, AesConfig().CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(strToDecryptByte, 0, strToDecryptByte.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;

                    plainText = encoding.GetString(ms.ToArray());
                }
            }

            return plainText;
        }

        /// <summary>
        /// Config you suitable AES algoritrm. In this case is AES-128 with AES/ECB/PKCS5Padding
        /// </summary>
        /// <returns></returns>
        private static Aes AesConfig()
        {
            byte[] keyAndIV = Encoding.UTF8.GetBytes(_key);
            Aes aes = Aes.Create();
            aes.Padding = PaddingMode.PKCS7; //PKCS7 is usable
            aes.Mode = CipherMode.ECB;
            aes.KeySize = 128;
            aes.BlockSize = 128;
            aes.IV = keyAndIV;
            aes.Key = keyAndIV;
            return aes;
        }
    }
}
