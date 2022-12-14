using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.ExceptionHandler.Exceptions
{
    public static class ExceptionStatusCode
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCodes = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(BloodBankArgumentException), HttpStatusCode.BadRequest},
            {typeof(BloodBankApiKeyAuthException), HttpStatusCode.Unauthorized},
            {typeof(BloodBankURIException), HttpStatusCode.InternalServerError},
            {typeof(BloodBankConnectionException), HttpStatusCode.BadGateway},
            {typeof(BloodConsumptionConfigurationArgumentException), HttpStatusCode.InternalServerError}

        };
        
        public static HttpStatusCode GetExceptionStatusCode(Exception ex)
        {
            bool excFound = exceptionStatusCodes.TryGetValue(ex.GetType(), out var statusCode);
            return excFound ? statusCode :HttpStatusCode.InternalServerError;
        }
    }
}
