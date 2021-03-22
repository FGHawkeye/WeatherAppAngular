using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dto
{
    public class HistoricalWeatherDto
    {
        public virtual CountryDto Country { get; set; }
        public virtual CityDto City { get; set; }
        public double Temperature { get; set; }
        public double ThermalSensation { get; set; }
    }
}
