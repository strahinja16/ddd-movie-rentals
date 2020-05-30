using System;
using Core.Models;

namespace Core.Interfaces
{
    public interface IDomainCustomersService : IDomainService
    {
        Customer CreateCustomer(string name, string lastName, string creditCardValue); 
    }
}
