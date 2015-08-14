using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Privileges.Privileges
{
    public class Privilage : Abstraction.User.Privileges.Privileges
    {
        public Privilage(int id, string name) : base(id, name){ }

        public void AddPrivilegeToGroups(List<IPrivilegeGroup> groupList)
        {
            groupList.Where(group => { group.AddPrivilege(new Privilage(Id, Name)); return true;});
        }
    }
}
