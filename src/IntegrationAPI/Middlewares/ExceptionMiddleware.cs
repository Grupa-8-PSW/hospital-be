using IntegrationAPI.ExceptionHandler.Exceptions;

namespace IntegrationAPI.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch(Exception ex)
            {
                httpContext.Response.StatusCode = (int) ExceptionStatusCode.GetExceptionStatusCode(ex);
                await httpContext.Response.WriteAsync(ex.Message);
            }
        }
    }
}
