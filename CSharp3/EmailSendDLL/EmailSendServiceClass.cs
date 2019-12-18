using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

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

        private void SendMail(string mail) // Отправка email конкретному адресату
        {
            using (MailMessage mm = new MailMessage(strLogin, mail))
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
        }//private void SendMail(string mail, string name)
        public void SendMails(IEnumerable<string> emails)
        {
            foreach (string email in emails)
            {
                SendMail(email);
            }
        }
    }  //private void SendMail(string mail, string name)
}
