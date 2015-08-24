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
            var test = new GenerateSecret(testSecret);
            var hash = test.GetSecret();
            var verifyTest = new VerifySecret(hash, testSecret);
            var verifyResult = verifyTest.Verification();
            Assert.IsTrue(verifyResult);
            var verifyTest2 = new VerifySecret(hash, "TajneHasl");
            var verifyResult2 = verifyTest2.Verification();
            Assert.IsFalse(verifyResult2);
        }
    }
}
