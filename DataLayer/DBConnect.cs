using System.Data.SqlClient;

namespace DataLayer
{
    public class DBConnect
    {
        private string conString = "Data Source=DESKTOP-3DRJQ43\\SQLEXPRESS;Initial Catalog=CentricaDemo;Integrated Security=True";
        private SqlConnection sqlConnection = null;

        public DBConnect()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = conString
            };
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }
    }
}
