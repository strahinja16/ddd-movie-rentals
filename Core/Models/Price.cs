using System;
namespace Core.Models
{
    public class Price : ValueObject<Price>
    {
        public decimal OriginalPrice { get; private set; }

        public decimal? PromoPrice { get; private set; }

        private Price() { }

        public static Price Create(decimal originalPrice, decimal? promoPrice)
        {
            if (originalPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(originalPrice), "Original price should be positive number e.g. 29.99");

            if (promoPrice.HasValue && originalPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(originalPrice), "Promo price should be positive number e.g. 29.99");

            return new Price() { OriginalPrice = originalPrice, PromoPrice = promoPrice };
        }
    }
}
