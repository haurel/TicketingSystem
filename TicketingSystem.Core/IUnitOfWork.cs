using System;
using System.Threading.Tasks;
using TicketingSystem.Core.Repositories;

namespace TicketingSystem.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepository Tickets { get; }
        void CommitAsync();
    }
}
