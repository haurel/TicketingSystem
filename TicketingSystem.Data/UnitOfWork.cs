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
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private ITicketRepository _tickets;
        private bool _disposed;

        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public ITicketRepository Tickets
        {
            get
            {
                return _tickets ?? (_tickets = new TicketRepository(_transaction));
            }
        }

        public void CommitAsync()
        {
            try
            {
                _transaction.Commit();
            }
            catch { 
                _transaction.Rollback(); 
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _tickets = null;
        }

        public void Dispose()
        {
            dispose(true);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}
