using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MySoftwareCompany.BaseServices.HealthEndpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var address = "http://0.0.0.0:8001";
            var host = BuildWebHost(address);
            host.Run();
        }

        public static IWebHost BuildWebHost(string urls)
        {
            //urls = "http://localhost:9001;https://localhost:10001";
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseKestrel()
                .UseUrls(urls)
                .Build();
        }
    }
}
