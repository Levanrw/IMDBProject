using IMDB.Models.RequestModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Service.Interface
{
  public  interface IExternalServiceCaller
    {
        public Task<string> GetAsync(ApiRequestModel apiRequest);
    }
}
