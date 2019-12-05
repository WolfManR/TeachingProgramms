using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;

namespace MailSender_WPFTest.Models
{
    public class EmailSendServiceClass
    {
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public ObservableCollection<string> EmailsToSend { get; set; }

        public EmailSendServiceClass(string senderEmail, string senderPassword, string smtpHost, int smtpPort) : this(senderEmail, senderPassword, smtpHost, smtpPort, null) { }
        public EmailSendServiceClass(string senderEmail, string senderPassword, string smtpHost, int smtpPort, IList<string> emailsToSend)
        {
            SenderEmail = senderEmail; 
            SenderPassword = senderPassword;
            SMTPHost = smtpHost;
            SMTPPort = smtpPort;
            EmailsToSend = new ObservableCollection<string>(emailsToSend);
        }

        public void SendMail(string title, string letter)
        {
            foreach (string mail in EmailsToSend)
            {
                using (MailMessage mm = new MailMessage(SenderEmail, mail))
                {
                    mm.Subject = title;
                    mm.Body = letter;
                    mm.IsBodyHtml = false;

                    using (SmtpClient sc = new SmtpClient(SMTPHost, SMTPPort))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }
    }
}
