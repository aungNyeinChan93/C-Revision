using Domain_02.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_02.Interfaces
{
    public interface UserApi
    {
        [Get("/users")]
        Task<UserList> GetAllAsync();

        [Get("/users/{id}")]
        Task<User?> GetOneAsync(int id);

        [Post("/users/add")]
        Task<User?> CreateAsync(User user);

        [Put("/users/{id}")]
        Task<User?> UpdateAsync(int id ,User user);

        [Delete("/users/{id}")]
        Task<User?> DeleteAsync(int id);

    }
}
