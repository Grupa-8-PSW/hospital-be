﻿using HospitalAPI.Connections;
using IntegrationAPI.ConnectionService.Interface;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Model.DTO;

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

        public void ChangeRequestStatus(BloodUnitRequestDTO bloodUnitRequestDto)
        {
            _connection.ChangeRequestStatus(bloodUnitRequestDto);
        }
    }
}
