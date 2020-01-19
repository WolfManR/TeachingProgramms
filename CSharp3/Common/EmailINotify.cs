using System.ComponentModel;

namespace Common
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
                    if (Value != null && Value.Length < 4) return "Необходимо указать правильный e-mail!";
                }
                return "";
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
