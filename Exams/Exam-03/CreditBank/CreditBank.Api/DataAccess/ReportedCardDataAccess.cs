using CreditBank.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return await _dbContext.ReportedCards
                .Where(card => card.IssuingNetwork == issuingNetworkName)
                .ToListAsync();
        }

        public async Task<ReportedCard> GetReportedCardById(int id)
        {
            return await _dbContext.ReportedCards.FindAsync(id);
        }

        public async Task AddReportedCard(ReportedCard reportedCard)
        {
            _dbContext.ReportedCards.Add(reportedCard);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReportedCard(ReportedCard reportedCard)
        {
            _dbContext.ReportedCards.Update(reportedCard);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteReportedCard(int id)
        {
            var reportedCard = await _dbContext.ReportedCards.FindAsync(id);
            if (reportedCard != null)
            {
                _dbContext.ReportedCards.Remove(reportedCard);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
