using Cassandra;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Cassandra
{
    public class CassandraDBContext : IDbContext
    {
        private string[] _ContactPoints;
        private string _username;
        private string _password;
        private int _retryCount;
        private ILogger<CassandraDBContext> _logger;
        private string _KeySpace;
        private ICluster _cluster;
        private ISession _session;

        public CassandraDBContext(string[] ContactPoints,string username,string password, ILogger<CassandraDBContext> logger,int retryCount)
        {
            _ContactPoints = ContactPoints;
            _username = username;
            _password = password;
            _retryCount = retryCount;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected ICluster SetCluster()
        {
            var cluster = Cluster.Builder()
                     .AddContactPoints(_ContactPoints)
                     .Build();
            return cluster;
        }

        public ISession SetSession(string keyspace)
        {
            ISession result = null;
            try
            {
                if (_cluster == null)
                    _cluster = this.SetCluster();
                this._KeySpace = keyspace;
                _cluster.Connect().CreateKeyspaceIfNotExists(_KeySpace);
                result = _cluster.Connect(_KeySpace);
            }
            catch(Exception ex)
            {
                _logger.LogError("Unble to connect Cassandra, Please validate host & credentials", ex);
                throw;
            }
            return result;

        }

        public void DisposeSession()
        {
            if(_session != null)
            {
                _session.Dispose();
            }
        }

        ~CassandraDBContext()
        {
            if (_cluster != null)
            {
                _cluster.Dispose();
            }
        }


    }
}
