using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HospitalLibrary.Core.Model;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;

namespace HospitalAPI.Connections
{
    public interface IHospitalHTTPConnection
    {
        public List<BloodUnitRequestDTO> GetAllBloodUnitRequests();
        public List<BloodUnitDTO> GetAllBloodUnits();

        public List<BloodDTO> GetAllBlood();

        public void ChangeRequestStatus(BloodUnitRequestDTO bloodUnitRequestDto);
    }
}
