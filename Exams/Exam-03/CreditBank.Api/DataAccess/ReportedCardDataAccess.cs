 
using System.Security.AccessControl;
using System;
using CreditBank.Api.DataAccess;
using System.Threading.Tasks;
using System.Collections.Generic;
using CreditBank.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
 
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
            throw  new NotImplementedException();
        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            return await _dbContext.ReportedCards.Where(item => item.IssuingNetwork == issuingNetworkName).ToListAsync();
        }

        public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
        {
            throw  new NotImplementedException();
        }

        public async Task<string> PutCreditCardReactivated(string creditCardNumber)
        {
            throw   new NotImplementedException();
        }
     
    }
}