﻿using Infrastructure.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metric.processor.model
{
    public class MetricModel : IntegrationEvent
    {
        public string Name { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public List<DataPoint> DataPoints { get; set; }
        public string Type { get; set; }


        public MetricModel()
        {
            Tags = new Dictionary<string, string>();
            DataPoints = new List<DataPoint>();
        }


    }

    public class DataPoint
    {
        public long Timestamp { get; set; }
        public object Value { get; set; }

        public DataPoint()
        {

        }
    }
}