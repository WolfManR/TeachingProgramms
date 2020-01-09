using MailSender.Views;
using System;
using System.Windows;

namespace MailSender.Code
{
    public static class MessageDialog
    {
        public static Window ViewOwner { get; set; } = Application.Current.MainWindow;
        public static void ShowDialog(MessageDialogType type, string message=null, string title=null)
        {
            switch (type)
            {
                case MessageDialogType.Error:
                    new ErrorMessage(message, "&#xE783;") { Owner=ViewOwner,Title = title }.ShowDialog();
                    break;
                case MessageDialogType.Message:
                    new ErrorMessage(message) { Owner = ViewOwner,Title=title }.ShowDialog();
                    break;
                case MessageDialogType.WorkDone:
                    new SendEndWindow { Owner = ViewOwner }.ShowDialog();
                    break;
                default:
                    throw new ApplicationException("There no this type Message Window");
            }
        }
    }

    public enum MessageDialogType
    {
        Error,Message,WorkDone
    }
}
