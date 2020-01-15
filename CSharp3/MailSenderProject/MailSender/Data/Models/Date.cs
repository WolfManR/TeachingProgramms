using MailSender.Code;
using System;

namespace MailSender.Data.Models
{
    public class Date
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Success Complete { get; set; } = Success.NotSend;
        public string ErrorMsg { get; set; } = null;
        public int TaskId { get; set; }

        public SchedulerTask Task { get; set; }
    }
}
