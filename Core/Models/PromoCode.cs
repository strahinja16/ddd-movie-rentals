using System;
namespace Core.Models
{
    public class PromoCode
    {
        public Guid PromoCodeId { get; private set; }

        public Guid MovieId { get; private set; }

        public DateTime PromoStart { get; private set; }

        public DateTime PromoEnd { get; private set; }

        public int Percentage { get; set; }

        public Movie Movie { get; private set; }

        private PromoCode() { }

        public static PromoCode Create(Movie movie, DateTime promoEnd, int percentage)
        {
            if (promoEnd < DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(promoEnd), "Promo End should be later than now.");

            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage should be between 0 and 100");

            return new PromoCode() {
                MovieId = movie.Id,
                Movie = movie,
                PromoStart = DateTime.Now,
                PromoEnd = promoEnd,
                Percentage = percentage
            };
        }
    }
}
