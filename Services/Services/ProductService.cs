using Newtonsoft.Json;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Services.Services
{
    public class ProductService
    {
        private HttpClient _client;

        private readonly string _baseUrl = "https://dummyjson.com/products";

        public ProductService()
        {
            _client = new HttpClient();
        }

        public async Task<string?> GetAllAsync()
        {
            var response = await _client.GetAsync(this._baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                return str;
            };
            return null;
        }

        public async Task<string?> GetOneAsync(int id)
        {
            var response = await _client.GetAsync($"{this._baseUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                return str;
            }
            return null;
        }

        public async Task<string?> CreateAsync(Product product)
        {
            var str = JsonConvert.SerializeObject(product);
            var strContent = new StringContent(str,Encoding.UTF8,"application/json");
            var response = await _client.PostAsync(this._baseUrl+ "/add", strContent);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;
        }

        public async Task<string?> UpdateAsyn(Product product,int id)
        {
            var str = JsonConvert.SerializeObject(product);
            var strContent = new StringContent(str, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(this._baseUrl + $"/{id}", strContent);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;
        }

        public async Task<string?> DeleteAsync( int id)
        {
            var response = await _client.DeleteAsync(this._baseUrl + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;
        }

    }
}
