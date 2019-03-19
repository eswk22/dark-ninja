using Infrastructure.TSDB;
using Infrastructure.Utility.Translators;
using metric.processor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metric.persistence.model
{
    public class DataPointTranslator : EntityMapperTranslator<Infrastructure.TSDB.DataPoint, processor.model.DataPoint>
    {
        public override processor.model.DataPoint BusinessToService(IEntityTranslatorService service, Infrastructure.TSDB.DataPoint value)
        {
            processor.model.DataPoint entity = null;
            if (value != null)
            {
                entity = new processor.model.DataPoint()
                {
                    Timestamp = value.Timestamp,
                    Value = value.Value
                };
            }
            return entity;
        }

        public override Infrastructure.TSDB.DataPoint ServiceToBusiness(IEntityTranslatorService service, processor.model.DataPoint value)
        {
            Infrastructure.TSDB.DataPoint entity = null;
            if (value != null)
            {
                entity = new Infrastructure.TSDB.DataPoint()
                {
                    Timestamp = value.Timestamp,
                    Value = value.Value
                };
            }
            return entity;
        }
    }
}
