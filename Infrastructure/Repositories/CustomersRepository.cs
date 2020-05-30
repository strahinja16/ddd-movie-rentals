using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
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
    }
}
