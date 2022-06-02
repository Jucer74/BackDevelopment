using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetBank.Api.Define;
using NetBank.Api.Models;
using NetBank.Api.Services;

namespace NetBank.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CreditCardController : ControllerBase
{
    private readonly ILogger<CreditCardController> _logger;
    
    private readonly CreditCardService _creditCardService;

    public CreditCardController(
        CreditCardService creditCardService,
        ILogger<CreditCardController> logger)
    {
        _logger = logger;
        _creditCardService = creditCardService;
    }

    [HttpGet(Name = "creditCardNumber")]
    public IActionResult Get(string creditCardNumber)
    {
        return Ok();
    }
}
