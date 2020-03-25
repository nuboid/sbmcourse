using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace MyResearch.ServiceDiscovery.Service001
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("please specify the Urls as argument.");
            }
            else
            {
                var urls = args[0];
                var host = BuildWebHost(urls);
                host.Run();
            }
        }

        public static IWebHost BuildWebHost(string urls)
        {
            //urls = "http://localhost:9001;https://localhost:10001";
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseUrls(urls)
                .Build();
        }
    }
}
