using Domain_02.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_02.Services
{
    public class RecipeService : IRecipeService
    {
        private RestClient _restClient;

        private readonly string _url = "https://dummyjson.com";

        public RecipeService()
        {
            _restClient = new RestClient(this._url);
        }

        public async Task<string?> GetAllAsync()
        {
            //RestRequest request = new RestRequest("recipes", Method.Get);
            var response = await _restClient.GetAsync(new RestRequest("recipes", Method.Get));
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content;
                return result;
            }
            return null;
        }

        public async Task<string?> GetOneAsync(int id)
        {
            RestRequest request = new RestRequest($"recipes/{id}", Method.Get);
            var response = await _restClient.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content;
                return result;
            }
            return null;
        }

        public async Task<string?> CreateAsync(Recipe recipe)
        {
            RestRequest request = new RestRequest("recipes/add", Method.Post);
            request.AddJsonBody<Recipe>(recipe);

            var response = await _restClient.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resultStr = response.Content;
                return resultStr;
            }
            return null;
        }

        public async Task<string?> UpdateAsync(Recipe recipe, int id)
        {
            RestRequest request = new RestRequest($"recipes/{id}", Method.Put);
            request.AddJsonBody<Recipe>(recipe);

            var response = await _restClient.PutAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resultStr = response.Content;
                return resultStr;
            }
            return null;
        }

        public async Task<string?> Delete(int id)
        {
            RestRequest request = new RestRequest($"recipes/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resultStr = response.Content;
                return resultStr;
            }
            ;
            return null;
        }
    }
}
