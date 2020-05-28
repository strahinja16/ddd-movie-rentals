using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class MovieAlreadyRentedException : ApplicationException
    {
        public MovieAlreadyRentedException() { }

        public MovieAlreadyRentedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MovieAlreadyRentedException(string message) : base(message) { }

        public MovieAlreadyRentedException(string message, Exception innerException) : base(message, innerException) { }
    }
}