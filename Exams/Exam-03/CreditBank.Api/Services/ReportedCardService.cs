using System;
using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;
using CreditBank.Api.Utilities;
using CreditBank.Api.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CreditBank.Api.Services
{
    public class ReportedCardService
    {
        private readonly ReportedCardDataAccess _reportedCardDataAccess;

        public ReportedCardService(ReportedCardDataAccess reportedCardDataAccess) /*Ojo pa*/
        {
            _reportedCardDataAccess = reportedCardDataAccess;
        }

        public async Task<IList<ReportedCard>> GetAllReportedCards()
        {
            var listReportedCards = await _reportedCardDataAccess.GetAllReportedCards();

            return listReportedCards;
        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            var listReportedCards = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

            if (listReportedCards == null || listReportedCards.Count == 0)
            {
                throw new NotFoundException($"{issuingNetworkName} Not Found");
            }

            return listReportedCards;
        }

        public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
        {
            var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);
            if (reportedCard == null)
            {
                throw new NotFoundException("Credit Card Not Found");
            }
            return reportedCard;
        }

        public async Task<string> PutCreditCardReactivated(string creditCardNumber)
        {
            await GetReportedCard(creditCardNumber);
           var messageUpdateCreditCard = await _reportedCardDataAccess.PutCreditCardReactivated(creditCardNumber);
           return messageUpdateCreditCard;
        }
    }
}
