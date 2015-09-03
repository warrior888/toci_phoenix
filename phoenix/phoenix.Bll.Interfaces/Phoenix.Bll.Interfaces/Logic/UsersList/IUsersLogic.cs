using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.UsersList;

namespace Phoenix.Bll.Interfaces.Logic.UsersList
{
    public interface IUsersLogic
    {
        IUsersBusinessModel GetUserById(int id);

        IEnumerable<IUsersBusinessModel> GetAllUsers();
    }
}