using Infrastructure.Repository;
using Infrastructure.Repository.Abstractions;
using Infrastructure.Repository.Cassandra;
using application.utility.api.manager;
using application.utility.api.model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.utility.api.bootstrap
{
    public static class BootStrapper
    {
        public static void RegisterComponents(IServiceCollection services, IConfiguration Configuration)
        {
            if (Configuration.GetValue<string>("Settings:Worker:Database:Type").ToLower() == "Cassandra".ToLower())
            {
                services.AddSingleton<IDbContext>(sp =>
                {
                    var logger = sp.GetRequiredService<ILogger<CassandraDBContext>>();
                    string[] ConnectedPoints = null;
                    string Username = string.Empty;
                    string Password = string.Empty;

                    if (!string.IsNullOrEmpty(Configuration["Settings:Worker:Database:Host"]))
                    {
                        ConnectedPoints = Configuration["Settings:Worker:Database:Host"]?.Split(";");
                    };

                    if (!string.IsNullOrEmpty(Configuration["Settings:Worker:Database:Username"]))
                    {
                        Username = Configuration["Settings:Worker:Database:Username"];
                    }

                    if (!string.IsNullOrEmpty(Configuration["Settings:Worker:Database:Password"]))
                    {
                        Password = Configuration["Settings:Worker:Database:Password"];
                    }

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["Settings:Worker:Database:RetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["Settings:Worker:Database:RetryCount"]);
                    }

                    return new CassandraDBContext(ConnectedPoints, Username, Password, logger, retryCount);
                });
                ApplicationModelMappings.Initialize();
                services.AddTransient(typeof(IRepository<>),typeof(CassandraRepository<>));
            }

            services.AddTransient<IExcelManager, ExcelManager>();



        }
    }
}
