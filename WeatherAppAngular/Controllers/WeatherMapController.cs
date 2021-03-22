using Microsoft.AspNetCore.Mvc;
using WeatherAppAngular.Services;

namespace WeatherAppAngular.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherMapController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        public WeatherMapController(IWeatherService weatherService, ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _weatherService = weatherService;
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetActualWeatherMap(int cityId)
        {
            var city = _cityService.GetCity(cityId);
            var country = _countryService.GetCountry(); //si hubiera mas paises, deberia pasarsele un id desde el front
            var weather = _weatherService.GetActualWeatherMap(city.Name, country.ApiCode);
            weather.City = city;
            weather.Country = country;
            _weatherService.AddHistoricalWeather(weather);
            return Ok(weather);     
        }

        [HttpGet]
        public IActionResult GetHistoricalWeather(int cityId)
        {
            var historicalWeather = _weatherService.GetHistoricalWeather(cityId);
            return Ok(historicalWeather);
        }
    }
}
