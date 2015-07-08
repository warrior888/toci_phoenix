using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface IDeveloperListLogic : IDbLogic
    {
        IDeveloperListBusinessModel GetDevById(int id);

        IEnumerable<IDeveloperListBusinessModel> GetAllDevelopers();

    }
}