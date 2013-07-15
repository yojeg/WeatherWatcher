namespace WeatherMonitor.WeatherSaverConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;
    using BusinessLogic.Parsers;
    using DataAccessLayer;
    using Domain.Entities;

    public class ForecastMonitor
    {
        private readonly IEnumerable<IWeatherSource> _weatherSources;
        private readonly IEnumerable<IWeatherParser> _weatherParsers;
        private readonly int _refreshInterval;
        private readonly Timer _timer;

        public ForecastMonitor(IEnumerable<IWeatherSource> weatherSources, IEnumerable<IWeatherParser> weatherParsers, int refreshInterval)
        {
            _weatherSources = weatherSources;
            _weatherParsers = weatherParsers;
            _refreshInterval = refreshInterval;
            _timer = new Timer(_refreshInterval);
        }

        public void Run()
        {
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            foreach (var weatherSource in _weatherSources)
            {
                using (var context = new WeatherMonitorDbContext())
                {
                    var parser = _weatherParsers.First(x => x.Name == weatherSource.SourceName);
                    var result = parser.Parse(weatherSource);
                    var source = context.WeatherSources.FirstOrDefault(x => x.Url == weatherSource.Url) ??
                                 weatherSource;

                    result.WeatherSource = (WeatherSource) source;
                    result.WeatherTime = DateTime.Now;
                    context.Weathers.Add((Weather)result);
                    context.SaveChanges();
                }
            }
        }
    }
}