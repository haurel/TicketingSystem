using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Core.Models;

namespace TicketingSystem.Core.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetAllTickes();
        ValueTask<Ticket> GetTicketById(int ticketId);
    }
}
