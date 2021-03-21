using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAppAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherMapController : ControllerBase
    {

        [HttpGet]
        public WeatherForecast Get()
        {
            return new WeatherForecast{
                Summary = "test",
                TemperatureC = 20,
                Date =new DateTime()
            };
        }
    }
}
