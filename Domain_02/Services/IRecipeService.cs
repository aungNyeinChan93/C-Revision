using Domain_02.Models;

namespace Domain_02.Services
{
    public interface IRecipeService
    {
        Task<string?> CreateAsync(Recipe recipe);
        Task<string?> Delete(int id);
        Task<string?> GetAllAsync();
        Task<string?> GetOneAsync(int id);
        Task<string?> UpdateAsync(Recipe recipe, int id);
    }
}