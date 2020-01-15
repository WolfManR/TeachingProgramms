using MailSender.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MailSender.Code
{
    public class Scheduler
    {
        public MailSendService SendService { get; set; }
        public ObservableCollection<Date> Dates { get; set; }
        public int Timer { get; set; }

        public void AddTask(List<Date> dates) 
        {
            dates.ForEach(x => Dates.Add(x));
        }

        public void CheckDates(DateTime now)
        {
            foreach (var item in Dates)
            {
                switch (item.Complete)
                {
                    case Success.Complete:
                        continue;
                    case Success.NotSend when item.Time == now:
                        SendService.SenderEmail = item.Task.From.Email;
                        SendService.SenderPassword = item.Task.From.Password;

                        SendService.SMTPHost = item.Task.From.SmtpSettings.Host;
                        SendService.SMTPPort = item.Task.From.SmtpSettings.Port;
                        SendService.EnableSSL = item.Task.From.SmtpSettings.EnableSSL;

                        SendService.IsBodyHTML = false;
                        try
                        {
                            SendService.SendMail(item.Task.Subject, item.Task.GetLetterAsString(), item.Task.To.Select(x => x.Email).ToArray());
                        }
                        catch (Exception)
                        {
                            item.Complete = Success.Error;
                            item.ErrorMsg = "Something Go Wrong";
                            throw;
                        }
                        item.Complete = Success.Complete;
                        break;
                    case Success.NotSend when item.Time > now:
                        throw new Exception($"Left send Time {item.Time}");
                    case Success.Error:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
