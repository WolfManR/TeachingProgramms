using GalaSoft.MvvmLight;
using MailSender.Code;
using MailSender.Data;
using MailSender.Data.LinqToSQL;
using MailSender.Data.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MailSender.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IDataAccessService dataService;
        private readonly System.Windows.Window MainView = App.Current.MainWindow;
        private string userEmail;

        public ObservableCollection<Emails> Emails { get; set; }
        public ObservableCollection<Emails> SelectedEmails { get; set; } = new ObservableCollection<Emails>();
        public List<SMTP> SMTPs { get; set; }
        public IMailSendService SendService { get; set; } = new MailSendService();
        public string UserEmail
        {
            get => userEmail; 
            set
            {
                Set( ref userEmail , value);
            }
        }

        public MainViewModel(IDataAccessService service)
        {
            dataService = service;
            Emails = dataService.GetEmails();
            SMTPs = dataService.GetSMTPList();
        }
    }
}
