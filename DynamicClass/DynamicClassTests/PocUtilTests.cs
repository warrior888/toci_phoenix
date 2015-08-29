using DynamicClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicClassTests
{
    [TestClass]
    public class PocUtilTests
    {
        [TestMethod]
        public void PocUtilTest()
        {
            var tmp = PocUtil.GetStringFromFile(PocUtil.Path);
        }
    }
}