using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Context;
using ProductsApi.Models;
using static System.Net.WebRequestMethods;

namespace ProductsApi.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);


            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products/ByPage


        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        [HttpGet("ByPage")]
        public async Task<IActionResult> GetPage([FromQuery] PaginationParagrams @params)
        {
            var product = await _context.Products
                .OrderBy(e => e.Id)
                .Where(e => e.Id > @params.Page - 1)
                .Take(@params.ItemsPerPage)
                .ToListAsync();

            var nextCursor = product.Any()
                ? product.LastOrDefault()?.Id
                : 0;

            Response.Headers.Add("X-Pagination", $"Next Cursor={nextCursor}");

            return Ok(product.Select(e => new Product
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                ImageName = e.ImageName
            }));
        }

        [HttpGet]
        [Route("customers/pagelinkheaders", Name = "GetPageLinkHeaders")]
        public HttpResponseMessage GetPageLinkHeaders(int pageNo = 1, int pageSize = 50)
        {
            // Determine the number of records to skip
            

            // Get total number of records
            int total = _context.Products.Count();

            // Select the customers based on paging parameters
            var products = _context.Products
                .OrderBy(c => c.Id)
                .Take(pageSize)
                .ToList();

            // Get the page links
            var linkBuilder = new PageLinkBuilder(Url, "GetPageLinkHeaders", "", pageNo, pageSize, total);

            // Create the response
            var response = Request.CreateResponse(HttpStatusCode.OK, products);
            var LinkHeaderTemplate = "http://localhost:5001/api/v1.0/Products/ByPage?";

            // Build up the link header
            List<string> links = new List<string>();
            if (linkBuilder.FirstPage != null)
                links.Add(string.Format(LinkHeaderTemplate, linkBuilder.FirstPage, "first"));
            if (linkBuilder.PreviousPage != null)
                links.Add(string.Format(LinkHeaderTemplate, linkBuilder.PreviousPage, "previous"));
            if (linkBuilder.NextPage != null)
                links.Add(string.Format(LinkHeaderTemplate, linkBuilder.NextPage, "next"));
            if (linkBuilder.LastPage != null)
                links.Add(string.Format(LinkHeaderTemplate, linkBuilder.LastPage, "last"));

            // Set the page link header
            response.Headers.Add("Link", string.Join(", ", links));

            // Return the response
            return response;
        }
    }
}
