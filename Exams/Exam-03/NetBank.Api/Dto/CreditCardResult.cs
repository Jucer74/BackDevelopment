namespace NetBank.Api.Dto;

public class CreditCardResult
{
    public string IssuingNetwork { get; set; }
    public bool Valid { get; set; }

    public CreditCardResult(string issuingNetworkName, bool valid)
    {
        IssuingNetwork = issuingNetworkName;
        Valid = valid;
    }
}