using System;
using System.Net;
using System.Net.Mail;

namespace MailSender_WPFTest.Models
{
    public class MailSendService
    {
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public bool EnableSSL { get; set; } = true;
        public bool IsBodyHTML { get; set; } = false;

        public MailSendService(string senderEmail, string senderPassword, string smtpHost, int smtpPort)
        {
            SenderEmail = senderEmail;
            SenderPassword = senderPassword;
            SMTPHost = smtpHost;
            SMTPPort = smtpPort;
        }

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

        public void SendMail(MailMessage letter, SmtpClient client, params string[] emailsToSend)
        {

            using (letter)
            {
                foreach (var item in emailsToSend)
                {
                    letter.To.Add(item);
                }

                using (client)
                {
                    try
                    {
                        client.Send(letter);
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
