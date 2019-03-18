using metric.processor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metric.processor.manager
{
    public interface IMetricManager
    {
        Task AddMetric(MetricModel metric);
    }
}
