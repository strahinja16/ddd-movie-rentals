using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class PaymentFailedException : ApplicationException
    {
        public PaymentFailedException() { }

        protected PaymentFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PaymentFailedException(string message) : base(message) { }

        public PaymentFailedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
