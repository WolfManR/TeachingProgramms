using MailSender.Data.LinqToSQL;

namespace MailSender.Data.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public SMTP SmtpSettings { get; set; }
    }
}
