using CreditBank.Api.Exceptions;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
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
         try
         {
            return Ok(await _reportedCardService.GetAllReportedCards());
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

      // GET api/<ReportedCardsController>/{creditCardNumber}
      [HttpGet("{creditCardNumber}")]
      public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
      {
         try
         {
            return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
         }
         catch (BadRequestException ex)
         {
            return BadRequest(ex.Message);
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

      // PUT api/v1.0/<ReportedCardsController>/{creditCardNumber}
      [HttpPut("{creditCardNumber}")]
      public async Task<ActionResult<ReportedCard>> PutCreditCardReactivated(string creditCardNumber)
      {
         try
         {
            return Ok(await _reportedCardService.PutCreditCardReactivated(creditCardNumber));
         }
         catch (BadRequestException ex)
         {
            return BadRequest(ex.Message);
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