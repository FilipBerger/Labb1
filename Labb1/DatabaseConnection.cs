using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1
{
    internal class DatabaseConnection
    {
        private MySqlConnection connection { get; set; }

        public DatabaseConnection() 
        {
            string connectionString = "server=localhost;database=labb1;uid=root;pwd=\"\";";
            connection = new MySqlConnection(connectionString);
        }

        public void SaveEncryptedString(string encryptedString)
        {
            try
            {
                connection.Open();
                MySqlCommand mySqlCommand = connection.CreateCommand();

                MessageBox.Show("Successful database connection!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to database!");
            }
        }
    }
}
