using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infrastructure.Settings
{
    public partial class BluePrint
    {
        [JsonProperty("ServiceBus")]
        public ServiceBus ServiceBus { get; set; }

        [JsonProperty("Loglevel")]
        public Loglevel Loglevel { get; set; }

        [JsonProperty("Worker")]
        public Worker Worker { get; set; }

        [JsonProperty("Agent")]
        public Agent Agent { get; set; }

        [JsonProperty("Stashengine")]
        public Agent Stashengine { get; set; }
        [JsonProperty("Common")]
        public Common Common { get; set; }
    }

    public partial class Agent
    {
    }

    public partial class Loglevel
    {
        [JsonProperty("Creator")]
        public string Creator { get; set; }

        [JsonProperty("Dispatcher")]
        public string Dispatcher { get; set; }
    }

    public partial class Common
    {
        [JsonProperty("UploadPath")]
        public string UploadPath { get; set; }
    }

    public partial class ServiceBus
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Host")]
        public string Host { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Port")]
        public long Port { get; set; }

        [JsonProperty("BrokerName", NullValueHandling = NullValueHandling.Ignore)]
        public string BrokerName { get; set; }
    }

    public partial class Worker
    {
        [JsonProperty("Creator")]
        public Creator Creator { get; set; }

        [JsonProperty("Dispatcher")]
        public Creator Dispatcher { get; set; }

        [JsonProperty("Database")]
        public ServiceBus Database { get; set; }
    }

    public partial class Creator
    {
        [JsonProperty("NumberOfInstance")]
        public long NumberOfInstance { get; set; }
    }

    public partial class BluePrint
    {
        public static BluePrint FromJson(string json) => JsonConvert.DeserializeObject<BluePrint>(json, Converter.Settings);
    }

  
}
