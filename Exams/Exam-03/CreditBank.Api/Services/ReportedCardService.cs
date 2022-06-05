using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CreditBank.Api.Controllers;


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
            return await _reportedCardDataAccess.GetAllReportedCards();
        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            var reportedCardsList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

            if (reportedCardsList.IsNullOrEmpty())
            {
                throw new NotImplementedException();
            }

            return reportedCardsList;
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
