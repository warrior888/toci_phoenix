using DynamicClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicClassTests
{
    [TestClass]
    public class DynamicClassTests
    {
        [TestMethod]
        public void DcTest()
        {
            var poc = new PocDynamicClass();

            Assert.AreEqual("Test message", poc.MethodOne());
        }
    }
}