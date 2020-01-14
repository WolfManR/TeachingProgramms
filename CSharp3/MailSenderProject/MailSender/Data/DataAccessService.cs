using MailSender.Data.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MailSender.Data
{
    public class DataAccessService : IDataAccessService
    {
        readonly DataContext context= new DataContext();


        public ObservableCollection<Emails> GetEmails()
        {
            return new ObservableCollection<Emails>(context.Emails);
        }

        public List<SMTP> GetSMTPs() => context.SMTPs;
        public int CreateEmail(string email,string name)
        {
            int id = context.Emails.Count;
            context.Emails.Add(new Emails { Id = id, Email = email, Name = name });
            return id;
        }

        public ObservableCollection<SchedulerTask> GetTasks() => new ObservableCollection<SchedulerTask>(context.Tasks);

        public ObservableCollection<Date> GetDates() 
        {
            var list = context.Dates;
            list.Sort((x, y) => x.Time.CompareTo(y.Time));
            return new ObservableCollection<Date>(list); 
        }
    }
}
