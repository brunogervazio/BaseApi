using System.Net;

namespace BaseApi.Domain.Exceptions
{
    public class UnauthorizedException(string message) : ApiException(message, HttpStatusCode.Unauthorized) { }
}
