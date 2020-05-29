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

        public List<PromoCode> PromoCodes { get; private set; }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Genre Genre { get; private set; }

        public DateTime CreatedAt { get; set; }

        private Movie() { }

        public static Movie Create(string name, Genre genre, decimal price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Movie price must be positive number e.g. 29.99.");

            return new Movie() {
                Genre = genre,
                Name = name,
                price = price,
                PromoCodes = new List<PromoCode>(),
                CreatedAt = DateTime.Now
            };
        }

        public void AddPromoCode(PromoCode promoCode)
        {
            if (!PromoCodes.Any())
            {
                PromoCodes.Add(promoCode);
                return;
            }

            if (PromoCodes.Any(pc => pc.PromoEnd > DateTime.Now))
            {
                throw new ThereIsAlreadyActivePromoCodeException($"There is already active promo code until {promoCode.PromoEnd.ToShortDateString()}");
            }

            PromoCodes.Add(promoCode);
        }

        public Price GetPrice()
        {
            var currentPromo = PromoCodes.Find(pc => pc.PromoEnd > DateTime.Now);
            var promoPrice = currentPromo != null ? price * (100 - currentPromo.Percentage) / 100: (decimal?) null;

            return Price.Create(price, promoPrice);
        }
    }
}
