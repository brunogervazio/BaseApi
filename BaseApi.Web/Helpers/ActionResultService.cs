using BaseApi.Application.Services;
using BaseApi.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseApi.Web.Helpers
{
    public abstract class ActionResultService : ActionResult
    {
        private static readonly Dictionary<HttpStatusCode, Func<ResponseService, ActionResult>> StatusCodeActionMap = new()
        {
            { HttpStatusCode.OK, data => new OkObjectResult(data) },
            { HttpStatusCode.Created, data => new CreatedResult(string.Empty, data) },
            { HttpStatusCode.NoContent, _ => new NoContentResult() },
            { HttpStatusCode.BadRequest, message => new BadRequestObjectResult(message) },
            { HttpStatusCode.Unauthorized, _ => new UnauthorizedResult() },
            { HttpStatusCode.Forbidden, _ => new ForbidResult() },
            { HttpStatusCode.NotFound, message => new NotFoundObjectResult(message) },
            { HttpStatusCode.Conflict, message => new ConflictObjectResult(message) },
            { HttpStatusCode.UnsupportedMediaType, _ => new UnsupportedMediaTypeResult() },
            { HttpStatusCode.UnprocessableEntity, message => new UnprocessableEntityObjectResult(message) },
            { HttpStatusCode.InternalServerError, message => new ObjectResult(message) { StatusCode = StatusCodes.Status500InternalServerError } }
        };

        public static ActionResult SuccessResult(ResponseService response, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (StatusCodeActionMap.TryGetValue(statusCode, out var actionResultFunc))
                return actionResultFunc(response);

            return new ObjectResult(response.Message ?? "Unknown error") { StatusCode = StatusCodes.Status500InternalServerError };
        }

        public static ActionResult ErrorResult(ApiException ex)
        {
            if (StatusCodeActionMap.TryGetValue(ex.StatusCode, out var actionResultFunc))
                return actionResultFunc(ResponseService.ErrorResponse(ex.Message));

            return new ObjectResult(ex.Message ?? "Unknown error") { StatusCode = StatusCodes.Status500InternalServerError };
        }
    }
}
