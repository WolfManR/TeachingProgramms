using System.Data.SqlClient;

namespace OrganizationProject_ADO_Library.ADO
{
    public class ADOBase
    {
        public SqlConnection Connection { get; }
        public SqlDataAdapter Adapter { get; }
        public ADOBase(string connectionString, SqlDataAdapter adapter)
        {
            Connection = new SqlConnection(connectionString);
            Adapter = adapter;
        }

        public void SetSelectCommand(SqlCommand command)
        {
            Adapter.SelectCommand = command;
        }
        public void SetInsertCommand(SqlCommand command)
        {
            Adapter.InsertCommand = command;
        }
        public void SetUpdateCommand(SqlCommand command)
        {
            Adapter.UpdateCommand = command;
        }
        public void SetDeleteCommand(SqlCommand command)
        {
            Adapter.DeleteCommand = command;
        }

    }
}
