using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeCamp.ReactApp.Models;
using CodeCamp.ReactApp.Repositories;

namespace CodeCamp.ReactApp.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IWeatherForecastRepository forecasts;

        public SampleDataController(IWeatherForecastRepository forecasts)
        {
            this.forecasts = forecasts;
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            return forecasts.Get(startDateIndex);
        }
    }
}