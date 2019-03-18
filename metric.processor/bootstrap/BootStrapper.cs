using Infrastructure.TSDB;
using Infrastructure.Utility.Translators;
using metric.processor.manager;
using metric.processor.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metric.processor.bootstrap
{
    public static class BootStrapper
    {
        public static void RegisterComponents(IServiceCollection services, IConfiguration Configuration)
        {
            if (Configuration.GetValue<string>("Settings:StashEngine:tsdb:Type").ToLower() == "Kairos".ToLower())
            {
                services.AddSingleton<IRestClient>(sp =>
                {
                    string[] IPAddresses = null;
                    int port = 8080;

                    if (!string.IsNullOrEmpty(Configuration["Settings:StashEngine:tsdb:IPAddresses"]))
                    {
                        IPAddresses = Configuration["Settings:StashEngine:tsdb:IPAddresses"]?.Split(";");
                    };

                    if (!string.IsNullOrEmpty(Configuration["Settings:StashEngine:tsdb:Port"]))
                    {
                        port = int.Parse(Configuration["Settings:StashEngine:tsdb:Port"]);
                    }

                    if (IPAddresses.Length == 0)
                    {
                        throw new Exception("TSDB Ipaddress should be empty");
                    }

                    return new RestClient(IPAddresses, port);
                });
            }
            services.AddSingleton<IEntityTranslatorService, EntityTranslatorService>();


            services.AddTransient<IMetricManager, MetricManager>();



        }

        public static void RegisterTranslators(IApplicationBuilder app)
        {
            var translatorService = app.ApplicationServices.GetRequiredService<IEntityTranslatorService>();

            translatorService.RegisterEntityTranslator(new MetricTranslator());

        }
    }
}
