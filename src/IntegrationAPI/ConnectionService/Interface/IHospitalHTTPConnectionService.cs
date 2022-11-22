﻿
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;

namespace IntegrationAPI.ConnectionService.Interface
{
    public interface IHospitalHTTPConnectionService
    {
        public List<BloodUnitRequestDTO> GetAllBloodUnitRequests();
        public List<BloodUnitDTO> GetAllBloodUnits();

        public void ChangeRequestStatus(BloodUnitRequestDTO bloodUnitRequestDto);
    }
}
