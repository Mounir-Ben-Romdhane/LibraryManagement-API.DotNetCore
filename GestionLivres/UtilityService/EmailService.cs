using GestionLivres.DomainModels;
using MailKit.Net.Smtp;
using MimeKit;

namespace GestionLivres.UtilityService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void SendEmail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            var from = _config["EmailSettings:From"];
            emailMessage.From.Add(new MailboxAddress("AuthApi", from));
            emailMessage.To.Add(new MailboxAddress(emailModel.To,emailModel.To));
            emailMessage.Subject = emailModel.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(emailModel.Content)
            };

            using (var client = new SmtpClient())
            {
                
                    client.Connect(_config["EmailSettings:SmtpServer"], 465, true);
                    client.Authenticate(_config["EmailSettings:From"], _config["EmailSettings:Password"]);
                   
                    client.Send(emailMessage);
                    client.Disconnect(true);
                
                
            }
        }

        public void SendMail(MailData mailData)
        {
            var smtpSettings = _config.GetSection("MailSettings");
            var message = new MimeMessage();
            var from = _config["MailSettings:SenderEmail"];
            message.From.Add(new MailboxAddress("Mounir", from));
            message.To.Add(new MailboxAddress(mailData.EmailToId,mailData.EmailToId));
            message.Subject = mailData.EmailSubject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(mailData.EmailBody)
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_config["MailSettings:Server"], 2525);
                client.Authenticate(smtpSettings["Username"], smtpSettings["Password"]);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
