using MailSender_WPFTest.Commands;
using MailSender_WPFTest.LinqToSQL;
using MailSender_WPFTest.Models;
using MailSender_WPFTest.Resources.Text;
using MailSender_WPFTest.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace MailSender_WPFTest.ViewModels
{
    public class WPFMailSenderViewModel
    {
        private readonly Window view;
        private static readonly DBclass db = new DBclass();

        #region SendMailCmd
        private RelayCommand<object> sendMailCmd = null;
        public RelayCommand<object> SendMailCmd => sendMailCmd ?? (sendMailCmd = new RelayCommand<object>(
            (param) => {
                var bindings = (object[])param;
                SendService.SMTPHost = (string)bindings[2];
                SendService.SMTPPort = int.Parse(bindings[3].ToString());
                SendService.EnableSSL = (bool)bindings[4];
                string[] emails = new string[SelectedEmails.Count];
                for (int i = 0; i < SelectedEmails.Count; i++)
                {
                    emails[i] = SelectedEmails[i].Email;
                }
                try
                {
                    // Find way to take Password correctly
                    SendService.SendMail((string)bindings[0], ((System.Windows.Controls.PasswordBox)bindings[1]).Password, (string)bindings[5], (string)bindings[6], emails);
                }
                catch (Exception ex)
                {
                    new ErrorMessageView(Errors.CantSendMail + "\n" + ex.ToString()) { Owner = view, Title = "Error" }.ShowDialog();
                }

                new SendEndWindow() { Owner = view }.ShowDialog();

            },
            param => param != null && SelectedEmails.Count != 0));
        #endregion

        #region addToSelectedCmd
        private RelayCommand<Emails> addToSelectedCmd = null;
        public RelayCommand<Emails> AddToSelectedCmd => addToSelectedCmd ?? (addToSelectedCmd = new RelayCommand<Emails>(
            (param) => {
                SelectedEmails.Add(param);
                Emails.Remove(param);
            },
            param => param != null && param is Emails));
        #endregion

        #region returnFromSelectedCmd
        private RelayCommand<Emails> returnFromSelectedCmd = null;
        public RelayCommand<Emails> ReturnFromSelectedCmd => returnFromSelectedCmd ?? (returnFromSelectedCmd = new RelayCommand<Emails>(
            (param) => {
                Emails.Add(param);
                SelectedEmails.Remove(param);
            },
            param => param != null && param is Emails));
        #endregion

        //public SenderSettings SenderSettings { get; set; }
        public MailSendService SendService { get; set; } = new MailSendService();

        public ObservableCollection<Emails> Emails { get; set; } = new ObservableCollection<Emails>(db.Emails);
        public ObservableCollection<Emails> SelectedEmails { get; set; } = new ObservableCollection<Emails>();
        public List<SMTP> SMTPs { get; set; } = db.SMTPs;

        public WPFMailSenderViewModel(Window view)
        {
            this.view = view;
        }
    }
}
