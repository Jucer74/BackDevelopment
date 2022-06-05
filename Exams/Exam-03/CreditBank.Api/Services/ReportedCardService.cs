using System;
using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;
using System.Threading.Tasks;
using System.Collections.Generic;

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
         var reportedCardList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

         if(reportedCardList == null || reportedCardList.Count == 0)
         {
            throw new NotImplementedException();
         }

         return reportedCardList;
      }

      public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
      {
         var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);

         return reportedCard;
      }

      public async Task<string> PutCreditCardReactivated(string creditCardNumber)
      {
         throw  new NotImplementedException();
      }
   }
}
