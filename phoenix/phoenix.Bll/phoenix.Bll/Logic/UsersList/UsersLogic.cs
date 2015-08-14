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
        public IUsers GetUserById(int id)
        {
            users userFromDb = FetchModelById<users>(id);

            Mapper.CreateMap<users, IUsers>();

            return Mapper.Map<IUsers>(userFromDb);
        }

        public IEnumerable<IUsers> GetAllUsers()
        {
            var usersModelsList = FetchModelsFromDb<users>(new users());

            Mapper.CreateMap<users, IUsers>();

            return usersModelsList.Select(user => Mapper.Map<IUsers>(user)).ToList();
        }
    }
}