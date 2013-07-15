namespace WeatherMonitor.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Weather : IWeather
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Pressure { get; set; }
        public int Degrees { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Humidity { get; set; }
        public DateTime WeatherTime { get; set; }
        
        public WeatherSource WeatherSource { get; set; }
    }
}