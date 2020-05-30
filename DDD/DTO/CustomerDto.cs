using System;
namespace WebApi.DTO
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public bool CreditCardValidity { get; set; }

        public string CreditCardLastDigits { get; set; }
    }
}
