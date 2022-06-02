using System.Collections.Generic;
using System.Threading.Tasks;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditBank.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ReportedCardsController : ControllerBase
   {
        private readonly ReportedCardService _reportedCardService;
        // GET: api/v1.0/<ReportedCardsController>
        [HttpGet]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
        {
            return Ok(_reportedCardService.GetAllReportedCards());
        }
    }
}
