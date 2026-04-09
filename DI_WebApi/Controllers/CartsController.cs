using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Services;

namespace DI_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private CartService _cartService;

        public CartsController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _cartService.GetAllAsync();
            if (carts is null)
            {
                return BadRequest();
            }
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute]int id)
        {
            var cart = await _cartService.GetOneAsync(id);
            if (cart is null)
            {
                return BadRequest();
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cart cart)
        {
            var c = await _cartService.CreatAsync(cart);
            if (c is null)
            {
                return BadRequest();
            }
            return Ok(c);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Cart cart, [FromRoute]int id)
        {
            var c = await _cartService.UpdateAsync(cart,id);
            if (c is null)
            {
                return BadRequest();
            }
            return Ok(c);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var c = await _cartService.DeleteAsync(id);
            if (c is null)
            {
                return BadRequest();
            }
            return Ok(c);
        }
    }
}
