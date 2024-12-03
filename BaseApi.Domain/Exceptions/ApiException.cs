using System.Net;

namespace BaseApi.Domain.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ApiException(HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base("An error occurred") { StatusCode = statusCode; }

        public ApiException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message) { StatusCode = statusCode; }
    }
}
