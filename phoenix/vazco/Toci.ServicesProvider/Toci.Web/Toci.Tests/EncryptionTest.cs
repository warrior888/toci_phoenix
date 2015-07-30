﻿using System;
using System.Diagnostics;
using EncodingLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Tests
{
    [TestClass]
    public class EncryptionTest
    {
        public const string testpass = "testpass";
        public const string testtexttocrypt = "testowytestdotestowychcelow";
        [TestMethod]
        public void TestMethod1()
        {
            var tociCrypting = new TociCrypting();
            var generateSecret = new GenerateSecret(testpass);
            var secretHash = generateSecret.GetSecret();
            var sectetText = tociCrypting.EncryptStringAes(testtexttocrypt, testpass, secretHash);
            Debug.Print("Encrypted data is: {0}", sectetText);
            var tociCrypting2 = new TociCrypting();
            var nonSecretText = tociCrypting2.DecryptStringAes(sectetText, testpass, secretHash);
            Assert.AreEqual(testtexttocrypt, nonSecretText);
        }
    }
}