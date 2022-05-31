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
        private readonly ILogger<CreditCardController> _logger;
        private readonly CreditCardService _creditCardService;
        public CreditCardController(CreditCardService creditCardService, ILogger<CreditCardController> logger)
        {
            _logger = logger;
            _creditCardService = creditCardService;
        }

        [HttpGet("{creditcardNumber}")]
        public IActionResult Get(string creditcardNumber)
        {
            var validateResult = _creditCardService.Validate(creditcardNumber);
            var result = _creditCardService.Result;

            switch (validateResult)
            {
                case ValidationResultType.Ok:
                    return Ok(result);     
                case ValidationResultType.BadRequest:
                    return BadRequest(result);     
                case ValidationResultType.NotFound:
                    return NotFound(result);     
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, new CreditCardResult("Internal Server Error", false));
            }
        }
    }
}
