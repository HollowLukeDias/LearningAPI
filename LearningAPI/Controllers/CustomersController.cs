using LearningAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        List<Customer> _customers = new List<Customer>()
        {
            new Customer(){ Id = 0, Email = "hyu@gmail.com", Name = "Luke", Phone = "991"},
            new Customer(){ Id = 1, Email = "ham@hotmail.com", Name = "Juin", Phone = "110"}
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            //If it passes the regular expression check
            if (ModelState.IsValid)
            {
                _customers.Add(customer);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        
    }
}
