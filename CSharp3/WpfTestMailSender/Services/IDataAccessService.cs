using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfTestMailSender.Services
{
    public interface IDataAccessService
    {
        ObservableCollection<Email> GetEmails();
        Dictionary<string, int> GetSmtps();
        int CreateEmail(Email email);
    }
}
