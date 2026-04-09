using RestSharp;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class CommentService
    {
        private readonly string _baseUrl = "https://dummyjson.com";

        private RestClient _restClient;

        public CommentService()
        {
            _restClient = new RestClient(this._baseUrl);
        }

        public async Task<string?> GetAllAsync()
        {
            var request = new RestRequest("/comments", Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content!;
                return result;
            }
            return null;
        }

        public async Task<string?> GetOneAsync(int id)
        {
            var request = new RestRequest($"/comments/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content!;
                return result;
            }
            return null;
        }

        public async Task<string?> CreateAsync(Comment comment)
        {
            var request = new RestRequest($"/comments/add", Method.Post);
            request.AddJsonBody(comment);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content!;
                return result;
            }
            return null;
        }

        public async Task<string?> DeleteAsync(int id)
        {
            var request = new RestRequest($"/comments/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content!;
                return result;
            }
            return null;
        }
    }
}
