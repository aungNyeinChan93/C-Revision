using Refit;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface CartApi
    {
        [Get("/carts")]
        Task<CartsModel?> GetAllAsync();

        [Get("/carts/{id}")]
        Task<Cart?> GetOneAsync(int id);

        [Post("/carts")]
        Task<Cart?> CreateAsync(Cart cart);

        [Put("/carts/{id}")]
        Task<Cart?> UpdateAsync(int id, Cart cart);

        [Delete("/carts/{id}")]
        Task<Cart?> DeleteAsync(int id);
    }
}
