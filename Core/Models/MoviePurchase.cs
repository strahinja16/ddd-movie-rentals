using System;
namespace Core.Models
{
    public class MoviePurchase
    {
        public Guid CustomerId { get; private set; }

        public Guid MovieId { get; private set; }

        public DateTime Date { get; private set; }

        private MoviePurchase() { }

        public static MoviePurchase Create(Guid customerId, Guid movieId)
        {
            return new MoviePurchase() { CustomerId = customerId, MovieId = movieId, Date = DateTime.Now };
        }
    }
}
