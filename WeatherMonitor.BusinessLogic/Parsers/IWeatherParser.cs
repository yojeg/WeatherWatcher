namespace WeatherMonitor.BusinessLogic.Parsers
{
    using Domain.Entities;

    public interface IWeatherParser
    {
        string Name { get; }
        IWeather Parse(IWeatherSource weatherSource);
    }
}