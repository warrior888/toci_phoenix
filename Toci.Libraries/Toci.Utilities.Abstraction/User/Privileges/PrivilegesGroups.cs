using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Abstraction.User.Privileges
{
    public abstract class PrivilegesGroups : IPrivilegeGroup
    {
        private readonly List<IPrivilege> _privileges;

        public string Name { get; set; }

        protected PrivilegesGroups(List<IPrivilege> privilages, string name)
        {
            _privileges = privilages;
            Name = name;
        }

        public void AddPrivilege(IPrivilege privilege)
        {
            _privileges.Add(privilege);
        }

        public void RevokePrivilege(IPrivilege privilege)
        {
            _privileges.Remove(privilege);
        }

        public void AddPrivilege(List<IPrivilege> privileges)
        {
           _privileges.AddRange(privileges);
        }

        public void RevokePrivilege(List<IPrivilege> privileges)
        {
            var values = _privileges.Join(
                privileges, 
                item => item.Id, 
                itemToRemove => itemToRemove.Id,
                (item, itemToRemove) => { _privileges.Remove(itemToRemove); return itemToRemove;
                });
        }

        public List<IPrivilege> GetPrivileges()
        {
            return _privileges;
        }
    }
}
