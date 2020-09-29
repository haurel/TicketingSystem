using System;
using Dapper.Contrib.Extensions;

namespace TicketingSystem.Core.Models
{
    [Table("Ticket")]
    public class Ticket : ITicket
    {
        [Key]
        public int TicketId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public int IssuerUserId { get; set; }
        public DateTime DeadLine { get; set; }
        public int StatusId { get; set; }
    }
}
