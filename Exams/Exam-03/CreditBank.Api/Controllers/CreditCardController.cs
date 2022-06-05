using CreditBank.Api.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace CreditBank.Api.Controllers
{
   [Route("api/v1.0/[controller]")]
   [ApiController]
   public class CreditCardController : ControllerBase
   {
      // GET api/v1.0/CreditCard/ValidationStatus/{creditCardNumber}
      [HttpGet("ValidationStatus/{creditCardNumber}")]
      public ActionResult<string> GEtCreditCardValidationStatus(string creditCardNumber)
      {
         try
         {
            if (CreditCardValidator.IsValid(creditCardNumber))
            {
               return Ok("Credit Card Is Valid");
            }

            return Ok("Credit Card Is NOT Valid");
         }
         catch (Exception ex)
         {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
         }
      }
   }
}
