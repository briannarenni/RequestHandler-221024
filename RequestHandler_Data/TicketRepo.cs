using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RequestHandler_Data
{
    public class TicketRepo : IRepo
    {
        static string connectionString = File.ReadAllText("/Users/briannarene/_code/_tools/connection-strings/request-DB.txt");

        public void getPendingTickets()
        {
            // using SqlConnection connection = new SqlConnection(connectionString);
            // connection.Open();

            // string cmdText = @"SELECT * FROM [User] WHERE username = @username;";
            // using SqlCommand command = new SqlCommand(cmdText, connection);

            // command.Parameters.AddWithValue("@email", email);
            // command.Parameters.AddWithValue("@password", password);
            // command.Parameters.AddWithValue("@role", role);

            // command.ExecuteNonQuery();


            // connection.Close();

        }

        public static bool createTicket()
        {
            // using SqlConnection connection = new SqlConnection(connectionString);
            // connection.Open();

            // string cmdText = "ADD";

            // using SqlCommand command = new SqlCommand(cmdText, connection);

            // command.Parameters.AddWithValue("@param", param);

            // command.ExecuteNonQuery();


            // connection.Close();

            return false;
        }




    }
}
