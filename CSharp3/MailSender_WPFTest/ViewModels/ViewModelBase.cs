using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MailSender_WPFTest.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose() { OnDispose(); }
        protected abstract void OnDispose();
    }
}
