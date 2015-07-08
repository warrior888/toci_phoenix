using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Phoenix.Bll.Interfaces.Logic.DevelopersList;

namespace Phoenix.Bll.Logic.DevelopersList
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