using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KPO_System
{
    public class Crypto
    {

        public string Decrypt(string encryptedString)
        {
            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
            desProvider.Mode = CipherMode.ECB;
            desProvider.Padding = PaddingMode.PKCS7;
            desProvider.Key = Encoding.ASCII.GetBytes("e5d66cf8");
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(encryptedString)))
            {
                using (CryptoStream cs = new CryptoStream(stream, desProvider.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs, Encoding.ASCII))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        public string Encrypt(string decryptedString)
        {
            DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
            desProvider.Mode = CipherMode.ECB;
            desProvider.Padding = PaddingMode.PKCS7;
            desProvider.Key = Encoding.ASCII.GetBytes("e5d66cf8");
            using (MemoryStream stream = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(stream, desProvider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] data = Encoding.Default.GetBytes(decryptedString);
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock(); // <-- Add this
                    return Convert.ToBase64String(stream.ToArray());
                }
            }
        }
    }
}
