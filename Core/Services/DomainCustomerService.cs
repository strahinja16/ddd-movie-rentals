using System;
using System.Linq;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.Infrastructure;
using Core.Models;
using Core.Models.Responses;

namespace Core.Services
{
    public class DomainCustomersService : IDomainCustomersService
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IPaymentService paymentService;
        private readonly IStreamingService streamingService;

        public DomainCustomersService(
            ICustomersRepository customersRepository,
            IPaymentService paymentService,
            IStreamingService streamingService)
        {
            this.customersRepository = customersRepository;
            this.paymentService = paymentService;
            this.streamingService = streamingService;
        }

        public Customer CreateCustomer(string name, string lastName, string creditCardValue)
        {
            var fullName = FullName.Create(name, lastName);

            var isCreditCardValid = paymentService.CreditCardIsValid(creditCardValue);

            var creditCard = CreditCard.Create(creditCardValue, isCreditCardValid);

            var customer = Customer.Create(fullName, creditCard);

            customersRepository.Add(customer);

            return customer;
        }

        public Customer EditCreditCard(Customer customer, string creditCardValue)
        {
            var isCreditCardValid = paymentService.CreditCardIsValid(creditCardValue);
            var creditCard = CreditCard.Create(creditCardValue, isCreditCardValid);

            return customersRepository.EditCreditCard(customer, creditCard);
        }

        public string WatchMovie(Customer customer, Movie movie)
        {
            var currentlyRentedMovie = customer.MovieRentals
                .FirstOrDefault(mr => mr.MovieId == movie.Id && mr.EndDate > DateTime.Now);
            var purchasedMovie = customer.MoviePurchases.FirstOrDefault(m => m.MovieId == movie.Id);

            if (currentlyRentedMovie == null && purchasedMovie == null)
                throw new MovieNotAcquiredException("Movie is not acquired. Please rent or purchase movie and try again.");

            if (currentlyRentedMovie != null)
            {
                return streamingService.GetMovieStream(currentlyRentedMovie.Movie);
            }

            if (purchasedMovie != null)
            {
                return streamingService.GetMovieStreamWithDownload(purchasedMovie.Movie);
            }

            return string.Empty;
        }
    }
}
