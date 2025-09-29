using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ComputerShop.Pages;
using MySql.Data.MySqlClient;

namespace ComputerShop.Services
{
    internal class ComputerTable : ISqlStatement
    {
        Connect conn = new Connect();
        public ICollection<object> GetAllData()
        {
            ICollection<object> data = new List<object>();
            conn.Connection.Open();


            conn.Connection.Close();

            return data;
        }
        public object GetData(string username,string password)
        {
            conn.Connection.Open();


            string sql = "SELECT * FROM users WHERE username = @username AND passwrod = @password";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            conn.Connection.Close();

            return new { message = " " };
        }

    }
}
