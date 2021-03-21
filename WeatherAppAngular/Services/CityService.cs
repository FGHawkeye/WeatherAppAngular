using AutoMapper;
using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAppAngular.Data;

namespace WeatherAppAngular.Services
{
    public class CityService : ICityService
    {
        private readonly WeatherContext _context;
        private readonly IMapper _mapper;
        public CityService(WeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<CityDto> GetCities()
        {
            var cities = _context.City.ToList();
            return _mapper.Map<IList<CityDto>>(cities);
        }

        public CityDto GetCity(int cityId)
        {
            var city = _context.City.FirstOrDefault(x => x.Id == cityId);
            return _mapper.Map<CityDto>(city);
        }
    }
}
