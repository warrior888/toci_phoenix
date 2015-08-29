using System;
using Con_Air.Terry;
using Con_Air.Terry.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConAir.Tests.Terry
{
    [TestClass]
    public class Base64Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            string msg = "Toci base64 test";
            string encoded = "VG9jaSBiYXNlNjQgdGVzdA==";

            BinaryFileOperations dllToString = new BinaryFileOperations();

            var base64Content = dllToString.GetBase64Representation("@\\..\\..\\..\\Terry\\TerryTests.dll");

            dllToString.CreateFile("@\\..\\..\\..\\Terry\\", "Testujemy", base64Content, BinaryFileExtension.Dll);

            Assert.AreEqual(msg, Base64StringOperations.Decode(encoded));

            
            
        }
    }
}
