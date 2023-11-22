using CreditBankAPI.Utilities;
using CreditBankAPI.Models;
using CreditBankAPI.Exceptions;

public class ReportedCardService
{
    private readonly ReportedCardDataAccess _reportedCardDataAccess;

    private readonly String REPORTED_STATUS="Stolen";

    public ReportedCardService(ReportedCardDataAccess reportedCardDataAccess)
    {
        _reportedCardDataAccess = reportedCardDataAccess;
    }

    public async Task<IList<ReportedCard>> GetAllReportedCards()
    {
        var reportedCardsList = await _reportedCardDataAccess.GetAllReportedCards();
        if (reportedCardsList.Count==0)
        {
            throw new NotFoundException($"Cards Not Found");
        }
        return reportedCardsList;
    }

    public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
    {
        if (issuingNetworkName==null || issuingNetworkName.Replace(" ","").Equals("")) {
            throw new BadRequestException("issuingNetworkName is required");
        }

        var reportedCardsList = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);

        if (reportedCardsList.Count == 0)
        {
            throw new NotFoundException($"{issuingNetworkName} cards Not Found");
        }

        return reportedCardsList;
    }

    public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
    {
        if (creditCardNumber == null || creditCardNumber.Replace(" ", "").Equals(""))
        {
            throw new BadRequestException("creditCardNumber is required");
        }

        ValidateCreditCard(creditCardNumber);

        var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);

        if (reportedCard==null)
        {
            throw new NotFoundException($"card {creditCardNumber} Not Found");
        }

        return reportedCard;
    }

    public async Task<ReportedCard> PutCreditCardReactivated(string creditCardNumber)
    {
        if (creditCardNumber == null || creditCardNumber.Replace(" ", "").Equals(""))
        {
            throw new BadRequestException("creditCardNumber is required");
        }

        ValidateCreditCard(creditCardNumber);

        var reportedCard = await _reportedCardDataAccess.GetReportedCard(creditCardNumber);

        if (reportedCard == null)
        {
            throw new NotFoundException($"card {creditCardNumber} Not Found");
        }

        if (!reportedCard.StatusCard.Equals(REPORTED_STATUS)) {
            throw new BadRequestException("the creditCard is not stolen");
        }

        return await _reportedCardDataAccess.PutCreditCardReactivated(creditCardNumber);
    }

    private void ValidateCreditCard(string creditCardNumber) {
        if (!CreditCardValidator.IsNumericCard(creditCardNumber))
        {
            throw new BadRequestException("Credit card number is not numeric");
        }
        if (!CreditCardValidator.IsValid(creditCardNumber))
        {
            throw new BadRequestException("Credit card number is not valid");
        }
    }
}