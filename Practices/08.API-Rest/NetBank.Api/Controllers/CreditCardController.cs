using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetBank.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{
    // GET: api/<CreditCardController>/{creditcardNumber}
    [HttpGet("{creditcardNumber}")]
    public IActionResult Get(string creditcardNumber)
    {
        throw new NotImplementedException();
    }
}
