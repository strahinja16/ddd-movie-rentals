using System;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces.Infrastructure;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly RentalDbContext context;

        public CustomersRepository(RentalDbContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
        }

        public Customer AddMovieRental(MovieRental movieRental)
        {
            var customer = context.Customers.Find(movieRental.CustomerId);

            customer.AddMovieRental(movieRental);

            context.Add(movieRental);
            context.SaveChanges();

            return customer;
        }

        public Customer AddMoviePurchase(MoviePurchase moviePurchase)
        {
            var customer = context.Customers.Find(moviePurchase.CustomerId);

            customer.AddMoviePurchase(moviePurchase);

            context.Add(moviePurchase);
            context.SaveChanges();

            return customer;
        }

        public Customer FindById(Guid id)
        {
            return context.Customers.Find(id);
        }

        public Customer FindByIdWithPurchasesAndRentals(Guid id)
        {
            return context.Customers
                .Include(c => c.MovieRentals)
                .Include(c => c.MoviePurchases)
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public void InvalidateCreditCard(Customer customer)
        {
            var customerFromDb = context.Customers.Find(customer.Id);

            customerFromDb.CreditCard = CreditCard.Create(customerFromDb.CreditCard.Value, false);

            context.SaveChanges();
        }

        public void FinishRental(MovieRental movieRental)
        {
            var customer = context.Customers
                .Include(c => c.MovieRentals)
                .Where(c => c.Id == movieRental.CustomerId)
                .First();

            customer.MovieRentals = customer.MovieRentals.Select(r =>
            {
                if (r == movieRental)
                {
                    r.EndDate = DateTime.Now;
                }
                return r;

            }).ToList();

            context.SaveChanges();
        }

        public Customer EditCreditCard(Customer customer, CreditCard creditCard)
        {
            customer.CreditCard = creditCard;

            context.SaveChanges();

            return customer;
        }
    }
}
