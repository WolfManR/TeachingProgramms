using MailSender.Data.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MailSender.Data
{
    public interface IDataAccessService
    {
        ObservableCollection<Emails> GetEmails();
        List<SMTP> GetSMTPs();
        ObservableCollection<SchedulerTask> GetTasks();
        ObservableCollection<Date> GetDates();
        int CreateEmail(string email,string name);
    }
}
