using System;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Pentagram.Logic.CaptchaLogic.Logic;

namespace PentagramTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]                                                                        
        public void TestMethod1()
        {
            PngParsers pars = new PngParsers();
            StreamReader reader = new StreamReader(@"C:\Users\ksebal\Desktop\test.txt");
            string a = reader.ReadToEnd();
            Image im = pars.ParseImage(a);
            CaptchaLogic logic = new CaptchaLogic(pars);
            MemoryStream stream = logic.DrawImage(a);
        }
    }
}
