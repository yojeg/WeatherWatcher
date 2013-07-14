namespace WeatherMonitor.DataAccessLayer
{
    using System.Data.Entity;
    using Domain.Entities;

    public class WeatherMonitorDbContext : DbContext
    {
        public DbSet<WeatherSource> WeatherSources { get; set; }
        public DbSet<Weather> Weathers { get; set; }
    }
}