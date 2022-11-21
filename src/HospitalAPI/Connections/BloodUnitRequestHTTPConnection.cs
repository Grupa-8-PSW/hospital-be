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
            var request = new RestRequest("api/BloodUnitRequest");

            //string jsonString = JsonSerializer.Serialize(dto);

            request.AddJsonBody(dto);
            
        //    request.AddJsonBody(jsonString);

            //request.AddParameter("type", bloodType);
            RestResponse response = client.Post(request);
            //Console.WriteLine("Status: " + response.StatusCode.ToString());
            return JsonSerializer.Deserialize<BloodUnitRequestDTO>(response.Content);
        }


    }
}


/*      private static void SendPostRequestRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:51963");
            var request = new RestRequest("/api/product");

            var values = new Dictionary<string, object>
            {
                {"name", "jeans" }, {"color", "blue" }, {"price", 55.4}
            };
            request.AddJsonBody(values);
            IRestResponse response = client.Post(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
        }
 * 
 * 
 


        private static async Task SendGetRequest()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:51963/api/product");
            Console.WriteLine("Status: " + response.StatusCode.ToString());

            string jsonContent = response.Content.ReadAsStringAsync().Result;
            List<ProductDto> result = JsonConvert.DeserializeObject<List<ProductDto>>(jsonContent);
            result.ForEach(product => Console.WriteLine(product.ToString()));
        }

        private static async Task SendPostRequest()
        {
            var values = new Dictionary<string, object>
            {
                {"name", "jeans" }, {"color", "blue" }, {"price", 55.4}
            };
            var content = new StringContent(JsonConvert.SerializeObject(values, Formatting.Indented), Encoding.UTF8, "application/json");
            using HttpClient client = new HttpClient();
            var response = await client.PostAsync("http://localhost:51963/api/product", content);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
        }

        private static void SendGetRequestWithRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:51963");
            var request = new RestRequest("/api/product");
            var response = client.Get<List<ProductDto>>(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
            List<ProductDto> result = response.Data;
            result.ForEach(product => Console.WriteLine(product.ToString()));
        }

        private static void SendPostRequestRestSharp()
        {
            var client = new RestSharp.RestClient("http://localhost:51963");
            var request = new RestRequest("/api/product");

            var values = new Dictionary<string, object>
            {
                {"name", "jeans" }, {"color", "blue" }, {"price", 55.4}
            };
            request.AddJsonBody(values);
            IRestResponse response = client.Post(request);
            Console.WriteLine("Status: " + response.StatusCode.ToString());
        }
    

 */
