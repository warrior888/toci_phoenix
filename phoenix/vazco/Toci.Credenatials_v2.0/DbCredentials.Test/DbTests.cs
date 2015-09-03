using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Generator.DatabaseModelGenerator;

namespace DbCredentials.Test
{
    [TestClass]
    public class DbTests
    {
        [TestMethod]
        public void ModelsGenerator()
        {
            WrapperModel model = new WrapperModel
            {
                CsprojPath = "",
            };
        }
    }
}
