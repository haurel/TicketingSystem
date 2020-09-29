using System.Data;
using System.Data.Common;

namespace TicketingSystem.Data.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = string.Format("Server={0}; Database={1}; Trusted_Connection = SSPI;", "DESKTOP-PDK1CV0", "TicketingSystem-Demo");
        public IDbConnection GetConnection
        {
            get
            {
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                return conn;
            }
        }

        public IDbTransaction GetTransaction
        {
            get
            {
                return GetConnection.BeginTransaction();
            }
        }

        public void CommitAsync()
        {
            try
            {
                GetTransaction.Commit();
            }
            catch
            {
                GetTransaction.Rollback();
                throw;
            }
            finally
            {
                GetTransaction.Dispose();
            }
        }
    }
}
