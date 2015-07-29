using System;
using System.Security.Cryptography;

namespace EncodingLib
{
    public class VerifySecret
    {
        private byte[] _salt = new byte[32];
        private byte[] _hash;
        private byte[] _hashBytes;

        public VerifySecret(string base64Hash, string password)
        {
            _hashBytes = Convert.FromBase64String(base64Hash);
            Array.Copy(_hashBytes, 0,_salt, 0, 32);
            var pbkdf2 = new Rfc2898DeriveBytes(password, _salt, 10000);
            _hash = pbkdf2.GetBytes(32);
        }

        public bool Verification()
        {
            for (int i = 0; i < 32; i++)
            {
                if (_hashBytes[i + 32] != _hash[i])
                    return false;
            }
            return true;
        }
    }
}