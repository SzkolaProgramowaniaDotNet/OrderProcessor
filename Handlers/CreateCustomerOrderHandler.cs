using MediatR;
using Microsoft.Extensions.Logging;
using OrderProcessor.Commands;
using OrderProcessor.Dtos;
using OrderProcessor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessor.Handlers
{
    public class CreateCustomerOrderHandler : IRequestHandler<CreateCustomerOrderCommand, OrderDto>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<CreateCustomerOrderHandler> _logger;

        public CreateCustomerOrderHandler(IOrdersRepository ordersRepository, ILogger<CreateCustomerOrderHandler> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }


        public async Task<OrderDto> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.CreateOrderAsync(request.CustomerId, request.ProductId);
            _logger.LogInformation($"Created order for customer: {order.Customer.Id} for product: {order.Product.Id}");
            return order;
        }
    }
}
