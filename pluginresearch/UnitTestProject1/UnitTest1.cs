using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingVsixOptions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dummy  d = new Dummy();

            d.dupa();
        }
    }
}
