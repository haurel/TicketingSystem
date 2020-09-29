using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingSystem.Core.Models;

namespace TicketingSystem.Core.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        ValueTask<Ticket> GetTicketById(int id);
        Task<int> InsertTicket(Ticket newTicket);
        Task<Ticket> UpdateTicket(int id, Ticket ticketToBeUpdated);
        Task<int> DeleteTicket(int id);
         
    }
}
