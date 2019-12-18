using MailSender.Data.LinqToSQL;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MailSender.Data
{
    public class DataAccessService : IDataAccessService
    {
        readonly EmailsDataContext context= new EmailsDataContext();


        public ObservableCollection<Emails> GetEmails()
        {
            ObservableCollection<Emails> emails = new ObservableCollection<Emails>();
            foreach (var item in context.Emails)
            {
                emails.Add(item);
            }
            return emails;
        }

        public Dictionary<string, int> GetSMTPDictionary()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            (from c in context.SMTP select c).ToList().ForEach(p => pairs.Add(p.Host, p.Port));
            return pairs;
        }
        public List<SMTP> GetSMTPList() => (from c in context.SMTP select c).ToList();
        public int CreateEmail(Emails email)
        {
            context.Emails.InsertOnSubmit(email);
            context.SubmitChanges();
            return email.Id;
        }
    }
}
