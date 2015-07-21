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

            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty).ToUpper();
            var privateKey = (RSACryptoServiceProvider) certificate.PrivateKey;
            byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
            return privateKey.SignHash(hash, CryptoConfig.MapNameToOID(algorithmName));
            
        }
    }
}