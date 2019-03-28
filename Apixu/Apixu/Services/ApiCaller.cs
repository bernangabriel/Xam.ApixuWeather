using Apixu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Apixu.Services
{
    public class ApiCaller
    {
        const string API_KEY = "124417a6b92f41b5a3c01517192803";
        const string BASE_API = "https://api.apixu.com/v1/current.json";


        HttpClient _client = default;

        public ApiCaller()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(BASE_API)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        /// <summary>
        /// Fetch async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ApiResponse> FetchAsync(string name)
        {
            ApiResponse result = default;
            var response = await _client.GetAsync($"?key={API_KEY}&q={name}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    result = JsonConvert.DeserializeObject<ApiResponse>(content);
                }
            }

            return result;
        }
    }
}
