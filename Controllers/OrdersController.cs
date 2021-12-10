using System;
using System.Threading.Tasks;
using OrderProcessor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderProcessor.Dtos;

namespace OrderProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrdersRepository ordersRepository, ILogger<OrdersController> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderDto createCustomerOrder)
        {
            var order = await _ordersRepository.CreateOrderAsync(createCustomerOrder.CustomerId, createCustomerOrder.ProductId);
            _logger.LogInformation($"Created order for customer: {order.Customer.Id} for product: {order.Product.Id}");

            return CreatedAtAction("GetOrder", new { orderId = order.Id }, order);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var orderDto = await _ordersRepository.GetOrderAsync(orderId);

            if (orderDto == null)
            {
                return NotFound();
            }

            return Ok(orderDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var ordersDto = await _ordersRepository.GetOrdersAsync();
            return Ok(ordersDto);
        }
    }
}