namespace WeatherMonitor.WeatherSaverConsole
{
    using System;
    using System.Collections.Generic;
    using BusinessLogic.ContentManager;
    using BusinessLogic.Parsers;
    using Domain.Entities;

    class Program
    {
        static void Main(string[] args)
        {
            var contentManager = new ContentManager();

            var parsers = new List<IWeatherParser>()
                {
                    new YahooWeatherParser(contentManager),
                    new WeatherCoUaParser(contentManager)
                };

            var weatherSources = new List<IWeatherSource>()
                {
                    new WeatherSource()
                        {
                            City = "Челябинск",
                            SourceName = "WeatherCoUa",
                            Url = "http://xml.weather.co.ua/1.2/forecast/1515"
                        },
                    new WeatherSource()
                        {
                            City = "Челябинск",
                            SourceName = "YahooWeather",
                            Url = "http://weather.yahooapis.com/forecastrss?w=1997422&u=c"
                        }
                };

            var monitor = new ForecastMonitor(weatherSources, parsers, 10000);

            monitor.Run();

            Console.WriteLine("Press any key to stop service");
            Console.ReadLine();
        }
    }
}
