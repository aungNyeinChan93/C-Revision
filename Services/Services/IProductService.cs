using Services.Models;

namespace Services.Services
{
    public interface IProductService
    {
        Task<string?> CreateAsync(Product product);
        Task<string?> DeleteAsync(int id);
        Task<string?> GetAllAsync();
        Task<string?> GetOneAsync(int id);
        Task<string?> UpdateAsyn(Product product, int id);
    }
}