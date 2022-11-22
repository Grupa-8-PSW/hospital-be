using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using HospitalAPI.DTO;

namespace HospitalAPI.Connections
{
    public interface IBloodUnitRequestHTTPConnection
    {
        public BloodUnitRequestDTO CreateBloodUnitRequestIntegration(BloodUnitRequestDTO dto);
    }
}
