using CreditBank.Api.DataAccess;
using CreditBank.Api.Exceptions;
using CreditBank.Api.Models;
using CreditBank.Api.Utilities;
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
         var reportedCardsList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

         if (reportedCardsList.IsNullOrEmpty())
         {
            throw new NotFoundException($"{issuingNetworkName} Not Found");
         }

         return reportedCardsList;
      }

      public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
      {
         if(!CreditCardValidator.IsNumericCard(creditCardNumber))
         {
            throw new BadRequestException($"{creditCardNumber} is NOT Numeric");
         }

         var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);

         if (reportedCard == null)
         {
            throw new NotFoundException($"{creditCardNumber} Not Found");
         }

         return reportedCard;
      }

      public async Task<ReportedCard> PutCreditCardReactivated(string creditCardNumber)
      {
         if (!CreditCardValidator.IsNumericCard(creditCardNumber))
         {
            throw new BadRequestException($"{creditCardNumber} is NOT Numeric");
         }

         var reportedCard = await _reportedCardDataAccess.PutCreditCardReactivated(creditCardNumber);

         if (reportedCard == null)
         {
            throw new NotFoundException($"{creditCardNumber} Not Found");
         }

         return reportedCard;
      }
   }
}