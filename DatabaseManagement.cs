using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using System.Security.Cryptography;

namespace test211_console
{
    public class DatabaseManagement
    {
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;
        private int _port;
        public DatabaseManagement() 
        {
            _server = "localhost";
            _database = "test211";
            _uid = "root";
            _port = 3306;
            _password = "admin";
            string connectionString = $"SERVER={_server};DATABASE={_database};UID={_uid};PORT = {_port};PASSWORD={_password};";
            _connection = new MySqlConnection(connectionString);

        }

        public void OpenConnction()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnction()
        {
            if ( _connection.State != ConnectionState.Closed)
            { 
                _connection.Close(); 
            }
        }

        public DataTable GetUsers()
        {
            OpenConnction();
            string query = "SELECT * FROM users";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConnction();
            return table;
        }
        public void CreateUser(string name, string email)
        {
            OpenConnction();
            string query = "INSERT INTO users (name, email) VALUES (@name, @email)";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.ExecuteNonQuery();
            CloseConnction();
        } 
        
        public void UpdateUser(string name, string email, int userId)
        {
            OpenConnction();
            string query = "UPDATE users SET name = @name, email = @email WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@id", userId);
            command.ExecuteNonQuery();
            CloseConnction();
        }


        public void DeleteUser(int id) 
        {
            OpenConnction();
            string query = "DELETE FROM users WHERE id = @id";
            MySqlCommand command = new MySqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }


      

    }
}
