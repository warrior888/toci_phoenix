using System;
using System.Reflection;
using Con_Air.Terry;
using Con_Air.Terry.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConAir.Tests.Terry
{
    [TestClass]
    public class Base64Test
    {
        protected string msg = "Toci base64 test";
        protected string encoded = "VG9jaSBiYXNlNjQgdGVzdA==";
        protected string srcPath = "@\\..\\..\\..\\Terry\\TerryTests.dll";
        protected string destPath = "@\\..\\..\\..\\Terry\\";
        protected string destName = "Testujemy";

        [TestMethod]
        public void TestMethod1()
        {
            BinaryFileOperations dllToString = new BinaryFileOperations();

            var base64Content = dllToString.GetBase64Representation(srcPath);

            dllToString.CreateFile(destPath, destName, base64Content, BinaryFileExtension.Dll);

            var byteArr = dllToString.GetByteArrRepresentation(srcPath);

            Assembly myAssembly = Assembly.Load(byteArr);

            Assert.AreEqual(msg, Base64Operations.Decode(encoded));

            
            
        }
    }
}
