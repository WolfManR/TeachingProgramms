using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            ReadAllCommand = new RelayCommand<string>(GetEmails);

            EmailInfo = new Email();
            SaveCommand = new RelayCommand<Email>(SaveEmail);
        }

        ObservableCollection<Email> emails;
        IDataAccessService serviceProxy;
        private Email emailInfo;
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

        public RelayCommand<string> ReadAllCommand { get; set; }
        public RelayCommand<Email> SaveCommand { get; set; }


        void GetEmails(string name)
        {
            Emails.Clear();
            if(string.IsNullOrEmpty(name)) foreach (var item in serviceProxy.GetEmails()) Emails.Add(item);
            else (serviceProxy.GetEmails().Where(x => x.Name.Contains(name) )).ToList().ForEach(p => Emails.Add(p));
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