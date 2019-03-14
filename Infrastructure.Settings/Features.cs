using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infrastructure.Settings
{
    public partial class Feature
    {
        [JsonProperty("Epics")]
        public EpicElement[] Epics { get; set; }
    }

    public partial class EpicElement
    {
        [JsonProperty("Epic")]
        public EpicEpic Epic { get; set; }
    }

    public partial class EpicEpic
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("Stories")]
        public StoryElement[] Stories { get; set; }
    }

    public partial class StoryElement
    {
        [JsonProperty("Story")]
        public StoryStory Story { get; set; }
    }

    public partial class StoryStory
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }

        [JsonProperty("Functions")]
        public FunctionElement[] Functions { get; set; }
    }

    public partial class FunctionElement
    {
        [JsonProperty("Function")]
        public FunctionFunction Function { get; set; }
    }

    public partial class FunctionFunction
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Active")]
        public bool Active { get; set; }
    }

    public partial class Feature
    {
        public static Feature FromJson(string json) => JsonConvert.DeserializeObject<Feature>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Feature self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
