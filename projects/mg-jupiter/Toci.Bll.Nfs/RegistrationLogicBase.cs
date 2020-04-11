using System;
using System.Data.Entity;
using System.Linq;
using Toci.Bll.Nfs.Interfaces;
using Toci.Dal.Aoe.Interfaces;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit; //mailkit nuget


namespace Toci.Bll.Nfs
{
    public class RegistrationLogicBase : LogicBase<ApplyForm>, IRegistrationLogic
    {

        
        public RegistrationLogicBase(Dal<ApplyForm> context) : base(context)
        {
        }

        public virtual ApplyForm Register(ApplyForm user)
        {
            //Send(System.Net.Mail.MailMessage message);
            var message = new MimeMessage();
            // var html = CreateTextHtmlPart();
            var builder = new BodyBuilder();
            message.From.Add(new MailboxAddress("Zespół Toci", "test.toci@outlook.com"));
            message.To.Add(new MailboxAddress("Szanowny kliencie", "test.toci@outlook.com"));
            message.Subject = "Join to IT in Toci";
            
            var rand = new Random();
            int validationNumber = rand.Next(111111111, 999999999);

            user.Token = validationNumber.ToString();

            ApplyFormDal(user);

            string messangetext = "http://localhost/index/email?token=" + validationNumber;

            message.Body = new TextPart("plain")
            {
                Text = @"Dzień dobry,

Przeprowadzamy weryfikację, jeśli użyty został formularz TOCI, kliknij w link.
" + messangetext + @"
Jeśli nie, zigoruj wiadomość

-- Zespół Toci"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("test.toci@outlook.com", "@@Toci1000@@");

                client.Send(message);
                client.Disconnect(true);
            }

            return user;
        }

        

        public bool EmailConfirm(string token)
        {
            ApplyForm form = new ApplyForm() { Token = token };
            form = Database.Select((model, id) => model.Token == token).First();

            form.EmailConfirmed = true;

            Database.Update(form);

            return true;
        }

        protected virtual ApplyForm ApplyFormDal(ApplyForm form)
        {
            return Database.Insert(form);
        }
    }
}