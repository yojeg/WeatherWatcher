namespace WeatherMonitor.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WeatherSource : IWeatherSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SourceName { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
    }
}