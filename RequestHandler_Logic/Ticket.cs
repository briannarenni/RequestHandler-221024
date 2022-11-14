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

        string submittedBy { get; set; }
        decimal requestedAmount { get; set; }
        string desc { get; set; } // travel, lodging, food, other
        //  filled from DB
        int ticketId { get; set; }
        DateTime submittedOn { get; set; } // DateTime myTime = DateTime.Parse(myString);
        string status { get; set; } // approved/denied

        // Constructors
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
