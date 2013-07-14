namespace WeatherMonitor.Domain.Entities
{
    public interface IWeatherSource
    {
        string Name { get; set; }
        string City { get; set; }
        string Url { get; set; }
    }
}