using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RequestHandler_Logic
{
    public class User
    {
        // Fields
        string username { get; set; }
        string password { get; set; }
        bool isManager { get; set; }
        //  filled from DB
        int userId { get; set; }
        int pendingTickets { get; set; }

        // Constructors
        public User() { }


        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.isManager = false;
        }

        // METHODS
        public void setUserDetails()
        {
            // return all fields in ArrayList
            ArrayList userDetails = new ArrayList();
            //  string username
            // string password
            // bool isManager
            // int userId
            // int pendingTickets


        }



    }
}
