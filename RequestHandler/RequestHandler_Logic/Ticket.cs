using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;

namespace RequestHandler_Logic
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public DateTime submittedOn { get; set; }
        public int submittedBy { get; set; }
        public string employeeName { get; set; }
        public string status { get; set; }
        public double amount { get; set; }
        public string category { get; set; }

        // Constructors
        public Ticket() { }

        public Ticket(int userId, string username, double amount, string category)
        {
            this.submittedBy = userId;
            this.employeeName = username;
            this.amount = amount;
            this.category = category;
        }

        public Ticket(int ticketId, DateTime submittedOn, int userId, string username, double amount, string category)
        {
            this.ticketId = ticketId;
            this.submittedOn = submittedOn;
            this.submittedBy = userId;
            this.employeeName = username;
            this.amount = amount;
            this.category = category;
        }

        // Methods
        public static string showUserTickets(DataTable userTickets)
        {
            userTickets.SetShowTableName(false);
            userTickets.Columns[1].SetDataTextFormat((DataColumn c, DataRow r) =>
                {
                    DateTime value = r.Field<DateTime>(c);
                    string time = value.ToString("MM/dd/yyyy");
                    return time.ToString();
                });

            userTickets.Columns[3].SetDataTextFormat((DataColumn c, DataRow r) =>
                {
                    Decimal value = r.Field<Decimal>(c);
                    string formatDecimal = Math.Round(value, 2).ToString("#.00");
                    return formatDecimal;
                });
            var table = userTickets.ToPrettyPrintedString();

            return table;
        }
        public static string showAllTickets(DataTable allTickets)
        {
            allTickets.SetShowTableName(false);
            allTickets.Columns[1].SetDataTextFormat((DataColumn c, DataRow r) =>
                {
                    DateTime value = r.Field<DateTime>(c);
                    string time = value.ToString("MM/dd/yyyy");
                    return time.ToString();
                });

            allTickets.Columns[4].SetDataTextFormat((DataColumn c, DataRow r) =>
                {
                    Decimal value = r.Field<Decimal>(c);
                    string formatDecimal = Math.Round(value, 2).ToString("#.00");
                    return formatDecimal;
                });
            var table = allTickets.ToPrettyPrintedString();

            return table;
        }

        // * Misc Methods
        public void updateTicketInfo((int, DateTime) details)
        {
            this.ticketId = details.Item1;
            this.submittedOn = details.Item2;
        }

        public void showTicketInfo()
        {
            Console.WriteLine($"Employee ID: {this.submittedBy}");
            Console.WriteLine($"Submitted By: {this.employeeName}");
            Console.WriteLine($"Amount requested: {this.amount.ToString()}");
            Console.WriteLine($"Reimbursement type: {this.category}");
        }


    }
}
