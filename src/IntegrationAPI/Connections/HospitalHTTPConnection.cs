using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using IntegrationLibrary.Core.Model.DTO;

namespace HospitalAPI.Connections
{
    public class HospitalHTTPConnection : IHospitalHTTPConnection
    {
        public HospitalHTTPConnection() { }

        public List<BloodUnitRequestDTO> GetAllBloodUnitRequests()
        {
            var client = new RestClient("http://localhost:5174/api/internal/BloodUnitRequest");
            var request = new RestRequest();


            RestResponse response = client.Get(request);
            return JsonSerializer.Deserialize<List<BloodUnitRequestDTO>>(response.Content);
        }
    }
}


