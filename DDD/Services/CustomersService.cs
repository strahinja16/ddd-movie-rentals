using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Core.Interfaces;
using Core.Interfaces.Infrastructure;
using Core.Models;
using WebApi.DTO;
using WebApi.Exceptions;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMoviesRepository moviesRepository;
        private readonly IMovieAcquisitionService movieAcquisitionService;
        private readonly IDomainCustomersService domainCustomersService;

        private readonly IMapper mapper;

        public CustomersService(
            ICustomersRepository customersRepository,
            IMoviesRepository moviesRepository,
            IMovieAcquisitionService movieAcquisitionService,
            IDomainCustomersService domainCustomersService,
            IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.moviesRepository = moviesRepository;
            this.movieAcquisitionService = movieAcquisitionService;
            this.domainCustomersService = domainCustomersService;

            this.mapper = mapper;
        }

        public PurchaseResponseDto PurchaseMovie(Guid customerId, Guid movieId)
        {
            var customer = customersRepository.FindByIdWithPurchasesAndRentals(customerId);
            if (customer == null)
            {
                throw new HttpException("Customer not found.", HttpStatusCode.NotFound);
            }

            var movie = moviesRepository.FindById(movieId);
            if (movie == null)
            {
                throw new HttpException("Movie not found.", HttpStatusCode.NotFound);
            }

            try
            {
                var purchaseResponse = movieAcquisitionService.PurchaseMovie(customer, movie);

                return mapper.Map<PurchaseResponseDto>(purchaseResponse);
            }
            catch (Exception ex)
            {
                throw new HttpException("Movie purchase failed.", ex);
            }
        }

        public RentResponseDto RentMovie(Guid customerId, Guid movieId)
        {
            var customer = customersRepository.FindByIdWithPurchasesAndRentals(customerId);
            if (customer == null)
            {
                throw new HttpException("Customer not found.", HttpStatusCode.NotFound);
            }

            var movie = moviesRepository.FindById(movieId);
            if (movie == null)
            {
                throw new HttpException("Movie not found.", HttpStatusCode.NotFound);
            }

            try
            {
                var rentResponse = movieAcquisitionService.RentMovie(customer, movie);

                return mapper.Map<RentResponseDto>(rentResponse);
            }
            catch (Exception ex)
            {
                throw new HttpException("Movie rental failed.", ex);
            }
        }

        public CustomerDto GetCustomerById(Guid id)
        {
            var customer = customersRepository.FindById(id);
            if (customer == null)
            {
                throw new HttpException("Customer not found.", HttpStatusCode.NotFound);
            }

            return mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var customer = domainCustomersService
                .CreateCustomer(createCustomerDto.Name, createCustomerDto.LastName, createCustomerDto.CreditCardValue);

            return mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto EditCreditCard(Guid customerId, string creditCardValue)
        {
            var customer = customersRepository.FindById(customerId);
            if (customer == null)
            {
                throw new HttpException("Customer not found.", HttpStatusCode.NotFound);
            }

            var editedCustomer = domainCustomersService.EditCreditCard(customer, creditCardValue);

            return mapper.Map<CustomerDto>(editedCustomer);
        }
    }
}
