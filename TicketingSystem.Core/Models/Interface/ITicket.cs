using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace TicketingSystem.Core.Models
{
    public interface ITicket
    {
        int TicketId { get; set; }
        DateTime DateCreated { get; set; }
        string Name { get; set; }
        int IssuerUserId { get; set; }
        DateTime Deadline { get; set; }
        int StatusId { get; set; }
    }
}
