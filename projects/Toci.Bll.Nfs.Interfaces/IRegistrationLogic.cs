using Toci.Dal.Aoe.Interfaces;

namespace Toci.Bll.Nfs.Interfaces
{
    public interface IRegistrationLogic
    {
        ApplyForm Register(ApplyForm user);
    }
}