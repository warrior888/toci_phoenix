using System;
using System.ComponentModel.Design.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Base.Abstract.Generator.Interfaces.LogicSkeleton.DdlHandling;
using Toci.Base.Abstract.Generator.LogicSkeleton.DdlHandling;

namespace Toci.Generators.Test.Base.Abstract.Generator.Tests
{
    [TestClass]
    public class DdlAnalyzerTests
    {
        private readonly IDdlAnalyzer _ddlAnalyzer;

        //Dictionary<string, string> GetAllTablesDdlsSeparated(string textFilePath)
        [TestMethod]
        public void GetAllTablesDdlsSeparatedTest()//nie używa się '_' w nazwach metod
        {
            //arrange
            const string textFilePath = @"\..\..\..\Toci.RoyalSchool.Dal\ddl\sql.sql";
            //act
            var ddlAnalyzer = new DdlAnalyzer();
            var result = ddlAnalyzer.GetAllTablesDdlsSeparated(Environment.CurrentDirectory+textFilePath);
            //assert nie jest niezbędny póki nie wiadomo dokładnie co wyjdzie 
            //Assert.AreEqual(result,null); 
        }
    }
}
