﻿using MySql.Data.MySqlClient;
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
            string connectionString = "server=localhost;database=labb1;uid=root;pwd=;"; // Adjust the connection string to match your database
            connection = new MySqlConnection(connectionString);
        }

        public void SaveEncryptedString(string encryptedString, byte[] salt)
        {
            try
            {
                connection.Open();
                MySqlCommand mySqlCommand = connection.CreateCommand();
                mySqlCommand.CommandText = "SELECT MAX(saltid) AS MaxID FROM salts"; // Get the highest saltid
                object result = mySqlCommand.ExecuteScalar();
                int maxId = result == DBNull.Value ? 0 : Convert.ToInt32(result); // If the table is empty, reset to start value

                mySqlCommand.CommandText = $"INSERT INTO salts(salt) VALUE(@salt)"; 
                mySqlCommand.Parameters.AddWithValue("@salt", salt); // Add the salt as a parameter, injection protected
                mySqlCommand.ExecuteNonQuery();
                mySqlCommand.CommandText = $"INSERT INTO encrypted_strings(encrypted_string, saltid) VALUES('{encryptedString}', {maxId + 1})"; // Add incrementing saltid to match the salt
                mySqlCommand.ExecuteNonQuery();

                MessageBox.Show("Successfully saved to database!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        public byte[] FetchSalt(string encryptedString)
        {
            try
            {
                connection.Open();
                MySqlCommand mySqlCommand = connection.CreateCommand();

                mySqlCommand.CommandText = $"SELECT salt FROM salts WHERE saltid = (SELECT saltid FROM encrypted_strings WHERE encrypted_string = '{encryptedString}')"; // Get the salt from the saltid of the encrypted string

                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                reader.Read();

                byte[] salt = (byte[])reader["salt"];
                connection.Close();
                return salt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
                return null;
            }
        }
    }
}
