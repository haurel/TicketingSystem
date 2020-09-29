using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TicketingSystem.Core.Models;
using TicketingSystem.Core.Repositories;
using TicketingSystem.Data.Infrastructure;

namespace TicketingSystem.Data.Repositories
{

    public class TicketRepository : ITicketRepository
    {
        IConnectionFactory _connectionFactory;

        public TicketRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<IEnumerable<Ticket>> GetAllTickets()
        {
            string query = "SELECT * FROM [dbo].[Ticket]";
            return SqlMapper.QueryAsync<Ticket>(_connectionFactory.GetConnection, query);
        }

        public ValueTask<Ticket> GetTicketById(int id)
        {
            string query = "SELECT * FROM [dbo].[Ticket] WHERE [dbo].[Ticket].[TicketId] = @ticketId";
            return new ValueTask<Ticket>(SqlMapper.QuerySingleAsync<Ticket>(_connectionFactory.GetConnection, query, new { ticketId = id }));
        }

        public Task<int> InsertTicket(Ticket newTicket)
        {
            string query = @"insert into dbo.Ticket(Name,IssuerUserId,DateCreated,DeadLine,StatusId)
                                values (@Name, @IssuerUserId, @DateCreated, @DeadLine, @StatusId);
                                select @Id = @@IDENTITY";


            var p = new DynamicParameters();
            p.Add("@Name", value: newTicket.Name);
            p.Add("@IssuerUserId", value: newTicket.IssuerUserId);
            p.Add("@DateCreated", value: newTicket.DateCreated, dbType: DbType.DateTime);
            p.Add("@DeadLine", value: newTicket.DeadLine, dbType: DbType.DateTime);
            p.Add("@StatusId", value: newTicket.StatusId);
            p.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);

            SqlMapper.Execute(_connectionFactory.GetConnection, query, p);

            _connectionFactory.CommitAsync();

            return Task.FromResult(p.Get<int>("@Id"));
        }

        public Task<Ticket> UpdateTicket(int id, Ticket ticketToBeUpdated)
        {
            string query = @"update dbo.Ticket set
                                Name = @Name, 
                                IssuerUserId = @IssuerUserId,
                                DateCreated = @DateCreated,
                                DeadLine = @DeadLine,
                                StatusId = @StatusId
                                WHERE TicketId = @TicketId";

            var p = new DynamicParameters();
            p.Add("@Name", value: ticketToBeUpdated.Name);
            p.Add("@IssuerUserId", value: ticketToBeUpdated.IssuerUserId);
            p.Add("@DateCreated", value: ticketToBeUpdated.DateCreated);
            p.Add("@DeadLine", value: ticketToBeUpdated.DeadLine);
            p.Add("@StatusId", value: ticketToBeUpdated.StatusId);
            p.Add("@TicketId", id);

            SqlMapper.ExecuteAsync(_connectionFactory.GetConnection, query, p);

            _connectionFactory.CommitAsync();

            return Task.FromResult(ticketToBeUpdated);
        }

        public Task<int> DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }
    }
}
