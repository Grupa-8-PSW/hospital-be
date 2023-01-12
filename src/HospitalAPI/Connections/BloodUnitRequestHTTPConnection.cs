using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;

namespace HospitalAPI.Connections
{
    public class BloodUnitRequestHTTPConnection : IBloodUnitRequestHTTPConnection
    {
        public BloodUnitRequestHTTPConnection() { }


        public BloodUnitRequestDTO CreateBloodUnitRequestIntegration(BloodUnitRequestDTO dto)
        {
            var client = new RestClient("https://localhost:7131/");
            var request = new RestRequest("api/TenderOffer");


            request.AddJsonBody(dto);
            
            RestResponse response = client.Post(request);
            return JsonSerializer.Deserialize<BloodUnitRequestDTO>(response.Content);
        }
    }
}


