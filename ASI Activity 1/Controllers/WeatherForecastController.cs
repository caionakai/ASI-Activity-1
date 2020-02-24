using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public struct City
{
    public string Temperature;
    public int Zipcode;
    public City(string temperature, int zipcode)
    {
        Temperature = temperature;
        Zipcode = zipcode;
    }
}

namespace ASI_Activity_1.Controllers
{
    

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly WeatherForecast[] FakeDb = new[]
        {
            new WeatherForecast {Date = new DateTime(2020, 02, 25, 16, 41, 48),
                TemperatureC = 1,
                Summary = "Freezing",
                Zipcode = 310230},
            new WeatherForecast {Date = new DateTime(2021, 02, 25, 16, 41, 48),
                TemperatureC = 50,
                Summary = "Hot",
                Zipcode = 310239}
        };

        

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            yield return new WeatherForecast
            {
                Date = new DateTime(2020, 02, 25, 16, 41, 48),
                TemperatureC = 21,
                Summary = "Sunny"
            };
            
           
        }

        [HttpGet("{zipcode}")]
        public WeatherForecast Get(int zipcode)
        {
            WeatherForecast inst = Array.Find(FakeDb, item=> item.Zipcode == zipcode);
            
            return inst;


        }
    }
}
