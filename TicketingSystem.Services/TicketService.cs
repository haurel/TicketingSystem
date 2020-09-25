using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingSystem.Core;
using TicketingSystem.Core.Services;

namespace TicketingSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Core.Models.Ticket> CreateTicket(Core.Models.Ticket newTicket)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Core.Models.Ticket>> GetAllWithUser()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Core.Models.Ticket> GetTicketById(int id)
        {
            return _unitOfWork.Tickets.GetTicketById(id);
        }

        public Task<IEnumerable<Core.Models.Ticket>> GetTicketsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTicket(Core.Models.Ticket ticketToBeUpdated, Core.Models.Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
