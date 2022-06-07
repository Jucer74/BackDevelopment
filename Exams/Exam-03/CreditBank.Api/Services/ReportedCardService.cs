using System;
using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CreditBank.Api.Exceptions;
using CreditBank.Api.Utilities;

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
            var reportedCardList = await _reportedCardDataAccess.GetAllReportedCards();

            return reportedCardList;
        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            var reportedCardList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

            if (reportedCardList == null || reportedCardList.Count == 0)
            {
                throw new NotFoundException($"{issuingNetworkName} Not Found");
            }

            return reportedCardList;
        }
        
        public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
        {
            var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);
            if (reportedCard == null)
            {
                throw new NotFoundException($"{creditCardNumber} is not found");
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
