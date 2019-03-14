using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Agent.Config
{
    public sealed class ServiceConfiguration
    {
        private static ServiceConfiguration instance = null;
        private static readonly object padlock = new object();

        public RootObject config { get; set; }

        ServiceConfiguration()
        {
            this.LoadJson();
        }

        public static ServiceConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ServiceConfiguration();
                        }
                    }
                }
                return instance;
            }
        }

        private void LoadJson()
        {
            using (StreamReader r = new StreamReader("configuration.json"))
            {
                string json = r.ReadToEnd();
                this.config = JsonConvert.DeserializeObject<RootObject>(json);
            }
        }


    }

    public class RootObject
    {
        public ServiceBus ServiceBus { get; set; }
    }

    public class Queue
    {
        public string Queuename { get; set; }
        public string Executor { get; set; }
        public bool IsActive { get; set; }
    }

    public class Topic
    {
        public string name { get; set; }
        public string Executor { get; set; }
        public bool IsActive { get; set; }
    }

    public class ServiceBus
    {
        public string ConnectionString { get; set; }
        public List<Queue> Queues { get; set; }
        public List<Topic> Topics { get; set; }
    }


}
