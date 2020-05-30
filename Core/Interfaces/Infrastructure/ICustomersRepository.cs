using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.Interfaces.Infrastructure
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        Customer FindByIdWithPurchasesAndRentals(Guid id);

        Customer AddMovieRental(MovieRental movieRental);

        Customer AddMoviePurchase(MoviePurchase moviePurchase);

        Customer EditCreditCard(Customer customer, CreditCard creditCard);

        void InvalidateCreditCard(Customer customer);

        void FinishRental(MovieRental movieRental);
    }
}
