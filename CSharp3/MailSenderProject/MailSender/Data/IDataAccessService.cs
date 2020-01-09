using MailSender.Data.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MailSender.Data
{
    public interface IDataAccessService
    {
        ObservableCollection<Emails> GetEmails();
        List<SMTP> GetSMTPs();
        int CreateEmail(Emails email);
    }
}
