using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;
using CreditBank.Api.Utilities;
using CreditBank.Api.Exceptions;


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
         var ReportedCards = await _reportedCardDataAccess.GetAllReportedCards();

         return ReportedCards;
      }

      public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         var ReportedCards = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

         if (ReportedCards == null || ReportedCards.Count == 0)
         {
               throw new NotFoundException($"{issuingNetworkName} Not Found");
         }

         return ReportedCards;
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
