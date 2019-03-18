using Infrastructure.Utility.Translators;
using metric.processor.integrationevents.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metric.processor.model
{
    public class MetricTranslator : EntityMapperTranslator<MetricAddIntegrationEvent, MetricModel>
    {
        public override MetricModel BusinessToService(IEntityTranslatorService service, MetricAddIntegrationEvent value)
        {
            MetricModel entity = null;
            if (value != null)
            {
                entity = new MetricModel()
                {
                    Name = value.Name,
                    Tags = value.Tags,
                    Type = value.Type,
                    DataPoints = value.DataPoints
                };
            }
            return entity;
        }

        public override MetricAddIntegrationEvent ServiceToBusiness(IEntityTranslatorService service, MetricModel value)
        {
            throw new NotImplementedException();
        }
    }
}
