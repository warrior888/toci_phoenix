using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;

namespace Toci.DigitalSignature.Abstract
{
    public abstract class CertificateParsers
    {
        public virtual string CertificateToString(X509Certificate2 certificate)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, certificate);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public virtual X509Certificate2 StringToCertifcate(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return (X509Certificate2)new BinaryFormatter().Deserialize(ms);
            }
        } 
    }
}