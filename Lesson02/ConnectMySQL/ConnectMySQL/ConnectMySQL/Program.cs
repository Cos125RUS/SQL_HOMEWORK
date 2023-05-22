using System;

namespace ConnectMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            UseMySQL db= new UseMySQL();
            db.Run();
        }
    }

}
