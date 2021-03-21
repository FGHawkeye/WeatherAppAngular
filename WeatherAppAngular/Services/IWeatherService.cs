using Domain.Dto;

namespace WeatherAppAngular.Services
{
    public interface IWeatherService
    {
        public HistoricalWeatherDto GetActualWeatherMap(string city, string country = "");
    }
}
