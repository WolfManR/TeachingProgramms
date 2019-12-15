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
    public class MainViewModel : ViewModelBase
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
        }
        public Window view { get; set; }
        ObservableCollection<Email> emails;
        IDataAccessService serviceProxy;
        private Email emailInfo;
        private string name;
        private Dictionary<DateTime,string> dates;
        public Dictionary<DateTime,string> Dates
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

        public RelayCommand ReadAllCommand { get; set; }
        public RelayCommand<Email> SaveCommand { get; set; }
        public RelayCommand<ObservableCollection<DateTime>> AddDateCommand { get; set; }
        public RelayCommand<DateTime> RemoveDateCommand { get; set; }
        public RelayCommand<DateTime> OpenLetterEditCommand { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
                RaisePropertyChanged(nameof(Name));
                Emails.Clear();
                (serviceProxy.GetEmails().Where(x => x.Name.Contains(Name))).ToList().ForEach(p => Emails.Add(p));
            }
        }

        void AddDate(ObservableCollection<DateTime> calDates)
        {
            if (calDates == null || calDates.Count < 0) return;
            else
            {
                Dates = new Dictionary<DateTime,string>();
                if (calDates.Count == 1) Dates.Add(calDates[0], null);
                else calDates.ToList().ForEach(x => Dates.Add(x,null));
            }
            
        }
        void RemoveDate(DateTime date)
        {
            Dates.Remove(date);
        }
        void GetLetter(DateTime date)
        {
            var letterWindow = new LetterWindow { Owner = view };
            if(letterWindow.ShowDialog() == true)
            {
                Dates[date] = new TextRange(letterWindow.Letter.ContentStart, letterWindow.Letter.ContentEnd).Text;
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
}