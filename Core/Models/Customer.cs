using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Exceptions;
using Core.Interfaces;

namespace Core.Models
{
    public class Customer : IAggregateRoot
    {
        private List<MoviePurchase> moviePurchases;

        private List<MovieRental> movieRentals;

        public Guid Id { get; private set; }

        public FullName FullName { get; private set; }

        public CreditCard CreditCard { get; private set; }

        private Customer() { }

        public static Customer Create(FullName fullName, CreditCard creditCard)
        {
            return new Customer() {
                FullName = fullName,
                CreditCard = creditCard,
                moviePurchases = new List<MoviePurchase>(),
                movieRentals = new List<MovieRental>()
            };
        }

        public void AddPurchasedMovie(MoviePurchase moviePurchase)
        {
            if (moviePurchases.Count > 0 && moviePurchases.Exists(mp => mp.MovieId == moviePurchase.MovieId))
                throw new MovieAlreadyPurchasedException("Movie already purchased.");

            moviePurchases.Add(moviePurchase);
        }

        public void AddRentedMovie(MovieRental movieRental)
        {
            if (moviePurchases.Count > 0 && moviePurchases.Exists(mp => mp.MovieId == movieRental.MovieId))
                throw new MovieAlreadyPurchasedException("Movie already purchased.");

            if (movieRentals.Count > 0 && movieRentals.Exists(mp => mp.MovieId == movieRental.MovieId))
                throw new MovieAlreadyRentedException($"Movie already rented.");

            movieRentals.Add(movieRental);
        }
    }
}
