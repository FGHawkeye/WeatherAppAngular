using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WeatherAppAngular.Data;

namespace WeatherAppAngular.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfiguration _config;
        private readonly WeatherContext _context;
        private readonly IMapper _mapper;
        public WeatherService(IConfiguration config, WeatherContext context, IMapper mapper)
        {
            _config = config;
            _context = context;
            _mapper = mapper;
        }

        public bool AddHistoricalWeather(HistoricalWeatherDto historicalWeatherDto)
        {
            try
            {
                //var historicalWeather = _mapper.Map<HistoricalWeather>(historicalWeatherDto);
                var historicalWeather = new HistoricalWeather
                {
                    ThermalSensation = historicalWeatherDto.ThermalSensation,
                    Temperature = historicalWeatherDto.Temperature,
                    City = _context.City.FirstOrDefault(x => x.Id == historicalWeatherDto.City.Id),
                    Country = _context.Country.FirstOrDefault(x => x.Id == historicalWeatherDto.Country.Id),
                };
                _context.Add<HistoricalWeather>(historicalWeather);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al guardar el historico");
                return false;
            }
            return true;
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

        public IList<HistoricalWeatherDto> GetHistoricalWeather(int cityId)
        {
            var historicalWeather = _context.HistoricalWeathers.Include("City").Include("Country").Where(x => x.City.Id == cityId).ToList();
            return _mapper.Map<IList<HistoricalWeatherDto>>(historicalWeather);
        }
    }
}
