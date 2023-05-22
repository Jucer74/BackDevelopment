using NetBank.Api.Context;
using NetBank.Api.Define;
using NetBank.Api.Dto;
using NetBank.Api.Models;

namespace NetBank.Api.Services;

public class CreditCardService
{
    private readonly AppDbContext _appDbContext;

    private const string NUMBER_REGEX = "^[0-9]*$";

    private static List<IssuingNetworkData> IssuingNetworkDataList = LoadIssuingNetworkData();

    public CreditCardResult Result { get; set; } = null!;

    public CreditCardService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public ValidationResultType Validate(string creditCardNumber)
    {
        throw new NotImplementedException();
    }

    private static List<IssuingNetworkData> LoadIssuingNetworkData()
    {
        throw new NotImplementedException();
    }

    private static List<IssuingNetwork> GetIssuingNetworks(AppDbContext appDbContext)
    {
        throw new NotImplementedException();
    }
}