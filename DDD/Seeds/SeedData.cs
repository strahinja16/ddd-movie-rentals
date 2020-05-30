using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Seeds
{
    public static class SeedData
    {
        public static void SeedDatabase(RentalDbContext context)
        {
            context.Database.Migrate();

            context.Movies.AddRange(SeedMovies());
            context.Customers.AddRange(SeedCustomers());

            context.SaveChanges();
        }

        private static List<Customer> SeedCustomers()
        {
            return new List<Customer>()
            {
                Customer.Create(FullName.Create("Strahinja", "Laktovic"), CreditCard.Create("0000-1111", true)),
                Customer.Create(FullName.Create("Nikola", "Trajkovic"), CreditCard.Create("1111-2222", true)),
                Customer.Create(FullName.Create("Bad", "Card"), CreditCard.Create("11-22", false)),
                Customer.Create(FullName.Create("AnotherBad", "Card"), CreditCard.Create("33-44", false))
            };
        }

        private static List<Movie> SeedMovies()
        {
            return new List<Movie>()
            {
                Movie.Create("Interstellar", Genre.Thriller, (decimal)29.99),
                Movie.Create("Inception", Genre.Thriller, (decimal)19.99),
                Movie.Create("Arrival", Genre.Thriller, (decimal)24.99),
                Movie.Create("Joker", Genre.Thriller, (decimal)18.99),

                Movie.Create("The Kissing Booth", Genre.Romantic, (decimal)29.99),
                Movie.Create("Fall Inn Love", Genre.Romantic, (decimal)12.99),
                Movie.Create("Silver Linings Playbook", Genre.Romantic, (decimal)14.99),

                Movie.Create("Babadook", Genre.Horror, (decimal)29.99),
                Movie.Create("Sinister", Genre.Horror, (decimal)14.99),
                Movie.Create("Insidious", Genre.Horror, (decimal)27.99),

                Movie.Create("Ocean's 11", Genre.Action, (decimal)11.99),
                Movie.Create("The Dark Knight", Genre.Action, (decimal)24.99),
                Movie.Create("Skyfall", Genre.Action, (decimal)19.99),
            };
        }
    }
}
