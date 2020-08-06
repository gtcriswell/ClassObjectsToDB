using System.Data.SqlClient;

namespace ClassObjectsToDB
{
    public class ConnectionInfo
    {
        private static string _ConnectionString { get; set; }

        public ConnectionInfo(string ConnectionString)
        {
            _ConnectionString = ConnectionString;

        }

        public static SqlConnection Connection
        {
            get
            {

                SqlConnection objConn = new SqlConnection(_ConnectionString);
                return objConn;
            }
        }
    }
}
