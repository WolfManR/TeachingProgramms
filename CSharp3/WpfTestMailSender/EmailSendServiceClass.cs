using System;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    public class EmailSendServiceClass
    {
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public bool EnableSSL { get; set; } = true;
        public bool IsBodyHTML { get; set; } = false;

        public EmailSendServiceClass() { }

        // изменить на async
        public void SendMail(string senderEmail, string senderPassword, string title, string letter, params string[] emailsToSend)
        {
            foreach (string mail in emailsToSend)
            {
                using (MailMessage mm = new MailMessage(senderEmail, mail))
                {
                    mm.Subject = title;
                    mm.Body = letter;
                    mm.IsBodyHtml = IsBodyHTML;

                    using (SmtpClient sc = new SmtpClient(SMTPHost, SMTPPort))
                    {

                        sc.EnableSsl = EnableSSL;
                        sc.Credentials = new NetworkCredential(senderEmail, senderPassword);
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
