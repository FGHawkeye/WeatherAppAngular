using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class HistoricalWeatherDto
    {
        public CountryDto Country { get; set; }
        public CityDto City { get; set; }
        public double Temperature { get; set; }
        public double ThermalSensation { get; set; }
    }
}
