using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestHandler_Logic
{
    public class Ticket
    {
        // ticket_id (IDENT PK)
        // submitted_on (DATETIME DEFAULT CURRENT_TIMESTAMP)
        // submitted_by (UNIQUE )
        // status (DEFAULT NULL, 0 denied, 1 approved)
        // dollar_amount (MONEY)
        // description (will be Travel, Food, Lodging or Other)
    }
}
