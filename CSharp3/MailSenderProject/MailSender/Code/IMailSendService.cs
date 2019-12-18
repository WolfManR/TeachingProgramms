namespace MailSender.Code
{
    public interface IMailSendService
    {
        string SenderEmail { get; set; }
        string SenderPassword { get; set; }
        string SMTPHost { get; set; }
        int SMTPPort { get; set; }
        bool EnableSSL { get; set; }
        bool IsBodyHTML { get; set; }

        void SendMail(string title, string letter, params string[] emailsToSend);
    }
}