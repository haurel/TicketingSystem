using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingSystem.API.Resource
{
    public class TicketResource
    {
        public int TicketId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public int IssuerUserId { get; set; }
        public DateTime Deadline { get; set; }
        public int StatusId { get; set; }
    }
}
