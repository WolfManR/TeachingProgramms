using MailSender_WPFTest.LinqToSQL;
using System.Collections.Generic;
using System.Linq;

namespace MailSender_WPFTest.Models
{
    public class DBclass
    {
        private EmailsDataContext context = new EmailsDataContext();
        public List<Emails> Emails { get => (from c in context.Emails select c).ToList(); }
        public List<SMTP> SMTPs { get => (from c in context.SMTP select c).ToList(); }

        void AddEmail()
        {
            
        }
    }
}
