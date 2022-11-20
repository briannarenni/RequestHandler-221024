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
        static StreamReader conFile = new System.IO.StreamReader("/Users/briannarene/_code/_tools/connection-strings/request-DB.txt");

        static string connectionString = conFile.ReadToEnd();

        // Methods
        // public static void getAllTickets(int userId)

        // public void getPendingTickets(User currUser)

        public static void addNewTicket()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            // string cmdText = @"INSERT INTO [User] ([username], [password])
            //     VALUES (@username, @password);";

            // using SqlCommand command = new SqlCommand(cmdText, connection);

            // command.Parameters.AddWithValue("@username", username);
            // command.Parameters.AddWithValue("@password", password);

            // command.ExecuteNonQuery();
            // connection.Close();
        }

        // Manager menu methods
        // public static void viewAllRequests()
        // public static void clearPendingRequests()



        // ! MAY REMOVE
        public static (int, DateTime) getTicketInfo(int userId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"SELECT ticket_id, submitted_by FROM [Ticket] WHERE submitted_by = @userId;";
            using SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = command.ExecuteReader();

            int ticketId = 0;
            DateTime submittedOn = new DateTime();

            while (reader.Read())
            {
                ticketId = Convert.ToInt32(reader["ticket_id"]);
                submittedOn = Convert.ToDateTime(reader["submitted_on"]);
            }
            return (ticketId, submittedOn);
            connection.Close();
        }

    }
}
