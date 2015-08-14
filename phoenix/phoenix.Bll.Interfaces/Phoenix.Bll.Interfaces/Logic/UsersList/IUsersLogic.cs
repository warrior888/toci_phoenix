using System.Collections.Generic;
using Phoenix.Bll.Interfaces.BusinessModels.UsersList;

namespace Phoenix.Bll.Interfaces.Logic.UsersList
{
    public interface IUsersLogic
    {
        IUsers GetUserById(int id);

        IEnumerable<IUsers> GetAllUsers();
    }
}