using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Sign: ISign
    {
        protected const string crypthoAlgorithm = "RSA";

        public virtual byte[] SignFile(byte[] inputFile, X509Certificate2 certificate)
        {
            if ( (inputFile.Equals(null)  || !certificate.HasPrivateKey)) return default(byte[]);

            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty);
            var privateKey = (RSACryptoServiceProvider) certificate.PrivateKey;
            if (!algorithmName.Contains("sha1") || !algorithmName.Contains("md5"))
            {
                RSACryptoServiceProvider privateKey1 = new RSACryptoServiceProvider();
                privateKey1.ImportParameters(privateKey.ExportParameters(true));
                privateKey = privateKey1;
            }
            byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
            return privateKey.SignHash(hash, CryptoConfig.MapNameToOID(algorithmName));
        }
    }
}