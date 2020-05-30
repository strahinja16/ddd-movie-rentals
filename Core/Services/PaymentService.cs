using System;
using System.Text.RegularExpressions;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class PaymentService : IPaymentService
    {
        public int RentalFee { get; } = 5;

        public bool CreditCardIsValid(string creditCardValue)
        {
            return Regex.IsMatch(creditCardValue, @"^\d{4}-\d{4}");
        }

        public bool Rent(Customer customer)
        {
            // pay using rental fee

            return CreditCardIsValid(customer.CreditCard.Value);
        }

        public bool Pay(Customer customer, Movie movie)
        {
            // pay using movie price, discounted or regular

            _ = movie.GetPrice();

            return CreditCardIsValid(customer.CreditCard.Value);
        }
    }
}
