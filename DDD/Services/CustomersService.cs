using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Core.Models;
using Infrastructure.Interfaces;
using WebApi.DTO;
using WebApi.Exceptions;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public CustomersService(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
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
    }
}
