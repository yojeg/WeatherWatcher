namespace WeatherMonitor.WeatherSaverConsole
{
    using System.Collections.Generic;
    using Domain.Entities;

    public class ForecastMonitor
    {
        private readonly IEnumerable<IWeatherSource> _weatherSources;

        public ForecastMonitor(IEnumerable<IWeatherSource> weatherSources)
        {
            _weatherSources = weatherSources;
        }

        public void Run()
        {
        }
    }
}