using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private bool isSelected = false;

        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public bool IsSelected
        {
            get => isSelected; 
            set
            {
                if (isSelected == value) return;
                isSelected = value;
                OnPropertyChanged();
            }
        }
        public Employee(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   LastName == employee.LastName &&
                   FirstName == employee.FirstName;
        }

        public override int GetHashCode()
        {
            var hashCode = -1698165572;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            return hashCode;
        }
    }
}
