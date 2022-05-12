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
    public class CreditCarController : ControllerBase
    {
        

        private readonly ILogger<CreditCarController> _logger;

        public CreditCarController(ILogger<CreditCarController> logger)
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
