using CarPartsStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] User user)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] User user)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromBody] User user)
        {
            try { return Ok(); }
            catch { return BadRequest(); }
        }
    }
}
