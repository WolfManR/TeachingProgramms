﻿using MailSender.Data.LinqToSQL;
using MailSender.Data.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MailSender.Code
{
    public class SchedulerService
    {
        public User From { get; set; }
        public Mail Mail { get; set; }
        public ObservableCollection<Emails> To { get; set; }
        public ObservableCollection<Date> Dates { get; set; }
        public bool Complete { get; set; }


        public void CheckDates(DateTime now,IMailSendService sendService)
        {
            foreach (var item in Dates)
            {
                switch (item.Complete)
                {
                    case Success.True:
                        continue;
                    case Success.False when item.Time==now: 
                        sendService.SenderEmail = From.Email;
                        sendService.SenderPassword = From.Password;

                        sendService.SMTPHost = From.SmtpSettings.Host;
                        sendService.SMTPPort = From.SmtpSettings.Port;
                        sendService.EnableSSL = From.SmtpSettings.EnableSSL;

                        sendService.IsBodyHTML = false;
                        try
                        {
                            sendService.SendMail(Mail.Subject, Mail.GetLetterAsString(), To.Select(x => x.Email).ToArray());
                        }
                        catch (Exception)
                        {
                            item.Complete = Success.Error;
                            item.ErrorMsg = "Something Go Wrong";
                            throw;
                        }
                        item.Complete = Success.True;
                        break;
                    case Success.False when item.Time > now:
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
