using System;
using System.Net;
using System.Net.Mail;

namespace MailSender_WPFTest.Models
{
    public class MailSendService
    {
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public bool EnableSSL { get; set; } = true;
        public bool IsBodyHTML { get; set; } = false;

        public MailSendService() { }

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

        public static void SendMail(MailMessage letter, SmtpClient client, params string[] emailsToSend)
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
