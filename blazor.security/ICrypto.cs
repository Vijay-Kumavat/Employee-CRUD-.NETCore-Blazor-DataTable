using System;

namespace blazor.security
{
    public interface ICrypto : IDisposable
    {
        string Encrypt(string TextToEncrypt);

        string Decrypt(string TextToDecrypt);

        string EncryptPassword(string TextToEncrypt);

        string DecryptPassword(string TextToEncrypt);
    }
}
