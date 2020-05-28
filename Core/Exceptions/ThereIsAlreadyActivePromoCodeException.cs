using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class ThereIsAlreadyActivePromoCodeException : ApplicationException
    {
        public ThereIsAlreadyActivePromoCodeException() {  }

        public ThereIsAlreadyActivePromoCodeException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ThereIsAlreadyActivePromoCodeException(string message) : base(message) { }
       
        public ThereIsAlreadyActivePromoCodeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
