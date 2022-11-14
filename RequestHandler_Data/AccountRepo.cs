using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RequestHandler_Data
{
    public class AccountRepo : IRepo
    {
        string connectionString = File.ReadAllText("../../connection-strings/request-DB.txt");

        public bool createUserAcc()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // string cmdText = "SELECT Username, Password FROM Users WHERE Username = @username";

            // using SqlCommand command = new SqlCommand(cmdText, connection);

            // command.Parameters.AddWithValue("@email", email);
            // command.Parameters.AddWithValue("@password", password);
            // command.Parameters.AddWithValue("@role", role);

            // command.ExecuteNonQuery();


            connection.Close();

            return true;
        }



    }
}
