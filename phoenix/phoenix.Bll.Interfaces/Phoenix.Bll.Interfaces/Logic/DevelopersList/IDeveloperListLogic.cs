using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface IDeveloperListLogic : IDbLogic
    {
        IDeveloperBusinessModel GetDevById(int id);

        IEnumerable<IDeveloperBusinessModel> GetAllDevelopers();

    }
}