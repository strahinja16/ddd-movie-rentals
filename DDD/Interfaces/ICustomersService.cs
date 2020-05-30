using System;
using WebApi.DTO;

namespace WebApi.Interfaces
{
    public interface ICustomersService
    {
        CustomerDto GetCustomerById(Guid id);

        CustomerDto CreateCustomer(CreateCustomerDto createCustomerDto);

        CustomerDto EditCreditCard(Guid id, string creditCardValue);

        PurchaseResponseDto PurchaseMovie(Guid customerId, Guid movieId);

        RentResponseDto RentMovie(Guid customerId, Guid movieId);

        WatchMovieResponseDto WatchMovie(Guid customerId, Guid movieId);
    }
}
