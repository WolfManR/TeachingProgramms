using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace MailSender.Data.Models
{
    public class SchedulerTask
    {
        public int Id { get; set; }
        public User From { get; set; }
        public string Subject { get; set; }
        public FlowDocument Letter { get; set; }
        public bool IsComplete { get; private set; } = false;

        public ObservableCollection<Emails> To { get; set; }

        public string GetLetterAsString() => new TextRange(Letter.ContentStart, Letter.ContentEnd).Text;
    }
}
