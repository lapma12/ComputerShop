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


            string sql = "SELECT * FROM users WHERE username = @username AND password = @password";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            MySqlDataReader reader = cmd.ExecuteReader();

            string result = "";
            if (reader.Read() == true)
            {
                result = "Regisztrált tag";
            }
            else
            {
                result = "Nincs regisztrálva";
            }
            conn.Connection.Close();

            return new { result };
        }

        public void InsertData(string username, string email, string fullname, string password)
        {
            try
            {
                conn.Connection.Open();
                string sql = "INSERT INTO users (username, email, fullname, password) VALUES (@username, @email, @fullname, @password)";
                MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fullname", fullname);
                cmd.Parameters.AddWithValue("@password", password); // FONTOS: Hash-eld jelszót élesben!

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a regisztráció során: " + ex.Message);
            }
            finally
            {
                conn.Connection.Close();
            }
        }

    }
}
