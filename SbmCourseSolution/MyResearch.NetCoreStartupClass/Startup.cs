using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyResearch.NetCoreStartupClass.Configuration;
using MyResearch.NetCoreStartupClass.FW;

namespace MyResearch.NetCoreStartupClass
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var myKeyValue = Configuration["MyKey"];
            var MyConfigurationStructureObject = Configuration.GetSection("MyConfigurationStructure").Get<MyConfigurationStructure>();
            var MyConfigurationStructureDirectField1 = Configuration["MyConfigurationStructure:Field1"];

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOurNeededStuff();


            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-3.1
            services.AddOptions();
            services.Configure<MyConfigurationStructure>(Configuration.GetSection("MyConfigurationStructure"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.Run(async (context) =>
            //{
            //    //Terminating middleware
            //    await context.Response.WriteAsync("my pipeline step");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync(" my pipeline step 1");
            //    await next();
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync(" my pipeline step 2");
            //    await next();
            //});

            //app.Use(async (context, next) =>
            //{
                
            //    await next();
            //});



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/mytinyendpoint/{param}", async context =>
                {
                    var name = context.Request.RouteValues["param"];
                    await context.Response.WriteAsync("Hello " + name);
                });
            });

           


        }
    }
}
