using System;
using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;
using System.Threading.Tasks;
using System.Collections.Generic;
using CreditBank.Api.Exceptions;
using System.Linq;
 

namespace CreditBank.Api.Services
{
    public class ReportedCardService
    {
    private readonly ReportedCardDataAccess _reportedCardDataAccess;

    public ReportedCardService(ReportedCardDataAccess reportedCardDataAccess)
    {
        _reportedCardDataAccess = reportedCardDataAccess;
    }

    public async Task<IList<ReportedCard>> GetAllReportedCards()
    {
        throw   new NotImplementedException();
    }

    public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
    {
        var reportedCardsList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

        string reportedCards = Convert.ToString(reportedCardsList);
        
        if (string.IsNullOrEmpty(reportedCards))
        {
            throw new NotFoundException($"{issuingNetworkName} Not Found");
        }

        return reportedCardsList;

    }

    public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
    {
        throw  new NotImplementedException();
    }

    public async Task<string> PutCreditCardReactivated(string creditCardNumber)
    {
        throw  new NotImplementedException();
    }
    }

}