using System.Collections.Generic;
using System.Threading.Tasks;
using CreditBank.Api.DataAccess;
using CreditBank.Api.Exceptions;
using CreditBank.Api.Models;
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
            var listReportedCards = await _reportedCardDataAccess.GetAllReportedCards();
            if (listReportedCards.Count == 0)
            {
                throw new NotFoundException("List ReportedCards is Empty");
            }
            return listReportedCards;
        }
       

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            if (!CreditCardValidator.IsAlphabeticIssuingNetworkName(issuingNetworkName))
            {
                throw new BadRequestException("Issuing Network Name Accept Only Letters");
            }
                var listReportedCardsIssuingNetworkName = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);
            if (listReportedCardsIssuingNetworkName.Count == 0)
            {
                throw new NotFoundException($"{issuingNetworkName} Not Found");
            }

            return listReportedCardsIssuingNetworkName;
        }

        public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
        {
            if (!CreditCardValidator.IsNumericCard(creditCardNumber))
            {
                throw new BadRequestException("Credit Card Number Is NOT Numeric");
            }
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
