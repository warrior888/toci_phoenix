using System;
using System.Collections.Generic;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMedia;
using Toci.Utilities.Interfaces.User.Privileges;

namespace Toci.Utilities.Interfaces.User
{
    public interface IUser : IUserPersonalData
    {
        Guid GetGuid(); // np 030B4A82-1B7C-11CF-9D53-00AA003C9CB6

        int GetUserId();

        //Dictionary<int, IPrivilege> GetUserPrivileges();
        List<IPrivilege> GetUserPrivileges();

        IPosition GetUserPosition();

        bool IsPrivileged(IPrivilege privilege);

        bool Authenticate(string username, string password, AuthenticationType authType);

        // for otp
        bool Authenticate(int userId, string password, AuthenticationType authType);

        ICommunicationMedia GetDefaultCommunicationMedium();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uniqueTypes">Get only one email in the result list regardless of how many emails the user has, same for mobile etc</param>
        /// <returns></returns>
        Dictionary<MessageMediaType, List<ICommunicationMedia>> GetAllCommunicationMediums(bool uniqueTypes = true);

        //CommunicationMediumPriority 3 ? 2 + 1 


        //AuthenticationType

        //Dictionary<int, IPrivilege> GetPrivileges();

        // email telefon
    }
}
