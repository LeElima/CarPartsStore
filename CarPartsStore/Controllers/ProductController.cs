using CarPartsStore.Application.DTOs;
using CarPartsStore.Application.Services.Interfaces;
using CarPartsStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try { return Ok( await _service.GetProductsAsync()); }
            catch { return BadRequest(); }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try { return Ok(await _service.GetByIdAsync(id)); }
            catch { return BadRequest(); }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            try 
            {
                await _service.AddAsync(product);
                return Ok();
            }
            catch { return BadRequest(); }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO product)
        {
            try
            {
                await _service.UpdateAsync(product);
                return Ok();
            }
            catch { return BadRequest(); }
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return Ok();
            }
            catch { return BadRequest(); }
        }
    }
}
