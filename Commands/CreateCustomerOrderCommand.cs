using MediatR;
using OrderProcessor.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessor.Commands
{
    public class CreateCustomerOrderCommand : IRequest<OrderDto>
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }

        public CreateCustomerOrderCommand(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
