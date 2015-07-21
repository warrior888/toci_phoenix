using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Verify: IVerify
    {
        protected const string crypthoAlgorithm = "RSA";


        public static string CertificateToString(X509Certificate2 certificate)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, certificate);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static X509Certificate2 StringToCertifcate(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return (X509Certificate2)new BinaryFormatter().Deserialize(ms);
            }
        }

        public bool VerifyFile(byte[] inputFile, byte[] signature, X509Certificate2 certificate)
        {
            if (inputFile.Equals(null) || signature == null) return false;
            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty).ToUpper();
            var publicKey = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            
            byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
            return publicKey.VerifyHash(hash, CryptoConfig.MapNameToOID(algorithmName), signature);
        }

        public bool VerifyFile(byte[] inputFile, byte[] signature, string base64String)
        {
            X509Certificate2 certificate = StringToCertifcate(base64String);

            if (inputFile.Equals(null) || signature == null) return false;
            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty).ToUpper();
            var publicKey = (RSACryptoServiceProvider)certificate.PublicKey.Key;

            byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
            return publicKey.VerifyHash(hash, CryptoConfig.MapNameToOID(algorithmName), signature);
        }
    }
}