using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditBank.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditBank.Api.DataAccess
{
   public class ReportedCardDataAccess
   {
        private readonly AppDbContext _dbContext;

        public ReportedCardDataAccess(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IList<ReportedCard>> GetAllReportedCards()
        {
            var findAllReportedCards = _dbContext.ReportedCards.ToList();
            List<ReportedCard> listReportedCards = await Task.Run(() => findAllReportedCards);
            return listReportedCards;
        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            var findAllByIssuingNetwork = _dbContext.ReportedCards.Where(columnIssuingNetwork => columnIssuingNetwork.IssuingNetwork == issuingNetworkName).ToList();
            List<ReportedCard> listReportedCardsIssuingNetwork = await Task.Run(() => findAllByIssuingNetwork);
            return listReportedCardsIssuingNetwork;
        }

        public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
        {
            ReportedCard reportedCard = await _dbContext.ReportedCards.FirstOrDefaultAsync(columnCreditCardNumber => columnCreditCardNumber.CreditCardNumber == creditCardNumber);
            return reportedCard;
        }

        public async Task<ReportedCard> PutCreditCardReactivated(string creditCardNumber)
        {
            var reportedCard = await GetReportedCard(creditCardNumber);
            reportedCard.StatusCard = "Recovered";
            reportedCard.LastUpdatedDate = DateTime.Now;
            _dbContext.SaveChanges();
            return reportedCard;
        }
    }
}
