using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem.Core.Models
{
    public class Ticket : ITicket
    {
        public int TicketId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public int IssuerUserId { get; set; }
        public DateTime Deadline { get; set; }
        public int StatusId { get; set; }
    }
}
