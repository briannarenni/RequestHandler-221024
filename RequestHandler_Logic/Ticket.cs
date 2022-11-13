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
        DateTime submittedOn { get; set; } // DateTime myTime = DateTime.Parse(myString);
        string submittedBy { get; set; }
        decimal requestedAmount { get; set; }
        string desc { get; set; } // number options
        string status { get; set; } // null = pending

        public Ticket() {}

        public Ticket(DateTime submitOn, string submittedBy, decimal amount, string desc)
            {
                this.submittedOn = submitOn;
                this.submittedBy = submittedBy;
                this.requestedAmount = amount;
                this.desc = desc;
            }

        // Methods





    }
}
