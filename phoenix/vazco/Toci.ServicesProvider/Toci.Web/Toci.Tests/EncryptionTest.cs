using System;
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
            var generateSecret = new GenerateSecred(testpass);
            var secretHash = generateSecret.GetSecret();
            var sectetText = tociCrypting.EncryptStringAES(testtexttocrypt, testpass, secretHash);
            Debug.Print("Encrypted data is: {0}", sectetText);

            var s2 = new GenerateSecred(testpass);
            var s22 = s2.GetSecret();

            var nonSecretText = tociCrypting.DecryptStringAES(sectetText, testpass, s22);
            Assert.AreEqual(testtexttocrypt, nonSecretText);
        }
    }
}
