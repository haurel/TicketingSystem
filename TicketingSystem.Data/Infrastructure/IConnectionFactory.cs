using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TicketingSystem.Data.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
        IDbTransaction GetTransaction { get; }

        public void CommitAsync();
    }
}
