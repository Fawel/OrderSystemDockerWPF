using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CustomersSystem.Models;
using CustomersSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomersSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, 
                                    ILogger<CustomerController> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(Guid uid)
        {
            var customer = _customerService.GetCustomer(uid);
            if (customer is null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost("{name}/{age}/{country}")]
        public async Task<IActionResult> AddCustomer([Required]string name,
                                                     [Range(1, 999)]int age,
                                                     Country country)
        {
            var newCustomer = new NewCustomer(name, age, country);
            await _customerService.AddCustomerAsync(newCustomer);

            return Ok();
        }
    }
}
