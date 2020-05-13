using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyResearch.NetCoreStartupClass.Configuration;
using MyResearch.NetCoreStartupClass.FW;

namespace MyResearch.NetCoreStartupClass.Controllers
{

    //publish C:\temp\PublishHere
    //for producution browse to https://localhost:5001/WeatherForecast
    //set MyKey=xxxxxxxxxxxxxxx
    //docker file ENV abc=hello
    //docker --env 

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IConfiguration _configuration { get; set; }
        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IConfiguration configuration,
            ISomethingWeNeedSomewhere somethingWeNeed,
            IOptions<MyConfigurationStructure> options)
        {
            _logger = logger;
            _configuration = configuration;

            var x = somethingWeNeed.DoingSomething("test");

            var f1 = options.Value.Field1;
            _logger.LogInformation("WeatherForecastController");
        }



        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromServices] ISomethingWeNeedSomewhere somethingWeNeed)
        {
            var x = somethingWeNeed.DoingSomething("test");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)]
                Summary = _configuration["MyKey"]
            })
            .ToArray();
        }
    }
}
