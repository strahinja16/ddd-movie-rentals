using System;
using System.Net;
using System.Runtime.Serialization;

namespace WebApi.Exceptions
{ 
    public class HttpException: Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }

        public HttpException(string message, HttpStatusCode status) : base(message)
        {
            HttpStatusCode = status;
        }
         
        public HttpException(string message, Exception innerException) : base(message, innerException)
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
