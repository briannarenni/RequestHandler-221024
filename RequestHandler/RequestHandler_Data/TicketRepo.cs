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

        // Read Methods (getUserPending, getUserHistory, getAllRequests)
        public static DataTable getTickets(string query)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            DataTable result = new DataTable();

            if (reader.HasRows)
            {
                result.Load(reader);
            }
            else
            {
                throw new Exception("No records found.");
            }

            return result;
            connection.Close();
        }

        public static DataTable getTickets(string query, int userId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userId", userId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            DataTable result = new DataTable();


            if (reader.HasRows)
            {
                result.Load(reader);
            }
            else
            {
                throw new Exception("No records found.");
            }

            return result;
            connection.Close();
        }

        // Update Methods (add/process requests)
        public static void addNewTicket(int userId, string username, decimal amount, string category)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"INSERT INTO [Ticket] ([submitted_by], [employee_name], [amount], [category])
                VALUES (@userId, @username, @amount, @category);";
            using SqlCommand command = new SqlCommand(cmdText, connection);

            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@category", category);

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void updatePendingRequests(string status, int ticketId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"UPDATE [Ticket] SET status = @status
                WHERE ticket_id = @ticketId;";

            using SqlCommand command = new SqlCommand(cmdText, connection);

            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@ticketId", ticketId);

            command.ExecuteNonQuery();
            connection.Close();
        }


        // ! MAY REMOVE
        public static (int, DateTime) getTicketInfo(int userId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string cmdText = @"SELECT ticket_id, submitted_by FROM [Ticket] WHERE submitted_by = @userId;";
            using SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("@userId", userId);
            using SqlDataReader reader = command.ExecuteReader();

            int ticketId = 0;
            DateTime submittedOn = new DateTime();

            while (reader.Read())
            {
                ticketId = Convert.ToInt32(reader["ticket_id"]);
                submittedOn = Convert.ToDateTime(reader["submitted_on"]);
            }
            return (ticketId, submittedOn);
        }

    }
}
