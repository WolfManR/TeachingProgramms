using MailSender.Data.LinqToSQL;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MailSender.Data
{
    public interface IDataAccessService
    {
        ObservableCollection<Emails> GetEmails();
        Dictionary<string, int> GetSMTPDictionary();
        List<SMTP> GetSMTPList();
        int CreateEmail(Emails email);
    }
}
