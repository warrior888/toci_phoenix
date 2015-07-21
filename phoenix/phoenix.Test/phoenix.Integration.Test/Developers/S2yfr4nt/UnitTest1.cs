﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.DigitalSignature.DigitalSignHandlers;

namespace Phoenix.Integration.Test.Developers.S2yfr4nt
{
    [TestClass]
    public class UnitTest1
    {
        string certSubject = "CertyfikatTestowy";
        string testMaterial = "asdasdasd";
        Dictionary<string, byte[]> hashList = new Dictionary<string, byte[]>();

        [TestMethod]
        public void SignTest()
        {
            X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            RSACryptoServiceProvider csp = null;
            Sign signProvider = new Sign();

            foreach (X509Certificate2 cert in my.Certificates)
            {
                if (cert.Subject.Contains(certSubject))
                {
                    hashList.Add(cert.Subject, signProvider.SignFile(Encoding.ASCII.GetBytes(testMaterial), Sign.CertificateToString(cert)));

                }
            }
            VerifyTest();
        }

        public void VerifyTest()
        {

            X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            RSACryptoServiceProvider csp = null;
            Verify verifyProvider = new Verify();
            var listOfFiles = Directory.GetFiles(@"C:\CertTest");
            foreach (var dictionaryEntity in hashList)
            {
                foreach (var path in listOfFiles)
                {
                    X509Certificate2 cert = new X509Certificate2(path);
                    if (cert.Subject.Contains(dictionaryEntity.Key))
                    {
                        Debug.Print(cert.Subject + " " + (verifyProvider.VerifyFile(Encoding.ASCII.GetBytes(testMaterial), dictionaryEntity.Value, Verify.CertificateToString(cert)) ? "TAK" : "NIE"));
                    }
                }


            }

        }
    }
}
