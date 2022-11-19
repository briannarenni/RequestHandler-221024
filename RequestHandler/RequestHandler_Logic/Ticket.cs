using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler_Logic
{
    public class Ticket
    {
        int ticketId { get; set; }
        DateTime submittedOn { get; set; }
        int submittedBy { get; set; }
        string employeeName { get; set; }
        string status { get; set; }
        decimal amount { get; set; }
        string desc { get; set; }

        public Dictionary<int, string> descOptions = new Dictionary<int, string>()
        {
            {1, "Travel"},
            {2, "Lodging"},
            {3, "Food"},
            {4, "Other"},
        };

        // Constructors
        public Ticket() { }

        public Ticket(int userId, string username, decimal amount, string desc)
        {
            this.submittedBy = userId;
            this.employeeName = username;
            this.amount = amount;
            this.desc = desc;
        }

        public Ticket(int ticketId, DateTime submittedOn, int userId, string username, decimal amount, string desc)
        {
            this.ticketId = ticketId;
            this.submittedOn = submittedOn;
            this.submittedBy = userId;
            this.employeeName = username;
            this.amount = amount;
            this.desc = desc;
        }

        // Methods
        public void updateTicketInfo((int, DateTime) details)
        {
            this.ticketId = details.Item1;
            this.submittedOn = details.Item2;
        }

        public void showTicketInfo()
        {
            Console.WriteLine($"Ticket ID: {this.ticketId}");
            Console.WriteLine($"Submitted on: {this.submittedOn}");
            Console.WriteLine($"Submitted By: {this.submittedBy}");
            Console.WriteLine($"Status: {this.status}");
            Console.WriteLine($"Amount requested: {this.amount}");
            Console.WriteLine($"Request category: {this.desc}");
        }


    }
}
