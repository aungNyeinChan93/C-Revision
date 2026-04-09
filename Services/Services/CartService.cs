using Refit;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class CartService
    {
        private readonly string _baseUrl = "https://dummyjson.com";

        private CartApi _api;

        public CartService()
        {
            _api = RestService.For<CartApi>(this._baseUrl); ;
        }


        public async Task<CartsModel?> GetAllAsync()
        {
            var cartModel = await _api.GetAllAsync();
            return cartModel;
        }

        public async Task<Cart?> GetOneAsync(int id)
        {
            var cartModel = await _api.GetOneAsync(id);
            return cartModel;
        }

        public async Task<Cart?> CreatAsync(Cart cart)
        {
            var cartModel = await _api.CreateAsync(cart);
            return cartModel;
        }

        public async Task<Cart?> UpdateAsync(Cart cart,int id)
        {
            var cartModel = await _api.UpdateAsync(id,cart);
            return cartModel;
        }

        public async Task<Cart?> DeleteAsync( int id)
        {
            var cartModel = await _api.DeleteAsync(id);
            return cartModel;
        }



    }
}
