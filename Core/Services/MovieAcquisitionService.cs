using System;
using System.Linq;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.Infrastructure;
using Core.Models;
using Core.Models.Responses;

namespace Core.Services
{
    public class MovieAcquisitionService : IMovieAcquisitionService
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IPaymentService paymentService;
        private readonly IStreamingService streamingService;

        public int RentalDays { get; } = 7;

        public MovieAcquisitionService(
            ICustomersRepository customersRepository,
            IPaymentService paymentService,
            IStreamingService streamingService
        )
        {
            this.customersRepository = customersRepository;
            this.paymentService = paymentService;
            this.streamingService = streamingService;
        }

        public PurchaseResponse PurchaseMovie(Customer customer, Movie movie)
        {
            if (customer.MoviePurchases.Select(r => r.MovieId).Contains(movie.Id))
                throw new MovieAlreadyPurchasedException("Movie already purchased.");

            if (!paymentService.Pay(customer, movie))
            {
                InvalidateCustomerCreditCard(customer);

                throw new PaymentFailedException(
                    $"Payment failed for customer {customer.FullName.ToString()}. " +
                    "Please check and update your credit card details."
                );
            }

            var moviePurchase = MoviePurchase.Create(customer, movie);
            customersRepository.AddMoviePurchase(moviePurchase);

            FinishCurrentRentalIfExists(customer, movie);

            var movieLinkWithDownload = streamingService.GetMovieStreamWithDownload(movie);

            return new PurchaseResponse(moviePurchase, movieLinkWithDownload);
        }

        public RentResponse RentMovie(Customer customer, Movie movie)
        {
            if (customer.MovieRentals.FirstOrDefault(r => r.MovieId == movie.Id && r.EndDate > DateTime.Now) != null)
                throw new MovieAlreadyRentedException("Movie already rented.");

            if (customer.MoviePurchases.Select(r => r.MovieId).Contains(movie.Id))
                throw new MovieAlreadyPurchasedException("Movie already purchased.");

            if (!paymentService.Rent(customer))
            {
                InvalidateCustomerCreditCard(customer);

                throw new PaymentFailedException(
                    $"Payment failed for customer {customer.FullName.ToString()}. " +
                    "Please check and update your credit card details."
                );
            }

            var movieRental = MovieRental.Create(customer, movie, DateTime.Now.AddDays(RentalDays));
            customersRepository.AddMovieRental(movieRental);

            var movieStream = streamingService.GetMovieStream(movie);

            return new RentResponse(movieRental, movieStream);
        }

        private void InvalidateCustomerCreditCard(Customer customer)
        {
            customersRepository.InvalidateCreditCard(customer);
        }

        private void FinishCurrentRentalIfExists(Customer customer, Movie movie)
        {
            var currentRental = customer.MovieRentals.FirstOrDefault(r => r.EndDate > DateTime.Now && r.MovieId == movie.Id);
            if (currentRental == null)
            {
                return;
            }

            customersRepository.FinishRental(currentRental);
        }
    }
}
