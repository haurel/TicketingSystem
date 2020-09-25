using System;
using System.Threading.Tasks;
using TicketingSystem.Core.Repositories;

namespace TicketingSystem.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //IUserRepository Users { get; }
        ITicketRepository Tickets { get; }
        void CommitAsync();
    }
}
