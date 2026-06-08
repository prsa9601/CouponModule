using ApplicationAPI.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ApplicationAPI.Infrastructure.ExceptionHandler
{
    public sealed class CouponAPIExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CouponAPIExceptionHandler(
            ILogger<CustomExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            var statusCode = exception switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                ArgumentException => StatusCodes.Status400BadRequest,
                FormatException => StatusCodes.Status400BadRequest,

                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

                KeyNotFoundException => StatusCodes.Status404NotFound,
                FileNotFoundException => StatusCodes.Status404NotFound,
                DirectoryNotFoundException => StatusCodes.Status404NotFound,

                TimeoutException => StatusCodes.Status408RequestTimeout,

                InvalidOperationException => StatusCodes.Status409Conflict,

                NotImplementedException => StatusCodes.Status501NotImplemented,

                _ => StatusCodes.Status500InternalServerError
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            var response = new
            {
                StatusCode = statusCode,
                Exception = exception.GetType().Name,
                Message = exception.Message
            };

            await httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(response),
                cancellationToken);

            return true;
        }
    }
}