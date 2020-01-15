namespace MailSender.Data.Models
{
    public class TaskAndEmails
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmailId { get; set; }

        public SchedulerTask Task { get; set; }
        public Emails Email { get; set; }
    }
}
