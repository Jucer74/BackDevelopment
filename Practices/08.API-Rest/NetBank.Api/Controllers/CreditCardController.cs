using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetBank.Api.Define;
using NetBank.Api.Models;
using NetBank.Api.Services;

namespace NetBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
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
