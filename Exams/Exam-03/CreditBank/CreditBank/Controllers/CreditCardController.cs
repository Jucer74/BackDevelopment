
using CreditBankAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace CreditBank.Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        // GET api/v1.0/CreditCard/CheckDigitStatus/{creditCardNumber}
        [HttpGet("CheckDigitStatus/{creditCardNumber}")]
        public ActionResult<string> GetCreditCardCheckDigitStatus(string creditCardNumber)
        {
            try
            {
                if (!CreditCardValidator.IsNumericCard(creditCardNumber))
                {
                    return BadRequest($"Credit Card [{creditCardNumber}] is NOT Numeric");
                }

                if (CreditCardValidator.IsValid(creditCardNumber))
                {
                    return Ok($"Credit Card [{creditCardNumber}] is Valid");
                }
                return Ok($"Credit Card [{creditCardNumber}] is Valid");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}