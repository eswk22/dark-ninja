using Infrastructure.EventBus.Abstractions;
using manager.web.api.integrationevents.events;
using manager.web.api.model;
using manager.web.api.repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace manager.web.api.manager
{
    public class JobManager :IJobManager
    {
        private readonly ILogger<JobManager> _logger;
        private readonly IJobRepository _jobRepository;
        private readonly IEventBus _eventBus;

        public JobManager(IJobRepository jobRepository, ILoggerFactory loggerFactory, IEventBus eventBus)
        {
            _logger = loggerFactory.CreateLogger<JobManager>();
            _jobRepository = jobRepository;
            _eventBus = eventBus;
        }

        public void SaveJob(JobItem job)
        {
            var result = new JobItem();
            try
            {
                _logger.LogTrace("Saving the Job", job);
                if (!string.IsNullOrEmpty(job.Id))
                {
                    Expression<Func<JobItem, bool>> expr = (x => x.Id == job.Id);
                    if (_jobRepository.Exists(expr))
                    {
                        result = _jobRepository.Update(job);
                    }
                    else
                    {
                        result = _jobRepository.Add(job);
                    }
                }
                else
                {
                    result = _jobRepository.Add(job);
                }

                JobCreatedIntegrationEvent test = new JobCreatedIntegrationEvent("test");
                _eventBus.Publish(test);


                _logger.LogTrace("Item Saved & event publised. event:",test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to save the ", ex);
            }
        }
    }
}
