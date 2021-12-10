using System;

namespace OrderProcessor.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public ProductDto Product { get; set; }

        public CustomerDto Customer { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Delivered { get; set; }
    }
}