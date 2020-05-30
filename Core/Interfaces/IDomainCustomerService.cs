using System;
using Core.Models;

namespace Core.Interfaces
{
    public interface IDomainCustomersService : IDomainService
    {
        Customer CreateCustomer(string name, string lastName, string creditCardValue);

        Customer EditCreditCard(Customer customer, string creditCardValue);

        string WatchMovie(Customer customer, Movie movie);
    }
}
