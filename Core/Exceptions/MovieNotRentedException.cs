using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class MovieNotRentedException : ApplicationException
    {
        public MovieNotRentedException() { }

        protected MovieNotRentedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MovieNotRentedException(string message) : base(message) { }

        public MovieNotRentedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
