using MailSender_WPFTest.Commands;
using MailSender_WPFTest.Models;

namespace MailSender_WPFTest.ViewModels
{
    public class WPFMailSenderViewModel
    {
        private RelayCommand sendMailCmd = null;
        public RelayCommand SendMailCmd => sendMailCmd ?? (sendMailCmd = new RelayCommand(
            () => {

            }
            ));

        public SenderSettings SenderSettings { get; set; }

        public MailSendService SendService { get; set; }
    }
}
