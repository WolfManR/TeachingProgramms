using ProjectForDepartaments.Models;
using System.Windows.Input;

namespace ProjectForDepartaments.Commands
{
    public class AddEmployeeCommand : BaseCommand, ICommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is Department;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Department dep)
            {
                var AddView = new Views.EmployeeAddView(dep);
                switch (AddView.ShowDialog())
                {
                    case true when AddView.Employee != null:
                        dep.Employees?.Add(AddView.Employee);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
