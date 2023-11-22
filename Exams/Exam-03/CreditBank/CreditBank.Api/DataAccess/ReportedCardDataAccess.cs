using CreditBank.Api.Models;

namespace CreditBank.Api.DataAccess;

public class ReportedCardDataAccess
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