namespace IntegrationAPI.GrpcServices
{
    public interface IClientScheduledService
    {
        public Task communicate(string apiKey);
    }
}
