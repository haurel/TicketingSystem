using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicketingSystem.Core.Models;
using TicketingSystem.Core.Repositories;

namespace TicketingSystem.Data.Repositories
{
    internal class Repository<TEntity> : RepositoryBase, IRepository<TEntity> where TEntity : class
    {
        public Repository(IDbTransaction transaction) : base(transaction)
        {
        }

        public Task<IEnumerable<TEntity>> Query(string query, object parameters = null, IDbTransaction transaction = null)
        {
            try
            {
                return Task.FromResult(Connection.Query<TEntity>(query, parameters, transaction).ToList() as IEnumerable<TEntity>);
            }
            catch (Exception)
            {
                //Handle the exception
                return Task.FromResult(new List<TEntity>() as IEnumerable<TEntity>);
            }
        }

        public ValueTask<TEntity> QuerySingle(string query, object parameters = null, IDbTransaction transaction = null)
        {
            try
            {
                return new ValueTask<TEntity>(Task.FromResult(Connection.Query<TEntity>(query, parameters, transaction).First()));
            }
            catch (Exception)
            {
                //Handle the exception
                return default;
            }
        }

        public Task Insert(TEntity obj)
        {
            throw new NotImplementedException();
        }

        

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
