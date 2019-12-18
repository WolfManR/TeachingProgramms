using System.Windows.Documents;

namespace MailSender.Data.Models
{
    public class Mail
    {
        public string Subject { get; set; }
        public FlowDocument Letter { get; set; }

        public string GetLetterAsString() => new TextRange ( Letter.ContentStart, Letter.ContentEnd ).Text;
    }
}
