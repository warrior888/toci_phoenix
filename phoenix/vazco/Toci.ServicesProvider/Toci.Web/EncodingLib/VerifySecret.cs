using System;
using System.Security.Cryptography;

namespace EncodingLib
{
    public class VerifySecret
    {
        private const int iterations = 10000;
        private byte[] _salt = new byte[32];
        private byte[] _hash;
        private byte[] _hashBytes;
        private const int sourceIndex = 0;
        private const int destinationIndex = 0;
        private const int copyLength = 32;
        private const int hashLength = 32;

        public VerifySecret(string base64Hash, string password)
        {
            _hashBytes = Convert.FromBase64String(base64Hash);
            Array.Copy(_hashBytes, sourceIndex,_salt, destinationIndex, copyLength);
            var pbkdf2 = new Rfc2898DeriveBytes(password, _salt, iterations);
            _hash = pbkdf2.GetBytes(hashLength);
        }

        public bool Verification()
        {
            for (int i = 0; i < hashLength; i++)
            {
                if (_hashBytes[i + hashLength] != _hash[i])
                    return false;
            }
            return true;
        }
    }
}