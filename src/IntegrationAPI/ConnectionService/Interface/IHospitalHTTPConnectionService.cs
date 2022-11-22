using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationAPI.ConnectionService.Interface
{
    public interface IHospitalHTTPConnectionService
    {
        public List<BloodUnitRequestDTO> GetAllBloodUnitRequests();
    }
}
