using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Winforms_Db_MS_Sql_Server.Classes
{
    public class DataBase
    {
        private readonly SqlConnection sqlConnection = new SqlConnection(@"Server=DBSRV\DUB2023;Database=Igors_project_data_base;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;encrypt=false");

        public DataBase() { }

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public DataTable SqlSelect(string query)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand(query, GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                var g = table;
                return table;
            }
        }

        public async Task<DataTable> SqlSelectAsync(string query)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand(query, GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public SqlCommand SqlInsert(string query)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand(query, GetConnection()))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
            return new SqlCommand();
        }

        public async Task<SqlCommand> SqlInsertAsync(string query)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand(query, GetConnection()))
            {
                await command.ExecuteNonQueryAsync();
            }
            CloseConnection();
            return new SqlCommand();
        }
    }
}
