using Core.APIConfig;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FakeJSON
{
    public class FakeJSONService : IFakeJSONService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public FakeJSONService(IHttpClientFactory httpClientFactory,IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClientFactory.CreateClient("FakeJSONClient");
            _apiKey = apiSettings.Value.ApiKey;  

        }

        public async Task<string> GetAlbums()
        {
            var url = "albums";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> GetComments()
        {
            var url = "comments";
            var response = await _httpClient.GetAsync(url); 
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> GetPhotos()
        {
            var url = "photos";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> GetPosts()
        {
            var url = "posts";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> GetPostsById(int id)
        {
            var url = $"posts/{id}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        public async Task<string> GetCommentsOfPost(int postId)
        {
            var url = $"posts/{postId}/comments";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> GetTodos()
        {
            var url = "todos";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
        public async Task<string> GetUsers()
        {
            var url = "users";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }
    }
}
