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

    public class Program
    {
        public static void Main(String[] args)
        {
            IRepo accRepo = new AccountRepo();
            IRepo ticketRepo = new TicketRepo();
            string username;
            string password;

            // ! MainMenu
           User currUser = MainMenu.startMenu();






            // TODO: Get user info from DB, save to account
            // account.getUser();
            // print to console


        }
    }
}