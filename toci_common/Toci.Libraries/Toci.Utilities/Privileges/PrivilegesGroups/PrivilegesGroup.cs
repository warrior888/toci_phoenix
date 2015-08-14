using System.Collections.Generic;
using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Privileges.PrivilegesGroups
{
    public class PrivilegesGroup : Abstraction.User.Privileges.PrivilegesGroups
    {
        public PrivilegesGroup(List<IPrivilege> privilages, string name) : base(privilages, name) { }
    }
}
