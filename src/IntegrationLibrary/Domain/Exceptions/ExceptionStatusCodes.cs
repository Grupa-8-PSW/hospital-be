using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Domain.Exceptions
{
    public static class ExceptionStatusCodes
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCodes = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(BloodBankArgumentException), HttpStatusCode.BadRequest},
            {typeof(BloodBankNotFound), HttpStatusCode.NotFound}
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool exceptionFound = exceptionStatusCodes.TryGetValue(exception.GetType(), out var statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }
    }
}
