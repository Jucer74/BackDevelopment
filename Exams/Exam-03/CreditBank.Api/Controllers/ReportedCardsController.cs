using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using System.Collections.Generic;

namespace CreditBank.Api.Controllers
{
   [ApiController]
   [Route("api/v1.0/[controller]")]
   public class ReportedCardsController : ControllerBase
   {
      private readonly ILogger<ReportedCardsController> _logger;
      private readonly ReportedCardService _reportedCardService;

      public ReportedCardsController(ReportedCardService reportedCardService, ILogger<ReportedCardsController> logger)
      {
         _logger = logger;
         _reportedCardService = reportedCardService;
      }

      // GET: api/v1.0/<ReportedCardsController>
      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         return Ok(await _reportedCardService.GetAllReportedCards());
      }

      // GET: api/v1.0/ReportedCards/IssuingNetwork/{issuingNetworkName}
      [HttpGet("IssuingNetwork/{issuingNetworkName}")]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         return Ok(await _reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
      }

      // GET: api/v1.0/ReportedCards/creditCardNumber
      [HttpGet("{creditCardNumber}")]
      public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
      {
         try
         {
            return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
         }
         catch (NotImplementedException)
         {
            
            return NotFound(_reportedCardService.NotFoundResult());
         }
      }

      // Put: api/v1.0/ReportedCards/{creditCardNumber}
      [HttpPut("{creditCardNumber}")]
      public async Task<ActionResult<string>> PutCreditCardReactivated(string creditCardNumber)
      {
         try
         {
            return Ok(await _reportedCardService.PutCreditCardReactivated(creditCardNumber));
         }
         catch (NotImplementedException)
         {
            return NotFound("Not Found");
         }
      }

      //Post: api/v1.0/ReportedCards/CheckCreditCardDigit/{creditCardNumber}
      [HttpGet("CheckCreditCardDigit/{creditCardNumber}")]
      public async Task<ActionResult<string>> GetCheckCreditCardDigit(string creditCardNumber)
      {
         try
         {
            return Ok(await _reportedCardService.GetCheckCreditCardDigit(creditCardNumber));
         }
         catch (NotImplementedException)
         {
            return NotFound("Not Implemented Exception");
         }
      }

      
      
   }
}
