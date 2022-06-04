using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using CreditBank.Api.Define;

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

      /* // PUT: api/v1.0/<ReportedCardsController>
      [HttpPut]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         return Ok(await _reportedCardService.GetAllReportedCards());
      }

      // POST: api/v1.0/<ReportedCardsController>
      [HttpGPost]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         return Ok(await _reportedCardService.GetAllReportedCards());
      }

      // GET: api/v1.0/<ReportedCardsController>
      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         return Ok(await _reportedCardService.GetAllReportedCards());
      }

      // GET: api/v1.0/<ReportedCardsController>
      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         return Ok(await _reportedCardService.GetAllReportedCards());
      } */
   }
}
