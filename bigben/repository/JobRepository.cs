using Infrastructure.Repository;
using Infrastructure.Repository.Abstractions;
using Infrastructure.Settings;
using bigben.model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bigben.repository
{
    public class JobRepository : IJobRepository
    {
        private readonly ILogger<JobRepository> _logger;
        private readonly IRepository<JobItem> _repository;
        private readonly IDbContext _iDBContext;
        private BluePrint _settings;
        
        public JobRepository(ILoggerFactory loggerFactory,IRepository<JobItem> repository,IDbContext iDBContext, IOptions<BluePrint> settings)
        {
            _logger = loggerFactory.CreateLogger<JobRepository>();
            _repository = repository;
            _settings = settings.Value;
            if (_settings.Worker.Database.Type == "Cassandra")
            {
                _iDBContext = iDBContext;
                _repository.Session = iDBContext.SetSession("manager");
                _repository.CreateTableifNotExists();
            }
        }

    
       
        public bool Exists(Expression<Func<JobItem, bool>> predicate)
        {
            return _repository.Exists(predicate);
        }

        public IEnumerable<JobItem> Find(Expression<Func<JobItem, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public IEnumerable<JobItem> Find(Expression<Func<JobItem, bool>> predicate, int page, int pagesize)
        {
            return _repository.Find(predicate, page, pagesize);
        }

        public IQueryable<JobItem> Get()
        {
            return _repository.Get();
        }

        public JobItem GetById(string id)
        {
            Expression<Func<JobItem, bool>> expression = (x => x.Id == id);
            return _repository.GetSingle(expression);
        }

    }
}
