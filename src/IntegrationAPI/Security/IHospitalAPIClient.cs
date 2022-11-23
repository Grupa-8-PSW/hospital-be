namespace IntegrationAPI.Security
{
    public interface IHospitalAPIClient
    {
        public bool ValidateAuthorizationHeader(string authorizationHeader);
    }
}
