using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookAndMore.Commons.Application.Exceptions;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        
        if (exception.GetType() == typeof(EntityNotFoundException))
        {
            var validation = new
            {
                Status = 404,
                Title = "Not Found",
                Detail = exception.Message
            };

            var json = new
            {
                errors = new[] { validation }
            };

            context.Result = new NotFoundObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.ExceptionHandled = true;
        }
        else if (exception.GetType() == typeof(EntityAlreadyExistException))
        {
            var validation = new
            {
                Status = 409,
                Title = "Conflict",
                Detail = exception.Message
            };

            var json = new
            {
                errors = new[] { validation }
            };

            context.Result = new ConflictObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.ExceptionHandled = true;
        }
        else if (exception.GetType() == typeof(BadRequestException))
        {
            var validation = new
            {
                Status = 400,
                Title = "Bad Request",
                Detail = exception.Message
            };

            var json = new
            {
                errors = new[] { validation }
            };

            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
        }
    }
}