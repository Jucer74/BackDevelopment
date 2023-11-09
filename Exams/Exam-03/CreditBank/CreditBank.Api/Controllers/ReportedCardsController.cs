using CreditBank.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditBank.Api.Controllers;

[Route("api/v1.0/[controller]")]
[ApiController]
public class ReportedCardsController : ControllerBase
{
    // GET: api/v1.0/<ReportedCardsController>
    [HttpGet]
    public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
    {
        throw new NotImplementedException();
    }

    // GET: api/v1.0/<ReportedCardsController>/IssuingNetwork/{issuingNetworkName}
    [HttpGet("IssuingNetwork/{issuingNetworkName}")]
    public async Task<ActionResult<IEnumerable<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
    {
        throw new NotImplementedException();
    }

    // GET api/<ReportedCardsController>/{creditCardNumber}
    [HttpGet("{creditCardNumber}")]
    public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
    {
        throw new NotImplementedException();
    }

    // PUT api/v1.0/<ReportedCardsController>/{creditCardNumber}
    [HttpPut("{creditCardNumber}")]
    public async Task<ActionResult<ReportedCard>> PutCreditCardReactivated(string creditCardNumber)
    {
        throw new NotImplementedException();
    }
}