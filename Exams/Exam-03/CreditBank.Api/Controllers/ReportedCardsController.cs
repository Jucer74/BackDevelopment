using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using CreditBank.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CreditBank.Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]

    public class ReportedCardsController : ControllerBase
    {
        private readonly ILogger<ReportedCardsController> _logger;
        private readonly ReportedCardService _reportedCardService;
        public ReportedCardsController(ReportedCardService reportedCardService, ILogger<ReportedCardsController> logger)
        {
            _logger = logger;
            _reportedCardService = reportedCardService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
        {
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

        [HttpGet("{creditCardNumber}")]
        public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
        {
            return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
        }

        [HttpPut("{creditCardNumber}")]
        public async Task<ActionResult<string>> PutCreditCardReactivated(string creditCardNumber)
        {
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