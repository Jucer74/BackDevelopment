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

   // OK. mejorar el badRequest y el NotFound
    public async Task<IList<ReportedCard>> GetAllReportedCards()
    {
        var allReportedCardsList = await _reportedCardDataAccess.GetAllReportedCards();

        string reportedCards = Convert.ToString(allReportedCardsList);
        
        if (string.IsNullOrEmpty(reportedCards))
        {
            throw new NotFoundException("Not Found");
        }

        return allReportedCardsList;
    }


   // OK. mejorar el badRequest y el NotFound
    public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
    {
        var reportedCardsList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);
       
        if (reportedCardsList == null || reportedCardsList.Count == 0)
        {
            throw new NotFoundException($"{issuingNetworkName} Not Found");
        }

        return reportedCardsList;

    }

    public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
    {
        var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);

        string converReportedCard = Convert.ToString(reportedCard);
        
        if (string.IsNullOrEmpty(converReportedCard))
        {
            throw new NotFoundException($"{creditCardNumber} Not Found");
        }

        return reportedCard;
    }

    public async Task<ReportedCard> PutCreditCardReactivated(string creditCardNumber)
    {
        var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);

        string converReportedCard = Convert.ToString(reportedCard);
        
        if (string.IsNullOrEmpty(converReportedCard))
        {
            throw new NotFoundException($"{creditCardNumber} Not Found");
        }

        var messageUpdateCard = await _reportedCardDataAccess.PutCreditCardReactivated(creditCardNumber);
 

        return await _reportedCardDataAccess.GetReportedCard(creditCardNumber);
    }
    }

}
