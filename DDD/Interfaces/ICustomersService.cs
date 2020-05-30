using System;
using WebApi.DTO;

namespace WebApi.Interfaces
{
    public interface ICustomersService
    {
        CustomerDto GetCustomerById(Guid id);
    }
}
