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
        static string userTicketsQuery = @"SELECT [ticket_id], [submitted_on], [employee_name], [amount], [category], [status] FROM [Ticket] WHERE submitted_by = @id";
        // static string userPendingQuery = @"SELECT * FROM [View.PendingTickets] WHERE employee_name = @username";

        public static bool empDashboard(User currUser)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Employee Request Dashboard:");
            Console.WriteLine();
            Console.WriteLine("Choose from menu: ");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1: Submit New Request");
            Console.WriteLine("2: View Submitted Requests");
            Console.WriteLine("3: View Account Information");
            Console.WriteLine("4: Log Out");
            Console.ResetColor();

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
                        newRequest(currUser);
                        return true;
                    case "2":
                        Console.Clear();
                        DataTable results = TicketRepo.getTickets(userTicketsQuery, currUser.userId);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any key to continue.");
                        Console.ResetColor();
                        string ticketViewer = Ticket.showUserTickets(results);
                        Console.WriteLine(ticketViewer);
                        Console.ReadLine();
                        return true;
                    case "3":
                        currUser.showUserInfo();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any key to continue.");
                        Console.ResetColor();
                        Console.ReadLine();
                        return true;
                    case "4":
                        Console.Clear();
                        return Validation.logOut();
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error, enter option number.");
                        Console.ResetColor();
                        return true;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please try again...");
                Console.ResetColor();
            }
            return true;

        } // END dashboard

        public static void newRequest(User currUser)
        {
            var categories = new Dictionary<int, string>() {
                {1, "Travel"},
                {2, "Lodging"},
                {3, "Food"},
                {4, "Other"},
            };

            string category = "";
            double amount = 00.00;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Submit Reimbursement Request");
            Console.WriteLine();
            Console.ResetColor();

            bool loop = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Choose reimbursement type: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1: Travel");
                Console.WriteLine("2: Lodging");
                Console.WriteLine("3: Food");
                Console.WriteLine("4: Other");
                Console.ResetColor();

                var type = Convert.ToInt32(Console.ReadLine());

                if (categories.ContainsKey(type))
                {
                    category = categories[type];

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Enter amount request, including decimals (00.00 format): ");
                    amount = Convert.ToDouble(Console.ReadLine());
                    Ticket newTicket = new Ticket(currUser.userId, currUser.username, amount, category);
                    Console.WriteLine();
                    Console.WriteLine("Review submission: (1: Submit | 2: Start Over)");
                    Console.WriteLine();
                    Console.ResetColor();

                    Console.WriteLine($"Amount: {newTicket.amount}");
                    Console.WriteLine($"Reimbursement Type: {newTicket.category}");

                    var input = Convert.ToInt32(Console.ReadLine());


                    if (input == 1)
                    {
                        TicketRepo.addNewTicket(currUser.userId, currUser.username, newTicket.amount, newTicket.category);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Request submitted successfully");
                        newTicket.showTicketInfo();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue.");
                        Console.ResetColor();

                        Console.ReadLine();
                        loop = false;
                    }
                    else if (input == 2)
                    {
                        Console.Clear();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid choice.");
                    Console.ResetColor();
                }
            } while (loop);

        }


    }
}
