
using CreditBankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditBankAPI.Controllers
{
    [Route("api/v1.0/ReportedCards")]
    [ApiController]
    public class ReportedCardsController:ControllerBase
	{
        private readonly ReportedCardService reportedCardService;

        public ReportedCardsController(ReportedCardService reportedCardService) {
            this.reportedCardService = reportedCardService;
        }

        //api/v1.0/ReportedCards
        [HttpGet]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
        {
             return Ok(await reportedCardService.GetAllReportedCards());
        }

        //api/v1.0/ReportedCards/IssuingNetwork/{issuingNetworkName}
        [HttpGet("IssuingNetwork/{issuingNetworkName}")]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName( String issuingNetworkName)
        {
            return Ok(await reportedCardService.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
        }

        //api/v1.0/ReportedCards/{creditCardNumber}
        [HttpGet("{creditCardNumber}")]
        public async Task<ActionResult<ReportedCard>> GetReportedCard(String creditCardNumber)
        {
            return Ok(await reportedCardService.GetReportedCard(creditCardNumber));
        }

        //api/v1.0/ReportedCards/{creditCardNumber}
        [HttpPut("{creditCardNumber}")]
        public async Task<ActionResult<ReportedCard>> PutCreditCardReactivated(String creditCardNumber)
        {
            return Ok(await reportedCardService.PutCreditCardReactivated(creditCardNumber));
        }
    }
}

