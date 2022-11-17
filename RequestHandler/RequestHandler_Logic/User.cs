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
        public int userId { get; set; } // Filled by DB
        public string username { get; set; }
        string password { get; set; }
        public int pendingTickets { get; set; } // Filled by DB
        public bool isManager { get; set; } // Filled by DB

        // Constructors
        public User() { }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public User(string username, string password, bool perms)
        {
            this.username = username;
            this.password = password;
            this.isManager = perms;
        }

        // METHODS
        public void updateUserInfo((int, int, bool) details)
        {
           this.userId = details.Item1;
           this.pendingTickets = details.Item2;
           this.isManager = details.Item3;
        }

        public void showUserInfo()
        {
            Console.WriteLine($"User ID: {this.userId}");
            Console.WriteLine($"Username: {this.username}");
            Console.WriteLine($"Pending Tickets: {this.pendingTickets}");

        }



    }
}
