using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizationProject_ADO_Library.ADO;

namespace OrganizationProject_ADO_Library.Repos
{
    public class EmployeeRepo : BaseRepo
    {
        public EmployeeRepo(ADOBase context) : base(context)
        {
            SelectAllCommand = new SqlCommand("Select * From Employees", context.Connection);

            InsertCommand = new SqlCommand("Insert Into Employees (FirstName,LastName,DepartmentId) Values (@Name)", context.Connection);
            InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            InsertCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { Direction = ParameterDirection.Output });

            UpdateCommand = new SqlCommand(@"Update Employees Set Name = @Name", context.Connection);
            UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { SourceVersion = DataRowVersion.Original });

            DeleteCommand = new SqlCommand(@"Delete From Employees Where Id = @Id", context.Connection);
            DeleteCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { SourceVersion = DataRowVersion.Original });
        }
    }
}
