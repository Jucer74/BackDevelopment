using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
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
            return await _dbContext.ReportedCards.ToListAsync();
        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            return await _dbContext.ReportedCards.Where(item => item.IssuingNetwork == issuingNetworkName).ToListAsync();
        }

        public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
        {
            return await _dbContext.ReportedCards.Where(item => item.CreditCardNumber == creditCardNumber).FirstOrDefaultAsync();
        }

        public async Task<string> PutCreditCardReactivated(string creditCardNumber)
        {
            var reportedCard = await GetReportedCard(creditCardNumber);
            reportedCard.StatusCard = "Recovered";
            _dbContext.SaveChanges();
            
            return "Credit Card Recovered";

        }
   }
}
