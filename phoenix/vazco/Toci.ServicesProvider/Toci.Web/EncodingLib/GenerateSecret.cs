using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace EncodingLib
{
    public class GenerateSecret
    {
        private byte[] _salt;
        private byte[] _hash;
        private byte[] _hashBytes = new byte[64];
        private const int iterationCount = 10000;
        private const int sourceIndex = 0;
        private const int destinationIndex = 0;
        private const int destinationOffset = 32;
        private const int copyLength = 32;
        private const int saltLength = 32;
        private const int hashLength = 32;

        private GenerateSecret()
        {
            new RNGCryptoServiceProvider().GetBytes(_salt = new byte[32]);
        }

        public GenerateSecret(string password) : this()
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, _salt, iterationCount);
            _hash = pbkdf2.GetBytes(hashLength);
            Array.Copy(_salt, sourceIndex, _hashBytes, destinationIndex, copyLength);
            Array.Copy(_hash, sourceIndex, _hashBytes, destinationOffset, copyLength);
        }

        public GenerateSecret(string password, byte[] salt) //czy to w ogóle jest potrzebne?
        {
            _salt = new byte[saltLength];
            _hash = new byte[hashLength];
            Array.Copy(salt, sourceIndex, _salt, destinationIndex, salt.Length<saltLength?salt.Length:saltLength);
            var pbkdf2 = new Rfc2898DeriveBytes(password, _salt, iterationCount);
            _hash = pbkdf2.GetBytes(hashLength);
            Array.Copy(_salt, sourceIndex, _hashBytes, destinationIndex, copyLength);
            Array.Copy(_hash, sourceIndex, _hashBytes, destinationOffset, copyLength);
        }

        public string GetSecret()
        {
            return Convert.ToBase64String(_hashBytes);
        }
    }
}
