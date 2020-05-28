using System;
namespace Core.Models
{
    public class CreditCard : ValueObject<CreditCard>
    {
        public string Value { get; private set; }

        public bool IsValid { get; private set; }

        private CreditCard() { }

        public static CreditCard Create(string value, bool isValid = false)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            return new CreditCard() { Value = value, IsValid = isValid };
        }
    }
}
