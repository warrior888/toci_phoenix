using System;
using EncodingLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.Tests
{
    [TestClass]
    public class GenerateSecredTest
    {
        public const string testSecret = "TajneHaslo";
        [TestMethod]
        public void TestMethod1()
        {
            var test = new GenerateSecred(testSecret);
            var hash = test.GetSecret();
            var verifyTest = new VerifySecret(hash, testSecret+"b");
            var verifyResult = verifyTest.Verification();
        }
    }
}
