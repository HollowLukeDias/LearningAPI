using LearningAPI.Data;
using LearningAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        ProductsDbContext productsDbContext;

        public ProductsController(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productsDbContext.Products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(prod => prod.ProductID == id);
            if (product == null)
            {
                return NotFound("No Product has been found with the given id");
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            //Model State just validates wheter or not the class under the model has the right elements
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
            return StatusCode(StatusCodes.Status201Created);


        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
