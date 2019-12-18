using System.ComponentModel;

namespace WpfTestMailSender
{
    public partial class Email : INotifyPropertyChanging, INotifyPropertyChanged, IDataErrorInfo
    {
        public string Error { get => ""; }

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "Value")
                {
                    if (_Value != null && _Value.Length < 4) return "Необходимо указать правильный e-mail!";
                }
                return "";
            }
        }
    }
}
