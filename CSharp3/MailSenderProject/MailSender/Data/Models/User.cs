using GalaSoft.MvvmLight;
using MailSender.Code;

namespace MailSender.Data.Models
{
    public class User : ObservableObject
    {
        private string password;
        private string email;
        private SMTP smtpSettings;

        public string Email { get => email; set => Set(ref email, value); }
        public string Password { get => password; set => Set(ref password, value); }
        public int SMTPSettingsId { get; set; }
        
        
        
        public SMTP SmtpSettings { get => smtpSettings; set => Set(ref smtpSettings, value); }

        public string DeencpryptPassword() => Encrypter.Deencript(password, Encrypter.EcrypterKey);
    }
}
