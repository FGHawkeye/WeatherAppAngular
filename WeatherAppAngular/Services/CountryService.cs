using AutoMapper;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAppAngular.Data;

namespace WeatherAppAngular.Services
{
    public class CountryService : ICountryService
    {
        private readonly WeatherContext _context;
        private readonly IMapper _mapper;
        public CountryService(WeatherContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CountryDto GetCountry()
        {
            var country = _context.Country.FirstOrDefault();
            return _mapper.Map<CountryDto>(country);
        }
    }
}
