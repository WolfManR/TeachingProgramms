using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTestMailSender.Services
{
    class DataAccessService : IDataAccessService
    {
        EmailsDataContext context;

        public DataAccessService()
        {
            context = new EmailsDataContext();
        }

        

        public ObservableCollection<Email> GetEmails()
        {
            ObservableCollection<Email> emails = new ObservableCollection<Email>();
            foreach (var item in context.Email)
            {
                emails.Add(item);
            }
            return emails;
        }

        public Dictionary<string, int> GetSmtps()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            (from c in context.Smtp select c).ToList().ForEach(p => pairs.Add(p.Host, p.Port));
            return pairs;
        }
        public int CreateEmail(Email email)
        {
            context.Email.InsertOnSubmit(email);
            context.SubmitChanges();
            return email.Id;
        }
    }
}
