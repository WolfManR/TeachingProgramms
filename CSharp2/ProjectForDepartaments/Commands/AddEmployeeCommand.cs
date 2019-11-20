using ProjectForDepartaments.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProjectForDepartaments.Commands
{
    public class AddEmployeeCommand : BaseCommand, ICommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is ObservableCollection<Employee>;
        }

        public override void Execute(object parameter)
        {
            if (parameter is ObservableCollection<Employee> Employees)
            {
                var AddView = new Views.EmployeeAddView();
                switch (AddView.ShowDialog())
                {
                    case true when AddView.Employee!=null:
                        Employees?.Add(AddView.Employee);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
