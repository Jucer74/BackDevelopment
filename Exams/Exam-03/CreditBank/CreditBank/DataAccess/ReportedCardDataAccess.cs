using CreditBankAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ReportedCardDataAccess
{
    private readonly AppDbContext _dbContext;

    private readonly String REACTIVATED_STATUS = "Recovered";

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


    public async Task<ReportedCard?> GetReportedCard(string creditCardNumber)
    {
        return await _dbContext.ReportedCards.SingleOrDefaultAsync(item => item.CreditCardNumber == creditCardNumber);
    }

    public async Task<ReportedCard> PutCreditCardReactivated(string creditCardNumber)
    {
        var creditCard = await _dbContext.ReportedCards.SingleOrDefaultAsync(item => item.CreditCardNumber == creditCardNumber);
        creditCard!.StatusCard = REACTIVATED_STATUS;
        creditCard!.LastUpdatedDate = DateTime.Now;
        _dbContext.Entry(creditCard).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return creditCard;
       
    }
}