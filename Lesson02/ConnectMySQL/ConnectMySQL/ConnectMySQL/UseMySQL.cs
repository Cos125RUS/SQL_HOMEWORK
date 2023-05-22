using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMySQL
{
    internal class UseMySQL
    {
        MySqlConnection connector;
        Operations operations;

        public UseMySQL ()
        {
            this.connector = DBUtils.GetDBConnection();
            this.operations= new Operations (connector);
        }

        public void Run() 
        {
            Console.WriteLine("Getting Connection ...");
            try
            {
                Console.WriteLine("Openning Connection ...");
                connector.Open();
                Console.WriteLine("Connection successful!\n");
                bool flag = true;

                while (flag)
                {
                    Console.Clear();
                    switch (ShowMenu())
                    {
                        case 1:
                            operations.Query();
                            break;
                        case 2:
                            (string uname, string pass) = EnterData();
                            operations.Insert(uname, pass);
                            break;
                        case 3:
                            operations.Delete(EnterId());
                            break;
                        default:
                            flag= false;
                            break;
                    }

                    if (flag)
                    {
                        Console.Write("\n\nPress Enter to Continue");
                        var key = Console.ReadKey(true).Key;
                    }
                    else Console.WriteLine("\nGood Bye!");
                }

                // Вставка данных
                //operations.Insert("user123", "qwerty");

                // Удаление строки
                //operations.Delete(13);

                // Просмотр таблицы
                //operations.Query();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                // Закрыть соединение.
                connector.Close();
                // Уничтожить объект, освободить ресурс.
                connector.Dispose();
            }

            Console.Read();
        }

        private int ShowMenu()
        {
            Console.WriteLine("Choice options:\n" +
                "1.Show Users\n" +
                "2.Add New User\n" +
                "3.Delete User\n" +
                "0.Exit");
            
            int choice = -1;
            do
            {
                
                Console.Write(">>");
                try { choice = Convert.ToInt32(Console.ReadLine()); }
                catch (Exception e) { Console.WriteLine("Error: " + e.Message); }
            }
            while (choice > 3 && choice < 0);

            return choice;
        }

        private (string, string) EnterData()
        {
            Console.Write("Enter Username: ");
            string user = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            return (user, pass);
        }

        private int EnterId()
        {
            Console.Write("Enter id user to delete: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
