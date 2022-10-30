using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Exceptions
{
    public static class ExceptionStatusCode
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCodes = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(BloodBankArgumentException), HttpStatusCode.BadRequest},
        };
        
        public static HttpStatusCode GetExceptionStatusCode(Exception ex)
        {
            bool excFound = exceptionStatusCodes.TryGetValue(ex.GetType(), out var statusCode);
            return excFound ? statusCode :HttpStatusCode.InternalServerError;
        }
    }
}
