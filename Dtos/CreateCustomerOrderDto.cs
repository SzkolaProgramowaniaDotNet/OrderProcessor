using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProcessor.Dtos
{
    public class CreateCustomerOrderDto
    {
        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }
    }
}
