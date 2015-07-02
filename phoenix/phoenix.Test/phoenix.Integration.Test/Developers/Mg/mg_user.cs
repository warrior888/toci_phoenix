using System;
using System.Collections.Generic;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMedia;
using Toci.Utilities.Interfaces.User;
using Toci.Utilities.Interfaces.User.Privileges;

namespace _3mb.Integration.Test.Developers.Mg
{
    class MgUser : IUser
    {
        public string Name { get;  set; }
        public string Surname { get; set; }
        public string PhoneNumber { get;  set; }
        public string Email { get; set; }
        public string PostalCode { get;  set; }
        public string City { get;  set; }
        public string Street { get;  set; }
        public Guid GetGuid()
        {
            throw new NotImplementedException();
        }

        public int GetUserId()
        {
            throw new NotImplementedException();
        }

        public List<IPrivilege> GetUserPrivileges()
        {
            throw new NotImplementedException();
        }

        public IPosition GetUserPosition()
        {
            throw new NotImplementedException();
        }

        public bool IsPrivileged(IPrivilege privilege)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(string username, string password, AuthenticationType authType)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(int userId, string password, AuthenticationType authType)
        {
            throw new NotImplementedException();
        }

        public ICommunicationMedia GetDefaultCommunicationMedium()
        {
            throw new NotImplementedException();
        }

        public Dictionary<MessageMediaType, List<ICommunicationMedia>> GetAllCommunicationMediums(bool uniqueTypes = true)
        {
            throw new NotImplementedException();
        }
    }
}
