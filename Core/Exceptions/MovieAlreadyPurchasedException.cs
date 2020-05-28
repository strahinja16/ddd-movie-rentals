using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class MovieAlreadyPurchasedException : ApplicationException
    {
        public MovieAlreadyPurchasedException() {  }

        public MovieAlreadyPurchasedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MovieAlreadyPurchasedException(string message) : base(message) { }
       
        public MovieAlreadyPurchasedException(string message, Exception innerException) : base(message, innerException) { }
    }
}