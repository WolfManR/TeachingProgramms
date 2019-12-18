using System;
using System.Net;
using System.Net.Mail;

namespace MailSender.Code
{
    public class MailSendService : IMailSendService
    {
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public bool EnableSSL { get; set; } = true;
        public bool IsBodyHTML { get; set; } = false;

        public MailSendService() { }

        // изменить на async
        public void SendMail(string title, string letter, params string[] emailsToSend)
        {
            foreach (string mail in emailsToSend)
            {
                using (MailMessage mm = new MailMessage(SenderEmail, mail))
                {
                    mm.Subject = title;
                    mm.Body = letter;
                    mm.IsBodyHtml = IsBodyHTML;

                    using (SmtpClient sc = new SmtpClient(SMTPHost, SMTPPort))
                    {

                        sc.EnableSsl = EnableSSL;
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
