using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Sign: ISign
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
                return (X509Certificate2) new BinaryFormatter().Deserialize(ms);
            }
        }

        public virtual byte[] SignFile(byte[] inputFile, X509Certificate2 certificate)
        {
            if ( (inputFile.Equals(null)  || !certificate.HasPrivateKey)) return default(byte[]);

            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty);
            var privateKey = (RSACryptoServiceProvider) certificate.PrivateKey;
            RSACryptoServiceProvider privateKey1 = new RSACryptoServiceProvider();
            privateKey1.ImportParameters(privateKey.ExportParameters(true));
            byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
            return privateKey1.SignHash(hash, CryptoConfig.MapNameToOID(algorithmName));
        }
        public virtual byte[] SignFile(byte[] inputFile, string base64String)
        {
            X509Certificate2 certificate = StringToCertifcate(base64String);

            if ((inputFile.Equals(null) || !certificate.HasPrivateKey)) return default(byte[]);

            var algorithmName = certificate.SignatureAlgorithm.FriendlyName;//Replace(crypthoAlgorithm, String.Empty);
            
            var privateKey = (RSACryptoServiceProvider)certificate.PrivateKey;
            byte[] hash = HashAlgorithm.Create("SHA1").ComputeHash(inputFile);
            
            return privateKey.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

        }
    }
}