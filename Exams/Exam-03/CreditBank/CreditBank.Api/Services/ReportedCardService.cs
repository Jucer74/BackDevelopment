using CreditBank.Api.Models;

namespace CreditBank.Api.Services;

public class ReportedCardService
{
    public async Task<IList<ReportedCard>> GetAllReportedCards()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
    {
        throw new NotImplementedException();
    }

    public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
    {
        throw new NotImplementedException();
    }

    public async Task<ReportedCard> PutCreditCardReactivated(string creditCardNumber)
    {
        throw new NotImplementedException();
    }
}