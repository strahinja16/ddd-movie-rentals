using System;
namespace Core.Models.Responses
{
    public class RentResponse
    {
        public MovieRental MovieRental { get; private set; }

        public string MovieStream { get; private set; }

        public RentResponse(MovieRental movieRental, string movieStream)
        {
            MovieRental = movieRental;
            MovieStream = movieStream;
        }
    }
}
