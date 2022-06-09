using CreditBank.Api.Models;
using CreditBank.Api.DataAccess;
using System.Security.AccessControl;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace CreditBank.Api.DataAccess
{
   public class ReportedCardDataAccess
{
   // lógica de Acceso  a los datos

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

        public async Task<ReportedCard> PutCreditCardReactivated(string creditCardNumber)
        {
            var reportedCard = await GetReportedCard(creditCardNumber);
            reportedCard.StatusCard = "Recovered";
            _dbContext.SaveChanges();

            return reportedCard;
        }
    }
}

