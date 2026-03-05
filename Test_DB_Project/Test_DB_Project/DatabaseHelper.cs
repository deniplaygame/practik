using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SimpleLibrary
{
    public class DatabaseHelper
    {
        
        private string connectionString = "Server=localhost;Database=LibraryDB;Uid=root;Pwd=123456;";

        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public void ExecuteQuery(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}