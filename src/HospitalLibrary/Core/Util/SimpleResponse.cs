using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Util
{
    public class SimpleResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object body { get; set; }

        public SimpleResponse(HttpStatusCode statusCode, object body)
        {
            StatusCode = statusCode;
            this.body = body;   
        }
    }
}
