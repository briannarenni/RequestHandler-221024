using System;
using System.Collections;
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
            Console.Clear();

            // ! Main Menu
            User currUser = MainMenu.startMenu(); // * WHAT
            Console.WriteLine();
            // Update user info from DB
            (int, int, bool) tieUserInfo = AccountRepo.getUserInfo(currUser.username);
            string username = currUser.username;


            // Attach to current User
            currUser.updateUserInfo(tieUserInfo);
            int userId = currUser.userId;


            Console.WriteLine($"{currUser.username} logged in successfully.");
            Console.WriteLine(currUser.isManager);


            // ! Employee Menu //WHAT
            if (!currUser.isManager)
            {
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = EmployeeMenu.empDashboard(currUser);
                    if (!showMenu) Environment.Exit(0);

                }

            }
            // TODO:
            // ? Not capturing perms to currUser

            else if (currUser.isManager) // ! Manager Menu
            {
                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = EmployeeMenu.empDashboard(currUser);
                    if (!showMenu) Environment.Exit(0);

                }

            }



        } // end Main
    }
}