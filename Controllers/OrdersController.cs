using System;
using System.Threading.Tasks;
using OrderProcessor.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderProcessor.Dtos;
using OrderProcessor.Queries;
using MediatR;
using OrderProcessor.Commands;

namespace OrderProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator, IOrdersRepository ordersRepository, ILogger<OrdersController> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
            _mediator = mediator;
        }
        
        [HttpPost("")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderDto createCustomerOrder)
        {
            var command = new CreateCustomerOrderCommand(createCustomerOrder.CustomerId, createCustomerOrder.ProductId);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetOrder", new { orderId = result.Id }, result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var query = new GetOrderByIdQuery(orderId);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}