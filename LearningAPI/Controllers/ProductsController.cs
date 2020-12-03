﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningAPI.Models;

namespace LearningAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductID = 0, ProductName = "Death", ProductPrice = "200000"},
            new Product(){ProductID = 0, ProductName = "Life", ProductPrice = "0"}
        };

        public IActionResult Get()
        {
            return Ok(_products);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            _products[id] = product;    
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }

    }
}
