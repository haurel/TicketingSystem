using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> QuerySingle(string query, object parameters = null, IDbTransaction transaction = null);
        Task<IEnumerable<TEntity>> Query(string query, object parameters = null);
        Task Insert(TEntity obj);
        Task Update(TEntity obj);
        Task Save();
    }
}
