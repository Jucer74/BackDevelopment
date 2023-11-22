using CreditBank.Api.Models;
using CreditBank.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _reportedCardService = reportedCardService ?? throw new ArgumentNullException(nameof(reportedCardService));
        }

        [HttpGet]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
        {
            try
            {
                return Ok(await _reportedCardService.GetAllReportedCards());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GetAllReportedCards: " + ex.Message);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("IssuingNetwork/{issuingNetworkName}")]
        public async Task<ActionResult<IEnumerable<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            try
            {
                var reportedUsingNotName = await _reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);
                if (!reportedUsingNotName.Any())
                {
                    return NotFound();
                }
                return Ok(reportedUsingNotName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en GetAllReportedCardsByIssuingNetworkName: " + ex.Message);
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // Otros métodos según sea necesario
    }
}
