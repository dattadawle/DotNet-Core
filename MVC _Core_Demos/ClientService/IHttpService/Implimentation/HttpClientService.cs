using ClientService.IHttpService.Contract;
using System.Net.Http.Json;

public class HttpClientService : IHttpClientService
    {
      private readonly HttpClient _client;

        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("HttpClientService");
        }

        public async Task<T> DeleteAsync<T>(string requestUri)
        {
            var response = await _client.DeleteAsync(requestUri);

            response.EnsureSuccessStatusCode();

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

