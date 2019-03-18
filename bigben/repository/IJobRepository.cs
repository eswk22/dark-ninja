using Infrastructure.Repository.Abstractions;
using bigben.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bigben.repository
{
    public interface IJobRepository
    {
  
        bool Exists(Expression<Func<JobItem, bool>> predicate);

        IEnumerable<JobItem> Find(Expression<Func<JobItem, bool>> predicate);

        IEnumerable<JobItem> Find(Expression<Func<JobItem, bool>> predicate, int page, int pagesize);

        IQueryable<JobItem> Get();

        JobItem GetById(string id);

        
     }
}
