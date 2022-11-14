using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RequestHandler_Data
{
    public class TicketRepo : IRepo
    {
        string connectionString = File.ReadAllText("../../connection-strings/request-DB.txt");

        public bool createTicket()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // string cmdText = "ADD";

            // using SqlCommand command = new SqlCommand(cmdText, connection);

            // command.Parameters.AddWithValue("@param", param);

            // command.ExecuteNonQuery();


            connection.Close();

            return true;
        }




    }
}
