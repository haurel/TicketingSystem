using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Core.Models;
using TicketingSystem.Core.Repositories;

namespace TicketingSystem.Data.Repositories
{
    internal class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(IDbTransaction transaction) : base(transaction)
        {
        }
        public Task<IEnumerable<Ticket>> GetAllTickes()
        {
            return Query("SELECT * FROM [dbo].[Ticket]", transaction: Transaction);
        }

        public ValueTask<Ticket> GetTicketById(int id)
        {
            return QuerySingle("SELECT * FROM [dbo].[Ticket] WHERE [dbo].[Ticket].[TicketId] = @ticketId", new { ticketId = id }, Transaction);
        }
    }
}
