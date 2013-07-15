namespace WeatherMonitor.Domain.Entities
{
    public interface IWeatherSource
    {
        string SourceName { get; set; }
        string City { get; set; }
        string Url { get; set; }
    }
}