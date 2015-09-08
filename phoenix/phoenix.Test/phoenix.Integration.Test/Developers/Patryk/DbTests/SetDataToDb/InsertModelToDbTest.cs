using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Bll;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Integration.Test.Developers.Patryk.DbTests.SetDataToDb
{

    [TestClass]
    public class InsertModelToDbTest : PhoenixDataAccessLogic
    {
        [TestMethod]
        public void TryInsertModelToDb()
        {
            portfolio portfolio = new portfolio()
            {
                EndDate = new DateTime(2012,05,06),
                StartDate = new DateTime(2011,11,09),
                TeamLeaderId = 20,
                ProjectName = "testowy45"
            };

            int fromInsert = InsertModel(portfolio);

            int fromDelete = DeleteModel(portfolio);

            List<portfolio> portfolios = FetchModelsFromDb<portfolio>(new portfolio());
            int a = 5;
        }
         
    }
}