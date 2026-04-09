using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Models;
using Services.Services;

namespace DI_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var str = await _productService.GetAllAsync();
            if (str is null)
            {
                return NotFound();
            }
            var productsModel = JsonConvert.DeserializeObject<ProductsModel>(str);
            return Ok(productsModel);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute]int id)
        {
            var str = await _productService.GetOneAsync(id);
            if (str is null)
            {
                return NotFound();
            }
            var product = JsonConvert.DeserializeObject<Product>(str);
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var str = await _productService.CreateAsync(product);
            if (str is null) return NotFound(); 
            var p = JsonConvert.DeserializeObject<Product>(str);
            if(p is null) return BadRequest();
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Product product, [FromRoute]int id)
        {
            var str = await _productService.UpdateAsyn(product,id);
            if (str is null) return NotFound();
            var p = JsonConvert.DeserializeObject<Product>(str);
            if (p is null) return BadRequest();
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var str = await _productService.DeleteAsync(id);
            if (str is null) return NotFound();
            var p = JsonConvert.DeserializeObject<Product>(str);
            if (p is null) return BadRequest();
            return Ok(p);
        }
    }
}
