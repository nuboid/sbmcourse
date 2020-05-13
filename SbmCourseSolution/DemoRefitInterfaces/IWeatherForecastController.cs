using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoRefitInterfaces
{

    public interface IWeatherForecastController
    {   
        //http://localhost:4628/weatherforecast
        [Get("/weatherforecast")]
        Task<IEnumerable<WeatherForecast>> Get();
    }
}