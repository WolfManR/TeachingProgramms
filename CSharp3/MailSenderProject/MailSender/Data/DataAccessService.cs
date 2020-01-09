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
        public int CreateEmail(Emails email)
        {
            //context.Emails.InsertOnSubmit(email);
            //context.SubmitChanges();
            return email.Id;
        }
    }
}
