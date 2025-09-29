using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop
{
    internal class Connect
    {
        public MySqlConnection Connection;
        private string _host;
        private string _db;
        private string _user;
        private string _pass;

        private string _connectionString;

        public Connect()
        {
            _host = "localhost";
            _db = "computershop";
            _user = "root";
            _pass = "";
            _connectionString = $"Server={_host};Database={_db};User ID={_user};Password={_pass};SslMode=None";

            Connection = new MySqlConnection(_connectionString);

            try
            {
                Connection.Open();
                Console.WriteLine("Sikeres csatlakozás az adatbázishoz.");
                Connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Hiba történt " + ex.Message);
            }
        }
    }    
}
