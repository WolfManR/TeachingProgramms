using GalaSoft.MvvmLight.Command;
using MailSender.Code;
using MailSender.Data.Models;
using System;
using System.Linq;
using System.Windows.Documents;

namespace MailSender.ViewModel
{
    public partial class MainViewModel
    {
        #region SendMailCmd
        private RelayCommand<object> sendMailCmd = null;
        public RelayCommand<object> SendMailCmd => sendMailCmd ?? (sendMailCmd = new RelayCommand<object>(
            (param) => {
                var (doc, subject, password, smtp) = ((FlowDocument,string,string,SMTP))param;

                SendService.SenderEmail = UserEmail;
                SendService.SenderPassword = password;

                SendService.SMTPHost = smtp.Host;
                SendService.SMTPPort = smtp.Port;
                SendService.EnableSSL = smtp.EnableSSL;
                try
                {
                    SendService.SendMail(subject, new TextRange(doc.ContentStart,doc.ContentEnd).Text, SelectedEmails.Select(x => x.Email).ToArray());
                }
                catch (Exception ex)
                {
                    MessageDialog.ShowDialog(MessageDialogType.Error,"Невозможно отправить письмо " + "\n" + ex.ToString(),"Error");
                }
                MessageDialog.ShowDialog(MessageDialogType.WorkDone);
            },
            param => param != null && SelectedEmails.Count != 0 && Dates.Count==0));
        #endregion

        #region AddTaskToSchedulerCmd
        private RelayCommand<object> addTaskToSchedulerCmd = null;
        public RelayCommand<object> AddTaskToSchedulerCmd => addTaskToSchedulerCmd ?? (addTaskToSchedulerCmd = new RelayCommand<object>(
            (param) => {
                var (doc, subject, password, smtp) = ((FlowDocument, string, string, SMTP))param;
                Scheduler.AddTask(new SchedulerTask
                {
                    From=new User { Email=UserEmail,Password=password,SmtpSettings=smtp},
                    Subject=subject,
                    Letter=doc,
                    To=Emails
                }, Dates.ToList());
            },
            param=>param!=null&&Dates.Count>0));
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
    }
}
