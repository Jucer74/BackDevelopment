using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CreditBank.Api.Exceptions;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet("GetAllReportedCards")]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
        {
            _logger.LogInformation("Consulta todas las tarjetas reportadas");
            try
            {
                return Ok(await _reportedCardService.GetAllReportedCards());
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet("IssuingNetwork/{issuingNetworkName}")]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            _logger.LogInformation("Consulta las tarjetas por entidad emisora");
            try
            {
                return Ok(await _reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
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

        [HttpGet("GetReportedCard/{creditCardNumber}")]
        public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
        {
            _logger.LogInformation("Consulta la tarjeta por numero");
            try
            {
                return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
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

        [HttpPut("CreditCardReactivated/{creditCardNumber}")]
        public async Task<ActionResult> PutCreditCardReactivated(string creditCardNumber)
        {
            _logger.LogInformation("Reactiva la tarjeta");
            try
            {
                return Ok(await _reportedCardService.PutCreditCardReactivated(creditCardNumber));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
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
