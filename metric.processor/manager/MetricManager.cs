using Infrastructure.EventBus.Abstractions;
using Infrastructure.TSDB;
using Infrastructure.Utility.Translators;
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
        public IEntityTranslatorService _translator { get; set; }

        public MetricManager(IRestClient tsdbClient, ILoggerFactory loggerFactory, IEventBus eventBus, IEntityTranslatorService translator)
        {
            _logger = loggerFactory.CreateLogger<MetricManager>();
            _tsdbClient = tsdbClient;
            _eventBus = eventBus;
            _translator = translator;
        }

        public async Task AddMetric(MetricModel metric)
        {
            try
            {
                _logger.LogTrace("Saving the Job", metric);
                Metric metricdto = _translator.Translate<Metric>(metric);

                await _tsdbClient.AddMetricsAsync(metricdto);

                MetricAddedIntegrationEvent test = new MetricAddedIntegrationEvent(
                    metric.Name,metric.Tags,metric.DataPoints,metric.Type);
                _eventBus.Publish(test);


                _logger.LogTrace("Item Saved & event publised. event:",test);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to save the  metric", ex);
            }
            await Task.CompletedTask;
        }
    }
}
