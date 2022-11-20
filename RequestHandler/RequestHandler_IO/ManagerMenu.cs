using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestHandler_Data;
using RequestHandler_Logic;

namespace RequestHandler_IO
{
    public class ManagerMenu
    {
        static string ticketQuery = @"SELECT * FROM [Ticket] ORDER BY [submitted_on] DESC;";

        public static bool mgrDashboard(User currUser)
        {
            // bool loop = true;

            Console.WriteLine("Manager Request Dashboard:");
            Console.WriteLine($"Welcome, {currUser.username}");
            Console.WriteLine();

            Console.WriteLine("Choose from menu: ");

            Console.WriteLine("1: Process Pending Requests");
            Console.WriteLine("2: View All Requests");
            Console.WriteLine("3: View Account Information");
            Console.WriteLine("4: Log Out");

            // Validate input
            string mgrChoice = Console.ReadLine();
            bool nullCheck = Validation.isChoiceNull(mgrChoice);
            bool inputCheck = Validation.isChoiceValid(mgrChoice);

            if (nullCheck && inputCheck)
            {
                // !Choose menu option, then decide if menu shows again
                switch (mgrChoice)
                {
                    case "1":
                    // Ticket.clearPendingTickets();

                    case "2":
                        Console.Clear();
                        DataTable results = TicketRepo.getTickets(ticketQuery);
                        Console.WriteLine("Press any key to continue.");
                        string ticketViewer = Ticket.showAllTickets(results);
                        Console.WriteLine(ticketViewer);
                        Console.ReadLine();
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

        public void clearPendingTickets()
        {
            ;
        }



    }

}
