namespace WeatherMonitor.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Weather : IWeather
    {
        [Key]
        public int Id { get; set; }

        public int Preassure { get; set; }
        public int Degrees { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Humidity { get; set; }
        public DateTime WeatherTime { get; set; }
        public WeatherSource WeatherSource { get; set; }
    }
}