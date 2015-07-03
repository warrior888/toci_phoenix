using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels;
using Phoenix.Bll.Interfaces.DevelopersList;
using Toci.Db.Interfaces;

namespace Phoenix.Bll.DevelopersList
{
    public class DeveloperListLogic : DbLogic, IDeveloperListLogic
    {
        public IDeveloperListBusinessModel GetDevById(int id)
        {
            //uzyc modeli bazodanowych wygenerowanych naszym generatorem
            throw new System.NotImplementedException();
        }

        public IEnumerable<IDeveloperListBusinessModel> GetAllDevelopers()
        {
            throw new System.NotImplementedException();
        }

    }
}