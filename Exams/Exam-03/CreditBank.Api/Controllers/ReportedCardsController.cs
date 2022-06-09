using System; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditBank.Api.Models;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using CreditBank.Api.Services;
 using Microsoft.Extensions.Logging;


using CreditBank.Api.Utilities;
using CreditBank.Api.Exceptions;

namespace CreditBank.Api.Controllers
{
   [Route("api/v1.0/[controller]")]
   [ApiController]
   public class ReportedCardsController : ControllerBase
   {

      private readonly ReportedCardService _reportedCardService;

      private readonly ILogger<ReportedCardsController> _logger;
      
      public ReportedCardsController(ReportedCardService reportedCardService, ILogger<ReportedCardsController> logger)
        {
            _logger = logger;
            _reportedCardService = reportedCardService;
        }

      // GET: api/v1.0/<ReportedCardsController>/ReportedCard
      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
           try
            {
                return Ok(await _reportedCardService.GetAllReportedCards());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
      }

      // GET: api/v1.0/<ReportedCardsController>/IssuingNetwork/{issuingNetworkName}
      [HttpGet("IssuingNetwork/{issuingNetworkName}")]
      public async Task<ActionResult<IEnumerable<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         try
         {
            return Ok( await _reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
         }
         catch (NotFoundException ex)
         {
            return NotFound(ex.Message);
         }
         catch (Exception ex)
         {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
         }
      }
 
      [HttpGet("{creditCardNumber}")]
      public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
      {
         try
         {
         
           if (!CreditCardValidator.IsNumericCard(creditCardNumber))
            {
               return BadRequest($"{creditCardNumber} is NOT Numeric");
            }

           if (CreditCardValidator.IsValid(creditCardNumber))
            {
               return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
            }

             return Ok($"{creditCardNumber} is NOT Valid");
         }
         catch (NotFoundException ex)
         {
            return NotFound(ex.Message);
         }
         catch (Exception ex)
         {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
         }
      }

      [HttpPut("{creditCardNumber}")]
      public async Task<ActionResult<string>> PutCreditCardReactivated(string creditCardNumber)
         {
         try
         {

            if (!CreditCardValidator.IsNumericCard(creditCardNumber))
            {
               return BadRequest($"{creditCardNumber} is NOT Numeric");
            }

           if (CreditCardValidator.IsValid(creditCardNumber))
            {
               return Ok(await _reportedCardService.PutCreditCardReactivated(creditCardNumber));
            }

             return Ok($"{creditCardNumber} is NOT Valid");
 
         }
         catch (NotFoundException ex)
         {
            return NotFound(ex.Message);
         }
         catch (Exception ex)
         {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
         }
      }
}

}