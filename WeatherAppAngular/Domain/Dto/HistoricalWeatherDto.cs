using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    class HistoricalWeatherDto
    {
        public CountryDto Country { get; set; }
        public CityDto City { get; set; }
        public string Temperature { get; set; }
        public string ThermalSensation { get; set; }
    }
}
