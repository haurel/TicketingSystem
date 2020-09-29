using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TicketingSystem.Core;
using TicketingSystem.Core.Repositories;
using TicketingSystem.Data.Repositories;

namespace TicketingSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITicketRepository _ticketRepository;

        public UnitOfWork(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public ITicketRepository TicketRepository
        {
            get
            {
                return _ticketRepository;
            }
        }
    }
}
