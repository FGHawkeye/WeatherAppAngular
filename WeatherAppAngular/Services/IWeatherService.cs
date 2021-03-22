using Domain.Dto;
using System.Collections.Generic;

namespace WeatherAppAngular.Services
{
    public interface IWeatherService
    {
        public HistoricalWeatherDto GetActualWeatherMap(string city, string country = "");
        public bool AddHistoricalWeather(HistoricalWeatherDto historicalWeatherDto);

        public IList<HistoricalWeatherDto> GetHistoricalWeather(int cityId);
    }
}
