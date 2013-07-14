namespace WeatherMonitor.Web.Models
{
    using System;

    public class WeatherModel
    {
        public int Preassure { get; set; }
        public int Degrees { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Humidity { get; set; }
        public DateTime WeatherTime { get; set; }
    }
}