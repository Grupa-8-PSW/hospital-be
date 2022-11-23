using RestSharp;

namespace IntegrationAPI.Security
{
    public class HospitalAPIClient : IHospitalAPIClient
    {
        private readonly RestClient _restClient;

        public HospitalAPIClient(IConfiguration configuration)
        {
            _restClient = new RestClient(configuration["HospitalAPI:BaseUrl"]);
        }

        public bool ValidateAuthorizationHeader(string authorizationHeader)
        {
            var request = new RestRequest("/auth/validate");
            request.AddHeader("Authorization", authorizationHeader);
            try
            {
                _restClient.Get(request);
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
