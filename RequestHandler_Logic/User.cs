using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler_Logic
{
    public class User
    {
        string username { get; set; }
        string password { get; set; }
        int pendingTickets { get; set; }
        int userId { get; set; }
        bool isManager;

        public User() { }

        public User(string fInitial, string lastName, string password)
        {
            this.username = fInitial + lastName;
            this.password = password;
        }
    }
}
