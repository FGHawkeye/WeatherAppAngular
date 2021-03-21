using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WeatherAppAngular.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var country = new Country() { Id = 1, Name = "Argentina", ApiCode = "AR" };
            var city1 = new City() { Id = 1, Name = "Buenos Aires" };
            var city2 = new City() { Id = 2, Name = "Tigre" };
            var city3 = new City() { Id = 3, Name = "La Plata" };
            var city4 = new City() { Id = 4, Name = "Rosario" };
            var city5 = new City() { Id = 5, Name = "Córdoba" };

            modelBuilder.Entity<Country>().HasData(new Country[] { country });
            modelBuilder.Entity<City>().HasData(new City[] { city1, city2, city3, city4, city5 });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<HistoricalWeather> HistoricalWeathers { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
    }
}
