using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMedia;
using Toci.Utilities.Interfaces.User;
using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Abstraction.User
{
    public abstract class User : IUser
    {
        protected Dictionary<int, IUser> Supervisors;

        protected Dictionary<int, IUser> Subordinates;

        //protected Dictionary<int, IPrivilege> Privileges;
        protected IPrivilegeGroup PrivilegeGroup;

        protected Guid UserGuid;

        protected int UserId;

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostionName { get; set; }

        public decimal MonthlyEarnings { get; set; }

        public virtual Dictionary<int, IUser> GetSuperiors()
        {
            return Supervisors;
        }

        public virtual Dictionary<int, IUser> GetSubordinates()
        {
            return Subordinates;
        }

        public Guid GetGuid()
        {
            return UserGuid;
        }

        public int GetUserId()
        {
            return UserId;
        }

        public List<IPrivilege> GetUserPrivileges()
        {
            return PrivilegeGroup.GetPrivileges();
        }

        public virtual bool IsPrivileged(IPrivilege privilege)
        {
            return PrivilegeGroup.GetPrivileges().Any(item => item.Id == privilege.Id);
            //return Privileges.Any(item => item.Value.PrivilegeId == privilege.PrivilegeId);
        }

        public abstract IPosition GetUserPosition();
        public abstract bool Authenticate(string username, string password, AuthenticationType authType);
        public abstract bool Authenticate(int userId, string password, AuthenticationType authType);
        public abstract ICommunicationMedia GetDefaultCommunicationMedium();
        public abstract Dictionary<MessageMediaType, List<ICommunicationMedia>> GetAllCommunicationMediums(bool uniqueTypes = true);
    }
}
