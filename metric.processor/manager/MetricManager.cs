using Infrastructure.EventBus.Abstractions;
using Infrastructure.TSDB;
using metric.processor.integrationevents.events;
using metric.processor.model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace metric.processor.manager
{
    public class MetricManager : IMetricManager
    {
        private readonly ILogger<MetricManager> _logger;
        private readonly IRestClient _tsdbClient;
        private readonly IEventBus _eventBus;

        public MetricManager(IRestClient tsdbClient, ILoggerFactory loggerFactory, IEventBus eventBus)
        {
            _logger = loggerFactory.CreateLogger<MetricManager>();
            _tsdbClient = tsdbClient;
            _eventBus = eventBus;
        }

        public async Task AddMetric(MetricModel metric)
        {
            try
            {
                _logger.LogTrace("Saving the Job", metric);
                MetricAddedIntegrationEvent test = new MetricAddedIntegrationEvent(
                    metric.Name,metric.Tags,metric.DataPoints,metric.Type);
                _eventBus.Publish(test);


                _logger.LogTrace("Item Saved & event publised. event:",test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to save the ", ex);
            }
            await Task.CompletedTask;
        }
    }
}
