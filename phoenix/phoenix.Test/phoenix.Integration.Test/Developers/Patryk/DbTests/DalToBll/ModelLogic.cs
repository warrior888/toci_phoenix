using System.Collections.Generic;
using Phoenix.Bll;
using Toci.Db.DbUtils;
using Toci.Db.DbVirtualization;

namespace Phoenix.Integration.Test.Developers.Patryk.DbTests.DalToBll
{
    public class ModelLogic : PhoenixDataAccessLogic
    {
        public List<T> GetModelFromDbTest<T>(T model) where T : Model
        {
            return FetchModelsFromDb<T>(model);
        }
         
    }
}