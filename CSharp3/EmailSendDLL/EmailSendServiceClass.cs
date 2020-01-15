using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSendDLL
{
    public class EmailSendServiceClass
    {
        #region vars
        private string strLogin;        
        private string strPassword;     
        private string strSmtp;         
        private int iSmtpPort;          
        private string strBody;         
        private string strSubject;
        public string Body { get=>strBody; set {strBody=value; } }
        public string Subject { get=>strSubject; set {strSubject=value; } }
        #endregion
        
        public EmailSendServiceClass(string sLogin, string sPassword, string smtpHost, int smtpPort, string subject, string text)
        {
            strLogin = sLogin;
            strPassword = sPassword;
            this.strSmtp = smtpHost;
            this.iSmtpPort = smtpPort;
            this.strBody = text;
            this.strSubject = subject;
        }

        private Task SendMail(object mail) // Отправка email конкретному адресату
        {
            return Task.Run(() => { 
            using (MailMessage mm = new MailMessage(strLogin, (string)mail))
            {
                mm.Subject = strSubject;
                mm.Body = strBody;
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
                try
                {
                    sc.Send(mm);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            });
        }
        public async void SendMailsAsync(IEnumerable<string> emails)
        {
            foreach (object email in emails)
            {
                await SendMail(email);
            }
        }
    }
}
