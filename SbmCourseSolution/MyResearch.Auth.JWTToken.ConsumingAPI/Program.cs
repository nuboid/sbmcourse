using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace MyResearch.Auth.JWTToken.ConsumingAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var urls = "http://localhost:9001";
            var host = BuildWebHost(urls);
            host.Run();
        }

        public static IWebHost BuildWebHost(string urls)
        {
            return WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseUrls(urls)
                .Build();
        }
    }
}
