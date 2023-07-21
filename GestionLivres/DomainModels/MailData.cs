namespace GestionLivres.DomainModels
{
    public class MailData
    {

        public string EmailToId { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }

        public MailData(string email, string v1, string v2)
        {
            this.EmailToId = email;
            this.EmailSubject = v1;
            this.EmailBody = v2;
        }

    }
}
