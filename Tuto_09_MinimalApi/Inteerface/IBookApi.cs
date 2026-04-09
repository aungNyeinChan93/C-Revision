using Microsoft.AspNetCore.Mvc;
using Refit;
using Tuto_09_MinimalApi.Models;

namespace Tuto_09_MinimalApi.Inteerface
{
    public interface IBookApi
    {
        [Get("/api/books")]
        Task<List<Book>> GetAllAsync();

        [Get("/api/books/{id}")]
        Task<Book> GetOneAsync(int id);

        [Post("/api/books")]
        Task<string?> CreateAsync(Book book);

        [Put("/api/books/{id}")]
        Task<string?> UpdateAsync(Book book, int id);

        [Delete("/api/books/{id}")]
        Task<string?> DeleteAsync(int id);
    }
}
