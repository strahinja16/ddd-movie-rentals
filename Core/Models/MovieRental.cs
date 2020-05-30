using System;
namespace Core.Models
{
    public class MovieRental
    {
        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public Guid MovieId { get; private set; }

        public Movie Movie { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; set; }

        private MovieRental() { }

        public static MovieRental Create(Customer customer, Movie movie, DateTime endDate)
        {
            if (endDate < DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(endDate), "Rental end date must be later than now.");

            return new MovieRental()
            {
                CustomerId = customer.Id,
                Customer = customer,
                MovieId = movie.Id,
                Movie = movie,
                StartDate = DateTime.Now,
                EndDate = endDate
            };
        }

        public bool IsExpired()
        {
            return EndDate < DateTime.Now;
        }
    }
}
