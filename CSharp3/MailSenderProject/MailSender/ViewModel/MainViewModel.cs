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
        private readonly Scheduler scheduler;
        private MailSendService sendService;
        private string userEmail;
        private SMTP currentSMTP;

        public string UserEmail { get => userEmail; set => Set(ref userEmail, value); }
        public SMTP CurrentSMTP { get => currentSMTP; set => Set(ref currentSMTP, value); }
        public List<SMTP> SMTPs { get; }

        public ObservableCollection<Emails> Emails { get; }
        public ObservableCollection<Emails> SelectedEmails { get; } = new ObservableCollection<Emails>();
        public ObservableCollection<SchedulerTask> SchedulerTasks { get; }
        public ObservableCollection<Date> Dates { get; } = new ObservableCollection<Date>();

        public MainViewModel(IDataAccessService service)
        {
            dataService = service;
            Emails = dataService.GetEmails();
            SMTPs = dataService.GetSMTPs();
            SchedulerTasks = dataService.GetTasks();
        }
    }
}
