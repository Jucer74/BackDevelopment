using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using CreditBank.Api.Models;
using CreditBank.Api.Services;

using System.Collections.Generic;

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

        // GET: api/v1.0/<ReportedCardsController>
        [HttpGet]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
        {
            return Ok(await _reportedCardService.GetAllReportedCards());
        }


        // GET: api/v1.0/<ReportedCardsByIssuingNetworkName>
        [HttpGet("issuingNetworkName")]
        public async Task<ActionResult<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            return Ok(await _reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
        }

        // GET: api/v1.0/<ReportedCard>
        [HttpGet("{creditCardNumber}")]
        public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
        {
            return Ok(await _reportedCardService.GetReportedCard(creditCardNumber));
        }

        // PUT: api/TodoItems/5
        [HttpPut("{creditCardNumber}")]
        public async Task<ActionResult<string>> PutCreditCardReactivated(string creditCardNumber)
        {
            return Ok(await _reportedCardService.PutCreditCardReactivated(creditCardNumber));
        }

       /*  [HttpGet("{creditCardNumber}")]
        public async Task<ActionResult<ReportedCard>> GetCreditCardValidationStatus(string creditCardNumber)
        {
            return Ok(await _reportedCardService.CreditCardValidationStatus(creditCardNumber));
        } */

    }
}