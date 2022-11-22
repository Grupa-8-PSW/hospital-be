using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using IntegrationLibrary.Core.Model.DTO;

namespace HospitalAPI.Connections
{
    public interface IHospitalHTTPConnection
    {
        public List<BloodUnitRequestDTO> GetAllBloodUnitRequests();
    }
}
