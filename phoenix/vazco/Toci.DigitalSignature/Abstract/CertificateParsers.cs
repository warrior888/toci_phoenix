using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Toci.DigitalSignature.Abstract
{
    public abstract class CertificateParsers
    {

        public virtual string CertificateToBase64(X509Certificate2 certificate)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(certificate.Export(X509ContentType.SerializedCert), Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(builder.ToString()));
        }
        public virtual X509Certificate2 Base64ToCertificate(string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            return new X509Certificate2(bytes);
        }


    }
}