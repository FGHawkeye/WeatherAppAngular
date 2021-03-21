using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class HistoricalWeather
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public string Temperature { get; set; }
        public string ThermalSensation { get; set; }
    }
}
