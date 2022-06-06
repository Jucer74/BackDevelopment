using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;

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
               throw new NotImplementedException();
            }

         public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
            {
               throw new NotImplementedException();
            }

         public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
            {
               throw new NotImplementedException();
            }

        public async Task<string> PutCreditCardReactivated(string creditCardNumber)
            {
               throw new NotImplementedException();
            }
      }
}
