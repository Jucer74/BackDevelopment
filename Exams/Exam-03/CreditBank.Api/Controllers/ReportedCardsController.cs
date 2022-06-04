using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditBank.Api.Models;
using CreditBank.Api.Services;

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
   }
}
