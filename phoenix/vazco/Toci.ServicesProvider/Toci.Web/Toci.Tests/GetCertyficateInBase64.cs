using System;
using System.IO;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.DigitalSignature.DigitalSignHandlers;

namespace Toci.Tests
{
    [TestClass]
    public class GetCertyficateInBase64
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sign = new Sign();
            var newtest = File.ReadAllBytes(@"C:\CertTest\TestPrywatnegoKlucza.pfx");
            var getcertbytes = Convert.ToBase64String(newtest);
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
        [TestMethod]
        public void GetCerCertInBase64()
        {
            var sign = new Sign();
            var test = File.ReadAllBytes(@"C:\CertTest\CertyfikatTestowy01.cer");
            var getcertstring = Convert.ToBase64String(test);
        }
    }
    


}
	
