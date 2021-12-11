using MediatR;
using OrderProcessor.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessor.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>>
    {
    }
}
