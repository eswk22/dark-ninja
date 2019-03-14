using System;
using System.Collections.Generic;
using System.Text;
using Cassandra;

namespace Infrastructure.Repository
{
    public interface IDbContext
    {
        ISession SetSession(string keyspace);
        void DisposeSession();
    }
}
