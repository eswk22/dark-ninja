using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Cassandra;

namespace Infrastructure.Repository.Abstractions
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {

        T GetById(string id);
        T GetSingle(Expression<Func<T, bool>> predicate);


        void Add(T entity);

        void Add(IEnumerable<T> entities);

        //T Update(T entity);

        T Update(Expression<Func<T, bool>> predicate,T entity);

        void Update(IEnumerable<T> entities);

        void Delete(string id);

        void Delete(T entity);

        void Delete(Expression<Func<T, bool>> predicate);

    
        void DeleteAll();

        long Count();

        long Count(Expression<Func<T, bool>> predicate);

        bool Exists(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate,int page,int pagesize);

        IQueryable<T> Get();

        //Cassandra session
        ISession Session { get; set; }

        void CreateTableifNotExists();
    }
}
