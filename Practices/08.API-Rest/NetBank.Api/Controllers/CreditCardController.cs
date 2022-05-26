using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;

        public CreditCardController(ILogger<CreditCardController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{creditcardNumber}")]
        public IActionResult Get(string creditcardNumber)
        {
           return Ok();
        }
    }
}
