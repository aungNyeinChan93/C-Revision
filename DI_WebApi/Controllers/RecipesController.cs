using Domain_02.Models;
using Domain_02.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DI_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var str = await _recipeService.GetAllAsync();
            var recipes = JsonConvert.DeserializeObject<RecipesModel>(str);
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync([FromRoute]int id)
        {
            var str = await _recipeService.GetOneAsync(id);
            var recipe= JsonConvert.DeserializeObject<Recipe>(str);
            return Ok(recipe);
        }
    }
}
