using GalaSoft.MvvmLight;
using MailSender.Code;
using MailSender.Data;
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
        private MailSendService sendService=null;
        private string userEmail;

        public string UserEmail { get => userEmail; set => Set(ref userEmail, value); }
        public List<SMTP> SMTPs { get; }
        
        public ObservableCollection<Emails> Emails { get; }
        public ObservableCollection<Emails> SelectedEmails { get; } = new ObservableCollection<Emails>();

        public ObservableCollection<SchedulerTask> SchedulerTasks { get; }

        public Scheduler Scheduler { get; }
        public MailSendService SendService => sendService??(sendService = new MailSendService()); 
        public ObservableCollection<Date> Dates { get; } = new ObservableCollection<Date>();

        public MainViewModel(IDataAccessService service)
        {
            dataService = service;
            Emails = dataService.GetEmails();
            SMTPs = dataService.GetSMTPs();
        }
    }
}
