using Domain_02.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_02.Services
{
    public class TodoService
    {
        private readonly string _url = "https://dummyjson.com/todos";

        private readonly HttpClient _client;

        public TodoService()
        {
            _client = new HttpClient();
        }

        public async Task<string?> GetAllAsync()
        {
            var response = await _client.GetAsync(this._url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            return result;


        }

        public async Task<string?> GetOneAsync(int id)
        {
            var result = string.Empty;
            var response = await _client.GetAsync($"{this._url}/{id}");
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();                
            }
            return result;
        }

        public async Task<string?> CreateAsync(TodoDto todoDto)
        {
            var todoSt = JsonConvert.SerializeObject(todoDto);
            var strContent = new StringContent(todoSt,Encoding.UTF8,"application/json");
            var response = await _client.PostAsync(this._url+ "/add",strContent);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;
        }

        public async Task<string?> UpdateAsync(TodoDto todoDto,int id)
        {
            var str = JsonConvert.SerializeObject(todoDto);
            var strContent =new StringContent(str,Encoding.UTF8,"application/json");
            var response = await _client.PutAsync($"{this._url}/{id}", strContent);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;

        }

        public async Task<string?> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{this._url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return null;
        }
    }
}
