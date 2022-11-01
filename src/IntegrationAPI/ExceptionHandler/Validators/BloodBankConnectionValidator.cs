using IntegrationAPI.ExceptionHandler.Exceptions;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.ExceptionHandler.Validators
{
    public static class BloodBankConnectionValidator
    {
        public static RestClient ValidateURL(string url) 
        {
            RestClient restClient = new RestClient();
            try
            {
                restClient = new RestClient(url);
            }
            catch(UriFormatException ex)
            {
                throw new BloodBankURIException("Invalid Blood Bank address!");
            }
            return restClient;
        }
        public static RestResponse Authenticate(RestClient restClient, RestRequest restRequest)
        {
            RestResponse restResponse = new RestResponse();
            try
            {
                restResponse = restClient.Get(restRequest);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new BloodBankApiKeyAuthException("Permission denied!");
                }
                else
                {
                    throw new BloodBankConnectionException("Blood bank server is not available at the moment");
                }  
            }
            return restResponse;
        }
    }

}
