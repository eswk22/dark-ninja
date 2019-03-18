using Autofac;
using Infrastructure.EventBus;
using Infrastructure.EventBus.Abstractions;
using Infrastructure.EventBus.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace bigben.bootstrap
{
    public static class BusBootStrapper
    {

        public static void RegisterEventBus(IServiceCollection services, IConfiguration Configuration)
        {
            var subscriptionClientName = Configuration["SubscriptionClientName"];

            if (Configuration.GetValue<string>("Settings:ServiceBus:Type").ToLower() == "RabbitMQ".ToLower())
            {

                services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
                {
                    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                    var factory = new ConnectionFactory()
                    {
                        HostName = Configuration["Settings:ServiceBus:Host"]
                    };

                    if (!string.IsNullOrEmpty(Configuration["Settings:ServiceBus:Username"]))
                    {
                        factory.UserName = Configuration["Settings:ServiceBus:Username"];
                    }

                    if (!string.IsNullOrEmpty(Configuration["Settings:ServiceBus:Password"]))
                    {
                        factory.Password = Configuration["Settings:ServiceBus:Password"];
                    }

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["Settings:ServiceBus:RetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["Settings:ServiceBus:RetryCount"]);
                    }

                    return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
                });




                services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                {
                    var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                    var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                    var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["Settings:ServiceBus:RetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["Settings:ServiceBus:RetryCount"]);
                    }

                    return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, retryCount);
                });
            }


            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            RegisterHandlers(services);
        }

        private static void RegisterHandlers(IServiceCollection services)
        {
          //  services.AddTransient<MetricAddIntegrationEventHandler>();
        }

        public static void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

         //   eventBus.Subscribe<MetricAddIntegrationEvent, MetricAddIntegrationEventHandler>();
        }


    }
}
