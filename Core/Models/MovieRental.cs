using System;
namespace Core.Models
{
    public class MovieRental
    {
        public Guid CustomerId { get; private set; }

        public Guid MovieId { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        private MovieRental() { }

        public static MovieRental Create(Guid customerId, Guid movieId, DateTime endDate)
        {
            if (endDate < DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(endDate), "Rental end date must be later than now.");

            return new MovieRental()
            {
                CustomerId = customerId,
                MovieId = movieId,
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
