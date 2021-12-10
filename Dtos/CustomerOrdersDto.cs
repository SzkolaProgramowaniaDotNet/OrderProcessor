using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessor.Dtos
{
    public class CustomerOrdersDto
    {
        public Guid CustomerId { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
