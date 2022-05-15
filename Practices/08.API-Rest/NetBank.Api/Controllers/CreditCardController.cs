using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public CreditCardController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
