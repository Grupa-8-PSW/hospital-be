using HospitalAPI.Connections;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Model;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;
using IntegrationLibraryAPI.Connections;
using Newtonsoft.Json;
using RestSharp;

namespace IntegrationAPI.ConnectionService
{

    public class HospitalHTTPConnectionService : IHospitalHTTPConnectionService
    {
        private readonly IHospitalHTTPConnection _connection;

        public HospitalHTTPConnectionService(IHospitalHTTPConnection connection)
        {
            _connection = connection;
        }

        public List<BloodUnitRequestDTO> GetAllBloodUnitRequests()
        {
            return _connection.GetAllBloodUnitRequests();
        }

        public List<BloodUnitDTO> GetAllBloodUnits()
        {
            return _connection.GetAllBloodUnits();
        }

        public List<BloodDTO> GetAllBlood()
        {
            return _connection.GetAllBlood();
        }

        public void ChangeRequestStatus(BloodUnitRequestDTO bloodUnitRequestDto)
        {
            _connection.ChangeRequestStatus(bloodUnitRequestDto);
        }

        public void RestockBlood(List<BloodDTO> bloods)
        {
            _connection.RestockBlood(bloods);
        }

        public void RestockBloodIfDelivered(BloodUnitRequestDeliveryDTO bloodUnitRequestDeliveryDTO)
        {
            BloodUnitRequestDTO bloodUnitRequestDTO = _connection.GetBloodRequestById(bloodUnitRequestDeliveryDTO.hospitalRequestId);
            if(bloodUnitRequestDTO != null)
            {
                BloodDTO bloodDTO = new ();
                bloodDTO.Quantity = bloodUnitRequestDTO.AmountL;
                bloodDTO.Type = bloodUnitRequestDTO.Type;
                BloodType bloodType;
                if (!Enum.TryParse<BloodType>(bloodDTO.Type, out bloodType))
                {
                    return;
                }
                bloodDTO.Id = (int)bloodType + 1;
                List<BloodDTO> bloodDTOs = new ();
                bloodDTOs.Add(bloodDTO);
                RestockBlood(bloodDTOs);
            }
        }

        public Doctor GetDoctorById(int id)
        {
            var client = new RestClient("http://localhost:5174");
            var request = new RestRequest("/api/Doctor/" + id, Method.Get);
            RestResponse response = client.Get(request);
            Doctor doctor = JsonConvert.DeserializeObject<Doctor>(response.Content);
            return doctor;
        }

        public List<Doctor> GetAllDoctors()
        {
            var client = new RestClient("http://localhost:5174");
            var request = new RestRequest("/api/Doctor/", Method.Get);
            RestResponse response = client.Get(request);
            List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(response.Content);
            return doctors;
        }

       
    }
}
