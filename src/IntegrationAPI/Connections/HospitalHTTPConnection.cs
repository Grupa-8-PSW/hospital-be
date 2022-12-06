﻿using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Core.Model;
using RestSharp;
using IntegrationLibrary.Core.Model.DTO;
using Newtonsoft.Json;
using HospitalLibrary.Core.Model;
using MimeKit;
using NuGet.Protocol;
using System.Text.Json;
using HospitalAPI.Connections;
using JsonSerializer = System.Text.Json.JsonSerializer;
using HospitalAPI.DTO;
using IntegrationLibraryAPI.Connections;
using BloodDTO = IntegrationLibrary.Core.Model.DTO.BloodDTO;
using BloodUnitDTO = IntegrationLibrary.Core.Model.DTO.BloodUnitDTO;
using BloodUnitRequestDTO = IntegrationLibrary.Core.Model.DTO.BloodUnitRequestDTO;
using Parameter = RestSharp.Parameter;

namespace IntegrationAPI.Connections
{
    public class HospitalHTTPConnection : IHospitalHTTPConnection
    {
        public HospitalHTTPConnection() { }

        public List<BloodUnitRequestDTO> GetAllBloodUnitRequests()
        {
            var client = new RestClient("http://localhost:5174/api/internal/BloodUnitRequest");
            var request = new RestRequest();


            RestResponse response = client.Get(request);

            List<BloodUnitRequestDTO> result = JsonConvert.DeserializeObject<List<BloodUnitRequestDTO>>( response.Content);
            return result;
        }

        public List<BloodUnitDTO> GetAllBloodUnits()
        {
            var client = new RestClient("http://localhost:5174/api/internal/BloodUnit");
            var request = new RestRequest();


            RestResponse response = client.Get(request);

            List<BloodUnitDTO> result = JsonConvert.DeserializeObject<List<BloodUnitDTO>>(response.Content);
            return result;
        }

        public void ChangeRequestStatus(BloodUnitRequestDTO bloodUnitRequestDto)
        {
            var client = new RestClient("http://localhost:5174");
            var request = new RestRequest("/api/internal/BloodUnitRequest/" + bloodUnitRequestDto.Id, Method.Put);
            request.AddJsonBody(bloodUnitRequestDto);
            client.Execute(request);
        }

        public List<BloodDTO> GetAllBlood()
        {
            var client = new RestClient("http://localhost:5174/api/internal/Blood");
            var request = new RestRequest();


            RestResponse response = client.Get(request);

            List<BloodDTO> result = JsonConvert.DeserializeObject<List<BloodDTO>>(response.Content);
            return result;
        }

        public void RestockBlood(List<BloodDTO> bloodList){
            var client = new RestClient("http://localhost:5174");
            var request = new RestRequest("/api/internal/Blood/restockBlood", Method.Put);
            var json = JsonConvert.SerializeObject(bloodList);
            request.AddBody(bloodList);
            RestResponse response = client.Execute(request);
        }

    }
}

