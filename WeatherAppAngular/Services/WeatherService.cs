using Domain.Dto;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace WeatherAppAngular.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _config;
        public WeatherService(IConfiguration config)
        {
            _config = config;
        }

        public HistoricalWeatherDto GetActualWeatherMap(string city, string country = "")
        {
            try
            {
                var uri = _config.GetValue<string>("ApiUrl");
                var parameters = String.Format("weather?q={0},{1}&appid={2}&units=metric", city, country, _config.GetValue<string>("ApiKey"));
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    var responseTask = client.GetAsync(parameters);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync();
                        readTask.Wait();

                        dynamic response = JObject.Parse(readTask.Result);
                        var weatherMapDto = new HistoricalWeatherDto
                        {
                            ThermalSensation = response.main.feels_like,
                            Temperature = response.main.temp
                        };
                        return weatherMapDto;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al consultar con la api");
            }
            return null;
        }
    }
}
