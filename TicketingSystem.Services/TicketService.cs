using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingSystem.Core;
using TicketingSystem.Core.Models;
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

        public Task<IEnumerable<Ticket>> GetAllWithUser()
        {
            return _unitOfWork.TicketRepository.GetAllTickets();
        }

        public ValueTask<Ticket> GetTicketById(int id)
        {
            return _unitOfWork.TicketRepository.GetTicketById(id);
        }

        public Task<int> InsertTicket(Ticket newTicket)
        {
            return _unitOfWork.TicketRepository.InsertTicket(newTicket);
        }

        public Task<Ticket> UpdateTicket(int id, Ticket ticketToBeUpdated)
        {
            return _unitOfWork.TicketRepository.UpdateTicket(id, ticketToBeUpdated);
        }

        public Task<IEnumerable<Ticket>> GetTicketsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        
    }
}
