using System;
using System.Runtime.Serialization;

namespace WebApi.Exceptions
{
    public enum HttpStatus
    {
        NotFound = 404,
        BadRequest = 400,
        Success = 200,
        InternalServerError = 500
    }

    public class HttpException: Exception
    {
        public HttpException(string message, HttpStatus status) : base($"Status: {status}. Message: {message}") { }
         
        public HttpException(string message, Exception innerException) : base(message, innerException) { }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
