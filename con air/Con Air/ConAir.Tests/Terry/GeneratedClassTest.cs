using System;
using System.Reflection;
using Con_Air.Common;
using Con_Air.Flexi;
using Con_Air.Terry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Db.ClusterAccess;
using Toci.Db.Interfaces;

namespace ConAir.Tests.Terry
{
    [TestClass]
    public class GeneratedClassTest
    {
        [TestMethod]
        public void Test()
        {
            var testVariable = new TerryGeneratedClass();

            int liczba;
            string napis;

            //testVariable.Compile(out liczba, out napis);

            var dbHandle = DbHandleFactory.GetHandle(SqlClientKind.PostgreSql, "postgres", "beatka", "localhost", "con_air");

            for (var i = 0; i < 10; i++)
            {
                dbHandle.InsertData(new CodeStorageModel() {Codeblob = testVariable.GetGeneratedClass(i)});
            }


            //Assert.AreEqual(888, liczba);
            //Assert.AreEqual("Toci", napis);

            //Assembly.LoadFrom()


            //Base64FormattingOptions.
        }
         
    }
}