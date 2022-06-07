public class ReportedCardService
  {
  private readonly ReportedCardDataAccess _reportedCardDataAccess;

  public ReportedCardBL(ReportedCardDataAccess reportedCardDataAccess)
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
