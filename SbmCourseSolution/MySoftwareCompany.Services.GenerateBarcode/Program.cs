using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MySoftwareCompany.Services.GenerateBarcode
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Directory.CreateDirectory(Environment.CurrentDirectory + @"/mydata");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().ConfigureLogging(logging => {
                        logging.ClearProviders();
                        logging.AddConsole();
                    });
                });
    }
}
