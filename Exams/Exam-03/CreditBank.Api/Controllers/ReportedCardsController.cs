using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using System.Collections.Generic;
using CreditBank.Api.Exceptions;
using System.Text.RegularExpressions;
using System.Net;

namespace CreditBank.Api.Controllers
{
   [ApiController]
   [Route("api/v1.0/[controller]")]
   public class ReportedCardsController : ControllerBase
   {
      private readonly ILogger<ReportedCardsController> _logger;
      private readonly ReportedCardService _reportedCardService;
      private const string NUMBER_REGEX = "^[0-9]*$";

      public ReportedCardsController(ReportedCardService reportedCardService, ILogger<ReportedCardsController> logger)
      {
         _logger = logger;
         _reportedCardService = reportedCardService;
      }

      // GET: api/v1.0/<ReportedCardsController>
      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         try
         {
            return Ok(await _reportedCardService.GetAllReportedCards());
         }
         catch (Exception ex)
         {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
         }
      }

      // GET: api/v1.0/ReportedCards/IssuingNetwork/{issuingNetworkName}
      [HttpGet("IssuingNetwork/{issuingNetworkName}")]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         try
         {
            return Ok(await _reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
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

      // GET: api/v1.0/ReportedCards/creditCardNumber
      [HttpGet("{creditCardNumber}")]
      public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
      {
         if((string.IsNullOrEmpty(creditCardNumber)) || !(new Regex(NUMBER_REGEX).IsMatch(creditCardNumber)))
         {
            return BadRequest($"{creditCardNumber} Is NOT Numeric");
         }
         	
         try
         {
            return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
         }
         catch (NotFoundException)
         {
            return NotFound(_reportedCardService.NotFoundResult());
         }
         catch (Exception ex)
         {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
         }
      }

      // Put: api/v1.0/ReportedCards/{creditCardNumber}
      [HttpPut("{creditCardNumber}")]
      public async Task<ActionResult<string>> PutCreditCardReactivated(string creditCardNumber)
      {
         if((string.IsNullOrEmpty(creditCardNumber)) || !(new Regex(NUMBER_REGEX).IsMatch(creditCardNumber)))
         {
            return BadRequest($"{creditCardNumber} Is NOT Numeric");
         }

         try
         {
            return Ok(await _reportedCardService.PutCreditCardReactivated(creditCardNumber));
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
