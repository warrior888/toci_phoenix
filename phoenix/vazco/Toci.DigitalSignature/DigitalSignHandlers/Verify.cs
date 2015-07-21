using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Verify: IVerify
    {
        protected const string crypthoAlgorithm = "RSA";

        public bool VerifyFile(byte[] inputFile, byte[] signature, X509Certificate2 certificate)
        {
            if (inputFile.Equals(null) || signature == null) return false;
            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty).ToUpper();
            var publicKey = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
            return publicKey.VerifyHash(hash, CryptoConfig.MapNameToOID(algorithmName), signature);
    
        }
    }
}