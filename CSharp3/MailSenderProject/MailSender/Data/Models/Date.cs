using MailSender.Code;
using System;

namespace MailSender.Data.Models
{
    public class Date
    {
        public DateTime Time { get; set; }
        public Success Complete { get; set; }
        public string ErrorMsg { get; set; }
    }
}
