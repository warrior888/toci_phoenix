using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toci.pentagram.bll.Buisnessmodel;
using toci.pentagram.bll.dblogic;
using toci.pentagram.bll.logic;
using toci.pentagram.interfaces;
using Toci.Pentagram.Logic.CaptchaLogic.Logic;
using Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.Interfaces;
using Toci.Pentagram.Logic.CaptchaLogic.RandomCaptchaLogic.logic;

namespace PentagramTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]                                                                        
        public void TestMethod1()
        {
         //  PngParsers pars = new PngParsers();
          // StreamReader reader = new StreamReader(@"C:\Users\ksebal\Desktop\test.txt");
           // string a = reader.ReadToEnd();
           // Image im = pars.ParseImage(a);
           // CaptchaLogic logics = new CaptchaLogic(pars);
          //  MemoryStream stream = logic.DrawImage(a);
           AutoMapperConfiguration maper = new AutoMapperConfiguration();
            maper.Configure();
            IApplicationTestsLogicToRand logic = new ApplicationTestsLogicToRand();
            IEnumerable<IApplicationTestsBuisnessModel> model = logic.GetAllTests();

           
            int dupa =
            32;
            
         


        }
    }
}
