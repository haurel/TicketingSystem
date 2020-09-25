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
        #region OFF
        //private IDbConnection _dbConnection;
        //public TicketRepository(ILogger logger, IDbConnection dbConnection) : base(logger, dbConnection)
        //{
        //    _dbConnection = dbConnection;
        //}

        //public Task<IEnumerable<Ticket>> GetAllTickes()
        //{
        //    _dbConnection.Open();
        //    IDbCommand command = _dbConnection.CreateCommand();

        //    List<Ticket> tickets = new List<Ticket>();

        //    command.CommandText = @"SELECT * FROM [dbo].[GetTicketsById](@ticketid)";
        //    using(IDataReader reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            Ticket obj = new Ticket();

        //            obj.TicketId = int.Parse(reader["id"].ToString());

        //            tickets.Add(obj);
        //        }
        //    }

        //    return Task.FromResult<IEnumerable<Ticket>>(tickets);
        //}

        //public Task<Ticket> GetTicketById()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        public Task<IEnumerable<Ticket>> GetAllTickes()
        {
            //return Query<Ticket>("SELECT * FROM [dbo].[Ticket]");
            return Query("SELECT * FROM [dbo].[Ticket]");
        }

        public ValueTask<Ticket> GetTicketById(int id)
        {
            return QuerySingle("SELECT * FROM [dbo].[Ticket] WHERE [dbo].[Ticket].[TicketId] = @ticketId", new { ticketId = id }, Transaction);
        }
    }
}
