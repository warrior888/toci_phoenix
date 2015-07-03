using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels;

namespace Phoenix.Bll.Interfaces.DevelopersList
{
    public interface IDeveloperListLogic : IDbLogic
    {
        IDeveloperListBusinessModel GetDevById(int id);

        IEnumerable<IDeveloperListBusinessModel> GetAllDevelopers();

    }
}