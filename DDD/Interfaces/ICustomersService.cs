using System;
using WebApi.DTO;

namespace WebApi.Interfaces
{
    public interface ICustomersService
    {
        CustomerDto GetCustomerById(Guid id);

        PurchaseResponseDto PurchaseMovie(Guid customerId, Guid movieId);

        RentResponseDto RentMovie(Guid customerId, Guid movieId);
    }
}
