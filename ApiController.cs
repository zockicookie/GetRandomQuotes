using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace YourWpfAppNamespace
{
    public class ApiController
    {
        private readonly HttpClient _httpClient;

        public ApiController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetApiResponseAsync()
        {
            string apiUrl = "https://api.api-ninjas.com/v1/quotes"; // Replace this with your API endpoint
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", "Kz3tfo4pVb+FsSP8+Chiig==FgjpWGtsskWNG2vN");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"Error: {e.Message}");
            }
        }
    }
}
