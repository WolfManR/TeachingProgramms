using MailSender.Data.Models;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace MailSender.Data
{
    public class DataContext
    {
        public List<Emails> Emails { get; } = new List<Emails>
        {
            new Emails{Id=1,Email="wolfman301@gmail.com",Name="MyGmail2"},
            new Emails{Id=2,Email="wolfmanr@mail.ru",Name="MyMail"}
        };

        public List<SMTP> SMTPs { get; } = new List<SMTP>
        {
            new SMTP{Id=1,Host="smtp.yandex.ru",Port=465,EnableSSL=true,For="Yandex"},
            new SMTP{Id=2,Host="smtp.gmail.com",Port=587,EnableSSL=true,For="Gmail"}
        };

        public List<SchedulerTask> Tasks { get; } = new List<SchedulerTask>
        {
            new SchedulerTask
            {
                Id=1,
                From=new User{ Email="somebody@gmail.com",Password="Gh2ks9fc2",SMTPSettingsId=2 },
                Subject="Test1 Theme",
                Letter=new FlowDocument(new Paragraph(new Run("Some Text")))
            }
        };

        public List<Date> Dates = new List<Date>
        {
            new Date{Id=1,TaskId=1,Time=new DateTime(2020,2,12,14,45,0)}
        };

        public List<TaskAndEmails> TaskAndEmails = new List<TaskAndEmails>
        {
            new TaskAndEmails{Id=1,TaskId=1,EmailId=2},
            new TaskAndEmails{Id=2,TaskId=1,EmailId=1}
        };
    }
}
