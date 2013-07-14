namespace WeatherMonitor.BusinessLogic.Parsers
{
    using Domain.Entities;

    public interface IWeatherParser
    {
        IWeather Parse(IWeatherSource weatherSource);
    }
}