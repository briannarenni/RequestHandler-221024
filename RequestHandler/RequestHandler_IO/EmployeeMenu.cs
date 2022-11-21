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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Employee Request Dashboard:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Choose from menu: ");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
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
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Enter valid number choice.");
                        Console.ResetColor();
                        return true;
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid entry.");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Submit Reimbursement Request");
            Console.WriteLine();
            Console.ResetColor();

            bool loop = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Choose reimbursement type: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1: Travel");
                Console.WriteLine("2: Lodging");
                Console.WriteLine("3: Food");
                Console.WriteLine("4: Other");
                Console.ResetColor();

                int type;
                bool inputType = Int32.TryParse(Console.ReadLine(), out type);

                if ((inputType) && categories.ContainsKey(type))
                {
                    category = categories[type];

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Enter amount request, including decimals (00.00 format): ");
                    Console.ResetColor();
                    string input1 = Console.ReadLine();
                    bool inputValid = Double.TryParse(input1, out amount);

                    if (!inputValid)
                    {
                        Console.WriteLine("Error: Please use 0.00 formatting.");
                    }
                    else
                    {
                        Ticket newTicket = new Ticket(currUser.userId, currUser.username, amount, category);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Review your submission");
                        Console.ResetColor();

                        Console.WriteLine($"Amount: {newTicket.amount}");
                        Console.WriteLine($"Reimbursement Type: {newTicket.category}");

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("1: Submit                 2: Start Over");
                        Console.ResetColor();

                        var input2 = Convert.ToInt32(Console.ReadLine());

                        if (input2 == 1)
                        {
                            TicketRepo.addNewTicket(currUser.userId, currUser.username, newTicket.amount, newTicket.category);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Request submitted successfully");
                            Console.ResetColor();

                            newTicket.showTicketInfo();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue.");
                            Console.ResetColor();

                            Console.ReadLine();
                            loop = false;
                        }
                        else if (input2 == 2)
                        {
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Invalid entry.");
                    Console.ResetColor();
                }
            } while (loop);

        }


    }
}
