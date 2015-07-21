using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Sign: ISign
    {
        protected const string crypthoAlgorithm = "RSA";
     
        public virtual byte[] SignFile(byte[] inputFile, X509Certificate2 certificate)
        {
            if ( (inputFile.Equals(null)  || !certificate.HasPrivateKey)) return default(byte[]);

            var algorithmName = certificate.SignatureAlgorithm.FriendlyName;//Replace(crypthoAlgorithm, String.Empty);
          //  algorithmName = algorithmName.ToUpper();
            var privateKey = (RSACryptoServiceProvider) certificate.PrivateKey;
            byte[] hash = HashAlgorithm.Create("SHA1").ComputeHash(inputFile);
            /*
             * HASH
              SHA1Managed 
              MD5CryptoServiceProvider
              SHA256Managed
              SHA384Managed
              SHA512Managed
            */
            /*dictionary
             [sha1] [sha1]
             [sha256]["System.Security.Cryptography.SHA256CryptoServiceProvider"]*/
            /*OID
             *"SHA1"-SHA1CryptoServiceProvider
             *"System.Security.Cryptography.SHA256CryptoServiceProvider" - SHA256CryptoServiceProvider
             *System.Security.Cryptography.SHA384CryptoServiceProvider - SHA384CryptoServiceProvider
             *System.Security.Cryptography.SHA512CryptoServiceProvider - SHA512CryptoServiceProvider
             *MD5, System.Security.Cryptography.MD5 - MD5CryptoServiceProvider
            */
            return privateKey.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
            
        }
    }
}