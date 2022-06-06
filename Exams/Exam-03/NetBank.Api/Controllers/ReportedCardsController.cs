0 sloc)  227 Bytes
   
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditBank.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ReportedCardsController : ControllerBase
   {

        [HttpGet("{creditcardNumber}")]
        public IActionResult Get(string creditcardNumber)
        {
        
        }

         [HttpGet("{creditcardNumber}")]
        public IActionResult Get(string creditcardNumber)
        {
        
        }
   }
}