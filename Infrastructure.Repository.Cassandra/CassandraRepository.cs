using Infrastructure.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Cassandra.Data.Linq;
using Cassandra;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Cassandra
{
    public class CassandraRepository<T> : IRepository<T>
        where T : IEntity
    {

        private ISession _session;
        public ISession Session
        {
            get
            {
                return this._session;
            }
            set
            {
                this._session = value;
            }
        }
      
        public CassandraRepository()
        {
             
        }

   
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
   
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CassandraRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        public void CreateTableifNotExists()
        {
            var table = new Table<T>(_session);
            table.CreateIfNotExists();
        }

        public virtual T GetById(string id)
        {
            throw new NotImplementedException();
            //var table = new Table<T>(_session);
            //return table.Where((x => x.Id == id)).Execute().SingleOrDefault();
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            var table = new Table<T>(_session);
            return table.Where(predicate).Execute().SingleOrDefault();
        }

        public virtual void Add(T entity)
        {
            var table = new Table<T>(_session);
            table.Insert(entity).Execute();
        }

        public virtual void Add(IEnumerable<T> entities)
        {
            var table = new Table<T>(_session);
            foreach(var entity in entities)
            {
                table.Insert(entity).Execute();
            }
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
            //var table = new Table<T>(_session);
            //table.Where(x => x.Id.ToString() == entity.Id.ToString()).Select(x => entity).Update().Execute();
            //return this.GetById(entity.Id);
        }

        public virtual T Update(Expression<Func<T, bool>> predicate,T entity)
        {
            var table = new Table<T>(_session);
            table.Where(predicate).Select(x => entity).Update().Execute();
            return this.GetSingle(predicate);
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            var table = new Table<T>(_session);
            foreach(var entity in entities)
                table.Where(x => x.Id.ToString() == entity.Id.ToString()).Select(x => entity).Update().Execute();
        }

        public virtual void Delete(string id)
        {
            throw new NotImplementedException();
            //var table = new Table<T>(_session);
            //table.DeleteIf(x => x.Id.ToString() == id.ToString()).Execute();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
            //var table = new Table<T>(_session);
            //this.Delete(entity.Id);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var table = new Table<T>(_session).AllowFiltering();
            table.DeleteIf(predicate).Execute();
        }

        public virtual void DeleteAll()
        {
            var table = new Table<T>(_session);
            table.Delete().Execute();
        }

        public virtual long Count()
        {
            var table = new Table<T>(_session);
            return table.Count().Execute();
        }

        public virtual long Count(Expression<Func<T, bool>> predicate)
        {
            var table = new Table<T>(_session).AllowFiltering();
            return table.Where(predicate).Count().Execute();
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return this.Count(predicate) != 0;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var table = new Table<T>(_session).AllowFiltering();
            return table.Where(predicate).Execute();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate, int page, int pagesize)
        {
            var table = new Table<T>(_session).AllowFiltering();
            table.SetPageSize(pagesize).Skip(page * pagesize);
            return table.Where(predicate).ExecutePaged();
        }

        public virtual IQueryable<T> Get()
        {
            var table = new Table<T>(_session);
            return table.AsQueryable();
        }

        #endregion

    }
}
