using OrganizationEF.EF;
using OrganizationEF.Models;
using OrganizationEF.Repos;
using ProjectForDepartaments.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ProjectForDepartaments.ViewModels
{
    public class OrganizationViewModel : INotifyPropertyChanged
    {
        private readonly Window view;
        static readonly GBOrganizationEntities context = new GBOrganizationEntities();
        readonly DepartmentRepo departRepo = new DepartmentRepo(context);
        readonly EmployeeRepo employeeRepo = new EmployeeRepo(context);
        private Employee selectedEmployee;
        private Department selectedDepartment;
        private RelayCommand addDepartmentCmd = null;
        private RelayCommand<Department> addNewEmployeeCmd = null;
        private RelayCommand<Employee> addNotHiredEmployeeCmd = null;
        private RelayCommand<Department> removeDepartmentCmd = null;
        private RelayCommand<Employee> fireEmployeeCmd = null;
        private RelayCommand<Employee> removeEmployeeCmd = null;
        private RelayCommand<object> swapDepartmentCmd = null;

        public RelayCommand AddDepartmentCmd => addDepartmentCmd ?? (addDepartmentCmd = new RelayCommand(() =>
         {
             var AddView = new Views.DepartmentAddView();
             view.IsEnabled = false;
             switch (AddView.ShowDialog())
             {
                 case true when (AddView.Department != null):
                     //add error "that item exist"
                     try
                     {
                         departRepo.Add(AddView.Department);
                     }
                     catch (System.Exception ex)
                     {
                         MessageBox.Show($"Something Bad Happend\n{ex.Message}");
                     }
                     
                     Departments.Add(AddView.Department);
                     Departments.Clear();
                     var departments = departRepo.GetAll();
                     departments.ForEach(x => Departments.Add(x));
                     break;
                 default:
                     break;
             }
             view.IsEnabled = true;
         }));
        public RelayCommand<Department> RemoveDepartmentCmd => removeDepartmentCmd ?? (removeDepartmentCmd = new RelayCommand<Department>(
            (parameter) => {
                Departments.Remove(parameter);
                UpdateEmployeeCollection(NotHired, null);
            },
            param => param != null && param is Department));
        public RelayCommand<Department> AddNewEmployeeCmd => addNewEmployeeCmd ?? (addNewEmployeeCmd = new RelayCommand<Department>(
            (parameter) => {
                var AddView = new Views.EmployeeAddView(parameter);
                view.IsEnabled = false;
                switch (AddView.ShowDialog())
                {
                    case true when AddView.Employee != null:
                        //add error "that item exist"
                        try
                        {
                            employeeRepo.Add(AddView.Employee);
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show($"Something Bad Happend\n{ex.Message}");
                        }
                        
                        UpdateEmployeeCollection(Employees, parameter.Id);
                        selectedDepartment.IsChanged = true;
                        selectedDepartment.IsChanged = false;
                        break;
                    default:
                        break;
                }
                view.IsEnabled = true;
            },
            param => param != null && param is Department));
        public RelayCommand<Employee> AddNotHiredEmployeeCmd => addNotHiredEmployeeCmd ?? (addNotHiredEmployeeCmd = new RelayCommand<Employee>(
            (param) =>
            {
                Employee empl = param as Employee;
                NotHired.Remove(empl);
                empl.Department = selectedDepartment;
                empl.DepartmentId = selectedDepartment.Id;
                try
                {
                    employeeRepo.Save(empl);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Something Bad Happend\n{ex.Message}");
                }

                UpdateEmployeeCollection(Employees, selectedDepartment.Id);
                
                selectedDepartment.IsChanged = true;
                selectedDepartment.IsChanged = false;
            },
            (param) => param != null && param is Employee && selectedDepartment!=null
            ));
        public RelayCommand<Employee> FireEmployeeCmd => fireEmployeeCmd ?? (fireEmployeeCmd = new RelayCommand<Employee>(
            (parameter) => {
                try
                {
                    employeeRepo.Delete(parameter);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Something Bad Happend\n{ex.Message}");
                }
                
                Employees.Remove(parameter);
                selectedDepartment.IsChanged = true;
                selectedDepartment.IsChanged = false;
            },
            param => param != null && param is Employee));
        public RelayCommand<Employee> RemoveEmployeeCmd => removeEmployeeCmd ?? (removeEmployeeCmd = new RelayCommand<Employee>(
            (parameter) => {
                try
                {
                    employeeRepo.Delete(parameter);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Something Bad Happend\n{ex.Message}");
                }
                
                NotHired.Remove(parameter);
            },
            param => param != null && param is Employee));
        public RelayCommand<object> SwapDepartmentCmd => swapDepartmentCmd ?? (swapDepartmentCmd = new RelayCommand<object>(
            (param) =>
            {
                var array = (object[])param;
                Department to = array[0] as Department;
                Employee empl = array[1] as Employee;
                empl.Department = to;
                empl.DepartmentId = to.Id;
                try
                {
                    employeeRepo.Save(empl);

                    Employees.Remove(empl);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show($"Something Bad Happend\n{ex.Message}");
                }
                
                selectedDepartment.IsChanged = true;
                selectedDepartment.IsChanged = false;
                to.IsChanged = true;
                to.IsChanged = false;
            },
            (param) =>
                param != null && 
                param is object[] array &&
                array.Length == 2 &&
                array[0] is Department dep && dep!=SelectedDepartment && 
                array[1] is Employee
            ));

        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                if (selectedDepartment == value) return;
                SelectedEmployee = null;
                selectedDepartment = value;
                if (value != null)
                {
                    Employees.Clear();
                    var list = (from x in employeeRepo.GetAll() where x.DepartmentId == value.Id select x).ToList();
                    list.ForEach(x => Employees.Add(x));
                }
                OnPropertyChanged();
            }
        }
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                if (selectedEmployee == value) return;
                selectedEmployee = value;
                OnPropertyChanged();
            }
        }
        public string OrganizationName { get; set; } = "GeekBrains";

        public IList<Department> Departments { get; set; } = new ObservableCollection<Department>();
        public IList<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public IList<Employee> NotHired { get; set; } = new ObservableCollection<Employee>();

        public OrganizationViewModel(Window view)
        {
            this.view = view;
            var departments = departRepo.GetAll();
            departments.ForEach(x=>Departments.Add(x));
            var list = (from x in employeeRepo.GetAll() where x.DepartmentId == null select x).ToList();
            list.ForEach(x => NotHired.Add(x));
            (Departments as ObservableCollection<Department>).CollectionChanged += Departments_CollectionChanged;
            (Employees as ObservableCollection<Employee>).CollectionChanged += Employees_CollectionChanged;
        }


        private void Departments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var action = e.Action;
            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (Department item in e.OldItems)
                    {
                        departRepo.Delete(item);
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }
        private void Employees_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var action = e.Action;
            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    
                    break;
                case NotifyCollectionChangedAction.Remove:
                    //selectedDepartment.IsChanged = true;
                    //selectedDepartment.IsChanged = false;
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        void UpdateEmployeeCollection<T>(IList<T> collection,int? departmentId) where T: Employee
        {
            collection.Clear();
            var list = (from x in employeeRepo.GetAll() where x.DepartmentId == departmentId select x).ToList();
            list.ForEach(x => collection.Add((T)x));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
