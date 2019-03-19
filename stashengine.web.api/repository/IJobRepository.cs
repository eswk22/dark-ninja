using Infrastructure.Repository.Abstractions;
using stashengine.web.api.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace stashengine.web.api.repository
{
    public interface IJobRepository
    {
        JobItem Add(JobItem entity);

        void Add(IEnumerable<JobItem> entities);

        long Count();

        long Count(Expression<Func<JobItem, bool>> predicate);

        void Delete(string id);

        void Delete(JobItem entity);

        void Delete(Expression<Func<JobItem, bool>> predicate);

        void DeleteAll();

        bool Exists(Expression<Func<JobItem, bool>> predicate);

        IEnumerable<JobItem> Find(Expression<Func<JobItem, bool>> predicate);

        IEnumerable<JobItem> Find(Expression<Func<JobItem, bool>> predicate, int page, int pagesize);

        IQueryable<JobItem> Get();

        JobItem GetById(string id);

        JobItem Update(JobItem entity);

        void Update(IEnumerable<JobItem> entities);
     }
}
