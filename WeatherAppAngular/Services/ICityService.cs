using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAppAngular.Services
{
    public interface ICityService
    {
        public IList<CityDto> GetCities();
        public CityDto GetCity(int cityId);
    }
}
