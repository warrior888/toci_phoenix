using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels;
using Phoenix.Bll.Interfaces.BusinessModels.DevelopersList;
using Toci.Db.Interfaces;

namespace Phoenix.Bll.Interfaces.Logic.DevelopersList
{
    public interface IDeveloperListLogic : IDbLogic
    {
        IDeveloperBusinessModel GetDevByUserId(int id);

        IEnumerable<IDeveloperBusinessModel> GetAllDevelopers();

    }
}