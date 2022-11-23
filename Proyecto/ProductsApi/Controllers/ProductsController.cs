using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Context;
using ProductsApi.Entities;
using ProductsApi.Dto;
using ProductsApi.Models;
using ProductsApi.Entities.New;
using ProductsApi.Entities.New.Meta;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using ProductsApi.Entities.New.Link;
using System.Net;
using System.Text.Json;
using System.Web;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Routing;


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
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

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

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(string queryValue)
        {
            IQueryable<Product> product = _context.Products;


            if (string.IsNullOrEmpty(queryValue))
            {
                return BadRequest();
            }
            product = product.Where(p => p.Name.Contains(queryValue)
            || p.Description.Contains(queryValue) || p.ImageName.Contains(queryValue));

            return Ok(product);
        }
        [HttpGet]
        [Route("ByPage", Name = "GetPageLinkHeaders")]
        public async Task<IActionResult> GetPage([FromQuery] PaginationParams @params)
            {

            var product = _context.Products
                .OrderBy(e => e.Id);


    
            
            var item = await _context.Products
                .Skip((@params.Page - 1) * @params.ItemsPerPage)
                .Take(@params.ItemsPerPage)
                .ToListAsync();

            var linkBuilder = new PageLinkBuilder(Url , "GetPageLinkHeaders", "", @params.Page, @params.ItemsPerPage, product.Count());


            var LinkHeaderTemplate = "http://localhost:5001/api/v1.0/Products/ByPage?";

            List<string> link = new List<string>();
            if (linkBuilder.FirstPage != null)
                link.Add(string.Format(LinkHeaderTemplate, linkBuilder.FirstPage, "first"));
            if (linkBuilder.PreviousPage != null)
                link.Add(string.Format(LinkHeaderTemplate, linkBuilder.PreviousPage, "previous"));
            if (linkBuilder.NextPage != null)
                link.Add(string.Format(LinkHeaderTemplate, linkBuilder.NextPage, "next"));
            if (linkBuilder.LastPage != null)
                link.Add(string.Format(LinkHeaderTemplate, linkBuilder.LastPage, "last"));

            Response.Headers.Add("Link", string.Join(", ", link));

            return Ok(item.Select(e => new Product 
                        {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                ImageName = e.ImageName
            }));;
        }


    }
}



