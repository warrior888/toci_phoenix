using System.Collections.Generic;

namespace Toci.Utilities.Interfaces.User.Privileges
{
    public interface IPrivilegeGroup
    {
        void AddPrivilege(IPrivilege privilege);

        void RevokePrivilege(IPrivilege privilege);

        void AddPrivilege(List<IPrivilege> privileges);

        void RevokePrivilege(List<IPrivilege> privileges);

        List<IPrivilege> GetPrivileges();
    }
}
