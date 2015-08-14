using Toci.Utilities.Interfaces.User;

namespace Toci.Utilities.Interfaces.Actions
{
    public interface IAction
    {
        bool Action(IUser user);
    }
}
