using System.Collections.ObjectModel;

namespace MailSender.Data.Models
{
    public class SMTP
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string For { get; set; }
    }
}
