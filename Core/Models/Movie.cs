using System;
using System.Collections.Generic;
using System.Linq;
using Core.Exceptions;
using Core.Interfaces;

namespace Core.Models
{
    public class Movie : IAggregateRoot
    {
        private decimal price;

        private readonly List<PromoCode> promoCodes = new List<PromoCode>();

        private Movie() { }

        public static Movie Create(string name, Genre genre, int price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Movie price must be positive number e.g. 29.99.");

            return new Movie() { Genre = genre, Name = name, price = price };
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Genre Genre { get; private set; }

        public void AddPromoCode(PromoCode promoCode)
        {
            if (!promoCodes.Any())
            {
                promoCodes.Add(promoCode);
            }

            if (promoCodes.Any(pc => pc.PromoEnd > DateTime.Now))
            {
                throw new ThereIsAlreadyActivePromoCodeException($"There is already active promo code until {promoCode.PromoEnd.ToShortDateString()}");
            }

            promoCodes.Add(promoCode);
        }

        public Price GetPrice()
        {
            var currentPromo = promoCodes.Find(pc => pc.PromoEnd > DateTime.Now);
            var promoPrice = currentPromo != null ? price * (100 - currentPromo.Percentage) / 100: (decimal?) null;

            return Price.Create(price, promoPrice);
        }
    }
}
