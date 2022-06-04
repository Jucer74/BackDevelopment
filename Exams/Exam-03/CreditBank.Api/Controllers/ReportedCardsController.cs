using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreditBank.Api.Models;
using CreditBank.Api.Services;

namespace CreditBank.Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]

    
    public class ReportedCardsController : ControllerBase
    {
        private readonly ILogger<ReportedCardsController> _logger;
        private readonly ReportedCardService _reportedCardSevice;
        public ReportedCardsController(ReportedCardService _reportedCardSevice ,ILogger<ReportedCardsController> logger)
        {
           _logger = logger;
           _reportedCardSevice = reportedCardService;
        }

        // GET: api/v1.0/<ReportedCardsController>
        [HttpGet]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
        {
            return Ok(await _reportedCardService.GetAllReportedCards());
        }


         // GET: api/v1.0/<ReportedCardsByIssuingNetworkName>
       /*   [HttpGet]
        public async Task<ActionResult<IList<ReportedCardsByIssuingNetworkName>>> GetAllReportedCardsByIssuingNetworkName()
        {
            return Ok(await _reportedCardService. GetAllReportedCardsByIssuingNetworkName());
        } */


    }
}