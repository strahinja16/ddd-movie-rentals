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

        public DomainCustomersService(ICustomersRepository customersRepository, IPaymentService paymentService)
        {
            this.customersRepository = customersRepository;
            this.paymentService = paymentService;
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
    }
}
