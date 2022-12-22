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
    public class BloodOrderHTTPConnection : IBloodOrderHTTPConnection
    {
        public BloodOrderHTTPConnection() { }

        public IEnumerable<MonthlySubscription> GetBloodOrderByBloodType(BloodType bloodType)
        {
            var client = new RestClient("https://localhost:7131/");
            var request = new RestRequest("api/MonthlySubscription/" + bloodType.ToString());


            RestResponse response = client.Get(request);
            IEnumerable<MonthlySubscription> monthlySubscriptions = JsonSerializer.Deserialize<IEnumerable<MonthlySubscription>>(response.Content);
            return monthlySubscriptions;
        }

    }
}
