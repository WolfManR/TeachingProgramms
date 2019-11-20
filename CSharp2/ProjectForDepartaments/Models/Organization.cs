using System.Collections.ObjectModel;

namespace ProjectForDepartaments.Models
{
    public class Organization
    {
        public ObservableCollection<Department> Departments { get; set; }
        public string Name { get; set; }
        public Organization(string name)
        {
            Name = name;
            Departments = new ObservableCollection<Department>();
        }


        //[Obsolete("Name of Method must change in future")]
        //public static void SwitchDepartment(Department from, Department to, Employee employee)
        //{
        //    var worker = from.RemoveEmployee(employee);
        //    to.AddEmployee(worker);
        //}

    }
}
