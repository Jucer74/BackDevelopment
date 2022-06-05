using CreditBank.Api.DataAccess;
using CreditBank.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
         return await _reportedCardDataAccess.GetAllReportedCards();
      }

      public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         return await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);
      }

      public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
      {
         return await _reportedCardDataAccess.GetReportedCard(creditCardNumber);
      }

      public async Task<string> PutCreditCardReactivated(string creditCardNumber)
      {
         return await _reportedCardDataAccess.PutCreditCardReactivated(creditCardNumber);
      }
   }
}
