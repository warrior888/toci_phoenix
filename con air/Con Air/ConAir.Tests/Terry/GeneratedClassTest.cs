using Con_Air.Terry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConAir.Tests.Terry
{
    [TestClass]
    public class GeneratedClassTest
    {
        [TestMethod]
        public void Test()
        {
            var testVariable = new GeneratedClass();

            int liczba;
            string napis;

            testVariable.Compile(out liczba, out napis);

            Assert.AreEqual(888, liczba);
            Assert.AreEqual("Toci", napis);
        }
         
    }
}