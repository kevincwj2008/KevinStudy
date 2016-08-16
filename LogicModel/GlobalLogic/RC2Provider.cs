using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace XFCompany.CIPnetWeb.LogicModel
{
    /// <summary>
    /// RC2算法类
    /// </summary>
    public class RC2Provider
    {
        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <param name="strKey">密钥</param>
        /// <param name="strIV">向量</param>
        public static void RC2Key(out String strKey, out String strIV)
        {
            try
            {
                RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
                // Get the key and IV.
                strKey = Convert.ToBase64String(rc2CSP.Key);
                strIV = Convert.ToBase64String(rc2CSP.IV);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// RC2的加密函数
        /// </summary>
        /// <param name="strKey">密钥</param>
        /// <param name="strIV">向量</param>
        /// <param name="strEncryptString">源码</param>
        /// <returns></returns>
        public static string RC2Encrypt(String strKey, String strIV, String strEncryptString)
        {
            try
            {
                RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

                byte[] key = Convert.FromBase64String(strKey);
                byte[] IV = Convert.FromBase64String(strIV);

                // Get an encryptor.
                ICryptoTransform encryptor = rc2CSP.CreateEncryptor(key, IV);

                // Encrypt the data as an array of encrypted bytes in memory.
                using(MemoryStream msEncrypt = new MemoryStream())
                {
                    CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

                    // Convert the data to a byte array.
                    byte[] toEncrypt = Encoding.ASCII.GetBytes(strEncryptString);

                    // Write all data to the crypto stream and flush it.
                    csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                    csEncrypt.FlushFinalBlock();

                    // Get the encrypted array of bytes.
                    byte[] encrypted = msEncrypt.ToArray();
                    return Convert.ToBase64String(encrypted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// RC2的解密函数
        /// </summary>
        /// <param name="strKey">密钥</param>
        /// <param name="strIV">向量</param>
        /// <param name="strEncryptString">源码</param>
        /// <returns></returns>
        public static string RC2Decrypt(String strKey, String strIV, String strDecryptString)
        {
            try
            {
                RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

                byte[] key = Convert.FromBase64String(strKey);
                byte[] IV = Convert.FromBase64String(strIV);
                byte[] encrypted = Convert.FromBase64String(strDecryptString);

                //Get a decryptor that uses the same key and IV as the encryptor.
                ICryptoTransform decryptor = rc2CSP.CreateDecryptor(key, IV);

                // Now decrypt the previously encrypted message using the decryptor
                // obtained in the above step.
                using (MemoryStream msDecrypt = new MemoryStream(encrypted))
                {
                    CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

                    // Read the decrypted bytes from the decrypting stream
                    // and place them in a StringBuilder class.

                    StringBuilder roundtrip = new StringBuilder();

                    int b = 0;

                    do
                    {
                        b = csDecrypt.ReadByte();

                        if (b != -1)
                        {
                            roundtrip.Append((char)b);
                        }

                    } while (b != -1);

                    return roundtrip.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
