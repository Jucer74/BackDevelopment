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
         var reportedCardList = await _reportedCardDataAccess.GetAllReportedCards();

         if(reportedCardList == null || reportedCardList.Count == 0)
         {
            throw new NotImplementedException();
         }

         return reportedCardList;
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

         if(reportedCard == null)
         {
            throw new NotImplementedException();
         }

         return reportedCard;
      }

      public async Task<string> PutCreditCardReactivated(string creditCardNumber)
      {
         var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);

         if(reportedCard == null)
         {
            throw new NotImplementedException();
         }

         return await _reportedCardDataAccess.PutCreditCardReactivated(creditCardNumber);

      }

      public async Task<string> GetCheckCreditCardDigit(string creditCardNumber)
      {
         var Result;

         if (!IsNumber(creditCardNumber))
         {
            Result = "Bad Request";
            return Result;
         }

         if(CreditCardValidator.IsValid(creditCardNumber))
         {
            Result = "Credit Card is Valid";
         }
         else
         {
            Result = "Credit Card is NOT Valid";
         }

         return Result;
      }

      private static bool IsNumber(string creditCardNumber)
      {
		  if(string.IsNullOrEmpty(creditCardNumber))
			  return false;
		  
         return new Regex(NUMBER_REGEX).IsMatch(creditCardNumber);
      }

      public ReportedCard NotFoundResult()
      {
         return new ReportedCard(-1, "Not Found","Not Found","Not Found","Not Found","Not Found");
      }
   }
}
