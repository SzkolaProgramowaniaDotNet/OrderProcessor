using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderProcessor.Dtos;

namespace OrderProcessor.Repositories
{
    public interface ICustomersRepository
    {
        Task<CustomerDto> GetCustomerAsync(Guid customerId);
        
        Task<List<CustomerDto>> GetCustomersAsync();
    }
}