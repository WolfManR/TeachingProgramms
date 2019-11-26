using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectForDepartaments.Models
{
    public class Department : INotifyPropertyChanged
    {
        private Organization organization;
        private string name;

        public ObservableCollection<Employee> Employees { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;
                name = value;
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

        public Department() : this(null) { }
        public Department(string name) : this(name, null) { }
        public Department(string name, Organization organization)
        {
            Name = name;
            Organization = organization;
            Employees = new ObservableCollection<Employee>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public override bool Equals(object obj)
        {
            return obj is Department department &&
                   EqualityComparer<ObservableCollection<Employee>>.Default.Equals(Employees, department.Employees) &&
                   Name == department.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -716137428;
            hashCode = hashCode * -1521134295 + EqualityComparer<ObservableCollection<Employee>>.Default.GetHashCode(Employees);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
