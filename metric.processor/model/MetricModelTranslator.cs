using Infrastructure.TSDB;
using Infrastructure.Utility.Translators;
using metric.processor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metric.persistence.model
{
    public class MetricModelTranslator : EntityMapperTranslator<Metric, MetricModel>
    {
        public IEntityTranslatorService _translatorService { get; set; }
        public MetricModelTranslator(IEntityTranslatorService translatorService)
        {
            _translatorService = translatorService;
        }
        public override MetricModel BusinessToService(IEntityTranslatorService service, Metric value)
        {
            MetricModel entity = null;
            if (value != null)
            {
                entity = new MetricModel();
                entity.Name = value.Name;
                entity.Type = value.Type;
                entity.Tags = (Dictionary<string,string>)value.Tags;
                entity.DataPoints = value.DataPoints.Select(s => _translatorService.Translate<processor.model.DataPoint>(s)).ToList();
            }
            return entity;
        }

        public override Metric ServiceToBusiness(IEntityTranslatorService service, MetricModel value)
        {
            Metric entity = null;
            if (value != null)
            {
                entity = new Metric(value.Name);
                entity.AddDataPoints(value.DataPoints.Select(s => _translatorService.Translate<Infrastructure.TSDB.DataPoint>(s)));
                entity.AddTags(value.Tags);
                entity.SetType(value.Type);
            }
            return entity;
        }

     
    }
}
