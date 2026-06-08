namespace ApplicationAPI.Infrastructure.Middlewares
{
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(
            this WebApplication app)
        {
            return app.UseMiddleware<CustomExceptionHandler>();
        }
    }
}