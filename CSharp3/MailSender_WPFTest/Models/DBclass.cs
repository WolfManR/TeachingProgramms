using MailSender_WPFTest.LinqToSQL;
using System.Collections.ObjectModel;
using System.Linq;

namespace MailSender_WPFTest.Models
{
    public class DBclass
    {
        private EmailsDataContext context = new EmailsDataContext();
        public ObservableCollection<Emails> Emails { get => new ObservableCollection<Emails>((from c in context.Emails select c).ToList()); }
        public IQueryable<SMTP> SMTPs { get => from c in context.SMTP select c; }

        void AddEmail()
        {
            
        }
    }
}
