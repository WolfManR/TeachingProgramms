
using OrganizationProject_ADO_WPF.WCF_ADOReference;
using System.Data;
using System.Threading.Tasks;

namespace OrganizationProject_ADO_WPF.ViewModels
{
    public class MainWindowViewModel
    {
        public DataTable Departments { get; set; } = new DataTable();
        public DataTable Employees { get; set; } = new DataTable();

    }
}
