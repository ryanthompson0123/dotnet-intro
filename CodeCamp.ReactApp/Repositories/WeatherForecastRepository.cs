
using System;
using System.Collections.Generic;
using System.Linq;
using CodeCamp.ReactApp.Models;

namespace CodeCamp.ReactApp.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> Get(int startDateIndex);
    }

    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly int numberOfDays;

        public WeatherForecastRepository(int numberOfDays)
        {
            this.numberOfDays = numberOfDays;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(int startDateIndex)
        {
            var rng = new Random();
            return Enumerable.Range(1, numberOfDays).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}