using OrganizationProject_ADO_Library.ADO;
using OrganizationProject_ADO_Library.Repos;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OrganizationProject_ADO_WPF.ViewModels
{
    public class MainWindowViewModel
    {
        public static ADOBase Context { get; } = new ADOBase(ConfigurationManager.ConnectionStrings["InAppData"].ConnectionString, new SqlDataAdapter());
        readonly DepartmentRepo departmentRepo = new DepartmentRepo(Context);
        readonly EmployeeRepo employeeRepo = new EmployeeRepo(Context);

        public DataTable Departments { get; set; } = new DataTable();
        public DataTable Employees { get; set; } = new DataTable();

        public MainWindowViewModel()
        {
            departmentRepo.Init();
            Context.Adapter.Fill(Departments);
            employeeRepo.Init();
            Context.Adapter.Fill(Employees);
        }
    }
}
