using DatabaseTwo.Models;
using Domain_01.Models;

namespace Domain_01.Features
{
    public interface IPostService
    {
        Task<ResponseModel<List<Post>>> GetAllAsync();
    }
}