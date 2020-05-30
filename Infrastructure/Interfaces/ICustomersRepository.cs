using System;
using System.Collections.Generic;
using Core.Models;

namespace Infrastructure.Interfaces
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        Customer FindByIdWithPurchasesAndRentals(Guid id);
    }
}
