using Infrastructure.EventBus.Abstractions;
using bigben.integrationevents.events;
using bigben.model;
using bigben.repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bigben.manager
{
    public class ScheduleManager : IScheduleManager
    {
        private readonly ILogger<ScheduleManager> _logger;
        private readonly IJobRepository _jobRepository;
        private readonly IEventBus _eventBus;

        public ScheduleManager(IJobRepository jobRepository, ILoggerFactory loggerFactory, IEventBus eventBus)
        {
            _logger = loggerFactory.CreateLogger<ScheduleManager>();
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
        //                result = _jobRepository.Update(job);
                    }
                    else
                    {
       //                result = _jobRepository.Add(job);
                    }
                }
                else
                {
       //             result = _jobRepository.Add(job);
                }

                JobDispatchRequestEvent test = new JobDispatchRequestEvent();
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
