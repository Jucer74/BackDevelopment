using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsApi.Controllers
{
   [Route("api/v1.0/[controller]")]
   [ApiController]
   public class TestsController : ControllerBase
   {
      private List<Product> productList = new List<Product>();

      public TestsController()
      {
         productList.Add(new Product() { Id = 1, Name = "Name1", Description = "Description1", Price = 1000, ImageName = "Image1" });
         productList.Add(new Product() { Id = 2, Name = "Name2", Description = "Description2", Price = 2000, ImageName = "Image2" });
         productList.Add(new Product() { Id = 3, Name = "Name3", Description = "Description3", Price = 3000, ImageName = "Image3" });
         productList.Add(new Product() { Id = 4, Name = "Name4", Description = "Description4", Price = 4000, ImageName = "Image4" });
         productList.Add(new Product() { Id = 5, Name = "Name5", Description = "Description5", Price = 5000, ImageName = "Image5" });
      }

      // GET: api/<TestsController>
      [HttpGet]
      public IEnumerable<Product> Get()
      {
         return productList;
      }

      // GET api/<TestsController>/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
         return "value";
      }

      // POST api/<TestsController>
      [HttpPost]
      public IActionResult Post([FromBody] Product product)
      {
         try
         {
            /*
             * Simular la Ejecucion
             * */
            // Dispara una Exception
            throw new Exception("Valor Duplicado");
            ////////////////////////

            return Ok(product);
         }
         catch (Exception ex)
         {

            return BadRequest($"Error: {ex.Message}");
         }
         
      }

      // PUT api/<TestsController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
      }

      // DELETE api/<TestsController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   }
}