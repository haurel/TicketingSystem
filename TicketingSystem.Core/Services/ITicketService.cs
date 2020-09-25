using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Core.Models;

namespace TicketingSystem.Core.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllWithUser();
        ValueTask<Ticket> GetTicketById(int id);
        Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId);
        Task<Ticket> CreateTicket(Ticket newTicket);
        Task UpdateTicket(Ticket ticketToBeUpdated, Ticket ticket);
    }
}
