using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuinta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("Data Source=localhost;Database=dbAppBanco;User ID=root;Password=12345678");
            mySqlConnection.Open();

            Console.WriteLine("Text");
            Console.ReadLine();

        }
    }
}
