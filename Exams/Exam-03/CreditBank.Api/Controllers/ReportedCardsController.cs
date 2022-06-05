using CreditBank.Api.Models;
using CreditBank.Api.Services;
using CreditBank.Api.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditBank.Api.Controllers
{
   [Route("api/v1.0/[controller]")]
   [ApiController]
   public class ReportedCardsController : ControllerBase
   {
      private readonly ReportedCardService _reportedCardService;

      public ReportedCardsController(ReportedCardService reportedCardService)
      {
         _reportedCardService = reportedCardService;
      }

      // GET: api/v1.0/<ReportedCardsController>
      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         return Ok(await _reportedCardService.GetAllReportedCards());
      }

      // GET: api/v1.0/<ReportedCardsController>/IssuingNetwork/{issuingNetworkName}
      [HttpGet("IssuingNetwork/{issuingNetworkName}")]
      public async Task<ActionResult<IEnumerable<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         return Ok(await _reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
      }

      // GET api/<ReportedCardsController>/{creditCardNumber}
      [HttpGet("{creditCardNumber}")]
      public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
      {
         return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
      }

      // POST api/v1.0/<ReportedCardsController>/{creditCardNumber}
      [HttpPost("{creditCardNumber}")]
      public ActionResult<string> PostCheckCreditCardDigit(string creditCardNumber)
      {
         if (CreditCardValidator.IsValid(creditCardNumber))
         {
            return Ok("Credit Card Is Valid");
         }

         return Ok("Credit Card Is NOT Valid");
      }

      // PUT api/v1.0/<ReportedCardsController>/{creditCardNumber}
      [HttpPut("{creditCardNumber}")]
      public async Task<ActionResult<string>> PutCreditCardReactivated(string creditCardNumber)
      {
         return Ok(await _reportedCardService.PutCreditCardReactivated(creditCardNumber));
      }
   }
}