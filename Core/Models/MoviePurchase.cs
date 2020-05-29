using System;
namespace Core.Models
{
    public class MoviePurchase
    {
        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public Guid MovieId { get; private set; }

        public Movie Movie { get; private set; }

        public DateTime Date { get; private set; }

        private MoviePurchase() { }

        public static MoviePurchase Create(Customer customer, Movie movie)
        {
            return new MoviePurchase() {
                CustomerId = customer.Id,
                Customer = customer,
                MovieId = movie.Id,
                Movie = movie,
                Date = DateTime.Now
            };
        }
    }
}
