using HospitalAPI.DTO;
using HospitalLibrary.Core.Enums;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using IntegrationLibrary.Core.Model;

namespace HospitalAPI.Connections
{
    public interface IBloodOrderHTTPConnection
    {
        public IEnumerable<MonthlySubscription> GetBloodOrderByBloodType(BloodType bloodType);
    }
}
