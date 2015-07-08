using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Communication;
using Toci.Utilities.Communication.MediaTypes;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMedia;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;
using Toci.Utilities.Interfaces.User;

namespace Phoenix.Integration.Test.Developers.Mg
{
    [TestClass]
    public class Communication
    {
        [TestMethod]
        public void SomeMethod()
        {
           // EmailMessage abc = new EmailMessage();

            ICommunicationMedia mailmedia = new EmailCommunicationMedia()
            {

            };

            IUser user1 = new MgUser()
            {
                Email = "user1@user.pl"
            };

            IUser user2 = new MgUser()
            {
                Email = "user2@user.pl"
            };

            IMessage emailMessage = new EmailMessage()
            {
         
            };
          
            IMessageAttachment abc = new EmailMessageAttachment(@"d:\lawd.jpg");

        }
    }
}
