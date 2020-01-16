using Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace WpfTestMailSender.Services
{
    public interface IEFAccessService
    {
        ObservableCollection<Common.Email> GetEmails();
        Dictionary<string, int> GetSmtps();
        int AddEmail(Common.Email email);
        int UpdateEmail(Common.Email email);
        int DeleteEmail(Common.Email email);
    }
    class EFAccessService:IEFAccessService
    {
        EmailsModelContainer context;
        public EFAccessService()
        {
            context = new EmailsModelContainer();
        }

        public ObservableCollection<Common.Email> GetEmails() => new ObservableCollection<Common.Email>(context.Emails.ToList());
        public Dictionary<string, int> GetSmtps()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            (from c in context.Smtps select c).ToList().ForEach(p => pairs.Add(p.Host, p.Port));
            return pairs;
        }
        public int AddEmail(Common.Email email)
        {
            context.Emails.Add(email);
            context.SaveChanges();
            return email.Id;
        }
        public int UpdateEmail(Common.Email email)
        {
            context.Emails.Attach(email);
            context.Entry(email).State = EntityState.Modified;
            context.SaveChanges();
            return email.Id;
        }
        public int DeleteEmail(Common.Email email)
        {
            if (context.Entry(email).State == EntityState.Detached)
            {
                context.Emails.Attach(email);
            }
            context.Emails.Remove(email);

            context.SaveChanges();
            return email.Id;
        }

    }
}
