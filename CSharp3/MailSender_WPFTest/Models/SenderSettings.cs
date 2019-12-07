using System.Net.Mail;

namespace MailSender_WPFTest.Models
{
    public class SenderSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public SmtpClient Smtp { get; set; }
    }
}
