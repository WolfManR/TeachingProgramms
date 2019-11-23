using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private Organization organization;
        private Department department;
        private string lastName;
        private string firstName;

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value) return;
                lastName = value;
                OnPropertyChanged();
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value) return;
                firstName = value;
                OnPropertyChanged();
            }
        }

        public Organization Organization
        {
            get => organization;
            set
            {
                if (organization == value) return;
                organization = value;
                OnPropertyChanged();
            }
        }
        public Department Department
        {
            get => department;
            set
            {
                if (department == value) return;
                department = value;
                OnPropertyChanged();
            }
        }

        public Employee() : this(null, null) { }
        public Employee(string firstName, string lastName) : this(firstName, lastName, null, null) { }
        public Employee(string lastName, string firstName, Department department, Organization organization)
        {
            LastName = lastName;
            FirstName = firstName;
            Department = department;
            Organization = organization;
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
