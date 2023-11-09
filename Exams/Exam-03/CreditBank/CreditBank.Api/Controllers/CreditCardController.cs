using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CreditBank.Api.Controllers;

[Route("api/v1.0/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{
    // GET api/v1.0/CreditCard/CheckDigitStatus/{creditCardNumber}
    [HttpGet("CheckDigitStatus/{creditCardNumber}")]
    public ActionResult<string> GetCreditCardCheckDigitStatus(string creditCardNumber)
    {
        // Si No es cadena Numerica Retorne => "Credit Card [{creditCardNumber}] is NOT Numeric"
        // Si no es Un numero de tarjeta Valida por longitud, tipos o digito de Chequeo debe retornar => "Credit Card [{creditCardNumber}] is Valid"
        // Si es Correcta Debe Retornar => "Credit Card [{creditCardNumber}] is Valid"
        // En caso de Cualquier Otra Exception No controlada debe retornar =>  StatusCode((int)HttpStatusCode.InternalServerError, ex.Message)

        // Implemente la Logica que permita Validar si el Numero de la tarjeta es valido
        throw new NotImplementedException();
    }
}