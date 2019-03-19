using Infrastructure.Repository;
using Infrastructure.Repository.Abstractions;
using Infrastructure.Repository.Cassandra;
using stashengine.web.api.manager;
using stashengine.web.api.model;
using stashengine.web.api.repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using MongoRepository;

namespace stashengine.web.api.bootstrap
{
    public static class BootStrapper
    {
        public static void RegisterComponents(IServiceCollection services, IConfiguration Configuration)
        {
            if (Configuration.GetValue<string>("Settings:Worker:Database:Type").ToLower() == "mongo".ToLower())
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

            //    services.AddTransient(typeof(IRepository<>), typeof(MongoRepository<>));
            }

            services.AddTransient<IJobManager, JobManager>();
            services.AddTransient<IJobRepository, JobRepository>();



        }
    }
}
