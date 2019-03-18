using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Settings;
using Infrastructure.Utility.Translators;
using metric.processor.bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace metric.processor
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<BluePrint>(Configuration.GetSection("Settings"));
            services.Configure<BluePrint>(Configuration.GetSection("Features"));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddHealthChecks();


         
            services.AddSingleton<IConfiguration>(Configuration);
       
            services.AddOptions();
            BusBootStrapper.RegisterEventBus(services, Configuration);
            BootStrapper.RegisterComponents(services, Configuration);

            var container = new ContainerBuilder();
            container.Populate(services);
            return  new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            BusBootStrapper.ConfigureEventBus(app);
            BootStrapper.RegisterTranslators(app);

        }
    }
}
