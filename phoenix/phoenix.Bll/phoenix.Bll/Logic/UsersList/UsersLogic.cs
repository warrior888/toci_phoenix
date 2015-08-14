using System;
using System.Collections.Generic;
using Phoenix.Bll.BusinessModels.UsersList;
using Phoenix.Bll.Interfaces.BusinessModels.UsersList;
using Phoenix.Bll.Interfaces.Logic.UsersList;
using Phoenix.Dal.GeneratedModels;
using Toci.Db.DbVirtualization;


namespace Phoenix.Bll.Logic.UsersList
{
    public class UsersLogic : DbLogic,IUsersLogic
    {
        public IUsers GetUserById(int id)
        {
            users userToDb = new users()
            {
                Id = id
            };
            userToDb.SetSelect("id",SelectClause.Equal);
            users userFromDb = FetchModelFromDb<users>(userToDb);
            return new Users()
            {
                Name = userFromDb.Name,
                Surname = userFromDb.Surname,
                Nick = userFromDb.Nick
            };
        }

        public IEnumerable<IUsers> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}