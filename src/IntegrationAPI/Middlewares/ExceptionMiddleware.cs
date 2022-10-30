using IntegrationLibrary.Core.Service.Exceptions;

namespace IntegrationAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            this._requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch(Exception ex)
            {
                httpContext.Response.StatusCode = (int) ExceptionStatusCode.GetExceptionStatusCode(ex);
                await httpContext.Response.WriteAsync(ex.Message);
            }
        }
    }
}
