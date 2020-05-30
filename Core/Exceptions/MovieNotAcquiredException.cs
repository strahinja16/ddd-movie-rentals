using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class MovieNotAcquiredException : ApplicationException
    {
        public MovieNotAcquiredException() { }

        protected MovieNotAcquiredException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MovieNotAcquiredException(string message) : base(message) { }

        public MovieNotAcquiredException(string message, Exception innerException) : base(message, innerException) { }
    }
}
