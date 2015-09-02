using Toci.Utilities.Interfaces.Actions;
using Toci.Utilities.Interfaces.User;
using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Abstraction.Actions
{
    public abstract class Actions : IAction
    {
        private IPrivilege _privilege;
 
        public virtual bool Action(IUser user)
        {
            return IsUserPrivileged(user) && PerformAction();
        }

        private bool IsUserPrivileged(IUser user)
        {
            return user.IsPrivileged(_privilege);
        }

        protected abstract bool PerformAction();
    }
}
