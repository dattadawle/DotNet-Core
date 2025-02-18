using ClientService.IHttpService.Contract;
using System.Net.Http.Json;
using System.Text.RegularExpressions;

    public class HttpClientService : IHttpClientService
    {
      private readonly HttpClient _client;

        public HttpClientService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> DeleteAsync<T>(string requestUri)
        {
            var response = await _client.DeleteAsync(requestUri);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> GetTAsync<T>(string requestUri)
        {
            var response = await _client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostAsync<T>(string requestUri, object content)
        {
            var response =await _client.PostAsJsonAsync(requestUri, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PutAsync<T>(string requestUri, object content)
        {
           var response = await _client.PutAsJsonAsync(requestUri, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }

