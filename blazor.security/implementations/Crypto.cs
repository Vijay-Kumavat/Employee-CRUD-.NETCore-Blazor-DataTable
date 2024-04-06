using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace blazor.security.implementations
{
    public class Crypto : ICrypto
    {
        private const string PASSWORD_SECRET_KEY = "2193D83E3FB2BDC186C91CDC1133D";
        private const string PASSWORD_IV_KEY = "953CDE9B7983762BA5BC82687BA69";

        private const string SECRET_KEY = "2193D83E3FB2BDC186C91CDC1133D";
        private const string IV_KEY = "953CDE9B7983762BA5BC82687BA69";

        public void Dispose() => GC.SuppressFinalize(this);

        public string Decrypt(string TextToDecrypt) => Decrypt(TextToDecrypt, SECRET_KEY, IV_KEY);

        public string Encrypt(string TextToEncrypt) => Encrypt(TextToEncrypt, SECRET_KEY, IV_KEY);

        public string EncryptPassword(string TextToEncrypt) => Encrypt(TextToEncrypt, PASSWORD_SECRET_KEY, PASSWORD_IV_KEY);

        public string DecryptPassword(string TextToEncrypt) => Decrypt(TextToEncrypt, PASSWORD_SECRET_KEY, PASSWORD_IV_KEY);

        #region Decrypt given string
        private string Decrypt(string cipherText, string key, string iv_key)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key + iv_key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return cipherText;

        }
        #endregion

        #region Encrypt given string
        private string Encrypt(string clearText, string key, string iv_key)
        {
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key + iv_key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return clearText;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return clearText;
        }
        #endregion
    }
}