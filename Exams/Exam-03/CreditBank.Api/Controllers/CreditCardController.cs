<<<<<<< HEAD
﻿using CreditBank.Api.Utilities;
=======
using CreditBank.Api.Utilities;
>>>>>>> a0e0e556083d1804f7af31e82f39414ad4263ed2
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

                return Ok($"Credit Card [{creditCardNumber}] is NOT Valid");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a0e0e556083d1804f7af31e82f39414ad4263ed2
