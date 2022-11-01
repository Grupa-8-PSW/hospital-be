using System.Runtime.CompilerServices;

namespace IntegrationAPI.Middlewares
{
    public static class MiddlewareExtrensions
    {
        public static IApplicationBuilder UseExceptionMiddleware( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
