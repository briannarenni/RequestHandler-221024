using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;
using RequestHandler_Data;
using RequestHandler_Logic;

namespace RequestHandler_IO
{
    public class EmployeeMenu
    {
        static string userTicketsQuery = @"SELECT [ticket_id], [submitted_on], [employee_name], [amount], [category], [status] FROM [Ticket] WHERE submitted_by = @userId";
        static string userPendingQuery = @"SELECT * FROM [View.PendingTickets] WHERE employee_name = @username";

        public static bool empDashboard(User currUser)
        {

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
                    // newRequest(currUser);
                    // return true;
                    case "2":
                        Console.Clear();
                        DataTable results = TicketRepo.getTickets(userTicketsQuery, currUser.userId);
                        Console.WriteLine("Press any key to continue.");
                        string ticketViewer = Ticket.showUserTickets(results);
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

        public static void newRequest(User currUser)
        {
            // int userId, string username, decimal amount, string category

        }


    }
}
