using System.Data;
using System.Data.SqlClient;
using OrganizationProject_ADO_Library.ADO;

namespace OrganizationProject_ADO_Library.Repos
{
    public class DepartmentRepo : BaseRepo
    {
        public DepartmentRepo(ADOBase context) : base(context)
        {
            SelectAllCommand = new SqlCommand("Select * From Departments", context.Connection);

            InsertCommand = new SqlCommand("Insert Into Departments (Name) Values (@Name)", context.Connection);
            InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            InsertCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { Direction = ParameterDirection.Output });

            UpdateCommand = new SqlCommand(@"Update Departments Set Name = @Name", context.Connection);
            UpdateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { SourceVersion=DataRowVersion.Original });

            DeleteCommand = new SqlCommand(@"Delete From Departments Where Id = @Id", context.Connection);
            DeleteCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, -1, "Id") { SourceVersion = DataRowVersion.Original });
        }

    }
}
