using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Toci.DigitalSignature.Abstract;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Verify: CertificateParsers, IVerify 
    {
        protected const string crypthoAlgorithm = "RSA";

        public bool VerifyFile(byte[] inputFile, byte[] signature, X509Certificate2 certificate)
        {
            if (inputFile.Equals(null) || signature == null) return false;
            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty).ToUpper();
            var publicKey = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            
            try
            {
                byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
                return publicKey.VerifyHash(hash, CryptoConfig.MapNameToOID(algorithmName), signature);
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid algorithm method");
            }
        }

        public bool VerifyFile(byte[] inputFile, byte[] signature, string base64String)
        {
            X509Certificate2 certificate = StringToCertifcate(base64String);


            return VerifyFile(inputFile, signature, certificate);
        }
    }
}