using Infrastructure.EventBus.Abstractions;
using Infrastructure.Utility.Translators;
using metric.processor.integrationevents.events;
using metric.processor.manager;
using metric.processor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metric.processor.integrationevents.eventhandling
{
    public class MetricAddIntegrationEventHandler : IIntegrationEventHandler<MetricAddIntegrationEvent>
    {
        private readonly IMetricManager _manager;
        private readonly IEntityTranslatorService _translator;

        public MetricAddIntegrationEventHandler(IMetricManager manager, IEntityTranslatorService translator)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _translator = translator ?? throw new ArgumentNullException(nameof(translator));
        }

        public async Task Handle(MetricAddIntegrationEvent @event)
        {
            var model = _translator.Translate<MetricModel>(@event);
            await _manager.AddMetric(model);
        }
    }
}
