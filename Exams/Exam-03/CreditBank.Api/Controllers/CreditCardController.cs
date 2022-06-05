using System;
using System.Net;
using CreditBank.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetBank.Api.Services;

namespace NetBank.Api.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly CreditCardService _creditCardService;
        public CreditCardController(CreditCardService creditCardService, ILogger<CreditCardController> logger)
        {
            _logger = logger;
            _creditCardService = creditCardService;
        }

        [HttpGet("CheckDigitStatus/{creditCardNumber}")]
        public ActionResult<string> GetCreditCardCheckDigitStatus(string creditCardNumber)
        {
            string messageIsValid = "";
            try
            {
                return messageIsValid = _creditCardService.GetCreditCardCheckDigitStatus(creditCardNumber);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
