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
        
        private GenerateSecret()
        {
            new RNGCryptoServiceProvider().GetBytes(_salt = new byte[32]);
        }

        public GenerateSecret(string password) : this()
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, _salt, 10000);
            _hash = pbkdf2.GetBytes(32);
            Array.Copy(_salt, 0, _hashBytes, 0, 32);
            Array.Copy(_hash, 0, _hashBytes, 32, 32);
        }

        public GenerateSecret(string password, byte[] salt) //czy to w ogóle jest potrzebne?
        {
            _salt = new byte[32];
            _hash = new byte[32];
            Array.Copy(salt, 0, _salt, 0, salt.Length<32?salt.Length:32);
            var pbkdf2 = new Rfc2898DeriveBytes(password, _salt, 10000);
            _hash = pbkdf2.GetBytes(32);
            Array.Copy(_salt, 0, _hashBytes, 0, 32);
            Array.Copy(_hash, 0, _hashBytes, 32, 32);
        }

        public string GetSecret()
        {
            return Convert.ToBase64String(_hashBytes);
        }
    }
}
