using System;
using Core.Models;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
        bool CreditCardIsValid(string creditCardValue);

        bool Rent(Customer customer);

        bool Pay(Customer customer, Movie movie);
    }
}
