using System;
using System.IO;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Tests
{
    [TestClass]
    public class GetCertyficateInBase64
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sign = new DigitalSignature.DigitalSignHandlers.Sign();
            var newtest = File.ReadAllBytes(@"C:\CertTest\TestPrywatnegoKlucza.pfx");

            string password = "pass";
            SecureString securedPassword = new SecureString();
            foreach (var c in password.ToCharArray())
            {
                securedPassword.AppendChar(c);
            }
            //work in progress
            var test = sign.PfxFileToCertificate(newtest, securedPassword);
           // X509Certificate2 cert = new X509Certificate2(@"C:\CertTest\TestPrywatnegoKlucza.pfx");
            var wynik = sign.CertificateToBase64(test);
            sign.SignFile(new byte[] {40, 50, 60, 70}, test);
        }
    }
}
	
