using Microsoft.AspNetCore.Mvc;
using NetBank.Api.Define;
using NetBank.Api.Dto;
using NetBank.Api.Services;

namespace NetBank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{
    private readonly CreditCardService _creditCardService;

    public CreditCardController(CreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }

    [HttpGet("{creditcardNumber}")]
    public IActionResult GetCreditCarDatad(string creditcardNumber)
    {
        // TODO: Adicione su codigo aqui
        throw new NotImplementedException();
    }
}