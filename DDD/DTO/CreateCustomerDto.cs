using System;
namespace WebApi.DTO
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string CreditCardValue { get; set; }
    }
}
