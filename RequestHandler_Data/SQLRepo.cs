using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RequestHandler_Data
{
    public class SQLRepo : IRepo
    {
        private string connectionString;

        public SQLRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool getOpenTickets(string username)
        {
            // public List<Ticket> GetOpenTickets()
            {
                // List<Ticket> tickets = new List<Ticket>();

                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                // int ticketNum, string amount, string description, bool isPending, int employeeId, string approvedBy

                // string cmdText = "SELECT TicketNum, Amount, Description, isPending, Name, ApprovedBy, EmployeeId FROM Project1.Tickets " +
                //     "JOIN Project1.Users ON EmployeeId = UserId " +
                //     "WHERE ApprovedBy IS NULL";

                // using SqlCommand cmd = new(cmdText, connection);

                // using SqlDataReader reader = cmd.ExecuteReader();

                // while (reader.Read())
                // {
                //     // TODO: fetch tickets

                // }

                // connection.Close();

                // if (tickets != null) return tickets;
                // else return null;

            }
        }




    }
}
