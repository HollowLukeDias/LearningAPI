using LearningAPI.Data;
using LearningAPI.Models;
using LearningAPI.Services;
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

        private IProduct productRepository;

        public ProductsController(IProduct _productRepository)
        {
            productRepository = _productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> Get(string searchProduct) => productRepository.GetProducts();
            

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProduct(id);

            if (product == null) 
                return NotFound("No product found");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            //Model State just validates wheter or not the class under the model has the right elements
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)     return BadRequest(ModelState);
            if (id != product.ProductID) return BadRequest("The ID in the submission is different from the Product ID");

            try
            {
                productRepository.UpdateProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No Product found with this id");
            }

            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.Delete(id);
            return Ok("The product has been deleted");
        }
    }
}
