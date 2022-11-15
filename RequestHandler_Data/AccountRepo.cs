using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler_Data
{
    public class AccountRepo : IRepo
    {
        static StreamReader conFile = new System.IO.StreamReader("/Users/briannarene/_code/_tools/connection-strings/request-DB.txt");

        static string connectionString = conFile.ReadToEnd();

        // TODO: checkUsername() returns bool
        public static bool checkUsername(string username)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"SELECT * FROM [User] WHERE username = @username;";
            using SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@username", username);

            using SqlDataReader reader = command.ExecuteReader();
            // while (reader.Read())
            // {
            //     return true; // Exists
            // }
            return reader.HasRows;
            connection.Close();
        }

        public static bool checkPassword(string username, string password)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"SELECT * FROM [User] WHERE username = @username AND password = @password;";
            using SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            using SqlDataReader reader = command.ExecuteReader();
            // while (reader.Read())
            // {
            //     return true; // Exists
            // }
            return reader.HasRows;
            connection.Close();
        }

        public static void addUser(string username, string password)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string cmdText = @"INSERT INTO [User] ([username], [password])
                VALUES (@username, @password);";

            using SqlCommand command = new SqlCommand(cmdText, connection);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static (int, int) updateUserInfo(string username)
        {
            // add id and pending tickets to User
            int userId = 0;
            int pendingTickets = 0;

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"SELECT user_id, pending_tickets FROM [User] WHERE username = @username;";
            using SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@username", username);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userId = Convert.ToInt32(reader["user_id"]);
                pendingTickets = (reader["pending_tickets"] == DBNull.Value) ? default(int) : (int)reader["pending_tickets"];
            }
            return (userId, pendingTickets);
            connection.Close();
        }
    }

}
