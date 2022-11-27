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
        static string pendingQuery = @"SELECT * FROM [View.PendingTickets] ORDER BY [submitted_on] DESC;";
        static string singlePendingQuery = @"SELECT * FROM [View.PendingTickets] WHERE ticket_id = @id;";

        public static bool mgrDashboard(User currUser)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Manager Request Dashboard:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Welcome, {currUser.username}");
            Console.WriteLine();
            Console.WriteLine("Choose from menu: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1: Process Pending Requests");
            Console.WriteLine("2: View All Requests");
            Console.WriteLine("3: View Account Information");
            Console.WriteLine("4: Log Out");
            Console.ResetColor();

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
                        Console.Clear();
                        clearPendingTickets(currUser);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any key to continue.");
                        Console.ResetColor();
                        Console.ReadLine();
                        return true;
                    case "2":
                        Console.Clear();
                        DataTable results = TicketRepo.getTickets(ticketQuery);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Press any key to continue.");
                        Console.ResetColor();
                        string ticketViewer = Ticket.showAllTickets(results);
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
                        Console.WriteLine("Error: Invalid entry.");
                        Console.ResetColor();
                        return true;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid entry.");
                Console.ResetColor();
            }
            return true;

        } // END dashboard

        public static void clearPendingTickets(User currUser)
        {
            var status = new Dictionary<int, string>() {
                { 1, "approved" },
                { 2, "denied" },
            };

            bool majorLoop = true;
            while (majorLoop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Process Pending Requests");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("To approve/deny an open request, enter a Ticket ID: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("To go back the the main menu, press Enter");
                Console.ResetColor();

                DataTable pendingResults = TicketRepo.getTickets(pendingQuery);
                string ticketViewer = Ticket.showAllTickets(pendingResults);
                Console.WriteLine(ticketViewer);

                var input1 = Console.ReadLine();
                bool isEmptyInput = Validation.isChoiceNull(input1);

                if (!isEmptyInput)
                {
                    majorLoop = false;
                }
                else // ticket id was entered
                {
                    int ticketID = Convert.ToInt32(input1);

                    bool ticketExists = TicketRepo.checkPending(pendingQuery, ticketID);

                    if (ticketExists)
                    {
                        DataTable result = TicketRepo.getTickets(singlePendingQuery, ticketID);
                        string singleViewer = Ticket.showAllTickets(result);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("1: Approve Request        2: Deny Request        3: Go Back");
                        // Console.WriteLine("2: Deny Request");
                        // Console.WriteLine("3: Go Back");
                        Console.ResetColor();

                        int input = Convert.ToInt32(Console.ReadLine());
                        if (status.ContainsKey(input))
                        {
                            switch (input)
                            {
                                case 1:
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    TicketRepo.updatePendingRequest(status[input], ticketID, currUser.username);
                                    Console.WriteLine($"Processing successful: Request {status[input]}");
                                    Console.WriteLine();

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Press any key to continue: ");
                                    Console.ReadLine();
                                    Console.ResetColor();
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Error: Invalid entry.");
                                    majorLoop = false;
                                    Console.ResetColor();
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Please enter status number.");
                            Console.ResetColor();
                        }
                    } //doesn't exist
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Invalid ticket ID.");
                        Console.ResetColor();
                    }

                }

            } // end process menu
        }

    }
}
