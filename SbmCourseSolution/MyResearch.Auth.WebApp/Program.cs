using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyResearch.Auth.WebApp.Data;

namespace MyResearch.Auth.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.IO.File.Delete("IdentityDatabase.db");
            using (var identityDbContext = new MyIdentityDBContext())
            {
                var ok = identityDbContext.Database.EnsureCreated();

            };

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
