using DynamicClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicClassTests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void MainTest()
        {
            var main = new MainClass();

            Assert.AreEqual("Hello from text file", main.Magic());
        }
    }
}