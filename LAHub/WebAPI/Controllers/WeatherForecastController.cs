using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet("GetBy/{name?}")]
        //public string GetBy(string name = "Hello World")
        //{
        //    return name;

        //}

        //[HttpGet("TestServicesByDistance/{latitude}/{longtitude}/{meters}/{pageNumber?}/{pageSize?}")]
        
        //public string TestServicesByDistance([FromRoute] double latitude, [FromRoute] double longtitude, [FromRoute] double meters, [FromRoute] int? pageNumber = 1, [FromRoute] int? pageSize = 10)
        //{
        //    return "Hello";

        //}
    }
}