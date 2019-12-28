using EmailSendDLL;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using WpfTestMailSender.Services;

namespace WpfTestMailSender.ViewModel
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
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
        [PreferredConstructor]
        public MainViewModel(IDataAccessService servProxy)
        {
            serviceProxy = servProxy;
            Emails = new ObservableCollection<Email>();
            ReadAllCommand = new RelayCommand(GetEmails);

            EmailInfo = new Email();
            SaveCommand = new RelayCommand<Email>(SaveEmail);

            AddDateCommand = new RelayCommand<ObservableCollection<DateTime>>(AddDate);
            RemoveDateCommand = new RelayCommand<DateTime>(RemoveDate);
            OpenLetterEditCommand = new RelayCommand<DateTime>(GetLetter);
            SendAtOnceCommand = new RelayCommand<object>(SendAtOnce);
            SendSchedulerCommand = new RelayCommand<object>(SendScheduler);
        }


        ObservableCollection<Email> emails;
        IDataAccessService serviceProxy;
        private Email emailInfo;
        private string name;

        private ObservableCollection<SchedulerLeter> dates;
        public ObservableCollection<SchedulerLeter> Dates
        {
            get => dates;
            set
            {
                dates = value;
                RaisePropertyChanged(nameof(Dates));
            }
        }
        public ObservableCollection<Email> Emails
        {
            get => emails; set
            {
                emails = value;
                RaisePropertyChanged(nameof(Emails));
            }
        }
        public Dictionary<string, int> Smtps { get => serviceProxy.GetSmtps(); }
        public Email EmailInfo
        {
            get => emailInfo;
            set
            {
                emailInfo = value;
                RaisePropertyChanged(nameof(EmailInfo));
            }
        }
        public Window View { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                RaisePropertyChanged(nameof(Name));
                GetEmails();
            }
        }

        public RelayCommand ReadAllCommand { get; set; }
        public RelayCommand<Email> SaveCommand { get; set; }
        public RelayCommand<ObservableCollection<DateTime>> AddDateCommand { get; set; }
        public RelayCommand<DateTime> RemoveDateCommand { get; set; }
        public RelayCommand<DateTime> OpenLetterEditCommand { get; set; }
        public RelayCommand<object> SendAtOnceCommand { get; set; }
        public RelayCommand<object> SendSchedulerCommand { get; set; }
        void SendAtOnce(object array)
        {
            if (array is object[] arr)
            {
                try
                {
                    EmailSendServiceClass serviceClass = PrepairSendClass(arr,SendType.SendAtOnce);
                    List<string> list = new List<string>();
                    foreach (Email item in Emails) list.Add(item.Value);
                    serviceClass.SendMailsAsync(list);
                }
                catch (SendClassFillException ex)
                {
                    new ErrorWindow(ex.Message) { Owner = View }.ShowDialog();
                }
                catch (Exception ex)
                {
                    new ErrorWindow(Texts.CantSendMail + ex.ToString()) { Owner = View }.ShowDialog();
                }
            }
        }
        void SendScheduler(object array)
        {
            if (array is object[] arr)
            {
                SchedulerClass sc = new SchedulerClass();
                try
                {
                    if (Dates == null || Dates.Count == 0) throw new SendClassFillException(Texts.DateAndTimeNotCorrect);
                    Dates.ToList().ForEach(x => sc.DatesEmailTexts.Add(x.Date, x.Letter));
                    EmailSendServiceClass serviceClass = PrepairSendClass(arr,SendType.Scheduler);
                    sc.SendEmails(serviceClass, Emails);
                }
                catch (SendClassFillException ex)
                {
                    new ErrorWindow(ex.Message) { Owner = View }.ShowDialog();
                }
                catch (Exception ex)
                {
                    new ErrorWindow(Texts.CantSendMail + ex.ToString()) { Owner = View }.ShowDialog();
                }
            }
        }
        EmailSendServiceClass PrepairSendClass(object[] array, SendType send)
        {
            string strLogin, strPassword, smtpHost, subject = null, letter = null;

            strLogin = array[0].ToString();
            if (string.IsNullOrEmpty(strLogin)) throw new SendClassFillException(Texts.LoginNotCorrect);

            strPassword = array[1].ToString();
            if (string.IsNullOrEmpty(strPassword)) throw new SendClassFillException(Texts.PassNotCorrect);

            smtpHost = array[2].ToString();
            int smtpPort = int.Parse(array[3].ToString());

            switch (send)
            {
                case SendType.Scheduler:
                    
                    break;
                case SendType.SendAtOnce:
                    if (!(array[5] is FlowDocument doc)) throw new SendClassFillException(Texts.LetterNotFilled);

                    subject = array[4].ToString();
                    letter = new TextRange(doc.ContentStart, doc.ContentEnd).Text;
                    break;
                default:
                    break;
            }

            return new EmailSendServiceClass(strLogin, strPassword, smtpHost, smtpPort, subject, letter);
        }


        void AddDate(ObservableCollection<DateTime> calDates)
        {
            if (calDates == null || calDates.Count < 0) return;
            else
            {
                Dates = new ObservableCollection<SchedulerLeter>();
                if (calDates.Count == 1) Dates.Add(new SchedulerLeter(calDates[0]));
                else calDates.ToList().ForEach(x => Dates.Add(new SchedulerLeter(x)));
            }

        }
        void RemoveDate(DateTime date)
        {
            Dates.Remove(Dates.First(x => Equals(x.Date, date)));
        }
        void GetLetter(DateTime date)
        {
            var obj = Dates.First(x => Equals(x.Date, date));
            var letterWindow = new LetterWindow { Owner = View, Letter = new FlowDocument(new Paragraph(new Run(obj.Letter))) };
            if (letterWindow.ShowDialog() == true)
            {
                obj.Letter = new TextRange(letterWindow.Letter.ContentStart, letterWindow.Letter.ContentEnd).Text;
            }
        }
        void GetEmails()
        {
            Emails.Clear();
            if (string.IsNullOrEmpty(Name)) foreach (var item in serviceProxy.GetEmails()) Emails.Add(item);
            else (serviceProxy.GetEmails().Where(x => x.Name.Contains(Name))).ToList().ForEach(p => Emails.Add(p));
        }
        void SaveEmail(Email email)
        {
            EmailInfo.Id = serviceProxy.CreateEmail(email);
            if (EmailInfo.Id != 0)
            {
                Emails.Add(EmailInfo);
                RaisePropertyChanged(nameof(EmailInfo));
            }
        }
    }

    public enum SendType
    {
        Scheduler, SendAtOnce
    }
}