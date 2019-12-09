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

    }

}
