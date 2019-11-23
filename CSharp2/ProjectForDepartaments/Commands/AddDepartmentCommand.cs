using ProjectForDepartaments.Models;
using System.Windows.Input;

namespace ProjectForDepartaments.Commands
{
    class AddDepartmentCommand : BaseCommand, ICommand
    {
        public override bool CanExecute(object parameter)
        {
            return parameter != null && parameter is Organization;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Organization organization)
            {
                var AddView = new Views.DepartmentAddView(organization);
                switch (AddView.ShowDialog())
                {
                    case true when (AddView.Department != null):
                        organization.Departments?.Add(AddView.Department);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
