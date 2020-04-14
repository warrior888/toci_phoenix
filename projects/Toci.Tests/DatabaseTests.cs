using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Bll.Nfs;
using Toci.Dal.Aoe.Interfaces;

namespace Toci.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void SelectTest()
        {
            Dal<ApplyForm> dal = new Dal<ApplyForm>(new tociEntities());

            IQueryable<ApplyForm> result =  dal.Select((model) => model.Id == 1);

            string name = result.First().ApplicantName;
        }

        [TestMethod]
        public void BllTest()
        {
            RegistrationLogicBase rlBase = new RegistrationLogicBase(new Dal<ApplyForm>(new tociEntities()));

            rlBase.EmailConfirm("125183185");

        }
    }
}
