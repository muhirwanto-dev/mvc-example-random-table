using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SingleScope.Common.Extensions;

namespace TableGenerator.Web.Middlewares
{
    public class ApiExceptionHandleMiddleware(
         RequestDelegate _next,
         ILogger<ApiExceptionHandleMiddleware> _logger,
         ProblemDetailsFactory _problemDetailsFactory
         )
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var problem = CreateProblem(context, exception);

            context.Response.StatusCode = problem.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.ProblemJson;

            return context.Response.WriteAsJsonAsync(problem);
        }

        private ProblemDetails CreateProblem(HttpContext context, Exception exception)
        {
            int statusCode;
            var message = exception.GetDeepMessage();

            if (exception is HttpRequestException httpException &&
                httpException.StatusCode != null)
            {
                statusCode = ((int)httpException.StatusCode);
            }
            else
            {
                statusCode = StatusCodes.Status500InternalServerError;
            }

            _logger.LogError(exception.ToString());

            return _problemDetailsFactory.CreateProblemDetails(
                context,
                statusCode: statusCode,
                title: "An error occurred while processing your request.",
                detail: message
            );
        }
    }
}
