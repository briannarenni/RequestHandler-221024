using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestHandler_Data;
using RequestHandler_IO;
using RequestHandler_Logic;

namespace RequestHandler_App
{

    class Program
    {
        public static void Main(String[] args)
        {
            IRepo accRepo = new AccountRepo();
            IRepo ticketRepo = new TicketRepo();
            string username;
            string password;

            // int userChoice = MainMenu.getMenuChoice();
            // Console.WriteLine(userChoice);

            username = MainMenu.getUsername();
            var existingUser = AccountRepo.checkUsername(username);
            Console.WriteLine(existingUser);




        }
    }
}