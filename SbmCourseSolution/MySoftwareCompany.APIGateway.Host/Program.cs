using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
namespace MySoftwareCompany.APIGateway.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateWebHostBuilder(args).Run();

            //new WebHostBuilder()
            //  .UseKestrel()
            //  .UseContentRoot(Directory.GetCurrentDirectory())
            //  .ConfigureAppConfiguration((hostingContext, config) =>
            //  {
            //      config
            //          .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            //          .AddJsonFile("appsettings.json", true, true)
            //          .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            //          .AddJsonFile("ocelot.json");
            //          //.AddEnvironmentVariables();
            //  })
            //  .ConfigureServices(s => {
            //      s.AddOcelot();
            //  })
            //  .ConfigureLogging((hostingContext, logging) =>
            //  {
            //       //add your logging
            //   })
            //  .UseIISIntegration()
            //  .Configure(app =>
            //  {
            //      app.UseOcelot().Wait();
            //  })
            //  .Build()
            //  .Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            return
                WebHost.CreateDefaultBuilder(args)
                     .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config
                       .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                       .AddJsonFile("ocelot.json")
                       .AddEnvironmentVariables();
               })
               .ConfigureServices(s =>
               {
                   s.AddOcelot();
               })
               .ConfigureLogging((hostingContext, logging) =>
               {
                   //add your logging
               })
               .UseIISIntegration()
               .Configure(app =>
               {
                   app.UseOcelot().Wait();
               })
               .UseUrls("http://localhost:9000;https://localhost:10000")
               .Build();
        }
    }
}
