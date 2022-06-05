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
         try
         {
            return await _reportedCardDataAccess.GetAllReportedCards();
         }
         catch (Exception ex)
         {
            throw new InternalServerErrorException("Internal Server Error", ex);
         }
      }

      public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         try
         {
            var reportedCardsList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

            if (reportedCardsList.IsNullOrEmpty())
            {
               throw new NotFoundException($"{issuingNetworkName} Not Found");
            }

            return reportedCardsList;
         }
         catch (Exception ex)
         {
            throw new InternalServerErrorException("Internal Server Error", ex);
         }
      }

      public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
      {
         try
         {
            return await _reportedCardDataAccess.GetReportedCard(creditCardNumber);
         }
         catch (Exception ex)
         {
            throw new InternalServerErrorException("Internal Server Error", ex);
         }
      }

      public async Task<string> PutCreditCardReactivated(string creditCardNumber)
      {
         try
         {
            return await _reportedCardDataAccess.PutCreditCardReactivated(creditCardNumber);
         }
         catch (Exception ex)
         {
            throw new InternalServerErrorException("Internal Server Error", ex);
         }
      }
   }
}