using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMySQL
{
    internal class Operations
    {
        MySqlConnection connect;
        MySqlCommand cmd;

        public Operations (MySqlConnection connect)
        {
            // Коннектор с ДБ
            this.connect = connect;
            // Создать объект Command
            this.cmd = new MySqlCommand();
            // Сочетать Command с Connection
            cmd.Connection = this.connect;
        }

        public void Query()
        {
            string sql = "SELECT id, user_name, pass FROM test_connect";
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader.GetValue(0)); //id index = 0
                        string user = reader.GetString(1);//user_name index = 1
                        int passIndex = reader.GetOrdinal("pass");// pass index = 2
                        string pass = reader.GetString(passIndex);

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Id:" + id);
                        Console.WriteLine("user:" + user);
                        Console.WriteLine("pass:" + pass);
                    }
                }
            }
        }

        public void Insert(string uname, string upass)
        {
            // Создать объект Parameter.
            MySqlParameter user_name = new MySqlParameter(
                $"'{uname}'", SqlDbType.VarChar);
            cmd.Parameters.Add(user_name);

            // Добавить параметр @highSalary (Написать кратко).
            MySqlParameter pass = new MySqlParameter(
                $"'{upass}'", SqlDbType.VarChar);
            cmd.Parameters.Add(pass);

            string sql = $"INSERT INTO test_connect(user_name, pass) " +
                $"VALUES ({user_name}, {pass});";
            cmd.CommandText = sql;

            // Выполнить Command (использованная для  delete, insert, update).
            cmd.ExecuteNonQuery();

            Console.WriteLine("New operation: " + sql + '\n');
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM test_connect WHERE id = {id};";
            cmd.CommandText = sql;

            // Выполнить Command (использованная для  delete, insert, update).
            cmd.ExecuteNonQuery();
            Console.WriteLine("New operation: " + sql + '\n');
        }
    }
}
