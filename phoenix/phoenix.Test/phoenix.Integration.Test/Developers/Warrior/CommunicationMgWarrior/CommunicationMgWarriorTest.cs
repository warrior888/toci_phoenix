using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phoenix.Integration.Test.Developers.Mg;
using Toci.Utilities.Communication;
using Toci.Utilities.Communication.MediaTypes;

namespace Phoenix.Integration.Test.Developers.Warrior.CommunicationMgWarrior
{
    [TestClass]
    public class CommunicationMgWarriorTest
    {
        [TestMethod]
        public void TestEmailSendOperation()
        {
            var communicationMedium = new EmailCommunicationMedia();

            //communicationMedium.Host = "poczta.o2.pl";
            //communicationMedium.Login = "test_toci@o2.pl"; 
            //communicationMedium.Password = "qwerty123";
            //communicationMedium.Port = 587;

            //----------------------------------------------------------
            communicationMedium.Host = "smtp.gmail.com";
            communicationMedium.Login = "toci.email.test@gmail.com";
            communicationMedium.Password = "toci.3mb";
            communicationMedium.Port = 587;
            //---------------------------------------------------------



            var emailMessage = new EmailMessage();

            //users
            var userSender = new MgUser();
            var userReciver = new MgUser();

            userReciver.Email = "test_toci@o2.pl";
            userSender.Email = "toci.email.test@gmail.com";

            emailMessage.Sender = userSender;
            emailMessage.Receiver = userReciver;

            //content
            emailMessage.Topic = "Test4";
            

            communicationMedium.Send(emailMessage);
        }
    }
}
