using GestionLivres.DomainModels;

namespace GestionLivres.UtilityService
{
    public interface IEmailService
    {
        void SendEmail(EmailModel emailModel);

        void SendMail(MailData mailData);
    }
}
