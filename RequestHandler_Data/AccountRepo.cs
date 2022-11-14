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

        public static void getUser()
        {
            // return all fields in ArrayList
            ArrayList userDetails = new ArrayList();

            // Fields
        }




    }
}
