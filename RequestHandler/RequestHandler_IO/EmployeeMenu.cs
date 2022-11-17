using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestHandler_Logic;

namespace RequestHandler_IO
{
    public class EmployeeMenu
    {
        public static bool empDashboard(User currUser)
        {
            Console.Clear();
            Console.WriteLine("Employee Request Dashboard:");
            Console.WriteLine($"Welcome, {currUser.username}");
            Console.WriteLine();

            Console.WriteLine("Choose from menu: ");
            Console.WriteLine("1: Submit New Request");
            Console.WriteLine("2: View Submitted Requests");
            Console.WriteLine("3: View Account Information");
            Console.WriteLine("4: Log Out");

            // Validate input
            string empChoice = Console.ReadLine();
            bool nullCheck = Validation.isChoiceNull(empChoice);
            bool inputCheck = Validation.isChoiceValid(empChoice);

            if (nullCheck && inputCheck)
            {
                // !Choose menu option, then decide if menu shows again
                switch (empChoice)
                {
                    case "1":
                        // createTicket();
                        Console.Clear();
                        return true;
                    case "2":
                        // viewUserTickets();
                        Console.Clear();
                        return true;
                    case "3":
                        currUser.showUserInfo();
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        return true;
                    case "4":
                        Console.Clear();
                        return Validation.logOut();
                    default:
                        Console.WriteLine("Error, enter option number.");
                        return true;
                }
            }
            else
            {
                Console.WriteLine("Please try again...");
            }
            return true;

        } // END dashboard



        // TODO: Ticket System
        public void viewUserTickets()
        {
            ;
        }

        public void createTicket(User currUser)
        {
            ;
        }
    }
}
