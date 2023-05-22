using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectMySQL
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";// Расположение MySQL Server
            int port = 3306;
            string database = "homework02";// Имя БД
            string username = "root";
            string password = "";//Паноль от MySQL

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}
