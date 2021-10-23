using IMDB.Models.RequestModels;
using IMDB.Service.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IMDB.Service
{
    public class ExternalServiceCaller: IExternalServiceCaller
    {
        private const string URL= "https://imdb-api.com";
        private const string ApiKey = "k_w4s25oaw";
        public async Task<string> GetAsync(ApiRequestModel apiRequest)
        {
            string apiEndPoint = $"{URL}/{apiRequest.Lang}/API/{apiRequest.KeyWord}/{ApiKey}/{apiRequest.Expression}";

            using (var httpClient = new HttpClient())
            {
                var Response = await httpClient.GetAsync(apiEndPoint);
                string Result=Response.Content.ReadAsStringAsync().Result;
                return Result;
            }
          
        }
    }
}
