

using MySql.Data.MySqlClient;
using System.Data;

namespace CrudInMvc.DbConnection
{
    public class MvcDataContext : DB
    {
       

        private IConfiguration _config;
        public MvcDataContext (IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection getOpenConection()
        {
            string ConnectionString = _config["DB:ConnectionString"];

            IDbConnection connection = null;
            connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;

        }
    }
}
