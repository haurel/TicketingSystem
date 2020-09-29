using System;
using System.Threading.Tasks;
using TicketingSystem.Core.Repositories;

namespace TicketingSystem.Core
{
    public interface IUnitOfWork
    {
        ITicketRepository TicketRepository { get; }
    }
}
