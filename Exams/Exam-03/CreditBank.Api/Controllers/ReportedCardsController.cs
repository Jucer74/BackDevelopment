using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CreditBank.Api.Models;
using CreditBank.Api.Services;
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
      private readonly ReportedCardService _reportedCardSevice;
      public ReportedCardsController(ReportedCardService reportedCardService, ILogger<ReportedCardsController> logger)
         {
            _logger = logger;
            _reportedCardSevice = reportedCardService;
         }

      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
         {
            return Ok(await _reportedCardSevice.GetAllReportedCards());
         }
    }
}
