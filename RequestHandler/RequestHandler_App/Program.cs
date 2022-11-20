using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;
using RequestHandler_Data;
using RequestHandler_IO;
using RequestHandler_Logic;

namespace RequestHandler_App
{

    public class Program
    {
        public static void Main(String[] args)
        {
            Console.Clear();
            IRepo accRepo = new AccountRepo();
            IRepo ticketRepo = new TicketRepo();

            // Main Menu creates current user
            User currUser = MainMenu.startMenu();
            Console.WriteLine();

            // Update user info from DB
            (int, bool) tieUserInfo = AccountRepo.getUserInfo(currUser.username);
            string username = currUser.username;

            // Attach to current User
            currUser.updateUserInfo(tieUserInfo);
            int userId = currUser.userId;

            // ! Employee Menu
            if (!currUser.isManager)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Welcome, {currUser.username}");
                Console.ResetColor();

                bool showMenu = true;
                while (showMenu)
                {
                    Console.Clear();
                    showMenu = EmployeeMenu.empDashboard(currUser);
                    if (!showMenu) Environment.Exit(0);

                }
            }

            else if (currUser.isManager) // ! Manager Menu
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Welcome, {currUser.username}");
                Console.ResetColor();

                bool showMenu = true;
                while (showMenu)
                {
                    Console.Clear();
                    showMenu = ManagerMenu.mgrDashboard(currUser);
                    if (!showMenu) Environment.Exit(0);

                }

            }



        } // end Main
    }
}