using application.utility.api.model;
using Infrastructure.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.utility.api.integrationevents.events
{
    public class MetricAddIntegrationEvent : IntegrationEvent
    {
        public string Name { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public List<DataPoint> DataPoints { get; set; }
        public string Type { get; set; }


        public MetricAddIntegrationEvent(string name, Dictionary<string, string> tags, List<DataPoint> datapoints, string type)
        {
            Name = name;
            Tags = tags;
            DataPoints = datapoints;
            Type = type;
        }
    }
}
