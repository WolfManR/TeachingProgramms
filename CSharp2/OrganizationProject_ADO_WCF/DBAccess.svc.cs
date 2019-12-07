using OrganizationProject_ADO_Library.ADO;
using OrganizationProject_ADO_Library.Enums;
using OrganizationProject_ADO_Library.Repos;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OrganizationProject_ADO_WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class DBAccess : IDBAccess
    {
        static ADOBase Context { get; } = new ADOBase(ConfigurationManager.ConnectionStrings["InAppData"].ConnectionString, new SqlDataAdapter());
        readonly DepartmentRepo departmentRepo = new DepartmentRepo(Context);
        readonly EmployeeRepo employeeRepo = new EmployeeRepo(Context);

        public void GetData(TableNames name,ref DataTable table)
        {
            switch (name)
            {
                case TableNames.Departments:
                    departmentRepo.Init();
                    Context.Adapter.Fill(table);
                    break;
                case TableNames.Employees:
                    employeeRepo.Init();
                    Context.Adapter.Fill(table);
                    break;
                default:
                    break;
            }
        }
    }
}
