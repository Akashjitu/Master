using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Employee.Service.ServiceConsumer
{
    public class ApiServiceConsumer : IApiServiceConsumer
    {
        public T GetApiData<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                return JsonConvert.DeserializeObject<T>(response);

       
            }
        }
    }
}