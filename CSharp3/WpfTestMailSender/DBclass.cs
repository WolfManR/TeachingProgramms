using System.Collections.Generic;
using System.Linq;

namespace WpfTestMailSender
{
    /// <summary>
    /// Класс, который отвечает за работу с базой данных
    /// </summary>
    public class DBclass
    {
        private EmailsDataContext emails = new EmailsDataContext();
        public IQueryable<Email> Emails
        {
            get
            {
                return from c in emails.Email select c;
            }
        }
        public Dictionary<string,int> Smtps
        {
            get
            {
                Dictionary<string, int> pairs = new Dictionary<string, int>();
                (from c in emails.Smtp select c).ToList().ForEach(p => pairs.Add(p.Host, p.Port));
                return pairs;
            }
        }
    }

}
