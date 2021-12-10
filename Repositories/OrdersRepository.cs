using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProcessor.Dtos;

namespace OrderProcessor.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly List<OrderDto> _orders = new List<OrderDto>
        {
            new OrderDto
            {
                Id = Guid.Parse("0bb7daa5-7f27-4b5f-95df-3d8b3b86d7ed"),
                DeliveryDate = DateTime.UtcNow,
                Product = new ProductDto
                {
                    Id = Guid.Parse("9f8dd03e-1298-4070-adc0-c21bbd5e179f"),
                    Name = "Amazing Product",
                    Price = 6.99m,
                    ReleaseDate = DateTime.UtcNow
                },
                Customer = new CustomerDto
                { 
                    Id = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"),
                    Name = "Patryk S³adek"
                },
                Delivered = false
            }
        };

        public Task<List<OrderDto>> GetOrdersAsync()
        {
            return Task.FromResult(_orders);
        }

        public Task<OrderDto> CreateOrderAsync(Guid customerId, Guid productId)
        {
            var customer = new CustomerDto
            {
                Id = customerId,
                Name = "Patryk S³adek"
            };

            var product = new ProductDto
            {
                Id = productId,
                Name = "Extra Product",
                Price = 9.66m,
                ReleaseDate = DateTime.UtcNow
            };

            var order = new OrderDto
            {
                Id = Guid.NewGuid(),
                Delivered = false,
                DeliveryDate = DateTime.UtcNow,
                Customer = customer,
                Product = product
            }; 
            _orders.Add(order);
            return Task.FromResult(order);
        }

        public Task<OrderDto> GetOrderAsync(Guid orderId)
        {
            return Task.FromResult(_orders.SingleOrDefault(x => x.Id == orderId));
        }
    }
}