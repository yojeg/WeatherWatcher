namespace WeatherMonitor.Domain.Entities
{
    using System;

    public interface IWeather
    {
        int Preassure { get; set; }
        int Degrees { get; set; }
        decimal WindSpeed { get; set; }
        decimal Humidity { get; set; }
        DateTime WeatherTime { get; set; }
        WeatherSource WeatherSource { get; set; }
    }
}