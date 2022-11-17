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
            User currUser = MainMenu.startMenu();
            Console.WriteLine();
            // Update user info from DB
            (int, int, bool) setCurrUserInfo = AccountRepo.updateUserInfo(currUser.username);
            // Attach to current User
            currUser.updateUserInfo(setCurrUserInfo);
            int userId = currUser.userId;
            string username = currUser.username;
            bool perms = currUser.isManager;
            Console.WriteLine($"{currUser.username} logged in successfully.");
            Console.WriteLine();



            // ! Employee Menu
            if (!perms)
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

            // else if (perms) // ! Manager Menu
            // {
            //    bool showMenu = true;
            //     while (showMenu)
            //     {
            //         showMenu = EmployeeMenu.empDashboard(currUser);
            //         if (!showMenu) Environment.Exit(0);

            //     }

            // }



        } // end Main
    }
}