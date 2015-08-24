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
            var secretText = tociCrypting.EncryptStringAes(testtexttocrypt, testpass, secretHash);
            Debug.Print("Encrypted data is: {0}", secretText);
            var tociCrypting2 = new TociCrypting();
            var nonSecretText = tociCrypting2.DecryptStringAes(secretText, testpass, secretHash);
            Assert.AreEqual(testtexttocrypt, nonSecretText);
        }
    }
}
