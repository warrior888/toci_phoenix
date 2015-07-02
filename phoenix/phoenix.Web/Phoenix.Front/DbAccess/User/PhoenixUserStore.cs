using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;
using Phoenix.Front.Models;

namespace Phoenix.Front.DbAccess.User
{
    public class PhoenixUserStore<TUser> : IUserStore<TUser>, IUserLoginStore<TUser>  where TUser : class, IUser<string>, new()//
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            return new Task<TUser>(() => default(TUser));
            throw new System.NotImplementedException();

            //return new Task<TUser>(() => new TUser());
        }
    }
}