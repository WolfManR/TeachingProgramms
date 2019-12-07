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
    }
}
