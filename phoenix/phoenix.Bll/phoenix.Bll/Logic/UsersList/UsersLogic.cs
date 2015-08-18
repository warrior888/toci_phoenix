using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Phoenix.Bll.Interfaces.BusinessModels.UsersList;
using Phoenix.Bll.Interfaces.Logic.UsersList;
using Phoenix.Dal.GeneratedModels;

namespace Phoenix.Bll.Logic.UsersList
{
    public class UsersLogic : DbLogic,IUsersLogic
    {
        public IUsersBusinessModel GetUserById(int id)
        {
            return GetElementById<IUsersBusinessModel, users>(id);
        }

        public IEnumerable<IUsersBusinessModel> GetAllUsers()
        {
            return GetAllElements<IUsersBusinessModel, users>();
        }
    }
}