namespace WeatherMonitor.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class WeatherSource : IWeatherSource
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
    }
}