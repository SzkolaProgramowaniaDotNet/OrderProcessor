using System;
using System.Linq;
using System.Threading.Tasks;
using OrderProcessor.Repositories;
using Microsoft.AspNetCore.Mvc;
using OrderProcessor.Dtos;

namespace OrderProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IOrdersRepository _ordersRepository;
        public CustomersController(ICustomersRepository customersRepository, IOrdersRepository ordersRepository)
        {
            _customersRepository = customersRepository;
            _ordersRepository = ordersRepository;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetCustomers()
        {
            var customersDto = await _customersRepository.GetCustomersAsync();

            return Ok(customersDto);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var customerDto = await _customersRepository.GetCustomerAsync(customerId);

            if (customerDto == null)
            {
                return NotFound();
            }

            return Ok(customerDto);
        }

        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders(Guid customerId)
        {
            var ordersDto = await _ordersRepository.GetOrdersAsync();
            var custmerOrders = new CustomerOrdersDto
            {
                CustomerId = customerId,
                Orders = ordersDto.Where(x => x.Customer.Id == customerId).ToList()
            };

            return Ok(custmerOrders);
        }
    }
}