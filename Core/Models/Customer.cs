using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Exceptions;
using Core.Interfaces;

namespace Core.Models
{
    public class Customer : IAggregateRoot
    {
        public List<MoviePurchase> MoviePurchases { get; set; }

        public List<MovieRental> MovieRentals { get; set; }

        public Guid Id { get; private set; }

        public FullName FullName { get; private set; }

        public CreditCard CreditCard { get; private set; }

        private Customer() { }

        public static Customer Create(FullName fullName, CreditCard creditCard)
        {
            return new Customer() {
                FullName = fullName,
                CreditCard = creditCard,
                MoviePurchases = new List<MoviePurchase>(),
                MovieRentals = new List<MovieRental>()
            };
        }

        public void AddMoviePurchase(MoviePurchase moviePurchase)
        {
            if (MoviePurchases.Count > 0 && MoviePurchases.Exists(mp => mp.MovieId == moviePurchase.MovieId))
                throw new MovieAlreadyPurchasedException("Movie already purchased.");

            MoviePurchases.Add(moviePurchase);
        }

        public void AddMovieRental(MovieRental movieRental)
        {
            if (MoviePurchases.Count > 0 && MoviePurchases.Exists(mp => mp.MovieId == movieRental.MovieId))
                throw new MovieAlreadyPurchasedException("Movie already purchased.");

            if (MovieRentals.Count > 0 && MovieRentals.Exists(mp => mp.MovieId == movieRental.MovieId))
                throw new MovieAlreadyRentedException("Movie already rented.");

            MovieRentals.Add(movieRental);
        }
    }
}
